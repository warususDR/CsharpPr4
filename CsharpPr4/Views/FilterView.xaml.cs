using CsharpPr4.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CsharpPr4.Views
{
    /// <summary>
    /// Логика взаимодействия для FilterView.xaml
    /// </summary>
    public partial class FilterView : UserControl
    {
        FilterViewModel _viewModel;

        public FilterView(Action goToPersonList)
        {
            InitializeComponent();
            DataContext = _viewModel = new FilterViewModel(goToPersonList);
        }
    }

    
   
}
