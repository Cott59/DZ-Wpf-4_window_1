using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.ComponentModel;
using DZ_Wpf_4_window.src;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;

namespace DZ_Wpf_4_window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<ToDo> todoList;
        public List<ToDo> TodoList
        {
            get { return todoList; }
            set 
            {
                todoList = value;
                OnPropertyChange();
            }
        }
        public int CountDone { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            
            TodoList = new List<ToDo>();
            
            TodoList.Add(new ToDo("Родиться", new DateTime(2024, 04, 10), "Важно_1!"));
            TodoList.Add(new ToDo("Посадить сына",    new DateTime(2024, 01, 11), "Важно2!!"));
            TodoList.Add(new ToDo("Построить дерево", new DateTime(2024, 01, 13), "Важно3!!!"));
            TodoList.Add(new ToDo("Вырастить дом",    new DateTime(2024, 01, 13), "Важно4!!!!"));
            
            listToDo.ItemsSource  = TodoList;
            this.DataContext = TodoList;
            

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange()
        {

            CountDone = TodoList.Where(e=>e.Done==true).ToList().Count;
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TodoList"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CountDone"));
        }

        public void DeleteJob(object sender, RoutedEventArgs e)
        {
            
            TodoList.Remove((sender as Button).DataContext as ToDo);
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = TodoList;
            OnPropertyChange();
        }

        
        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            WindowAddToDo windowAddToDo = new WindowAddToDo();
            windowAddToDo.Owner = this;
            windowAddToDo.Show();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(listToDo.SelectedItem != null) 
            {
                ((sender as CheckBox).DataContext as ToDo).Done = true;
                OnPropertyChange();
            }
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem != null)
            {
                ((sender as CheckBox).DataContext as ToDo).Done = false;
                OnPropertyChange();
            }
        }

    }

    


}