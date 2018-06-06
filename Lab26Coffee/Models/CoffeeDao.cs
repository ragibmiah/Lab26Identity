using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab26Coffee.Models
{
    public class CoffeeDao
    {
        private CoffeeEntities db;

        public CoffeeDao()
        {
            db = new CoffeeEntities();
        }
        public Item GetItem(int id)
        {
            return db.Items.Find(id);
        }

        public List<Item> GetItemList()
        {
            return db.Items.ToList();
        }

        public void AddItem(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
        }

        public void EditItem(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        //public List<Item> ItemsSorted(string column)
        //{
        //    List<Item> sort = new List<Item>();
        //    //LINQ Query
        //    if (column == "Name")
        //    {
        //        sort = (from i in db.Items
        //                  orderby i.Name
        //                  select i).ToList();
        //    }
        //    else if (column == "Description")
        //    {
        //        sort = (from i in db.Items
        //                  orderby i.Description
        //                  select i).ToList();
        //    }
        //    else if (column == "Price")
        //    {
        //        sort = (from i in db.Items
        //                  orderby i.Price
        //                  select i).ToList();
        //    }

        //    return View();
        //}

        public void Dispose()
        {
            db.Dispose();
        }
    }
}