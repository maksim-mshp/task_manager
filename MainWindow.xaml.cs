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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int id_counter = 1;
        List<Task> tasks = new List<Task>();
        public MainWindow()
        {
            InitializeComponent();
            add_task("first task");
        }

        public void remove_task(int task_id)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].id == task_id)
                {
                    listbox.Items.Remove(tasks[i]);
                    tasks.RemoveAt(i);
                }
            }
        }

        public void add_task(string title)
        {
            Task task = new Task();
            task.name.Text = title;
            task.id = id_counter;
            task.mainwindow = this;
            id_counter++;
            listbox.Items.Add(task);
            tasks.Add(task);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow window = new AddTaskWindow();
            window.mainwindow = this;
            window.Topmost = true;
            window.Show();
        }
    }


}
