using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace MyApp.Namespace
{
    public class ItemsController : Controller
    {
        // GET: ItemsController
        public ActionResult Index()
        {
            return View(ShopController.items);
        }

        // GET: ItemsController/Details/5
        public ActionResult Details(string _code)
        {
            Item found = ShopController.items.FirstOrDefault(i=>i.Code==_code);
            if (found!=null)
            {
                return View(found);    
            }
            return NotFound();
        }

        // GET: ItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item _item)
        {
            try
            {
                Item newItem = new Item(){Code=_item.Code, Description=_item.Description, Price=_item.Price};
                ShopController.items.Add(newItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemsController/Edit/5
        public ActionResult Edit(string _code)
        {
            Item found = ShopController.items.FirstOrDefault(i=>i.Code==_code);
            if (found!=null)
            {
                return View(found);    
            }
            return NotFound();
        }

        // POST: ItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item _item)
        {
            try
            {
                Item found = ShopController.items.FirstOrDefault(i=>i.Code==_item.Code);
                if (found!=null)
                {
                    found.Description=_item.Description;
                    found.Price = _item.Price;           
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemsController/Delete/5
        public ActionResult Delete(string _code)
        {
            Item found = ShopController.items.FirstOrDefault(i=>i.Code==_code);
            if (found!=null)
            {
                return View(found);    
            }
            return NotFound();
        }

        // POST: ItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Item _item)
        {
            try
            {
                Item found = ShopController.items.FirstOrDefault(i=>i.Code==_item.Code);
                if (found!=null)
                {   ShopController.items.Remove(found);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GoToShop()
        {
            return RedirectToAction("Index", "Shop");
        }
    }
}
