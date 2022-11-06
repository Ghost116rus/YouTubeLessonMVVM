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
using System.Windows.Shapes;
using YouTubeLessonMVVM.ViewModel;

namespace YouTubeLessonMVVM.View.Add
{
    /// <summary>
    /// Логика взаимодействия для AddNewStaffWindow.xaml
    /// </summary>
    public partial class AddNewStaffWindow : Window
    {
        public AddNewStaffWindow()
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
        }
    }
}
