﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO_Dojo;
using TP_Dojo.Data;
using TP_Dojo.Models;

namespace TP_Dojo.Controllers
{
    public class SamouraisController : Controller
    {
        private TP_DojoContext db = new TP_DojoContext();

        // GET: Samourais
        public ActionResult Index()
        {

            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiVM sVM = new SamouraiVM();
            sVM.ListeArmes = db.Armes.ToList();
            return View(sVM);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM sVM)
        {
            if (ModelState.IsValid)
            {
                sVM.Samourai.Arme = db.Armes.Find(sVM.ArmeId);
                db.Samourais.Add(sVM.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sVM);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamouraiVM sVM = new SamouraiVM();
            Samourai samourai = db.Samourais.Find(id);
            
            if (samourai == null)
            {
                return HttpNotFound();
            } else
            {
                sVM.ListeArmes = db.Armes.ToList();
                sVM.Samourai = samourai;

                if (samourai.Arme != null)
                {
                    sVM.ArmeId = samourai.Arme.Id;
                }
                
                return View(sVM);
            }
           
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiVM sVM)
        {
            if (ModelState.IsValid)
            {
                sVM.Samourai.Arme = db.Armes.Find(sVM.ArmeId);
                Samourai samourai = sVM.Samourai;
                db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sVM);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}