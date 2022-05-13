using CsharpPr4.Service;
using PracticeDateHandling.Models;
using PracticeDateHandling.Tools.KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPr4.ViewModels
{
    class PersonListViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object> _gotoDatePickCommand;
        private RelayCommand<object> _gotoDeleteCommand;
        private RelayCommand<object> _gotoFilterCommand;
        private RelayCommand<object> _exitCommand;
        private ObservableCollection<Person> _persons;
        private PersonSaveService _personService;
        private Action _gotoDatePick;
        private Action _gotoDelete;
        private Action _gotoFilter;

        public RelayCommand<object> GotoDatepickCommand
        {
            get
            {
                return _gotoDatePickCommand ??= new RelayCommand<object>(_ => GotoDatePick(), canExecute);
            }
        }

        public RelayCommand<object> GotoDeleteCommand
        {
            get
            {
                return _gotoDeleteCommand ??= new RelayCommand<object>(_ => GotoDelete(), canExecute);
            }
        }

        public RelayCommand<object> GotoFilterCommand
        {
            get
            {
                return _gotoFilterCommand ??= new RelayCommand<object>(_ => GotoFilter(), canExecute);
            }
        }

        public RelayCommand<object> ExitCommand
        {
            get
            {
                return _exitCommand ??= new RelayCommand<object>(_ => Environment.Exit(0), canExecute);
            }
        }

        private bool canExecute(object obj)
        {
            return true;
        }

        public ObservableCollection<Person> Persons
        {
            get
            {
                return _persons;
            }
            private set
            {
                _persons = value;
                OnPropertyChanged("Persons");
            }
        }

        public PersonListViewModel(Action gotoDatePick, Action gotoDelete, Action gotoFilter)
        {
            _gotoDatePick = gotoDatePick;
            _gotoDelete = gotoDelete;
            _gotoFilter = gotoFilter;
            _personService = new PersonSaveService();
            _persons = new ObservableCollection<Person>(_personService.getAllPersons());
        }

        public void GotoDatePick()
        {
            _gotoDatePick.Invoke();
        }

        public void GotoDelete()
        {
            _gotoDelete.Invoke();
        }

        public void GotoFilter()
        {
            _gotoFilter.Invoke();
        }

        // onPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
