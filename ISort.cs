using ConsoleApp9.Models.Activity;
using System.Collections.Generic;

namespace ConsoleApp9.Models.Interfaces
{
    public interface ISort
    {
        List<TrainingUnit> Units { get; set; }
        void Sort();
    }
}
