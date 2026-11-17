using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace MyApp.Namespace
{
    public class ShopController : Controller
    {
        public static List<Item> items  = new List<Item>()
            {
            new Item(){Code="XYZ123", Description="Cuddly Toy", Price=9.99},
            new Item(){Code="AAA123", Description="Television", Price=369.99},
            new Item(){Code="Z9903", Description="Microwave Oven", Price=75.50},
            new Item(){Code="YK88", Description="Coffee Pot", Price=24.75},
            new Item(){Code="HH546", Description="Mug", Price=3.75}
            };

        private static Cart cart = new Cart();

        // GET: ShopController
        public ActionResult Index()
        {
            ViewBag.CartTotal = cart.CalculateTotalPrice();
            return View(items);
        }

        // GET: ShopController/Details/5
        public ActionResult AddToCart(string _code)
        {
            foreach(Item itm in items)
            {
                if (itm.Code == _code)
                {
                    cart.AddItem(itm);
                    break;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
