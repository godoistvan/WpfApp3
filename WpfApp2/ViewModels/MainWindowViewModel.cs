using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;
using WpfApp2.Logic;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        ITyukLogic logic;
        public ObservableCollection<Tyuk> tyuk { get; set; }
        public ICommand AddFoodCommand { get; set; }
        public ICommand RemoveEggCommand { get; set; }
        public int EggCount
        {
            get
            {
                return logic.TojasCount;
            }
        }
        public MainWindowViewModel(ITyukLogic logic)
        {
            this.logic = logic;
            tyuk = new ObservableCollection<Tyuk>();
            tyuk.Add(new Tyuk()
            {
                Name = "Aranka",
                Eggcount=0,
                Isfed=false
            });
            tyuk.Add(new Tyuk()
            {
                Name = "Kotkoda",
                Eggcount = 0,
                Isfed = false
            });

            tyuk.Add(new Tyuk()
            {
                Name = "Rozsdás",
                Eggcount = 0,
                Isfed = false
            });
            logic.SetupCollection(tyuk);
            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recipient, msg) =>
            {
                OnPropertyChanged("TojasCount");
            });
        }
    }
}
