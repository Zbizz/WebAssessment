using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAssessment.Models;

namespace WebAssessment.Factory
{
    public static class BasketFactory
    {
        public static BasketItem addBasketItem (WebAssessmentContext db, int OrderId, Product product, int quantity = 1)
        {
            BasketItem basketItem = new BasketItem{ OrderId=OrderId, CreatedDate=DateTime.Now, Price=product.Price, ProductId=product.Id, Quantity = quantity };
            db.BasketItems.Add(basketItem);
            db.SaveChanges();
            return basketItem;
        }
    }
}