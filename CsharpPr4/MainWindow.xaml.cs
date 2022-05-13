
using CsharpPr4.Views;
using PracticeDateHandling.Views;
using System.Windows;

namespace PracticeDateHandling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GoToPersonList();
        }

        public void GoToDatePick()
        {
            Content = new DatePickView(GoToPersonList);
        }

        public void GoToPersonList()
        {
            Content = new PersonListView(GoToDatePick, GoToDelete, GoToFilter);
        }

        public void GoToDelete()
        {
            Content = new DeleteView(GoToPersonList);
        }

        public void GoToFilter()
        {
            Content = new FilterView(GoToPersonList);
        }

    }
}
