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

namespace WebAssessment.Controllers
{
    public class CustomersController : Controller
    {
        private WebAssessmentContext db = new WebAssessmentContext();


        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CreatedDate = DateTime.Now;
                db.Customers.Add(customer);
                await db.SaveChangesAsync();

                return RedirectToRoute(new { controller = "Orders", action = "Thanks" });
            }

            return View(customer);
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
