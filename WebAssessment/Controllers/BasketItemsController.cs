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
