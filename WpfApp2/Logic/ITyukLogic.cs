using System.Collections.Generic;
using WpfApp2.Models;

namespace WpfApp2.Logic
{
    public interface ITyukLogic
    {
        int TojasCount { get; }

        void AddFood(string name);
        void RemoveEgg(string name);
        void SetupCollection(IList<Tyuk> tyukok);
    }
}