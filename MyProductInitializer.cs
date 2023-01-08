using ConsoleApp9.Models.Activity;
using ConsoleApp9.Models.EF;
using ConsoleApp9.Models.Product;
using System;

namespace ConsoleApp9.Initializer
{
    public static class MyProductInitializer
    {
        public static void Initialize(ActivityDatabase db)
        {
          if(db.Products.ToList().Count == 0)
          {
            db.Products.AddRange(
                new MyProduct("Апельсин", 38, 1, 0, 8),
                new MyProduct("Банан", 91, 1.5, 0, 22),
                new MyProduct("Яблуко", 47, 0.4, 0.4, 10),
                new MyProduct("Картопля", 83, 2, 0.1, 20),
                new MyProduct("Капуста", 28, 1.8, 0.5, 4),
                new MyProduct("Бiлi гриби", 25, 3.2, 0.7, 1.6),
                new MyProduct("Горох", 320, 23, 1.4, 55),
                new MyProduct("Квасоля ", 309, 22.3, 1.7, 55),
                new MyProduct("Камбала", 88, 16, 2.6, 0),
                new MyProduct("Карась", 75, 18, 0.3, 0),
                new MyProduct("Лосось", 142, 19, 6, 0),
                new MyProduct("Курка", 170, 25, 7, 0),
                new MyProduct("Свинина", 160, 19, 7, 0),
                new MyProduct("Яловичина", 187, 19, 12, 0),
                new MyProduct("Кефiр", 40, 3, 1.5, 4),
                new MyProduct("Молоко", 58, 3, 3, 5),
                new MyProduct("Сир", 370, 25, 30, 0)
                );
            db.SaveChanges();
          }
        }
    }
}
