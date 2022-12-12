using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Models.Activity
{
    public class PullUps : BaseActivity
    {
        public int Amount { get; set; }

        public double Height { get; set; }

        public PullUps(int duration, int amount, double height) : base("Підтягування", duration)
        {
            Amount = amount;
            Height = height;    
        }
    }
}
