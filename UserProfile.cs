using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Models.User
{
    public class UserProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public double WishWeight { get; set; }

        public UserProfile(string name, string nickName, double height, double weight, double wishWeight)
        {
            Name = name;
            NickName = nickName;
            Height = height;
            Weight = weight;
            WishWeight = wishWeight;
        }

        public override string ToString()
        {
            return "Id: " + Id + ". Нiкнейм: " + NickName + ". iм'я: " + Name + ".\nЗрiст: " + Height + ". Вага: " + Weight + ". Бажана вага: " + WishWeight;
        }
    }
}
