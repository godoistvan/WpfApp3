using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Logic
{
    public class TyukLogic : ITyukLogic
    {
        IList<Tyuk> tyukok;
        IMessenger messenger;

        public TyukLogic(IMessenger messenger)
        {
            this.messenger = messenger;
        }
        public int TojasCount
        {
            get
            {
                return tyukok.Sum(t => t.Eggcount);
            }
        }
        public void AddFood(string name)
        {
            foreach (var item in tyukok)
            {
                if (item.Name == name)
                {
                    item.Isfed = true;
                }
            }
            messenger.Send("Food given", "Info");
        }
        public void RemoveEgg(string name)
        {
            int amount = 0;
            foreach (var item in tyukok)
            {
                if (item.Name == name)
                {
                    amount += item.Eggcount;
                    item.Eggcount = 0;
                }
            }
            messenger.Send("Eggs removed", "Info");
        }
        public void SetupCollection(IList<Tyuk> tyukok)
        {
            this.tyukok = tyukok;
        }
    }
}
