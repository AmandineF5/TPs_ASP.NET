using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using BO_Dojo;
using TP_Dojo.Data;

namespace TP_Dojo.Controllers
{
    /*
    La classe WebApiConfig peut exiger d'autres modifications pour ajouter un itinéraire à ce contrôleur. Fusionnez ces instructions dans la méthode Register de la classe WebApiConfig, le cas échéant. Les URL OData sont sensibles à la casse.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using BO_Dojo;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Samourai>("Samourais");
    builder.EntitySet<Arme>("Armes"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SamouraisController : ODataController
    {
        private TP_DojoContext db = new TP_DojoContext();

        // GET: odata/Samourais
        [EnableQuery]
        public IQueryable<Samourai> GetSamourais()
        {
            return db.Samourais;
        }

        // GET: odata/Samourais(5)
        [EnableQuery]
        public SingleResult<Samourai> GetSamourai([FromODataUri] int key)
        {
            return SingleResult.Create(db.Samourais.Where(samourai => samourai.Id == key));
        }

        // PUT: odata/Samourais(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Samourai> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Samourai samourai = db.Samourais.Find(key);
            if (samourai == null)
            {
                return NotFound();
            }

            patch.Put(samourai);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SamouraiExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(samourai);
        }

        // POST: odata/Samourais
        public IHttpActionResult Post(Samourai samourai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Samourais.Add(samourai);
            db.SaveChanges();

            return Created(samourai);
        }

        // PATCH: odata/Samourais(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Samourai> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Samourai samourai = db.Samourais.Find(key);
            if (samourai == null)
            {
                return NotFound();
            }

            patch.Patch(samourai);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SamouraiExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(samourai);
        }

        // DELETE: odata/Samourais(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Samourai samourai = db.Samourais.Find(key);
            if (samourai == null)
            {
                return NotFound();
            }

            db.Samourais.Remove(samourai);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Samourais(5)/Arme
        [EnableQuery]
        public SingleResult<Arme> GetArme([FromODataUri] int key)
        {
            return SingleResult.Create(db.Samourais.Where(m => m.Id == key).Select(m => m.Arme));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SamouraiExists(int key)
        {
            return db.Samourais.Count(e => e.Id == key) > 0;
        }
    }
}
