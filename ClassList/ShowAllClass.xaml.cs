using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ClassList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Classes classes;
        private Groups groups;
        private Students students;
        public MainWindow()
        {
            InitializeComponent();
            classes = (Classes)Application.Current.FindResource("class_controller");
            groups = (Groups)Application.Current.FindResource("group_controller");
            students = (Students)Application.Current.FindResource("student_controller");
            ShowButton.Visibility = Visibility.Collapsed;
        }

        private void ClassListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetailsPanel.DataContext = ClassListBox.SelectedItem;
        }

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButton_Click(sender, e);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Class> class_list = classes.GetViewableList();
            SearchListBox.Items.Clear();
            if (AttributeBox.Text == "Class ID")
            {
                String class_id = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (class_id.Count() != 0)
                {
                    for (int i = 0; i < class_list.Count; i++)
                    {
                        if (class_list[i].class_id == Convert.ToInt64(class_id))
                        {
                            SearchListBox.Items.Add(class_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check attribute and key word!");
                }
            }
            else if (AttributeBox.Text == "Group ID")
            {
                String group_id = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (group_id.Count() != 0)
                { 
                    for (int i = 0; i < class_list.Count; i++)
                    {
                        if (class_list[i].group_id == Convert.ToInt64(group_id))
                        {
                            SearchListBox.Items.Add(class_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check attribute and key word!");
                }
            }
            else if (AttributeBox.Text == "Day")
            {
                String day = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (day.Count() != 0)
                {
                    for (int i = 0; i < class_list.Count; i++)
                    {
                        String day_record = String.Concat(class_list[i].day.Where(c => !Char.IsWhiteSpace(c)));
                        if (day_record.ToLower() == day.ToLower())
                        {
                            SearchListBox.Items.Add(class_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check attribute and key word!");
                }
            }
            else if(AttributeBox.Text == "Room")
            {
                String room = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (room.Count() != 0)
                {
                    for (int i = 0; i < class_list.Count; i++)
                    {
                        String room_record = String.Concat(class_list[i].room.Where(c => !Char.IsWhiteSpace(c)));
                        if (room_record.ToLower() == room.ToLower())
                        {
                            SearchListBox.Items.Add(class_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check attribute and key word!");
                }
            }
            else{
                MessageBox.Show("Please select required attribute and enter key word");
            }
        }

        private void AttributeBox_DropDownOpened(object sender, EventArgs e)
        {
        }

        private void SearchListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetailsPanel.DataContext = SearchListBox.SelectedItem;
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            ClassListBox.Items.Clear();
            for (int i = 0; i < classes.GetViewableList().Count; i++)
            {
                ClassListBox.Items.Add(classes.GetViewableList()[i]);
            }
        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            Class Class_List_selected_class = new Class();
            Class Search_List_selected_class = new Class();
            Class_List_selected_class = (ClassListBox.SelectedItem) as Class;
            Search_List_selected_class = (SearchListBox.SelectedItem) as Class;
            SearchListBox.Items.Clear();
            if (Class_List_selected_class != null)
            {
                int required_group_id = Class_List_selected_class.group_id;
                for (int i = 0; i < groups.GetViewableList().Count; i++)
                {
                    if (required_group_id == groups.GetViewableList()[i].group_id)
                    {
                        SearchListBox.Items.Add(groups.GetViewableList()[i]);
                    }
                }
            }
            else if (Search_List_selected_class != null)
            {
                int required_group_id = Search_List_selected_class.group_id;
                for (int i = 0; i < groups.GetViewableList().Count; i++)
                {
                    if (required_group_id == groups.GetViewableList()[i].group_id)
                    {
                        SearchListBox.Items.Add(groups.GetViewableList()[i]);
                    }
                }
            }
            else 
            {
                MessageBox.Show("There is no class selected!");
            }
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Student> student_list = students.GetViewableList();
            String student_id = String.Concat(LogTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
            if (student_id.Count() != 0)
            {
                for (int i = 0; i < student_list.Count; i++)
                {
                    if (student_list[i].student_id == Convert.ToInt64(student_id))
                    {
                        MessageBox.Show("Log on successfully!");
                        if (student_list[i].category == "Masters")
                        {
                            ShowButton.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please check your student ID entered!");
            }
        }
    }
}
