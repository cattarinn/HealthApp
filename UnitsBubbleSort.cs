using ConsoleApp9.Models.Activity;
using ConsoleApp9.Models.Interfaces;
using System.Collections.Generic;

namespace ConsoleApp9.Models
{
    public class UnitsBubbleSort : ISort
    {
        public List<TrainingUnit> Units { get; set; }

        public UnitsBubbleSort(List<TrainingUnit> units)
        {
            Units = units;
        }

        public void Sort()
        {
            TrainingUnit unit;
            for (int i = 0; i < Units.Count; i++)
            {
                for (int j = 0; j < Units.Count - 1; j++)
                {
                    if (Units[j].CaloriesByDay > Units[j + 1].CaloriesByDay)
                    {
                        unit = Units[j];
                        Units[j] = Units[j + 1];
                        Units[j + 1] = unit;
                    }
                }
            }
        }
    }
}
