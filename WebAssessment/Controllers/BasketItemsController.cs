using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAssessment.Models;
using WebAssessment.Factory;

namespace WebAssessment.Controllers
{
    public class BasketItemsController : Controller
    {
        private WebAssessmentContext db = new WebAssessmentContext();

        // GET: BasketItems
        public async Task<ActionResult> Index()
        {
            return View(await db.BasketItems.ToListAsync());
        }

        // GET: BasketItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasketItem basketItem = await db.BasketItems.FindAsync(id);
            if (basketItem == null)
            {
                return HttpNotFound();
            }
            return View(basketItem);
        }

        // GET: BasketItems/Create
        public ActionResult Create(int id)
        {
            if (Session["OrderId"] == null)
            {
                Order newOrder = OrderFactory.CreateNewOrder(db);
                Session.Add("OrderId", newOrder.Id);
            }
            int thisOrderId = Int32.Parse(Session["OrderId"].ToString());

            Product chosenProduct = db.Products.Find(id);
            BasketFactory.addBasketItem(db, thisOrderId ,chosenProduct, 1);
            Order order = db.Orders.Find(thisOrderId);
            OrderFactory.UpdateOrder(db, order);

            return RedirectToRoute(new { controller = "Orders", action = "Details", id = thisOrderId });
        }

        // POST: BasketItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductId,OrderId,Quantity,Price,CreatedDate")] BasketItem basketItem)
        {
            if (ModelState.IsValid)
            {
                db.BasketItems.Add(basketItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(basketItem);
        }

        // GET: BasketItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasketItem basketItem = await db.BasketItems.FindAsync(id);
            if (basketItem == null)
            {
                return HttpNotFound();
            }
            return View(basketItem);
        }

        // POST: BasketItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductId,OrderId,Quantity,Price,CreatedDate")] BasketItem basketItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basketItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(basketItem);
        }

        // GET: BasketItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasketItem basketItem = await db.BasketItems.FindAsync(id);
            if (basketItem == null)
            {
                return HttpNotFound();
            }
            return View(basketItem);
        }

        // POST: BasketItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BasketItem basketItem = await db.BasketItems.FindAsync(id);
            db.BasketItems.Remove(basketItem);
            await db.SaveChangesAsync();
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
