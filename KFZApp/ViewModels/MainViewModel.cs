using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //Brauchen wir für INotifyPropertyChanged
using System.Windows.Input;
using CommandHelper;
using CommonTypes;
using DataAccess;
using DataAccess.Events;


namespace KFZApp.ViewModels
{
    class MainViewModel : INotifyPropertyChanged //vgl. abstrakten Klasse
    {
        public List<KFZ> AlleKFZs 
        {
            get { return _alleKFZs; }
            set {
                _alleKFZs = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlleKFZs"));
            } 
        }
        private KFZ _selectedKFZ;
        private List<KFZ> _alleKFZs;

        private ICommand _saveAllKFZCommand;
        private ICommand _saveKFZDetailsCommand;
        private ICommand _getAllKFZCommand;
        private ICommand _deleteKFZCommand;
        private ICommand _newKFZCommand;


        public ICommand SaveAllKFZCommand
        {
            get 
            {
                if (_saveAllKFZCommand == null)
                {
                    _saveAllKFZCommand = new RelayCommand(c => SaveAllKFZ());
                }
                return _saveAllKFZCommand;
            }
        }
        public ICommand SaveKFZDetailsCommand
        {
            get
            {
                if (_saveKFZDetailsCommand == null)
                {
                    _saveKFZDetailsCommand = new RelayCommand(d => SaveKFZDetails());
                }
                return _saveKFZDetailsCommand;
            }
        }
        public ICommand GetAllKFZCommand
        {
            get
            {
                if (_getAllKFZCommand == null)
                {
                    _getAllKFZCommand = new RelayCommand(d => GetAllKFZ());
                }
                return _getAllKFZCommand;
            }
        }
        public ICommand DeleteKFZCommand
        {
            get
            {
                if (_deleteKFZCommand == null)
                {
                    _deleteKFZCommand = new RelayCommand(d => DeleteKFZ());
                }
                return _deleteKFZCommand;
            }
        }
        public ICommand NewKFZCommand
        {
            get
            {
                if (_newKFZCommand == null)
                {
                    _newKFZCommand = new RelayCommand(d => NewKFZ());
                }
                return _newKFZCommand;
            }
        }
    
        public KFZ SelectedKFZ 
        {
            get { return _selectedKFZ; }
            set {
                _selectedKFZ = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            this.GetAllKFZ();
            //DataAccess.Events.Events events = new Events();
            //events(del);
            
            //    AlleKFZs = new List<KFZ>();
            //    AlleKFZs.Add(new KFZ() { Kennzeichen = "S-RT 584", Typ="SUV" , FahrgestellNr="FG 4245", Leistung = 1});
            //    AlleKFZs.Add(new KFZ() { Kennzeichen = "RT-XD 5213", Typ="Cabrio", FahrgestellNr="FG 4333", Leistung= 2 });
            //    AlleKFZs.Add(new KFZ() { Kennzeichen = "B-BD 4302", Typ="Crossover", FahrgestellNr = "FG 4333",Leistung= 3 });
        }
          
        private void SaveKFZDetails()
        {
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            da.SaveCurrenKFZ(SelectedKFZ);
            this.GetAllKFZ();
        }
        private void SaveAllKFZ()
        {
            DataAccess.DataAccess da = new DataAccess.DataAccess();

            foreach (var kfz in AlleKFZs)
            {
                da.SaveKFZ(kfz);
            }
        }
        private void GetAllKFZ()
        {
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            AlleKFZs = da.GetALLKFZ();

        }
        private void DeleteKFZ()
        {
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            da.DeleteKFZ(SelectedKFZ.KFZid);
            this.GetAllKFZ();
        }
        private void NewKFZ()
        {
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            da.NewKFZ(SelectedKFZ);
        }
    }
}
