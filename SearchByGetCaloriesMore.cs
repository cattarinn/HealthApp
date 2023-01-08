using ConsoleApp9.Models.Activity;
using ConsoleApp9.Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Search
{
    public class SearchByGetCaloriesMore: ISearch
    {
        List<TrainingUnit> units;
        public SearchByGetCaloriesMore(List<TrainingUnit> units)
        {
            this.units = units;
        }

        public IEnumerable<TrainingUnit> Search(int idUser, object value)
        {
            double caloriesByDay = Convert.ToDouble(value);
            var newList = new List<TrainingUnit>();
            foreach (var unit in units)
            {
                if (unit.User.Id == idUser)
                {
                    if (unit.CaloriesByDay >= caloriesByDay)
                    {
                        newList.Add(unit);
                    }
                }
            }
            return newList;
        }
    }
}
