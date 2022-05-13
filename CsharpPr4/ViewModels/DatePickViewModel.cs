using PracticeDateHandling.Models;
using PracticeDateHandling.Tools;
using PracticeDateHandling.Tools.KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using PracticeDateHandling.Exceptions;
using CsharpPr4.Service;

namespace PracticeDateHandling.ViewModels
{
    class DatePickViewModel : INotifyPropertyChanged
    {
        private Person _user;
        private PersonSaveService _personService;
        //attributes
        private RelayCommand<object> _submitDateCommand;
        private RelayCommand<object> _cancelCommand;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;
        private bool _isEnabled = true;
        Action _gotoPersonList;

        //constructor

        public DatePickViewModel(Action goToPersonList)
        {
            _gotoPersonList = goToPersonList;
            _personService = new PersonSaveService();
            MessageBox.Show("If you want to update a person, enter his/her email.\nIf you want to add a person, enter a new email.");
        }

        //modifiers for attributes
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }


        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value;
                OnPropertyChanged("Birthday");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
   
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set 
            { 
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public void GotoPersonList()
        {
            _gotoPersonList.Invoke();
        }

        //buttons
        public RelayCommand<object> SubmitDateCommand
        {
            get
            {
                return _submitDateCommand ??= new RelayCommand<object>(_ => SubmitDateAsync(), canExecute);
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand<object>(_ => GotoPersonList(), canExecuteCancel);
            }
        }
        
        private bool canExecute(object obj)
        {
            return Name != "" && Surname != "" && Email != "" && Birthday != default(DateTime) ;
        }
        private bool canExecuteCancel(object obj)
        {
            return true;
        }
        //submitDate
        private void SubmitDate()
        {
            try
            {
                IsEnabled = false;
                //Time Consumed by Operations simulation 
                Thread.Sleep(500);
                //End of simulation
                _user = new Person(Name, Surname, Email, Birthday);
                _personService.AddUpdatePerson(_user);
                MessageBox.Show("New Person added!");
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _gotoPersonList.Invoke();
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private async void SubmitDateAsync()
        {
            await Task.Run(() => SubmitDate());
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
