using CsharpPr4.Service;
using PracticeDateHandling.Models;
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
    class FilterViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object> _cancelCommand;
        private RelayCommand<object> _filterCommand;
        private Action _gotoPersonList;
        private string _selectedProp;
        private string _propValue;
        private PersonSaveService _personService;
        private List<Person> _filteredPeople;
        private Visibility _filteredVisible;
        public FilterViewModel(Action gotoPersonList)
        {
            _gotoPersonList = gotoPersonList;
            _personService = new PersonSaveService();
            FilteredVisible = Visibility.Collapsed;
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand<object>(_ => GotoPersonList(), canExecuteCancel);
            }
        }

        public RelayCommand<object> FilterCommand
        {
            get
            {
                return _filterCommand ??= new RelayCommand<object>(_ => FilterPeople(), canExecuteFilter);
            }
        }

        private bool canExecuteFilter(object obj)
        {
            return SelectedProp != null && PropValue != null;
        }

        private bool canExecuteCancel(object obj)
        {
            return true;
        }

        public void GotoPersonList()
        {
            _gotoPersonList.Invoke();
        }

        public string SelectedProp
        {
            get
            {
                return _selectedProp;
            }
            set
            {
                _selectedProp = value;
                OnPropertyChanged("SelectedProp");
            }

        }

        public string PropValue
        {
            get
            {
                return _propValue;
            }
            set
            {
                _propValue = value;
                OnPropertyChanged("PropValue");
            }

        }

        public List<Person> FilteredPeople
        {
            get
            {
                return _filteredPeople;
            }
            set
            {
                _filteredPeople = value;
                OnPropertyChanged("FilteredPeople");
            }
        }

        public Visibility FilteredVisible
        {
            get
            {
                return _filteredVisible;
            }
            set
            {
                _filteredVisible = value;
                OnPropertyChanged("FilteredVisible");
            }
        }



        public void FilterPeople()
        {
            FilteredVisible = Visibility.Collapsed;
            List<Person> allPeople = _personService.getAllPersons();
            FilteredPeople = new List<Person>();
            string SelectedPropStr = SelectedProp.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
            switch (SelectedPropStr)
            {
                case "Name":
                    var s = from person in allPeople
                            where person.Name.Equals(PropValue)
                            select person;
                    FilteredPeople = s.ToList();
                    break;

                case "Surname":
                    s = from person in allPeople
                        where person.Surname.Equals(PropValue)
                        select person;
                    FilteredPeople = s.ToList();
                    break;

                case "Email":
                    s = from person in allPeople
                        where person.Email.Equals(PropValue)
                        select person;
                    FilteredPeople = s.ToList();
                    break;

                case "Birthday":
                    try
                    {
                        s = from person in allPeople
                            where person.Birthday.Equals(DateTime.Parse(PropValue))
                            select person;
                        FilteredPeople = s.ToList();
                    }
                    catch
                    {

                    }
                    break;

                case "IsAdult":
                    try
                    {
                        s = from person in allPeople
                            where person.IsAdult.Equals(Convert.ToBoolean(PropValue))
                            select person;
                        FilteredPeople = s.ToList();
                    }
                    catch
                    {

                    }
                    break;

                case "SunSign":
                    s = from person in allPeople
                        where person.SunSign.Equals(PropValue)
                        select person;
                    FilteredPeople = s.ToList();
                    break;

                case "ChineseSign":
                    s = from person in allPeople
                        where person.ChineseSign.Equals(PropValue)
                        select person;
                    FilteredPeople = s.ToList();
                    break;

                case "IsBirthday":
                    try
                    {
                        s = from person in allPeople
                            where person.IsBirthday.Equals(Convert.ToBoolean(PropValue))
                            select person;
                        FilteredPeople = s.ToList();
                    }
                    catch
                    {

                    }
                    break;                  
            }
            if (FilteredPeople.Count == 0)
            {
                MessageBox.Show("Found no matches. Check property value.");
                FilteredVisible = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show($"Found {FilteredPeople.Count} matches.");
                FilteredVisible = Visibility.Visible;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
