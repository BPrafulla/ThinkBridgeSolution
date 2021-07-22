using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ItemController : Controller
    {
         itemsDBEntities db = new itemsDBEntities();

        // GET: api/Item
        public async Task<ActionResult> GetItem()
        {
            return View(await db.Items.ToListAsync());
        }

        public ActionResult CreateItem()
        {
            return View(new Item());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateItem(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                await db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Saved Successfully";
                return RedirectToAction("GetItem", "Item");
            }
            else
            {
                return View(item);
            }
            }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = await db.Items.FindAsync(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Item item)
        {

            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["EditSuccessMessage"] = "Item Edited Successfully";
                return RedirectToAction("GetItem");
            }
            return View(item);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = await db.Items.FindAsync(id);
           
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            TempData["DeleteSuccessMessage"] = "Item Deleted Successfully";
            return RedirectToAction("GetItem");
           
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