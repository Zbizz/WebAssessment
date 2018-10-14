using System;
using System.Collections.Generic;
using System.Linq;
using WebAssessment.Models;

namespace WebAssessment.Factory
{
    public static class OrderFactory
    {
        public static Order CreateNewOrder (WebAssessmentContext db)
        {
            Order newOrder = new Order();
            newOrder.CreatedDate = DateTime.Now;
            newOrder.OrderDate = DateTime.Now;
            db.Orders.Add(newOrder);
            db.SaveChanges();
            return newOrder;
        }

        public static void UpdateOrder(WebAssessmentContext db, Order order)
        {
            decimal _fullPrice = order.FullPrice;
            foreach (BasketItem item in order.Basket)
            {
                _fullPrice = _fullPrice + item.Price;
            }

            Order orderToUpdate = db.Orders.Find(order.Id);
            orderToUpdate.FullPrice = _fullPrice;
            db.SaveChanges();

        }
    }
}