using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Models.Activity
{
    public class BaseActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public BaseActivity(string name,int duration)
        {
            Name = name;
            Duration = duration;
        }
    }
}
