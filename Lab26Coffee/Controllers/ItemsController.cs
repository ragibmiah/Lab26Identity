using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab26Coffee.Models;
using Microsoft.AspNet.Identity;

namespace Lab26Coffee.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
            private CoffeeDao dao = new CoffeeDao();

            // GET: Items
            public ActionResult Index()
            {
                return View(dao.GetItemList());
            }

            // GET: Items/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Items/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Name,Description,Quantity,Price,ID")] Item item)
            {
                if (ModelState.IsValid)
                {
                    dao.AddItem(item);
                    return RedirectToAction("Index");
                }

                return View(item);
            }

            // GET: Items/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Item item = dao.GetItem((int)id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);
            }

            // POST: Items/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Name,Description,Quantity,Price,ID")] Item item)
            {
                if (ModelState.IsValid)
                {
                    dao.EditItem(item);
                    return RedirectToAction("Index");
                }
                return View(item);
            }

            // GET: Items/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Item item = dao.GetItem((int)id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);
            }

            // POST: Items/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                dao.DeleteItem(id);
                return RedirectToAction("Index");
            }

            public ActionResult Add(int id)
            {
                CoffeeEntities db = new CoffeeEntities();

                if (Session["Cart"] == null)
                {
                    //if it doesnt,make a new list, add the book, then add list to the session
                    List<Item> cart = new List<Item>();
                    cart.Add((from i in db.Items
                              where i.ID == id
                              select i).Single());
                    Session.Add("Cart", cart);

                }
                else
                {
                    //if it does exist, get the list and add book to it, and may add back to session.
                    List<Item> cart = (List<Item>)(Session["Cart"]);
                    cart.Add((from i in db.Items
                              where i.ID == id
                              select i).Single());

                }
                return View();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    dao.Dispose();
                }
                base.Dispose(disposing);
            }
    }
}
