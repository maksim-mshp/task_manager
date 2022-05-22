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
        public int id = 0;
        public MainWindow mainwindow;

        public Task()
        {
            InitializeComponent();
        }

        private void delete_task_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainwindow.remove_task(id);
        }

        private void task_name_Unchecked(object sender, RoutedEventArgs e)
        {
            name.TextDecorations = null;
            if (mainwindow.is_inited == true)
            {
                mainwindow.write_tasks();
            }
        
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            name.TextDecorations = TextDecorations.Strikethrough;
            if (mainwindow.is_inited == true)
            {
                mainwindow.write_tasks();
            }
        }


        private void name_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (checkbox.IsChecked == true)
            {
                checkbox.IsChecked = false;
                name.TextDecorations = null;
            } else
            {
                checkbox.IsChecked = true;
                name.TextDecorations = TextDecorations.Strikethrough;
            }
        }
    }
}
