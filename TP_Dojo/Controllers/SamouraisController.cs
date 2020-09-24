using System;
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
using TP_Dojo.Utils;

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
            this.getListeArmesDisposDb(sVM);

            sVM.ListeArtMartials = db.ArtMartials.ToList();
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
                Samourai samourai = sVM.Samourai;
                samourai.Arme = db.Armes.Find(sVM.ArmeId);
                samourai.ArtMartials = db.ArtMartials.Where(x => sVM.ListeArtMartialsId.Contains(x.Id)).ToList();
                db.Samourais.Add(samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            this.getListeArmesDisposDb(sVM);
            sVM.ListeArtMartials = db.ArtMartials.ToList();
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
            }
            else
            {
                this.getListeArmesDisposDb(sVM);
                sVM.ListeArtMartials = db.ArtMartials.ToList();
                sVM.Samourai = samourai;

                if (samourai.Arme != null)
                {
                    sVM.ArmeId = samourai.Arme.Id;
                    sVM.ListeArmes.Add(db.Armes.Where(x => x.Id == sVM.ArmeId).FirstOrDefault());
                }
                if (samourai.ArtMartials.Any())
                {
                    sVM.ListeArtMartialsId = samourai.ArtMartials.Select(x => x.Id).ToList();
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
                Samourai samourai = db.Samourais.Include(x => x.Arme).Include(x => x.ArtMartials).FirstOrDefault(x => x.Id == sVM.Samourai.Id);
                //samourai.Force = sVM.Samourai.Force;
                //samourai.Nom = sVM.Samourai.Nom;
                samourai.SetObjectProp(sVM.Samourai);
                Samourai SamouraiAvecArme = db.Samourais.Where(x => x.Arme.Id == sVM.ArmeId).FirstOrDefault();
                if (sVM.ArmeId != null)
                {
                    samourai.Arme = db.Armes.Find(sVM.ArmeId);
                }
                else
                {
                    samourai.Arme = null;
                }
                if (sVM.ListeArtMartialsId.Any())
                {
                    samourai.ArtMartials = db.ArtMartials.Where(x => sVM.ListeArtMartialsId.Contains(x.Id)).ToList();
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            this.getListeArmesDisposDb(sVM);
            sVM.ListeArtMartials = db.ArtMartials.ToList();
            return View(sVM);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
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
            }
            else
            {
                sVM.Samourai = samourai;

                if (samourai.Arme != null)
                {
                    sVM.ArmeId = samourai.Arme.Id;
                }
                 if (samourai.ArtMartials.Any())
                {
                    sVM.ListeArtMartials = samourai.ArtMartials.ToList();
                }
               
                return View(sVM);
            }
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            if (samourai.Arme != null)
            {
                samourai.Arme = null;
            }

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

        private List<Arme> getListeArmesDisposDb(SamouraiVM sVM)
        {
            sVM.ListeArmes = new List<Arme>();
            foreach (var arme in db.Armes.ToList())
            {
                if (db.Samourais.Where(x => x.Arme.Id == arme.Id).ToList().Count() == 0)
                {
                    sVM.ListeArmes.Add(arme);
                }
            }
            return sVM.ListeArmes;
        }

       
    }
}
