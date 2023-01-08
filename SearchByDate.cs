using ConsoleApp9.Models.Activity;
using ConsoleApp9.Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9.Search
{
    public class SearchByDate: ISearch
    {

        List<TrainingUnit> units;
        public SearchByDate(List<TrainingUnit> units)
        {
            this.units = units;
        }

        public IEnumerable<TrainingUnit> Search(int idUser, object value)
        {
            var date = Convert.ToDateTime(value);
            var newList = new List<TrainingUnit>();
            foreach (var unit in units)
            {
                if (unit.User.Id == idUser)
                {
                    if (unit.Date.Day == date.Date.Day && unit.Date.Month == date.Date.Month && unit.Date.Year == date.Date.Year)
                    {
                        newList.Add(unit);
                    }
                }
            }
            return newList;
        }
    }
}
