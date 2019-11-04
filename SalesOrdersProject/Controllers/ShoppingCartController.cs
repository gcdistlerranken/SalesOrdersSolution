using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesOrdersProject.Models;

namespace SalesOrdersProject.Controllers
{
    public class ShoppingCartController : Controller
    {
        private SalesOrdersDatabase2Entities db = new SalesOrdersDatabase2Entities();

        public ShoppingCartController()
        { }


        // GET: ShoppingCart
        public ViewResult Index(string returnUrl)
        {
            return View(new ShoppingCartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int productID, string returnUrl)
        {
            Product product = db.Products.SingleOrDefault(
                                        p => p.ProductID == productID);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productID, string returnUrl)
        {
            GetCart().RemoveItem(productID);
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult CartWidget(ShoppingCartModel cart)
        {
            return PartialView(cart);
        }

        private ShoppingCartModel GetCart()
        {
            ShoppingCartModel cart = (ShoppingCartModel)Session["Cart"];

            if (cart == null)
            {
                cart = new ShoppingCartModel();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public ViewResult ShippingInfo()
        {
            return View(new ShippingInfo());
        }

        [HttpPost]
        public ActionResult ShippingInfo(ShippingInfo shippingInfo)
        {
            if (ModelState.IsValid)
            {
                ShoppingCartModel cart = GetCart();
                cart.ShippingInfo = shippingInfo;

                return RedirectToAction("BillingInfo");
            }
            else
            {
                return View(shippingInfo);
            }
        }

        [HttpGet]
        public ViewResult BillingInfo()
        {
            return View(new BillingInfo());
        }

        [HttpPost]
        public ViewResult BillingInfo(BillingInfo billingInfo)
        {
            if (ModelState.IsValid)
            {
                ShoppingCartModel cart = GetCart();
                cart.BillingInfo = billingInfo;

                ProcessOrder(cart);
                cart.Clear();

                return View("OrderComplete");
            }
            else
            {
                return View(billingInfo);
            }
        }

        private void ProcessOrder(ShoppingCartModel cart)
        {
            Customer customer = new Customer
            {
                CustomerFirstName = cart.BillingInfo.FirstName,
                CustomerLastName = cart.BillingInfo.LastName,
                BillingAddress = cart.BillingInfo.Address,
                BillingCity = cart.BillingInfo.City,
                BillingState = cart.BillingInfo.State,
                BillingPostalCode = cart.BillingInfo.PostalCode,
                BillingCreditCardNumber = cart.BillingInfo.CreditCardNumber,
                BillingExpireMonth = cart.BillingInfo.ExpireMonth,
                BillingExpireYear = cart.BillingInfo.ExpireYear
            };

            db.Customers.Add(customer);
            db.SaveChanges();

            Order order = new Order
            {
                CustomerID = customer.CustomerID,
                OrderDate = DateTime.Now,
                ShippingAddress = cart.ShippingInfo.Address,
                ShippingCity = cart.ShippingInfo.City,
                ShippingState = cart.ShippingInfo.State,
                ShippingPostalCode = cart.ShippingInfo.PostalCode
            };

            db.Orders.Add(order);
            db.SaveChanges();

            foreach (ShoppingCartItemModel item in cart.Items)
            {
                OrderDetail orderItem = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ProductID = item.Product.ProductID,
                    OrderDetailQuantityOrdered = item.Quantity
                };

                db.OrderDetails.Add(orderItem);
            }
            db.SaveChanges();
        }
    }
}