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

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public partial class Task : UserControl
    {
        public Task()
        {
            InitializeComponent();
        }

        private void delete_task_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void task_name_Unchecked(object sender, RoutedEventArgs e)
        {
            tbx.TextDecorations = null;
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            tbx.TextDecorations = TextDecorations.Strikethrough;
        }
    }
}
