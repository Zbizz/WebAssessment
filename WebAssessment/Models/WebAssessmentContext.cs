using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAssessment.Models
{
    public class WebAssessmentContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebAssessmentContext() : base("name=WebAssessmentContext")
        {
            Database.SetInitializer ( new DataInitialiser());
        }

        public System.Data.Entity.DbSet<WebAssessment.Models.Product> Products { get; set; }

        public class DataInitialiser : DropCreateDatabaseIfModelChanges<WebAssessmentContext>
        {
            protected override void Seed ( WebAssessmentContext context )
            {
                List<Product> theProducts = new List<Product> ();
                theProducts.Add ( new Product () { Id = 1, CreatedDate = DateTime.Now, Name = "Golden Delicious Apples, Organic (700g)", Description = "Golden Delicious: perhaps one of the most well known varieties of apple around.", Price = 3.50M } );
                theProducts.Add ( new Product () { Id = 2, CreatedDate = DateTime.Now, Name = "Yellow Plums, Organic (400g)", Description = "Organic yellow plums remain slightly firmer than their purple peers.", Price = 2.35M } );
                theProducts.Add ( new Product () { Id = 3, CreatedDate = DateTime.Now, Name = "Bananas, Fairtrade, Organic (8 pieces)", Description = "Banana trees are actually giant flowering herbs, and their fruit is now the world's most popular.", Price = 3.20M } );
                theProducts.Add ( new Product () { Id = 4, CreatedDate = DateTime.Now, Name = "Lemons, Organic (600g)", Description = "Perfect for squeezing into a variety of dishes or even added to a nice glass of G&T,", Price = 2.90M } );
                theProducts.Add ( new Product () { Id = 5, CreatedDate = DateTime.Now, Name = "Carrots, Organic (500g)", Description = "One of the UK's most popular vegetables, carrot can be cooked or eaten raw.", Price = 1.10M } );
                theProducts.Add ( new Product () { Id = 6, CreatedDate = DateTime.Now, Name = "Oranges, Organic (700g)", Description = "There are more ways to peel an orange than there are to eat a cream egg.", Price = 2.40M } );
                theProducts.Add ( new Product () { Id = 7, CreatedDate = DateTime.Now, Name = "Red Seedless Grapes, Organic (400g)", Description = "These red seedless grapes boast a crisp and juicy texture and taste deliciously sweet.", Price = 3.50M } );
                theProducts.Add ( new Product () { Id = 8, CreatedDate = DateTime.Now, Name = "Mango, Organic", Description = "Our mangos are extra large at the moment. A popular tropical fruit that can be eaten whole and remains green even when ripe.", Price = 2.95M } );
                theProducts.Add ( new Product () { Id = 9, CreatedDate = DateTime.Now, Name = "Cucumber, Organic", Description = "Our cucumbers are full of flavour with thicker skins that will give your salad real substance.", Price = 2.00M } );
                theProducts.Add ( new Product () { Id = 10, CreatedDate = DateTime.Now, Name = "Red Peppers, Organic (2 pieces)", Description = "These new season peppers are so full of flavour you'll never buy your peppers anywhere else again. ", Price = 2.65M } );

                context.Products.AddRange ( theProducts );

                base.Seed ( context );
            }
            
        }

        public System.Data.Entity.DbSet<WebAssessment.Models.BasketItem> BasketItems { get; set; }

        public System.Data.Entity.DbSet<WebAssessment.Models.Order> Orders { get; set; }
    }
}
