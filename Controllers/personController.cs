using Crudopration.DB_connection;
using Crudopration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crudopration.Controllers
{
    public class personController : Controller
    {
        masterEntities db = new masterEntities();
        private object prod;
        private int productId;

        // GET: person
        public ActionResult Index()
        {
            return View();
        }

                public ActionResult savedata (demo _demo)
        {
            product_managment _Managment = new product_managment();
            _Managment.ProductId = _demo.ProductId;
            _Managment.ProductName = _demo.ProductName;
            _Managment.categoryId = _demo.categoryId;
            _Managment.categoryName = _demo.categoryName;
            db.product_managment.Add(_Managment);
            db.SaveChanges();
            return RedirectToAction("GetAllRecord");
        }
        public ActionResult getallrecord()
        {
            var data = db.product_managment.ToList();
            return View(data);

        }

     public ActionResult Getlist(string search,int pagenumber =1)

        {
            var data = db.product_managment.ToList();
            var product = from prod in db.product_managment select prod;
            product = product.OrderBy(prod => prod.ProductName);
            ViewBag.totalpage = Math.Ceiling(product.Count() / 9.0);
            ViewBag.pageno = pagenumber;
            data = product.Skip((pagenumber - 1) * 9).Take(9).ToList();
            if(search != null)
            {
                return View(db.product_managment.Where(m => m.ProductName.Equals(search) || search == null).ToList());

            }
            return View(data);


        }

 
        public ActionResult Edit(int id)
        {
            var data = db.product_managment.Where(m => m.ProductId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult editsave(demo dj)
        {
            var data = db.product_managment.Where(m => m.ProductId == dj.ProductId).FirstOrDefault();
            if (data != null)
            {
                data.ProductId = dj.ProductId;
                data.ProductName = dj.ProductName;
                data.categoryId = dj.categoryId;
                data.categoryName = dj.categoryName;
                db.SaveChanges();
                return RedirectToAction("getallrecord");

            }

            return RedirectToAction("getallrecord");

        }
        public ActionResult delete(int id)

        {
            var data = db.product_managment.Where(m => m.ProductId == id).FirstOrDefault();
            db.product_managment.Remove(data);
            db.SaveChanges();
            return RedirectToAction("getallrecord");
        }


    }
} 