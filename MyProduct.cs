using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Models.Product
{
    public class MyProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Calories { get; set; }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public double Carbohydrates { get; set; }

        public MyProduct(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }

        public override string ToString()
        {
            return "Id: " + Id + ". Name: " + Name + ". Calories: " + Calories + ". Proteins: " + Proteins + ". Fats: " + Fats + ". Carbohydrates: " + Carbohydrates;
        }
    }
}
