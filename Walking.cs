using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Models.Activity
{
    public class Walking:BaseActivity
    {
        public double Speed { get; set; }

        public int StepAmount { get; set; }
        public Walking(int duration, double speed, int stepAmount) : base("Біг", duration)
        {
            Speed = speed;
            StepAmount = stepAmount;
        }
    }
}
