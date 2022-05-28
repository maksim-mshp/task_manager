using System;
using System.Collections.Generic;
using System.IO;
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

namespace TaskManager {

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window {

        public int id_counter = 1;
        public bool is_inited = false;
        List < Task > tasks = new List < Task > ();
        public static RoutedCommand MyCommand = new RoutedCommand();

        public MainWindow() {
            InitializeComponent();
            MyCommand.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));

            read_tasks();
        }

        public void remove_task(int task_id) {
            for (int i = 0; i < tasks.Count; i++) {
                if (tasks[i].id == task_id) {
                    listbox.Items.Remove(tasks[i]);
                    tasks.RemoveAt(i);
                }
            }
            write_tasks();
        }

        public void add_task(string title, bool isdone = false) {
            Task task = new Task();
            task.name.Text = title;
            task.id = id_counter;
            task.mainwindow = this;
            task.checkbox.IsChecked = isdone;
            id_counter++;
            listbox.Items.Add(task);
            tasks.Add(task);
            if (is_inited == true) {
                write_tasks();
            }

        }

        public void clear_tasks() {
            tasks.Clear();
            listbox.Items.Clear();
            write_tasks();
        }

        private void add_Click(object sender, RoutedEventArgs e) {
            AddTaskWindow window = new AddTaskWindow();
            window.mainwindow = this;
            window.Topmost = true;
            window.Show();
        }

        public void write_tasks() {
            using(StreamWriter sw = new StreamWriter("data.txt")) {
                string data = "";
                data += tasks.Count.ToString() + "\n";
                for (int i = 0; i < tasks.Count; i++) {
                    if (tasks[i].checkbox.IsChecked == true) {
                        data += "1";
                    } else {
                        data += "0";
                    }
                    data += tasks[i].name.Text;
                    data += "\n";
                }
                sw.Write(data);
                sw.Close();
            }
        }

        public void read_tasks() {
            if (File.Exists("data.txt")) {
                using(StreamReader sr = new StreamReader("data.txt")) {
                    int len = Convert.ToInt32(sr.ReadLine());
                    for (int i = 0; i < len; i++) {
                        string line = sr.ReadLine();
                        bool fl = false;
                        if (line[0] == '1') {
                            fl = true;
                        }
                        add_task(line.Remove(0, 1), fl);
                    }
                    sr.Close();
                    is_inited = true;
                }
                write_tasks();
            }

        }

        private void clear_btn_Click(object sender, RoutedEventArgs e) {
            clear_tasks();
        }

        private void add_rand_btn_Click(object sender, RoutedEventArgs e) {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string name = "";
            Random rand = new Random();
            int len = rand.Next(3, 10);
            for (int i = 0; i < len; i++) {
                name += chars[rand.Next(0, chars.Length)];
            }
            add_task(name);
        }

        private void exit_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void clearall_Click(object sender, RoutedEventArgs e) {
            clear_tasks();
        }

        private void about_btn_Click(object sender, RoutedEventArgs e) {
            Window1 window = new Window1();
            window.Topmost = true;
            window.Show();
        }

        private void MyWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Control) && e.Key == Key.N) {
                AddTaskWindow window = new AddTaskWindow();
                window.mainwindow = this;
                window.Topmost = true;
                window.Show();
            }
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Control) && e.Key == Key.R) {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                string name = "";
                Random rand = new Random();
                int len = rand.Next(3, 10);
                for (int i = 0; i < len; i++) {
                    name += chars[rand.Next(0, chars.Length)];
                }
                add_task(name);
            }
            if (e.Key == Key.D1 || e.Key == Key.NumPad1) {
                if (tasks.Count > 0) tasks[0].make_done();
            }
            if (e.Key == Key.D2 || e.Key == Key.NumPad2) {
                if (tasks.Count > 1) tasks[1].make_done();
            }
            if (e.Key == Key.D3 || e.Key == Key.NumPad3) {
                if (tasks.Count > 2) tasks[2].make_done();
            }
            if (e.Key == Key.D4 || e.Key == Key.NumPad4) {
                if (tasks.Count > 3) tasks[3].make_done();
            }
            if (e.Key == Key.D5 || e.Key == Key.NumPad5) {
                if (tasks.Count > 4) tasks[4].make_done();
            }
            if (e.Key == Key.D6 || e.Key == Key.NumPad6) {
                if (tasks.Count > 5) tasks[5].make_done();
            }
            if (e.Key == Key.D7 || e.Key == Key.NumPad7) {
                if (tasks.Count > 6) tasks[6].make_done();
            }
            if (e.Key == Key.D8 || e.Key == Key.NumPad8) {
                if (tasks.Count > 7) tasks[7].make_done();
            }
            if (e.Key == Key.D9 || e.Key == Key.NumPad9) {
                if (tasks.Count > 8) tasks[8].make_done();
            }

            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Shift) && (e.Key == Key.D1 || e.Key == Key.NumPad1)) {
                if (tasks.Count > 0) remove_task(tasks[0].id);
            }
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Shift) && (e.Key == Key.D2 || e.Key == Key.NumPad2)) {
                if (tasks.Count > 1) remove_task(tasks[1].id);
            }
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Shift) && (e.Key == Key.D3 || e.Key == Key.NumPad3)) {
                if (tasks.Count > 2) remove_task(tasks[2].id);
            }
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Shift) && (e.Key == Key.D4 || e.Key == Key.NumPad4)) {
                if (tasks.Count > 3) remove_task(tasks[3].id);
            }
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Shift) && (e.Key == Key.D5 || e.Key == Key.NumPad5)) {
                if (tasks.Count > 4) remove_task(tasks[4].id);
            }
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Shift) && (e.Key == Key.D6 || e.Key == Key.NumPad6)) {
                if (tasks.Count > 5) remove_task(tasks[5].id);
            }
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Shift) && (e.Key == Key.D7 || e.Key == Key.NumPad7)) {
                if (tasks.Count > 6) remove_task(tasks[6].id);
            }
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Shift) && (e.Key == Key.D8 || e.Key == Key.NumPad8)) {
                if (tasks.Count > 7) remove_task(tasks[7].id);
            }
            if (e.KeyboardDevice.Modifiers == (ModifierKeys.Shift) && (e.Key == Key.D9 || e.Key == Key.NumPad9)) {
                if (tasks.Count > 8) remove_task(tasks[8].id);
            }
        }
    }
}