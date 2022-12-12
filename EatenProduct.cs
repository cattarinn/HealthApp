using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Models.Product
{
    public class EatenProduct
    {
        public int ProductId { get; set; }

        public double Grams { get; set; }

        public EatenProduct(int productId, double grams)
        {
            ProductId = productId;
            Grams = grams;
        }
    }
}
