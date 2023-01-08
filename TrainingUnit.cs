using ConsoleApp9.Models.Product;
using ConsoleApp9.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Models.Activity
{
    public class TrainingUnit
    { 
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public UserProfile User { get; set; }

        public double CaloriesByDay { get; set; } = 0;

        public List<BaseActivity> Actives { get; set; }

        public TrainingUnit()
        {

        }

        public TrainingUnit(DateTime date, UserProfile user, List<BaseActivity> actives)
        {
            Date = date;
            User = user;
            Actives = actives;
        }

        public Dictionary<string, string> BurnedCalories
        {
            get
            {
                Dictionary<string, string> burnedCalories = new Dictionary<string, string>();
                foreach (var act in Actives)
                {
                    switch(act.Name)
                    {
                        case "Підтягування":
                            {
                                burnedCalories.Add( "Пiдтягування", Convert.ToString(User.Weight * 10 * Convert.ToDouble((act as PullUps).Height)));
                                break;
                            }
                        case "Підняття ваги":
                            {
                                burnedCalories.Add("Пiдняття ваги", Convert.ToString(User.Weight * 6 * Convert.ToDouble(act.Duration)/ 3600));
                                break;
                            }
                        case "Біг":
                            {
                                burnedCalories.Add("Бiг", Convert.ToString(1.3 * User.Weight * (act as Run).Speed * Convert.ToDouble(act.Duration) / 3600));
                                break;
                            }
                        case "Ходьба":
                            {
                                burnedCalories.Add("Ходьба", Convert.ToString(0.3 * User.Weight * (act as Walking).Speed * Convert.ToDouble(act.Duration) / 3600));
                                break;
                            }
                        case "Плавання":
                            {
                                burnedCalories.Add("Плавання", Convert.ToString(4.5 * User.Weight * Convert.ToDouble(act.Duration) / 3600));
                                break;
                            }
                        case "Гімнастика":
                            {
                                burnedCalories.Add("Гiмнастика", Convert.ToString(2 * User.Weight * Convert.ToDouble(act.Duration) / 3600));
                                break;
                            }
                        case "Йога":
                            {
                                burnedCalories.Add("Йога", Convert.ToString(3.2 * User.Weight * Convert.ToDouble(act.Duration) / 3600));
                                break;
                            }
                    }
                }
                return burnedCalories;
            }
        }
        public Dictionary<string, string> ActivityQty
        {
            get
            {
                Dictionary<string, string> activityQty = new Dictionary<string, string>();
                int walks = 0;
                double way = 0;
                foreach (var activity in Actives)
                {
                    if(activity.Name == "Ходьба")
                    {
                        walks += Convert.ToInt32((activity as Walking).StepAmount);
                    }
                    else if (activity.Name == "Біг")
                    {
                        walks += Convert.ToInt32((activity as Run).StepAmount);
                    }
                    if (activity.Name == "Ходьба")
                    {
                        way += ((activity as Walking).Speed * Convert.ToDouble((activity as Walking).Speed));
                    }
                    if (activity.Name == "Біг")
                    {
                        way += ((activity as Run).Speed * Convert.ToDouble((activity as Run).Speed));
                    }
                }

                activityQty.Add("Кiлькiсть крокiв",Convert.ToString(walks));
                activityQty.Add("Пройдений шлях", Convert.ToString(way));
                return activityQty;
            }
        }

        public int TrainingDuration
        {
            get
            {
                int result = 0;
                foreach (var activity in Actives)
                {
                    result += activity.Duration;
                }
                return result;
            }
        }


        public void CalculateCaloriesByDay(List<EatenProduct> eatenProducts, List<MyProduct> products)
        {
            foreach (var eatenProduct in eatenProducts)
            {
                foreach (var product in products)
                {
                    if(eatenProduct.ProductId == product.Id)
                    {
                        CaloriesByDay += ((product.Fats + product.Calories + product.Proteins + product.Carbohydrates)/100) * eatenProduct.Grams;
                    }
                }
            }
        }
        public override string ToString()
        {
            string res = "Id: " + Id + ". Дата: " + Date + "\n";
            foreach (var item in ActivityQty)
            {
                res += item.Key + ": " + item.Value + "\n";
            }
            res += "Калорiї отриманi за день: " + CaloriesByDay + "\nСпаленi калорiї:\n";
            foreach (var item in BurnedCalories)
            {
                res += item.Key + ": " + item.Value + "\n";
            }
            return res;
        }
    }
}
