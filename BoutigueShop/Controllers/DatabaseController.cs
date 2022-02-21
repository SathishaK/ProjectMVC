using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoutigueShop.Models;

namespace BoutigueShop.Controllers
{
    public class DatabaseController : Controller
    {

        Boutique Dress = new Boutique();
            // GET: User
            public ActionResult Index()
            {
                var data = Dress.Details();
                return View(data);
            }
            public ActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Create(Shop sp)
            {

                if (Dress.Insertdress(sp))
                {
                    TempData["Inserting"] = "user saved successful..";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error to Insert"] = "dress not saved..";
                }
                return View();
            }
            public ActionResult Details(int Did)
            {

                var data = Dress.Details().Find(s => s.Did == Did);
                return View(data);
            }
            public ActionResult Edit(int Did)
            {

                var data = Dress.Details().Find(s => s.Did == Did);
                return View(data);
            }
            [HttpPost]
            public ActionResult Edit(Shop sp)
            {

                if (Dress.Updatedress(sp))
                {
                    TempData["Updating"] = "Dress updated";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error updating"] = "Dress not updated..";
                }
                return View();
            }
            [HttpDelete]
            public ActionResult Delete(int Did)
            {
                int res = Dress.Deletedress(Did);
                if (res > 0)
                {
                    TempData["Deleted"] = "dress Deleted successful..";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Dress not Deleted..";
                }
                return View();


            }

        }
    }


