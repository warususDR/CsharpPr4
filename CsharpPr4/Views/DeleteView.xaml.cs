using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CsharpPr4.ViewModels;

namespace PracticeDateHandling.Views
{
    /// <summary>
    /// Логика взаимодействия для DeleteView.xaml
    /// </summary>
    public partial class DeleteView : UserControl
    {
        private DeleteViewModel _deleteViewModel;

        public DeleteView(Action goToPersonList)
        {
            InitializeComponent();
            DataContext = _deleteViewModel = new DeleteViewModel(goToPersonList);
        }
    }
}
