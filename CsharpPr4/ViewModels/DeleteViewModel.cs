using CsharpPr4.Service;
using PracticeDateHandling.Tools;
using PracticeDateHandling.Tools.KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CsharpPr4.ViewModels
{
    class DeleteViewModel : INotifyPropertyChanged
    {
        private Action _gotoPersonList;
        PersonSaveService _personService;
        private string _email;
        private RelayCommand<object> _deleteCommand;
        private RelayCommand<object> _cancelCommand;
        public DeleteViewModel()
        {

        }

        public DeleteViewModel(Action goToPersonList)
        {
            _gotoPersonList = goToPersonList;
        }

        public void GotoPersonList()
        {
            _gotoPersonList.Invoke();
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }

        }

        public RelayCommand<object> DeleteCommand
        {
            get
            {
                return _deleteCommand ??= new RelayCommand<object>(_ => deletePerson(), canExecute);
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
            try
            {
                Utilities.IsValidEmail(Email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool canExecuteCancel(object obj)
        {
            return true;
        }

        void deletePerson()
        {
            try
            {
                _personService = new PersonSaveService();
                _personService.DeletePerson(Email);
                MessageBox.Show("Deleted!");
                GotoPersonList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
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
