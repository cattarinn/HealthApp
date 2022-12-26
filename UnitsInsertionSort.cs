using ConsoleApp9.Models.Activity;
using ConsoleApp9.Models.Interfaces;
using System.Collections.Generic;

namespace ConsoleApp9.Sort
{
    public class UnitsInsertionSort : ISort
    {
        public List<TrainingUnit> Units { get; set; }

        public UnitsInsertionSort(List<TrainingUnit> units)
        {
            Units = units;
        }
        public void Sort()
        {
            int j;
            TrainingUnit unit;
            for (int i = 1; i < Units.Count; i++)
            {
                unit = Units[i];
                for (j = i - 1; j >= 0 && Units[j].CaloriesByDay > unit.CaloriesByDay; j--)
                {
                    Units[j + 1] = Units[j];
                }
                Units[j + 1] = unit;
            }
        }
    }
}
