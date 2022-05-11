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

namespace StudentList1
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

        private void StudentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetailsPanel.DataContext = StudentListBox.SelectedItem;
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
            ObservableCollection<Student> student_list = students.GetViewableList();
            SearchListBox.Items.Clear();
            if (AttributeBox.Text == "Student ID")
            {
                String student_id = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (student_id.Count() != 0)
                {
                    for (int i = 0; i < student_list.Count; i++)
                    {
                        if (student_list[i].student_id == Convert.ToInt64(student_id))
                        {
                            SearchListBox.Items.Add(student_list[i]);
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
                String student_id = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (student_id.Count() != 0)
                {
                    for (int i = 0; i < student_list.Count; i++)
                    {
                        if (student_list[i].group_id == Convert.ToInt64(group_id))
                        {
                            SearchListBox.Items.Add(student_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check attribute and key word!");
                }
            }
            else if (AttributeBox.Text == "Given Name")
            {
                String given_name = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (given_name.Count() != 0)
                {
                    for (int i = 0; i < student_list.Count; i++)
                    {
                        String given_name_record = String.Concat(student_list[i]..Where(c => !Char.IsWhiteSpace(c)));
                        if (given_name_record.ToLower() == given_name.ToLower())
                        {
                            SearchListBox.Items.Add(student_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check given name!");
                }
            }
            else if (AttributeBox.Text == "Family Name")
            {
                String family_name = String.Concat(SearchTextBox.Text.Where(c => !Char.IsWhiteSpace(c)));
                if (family_name.Count() != 0)
                {
                    for (int i = 0; i < student_list.Count; i++)
                    {
                        String family_name_record = String.Concat(student_list[i].room.Where(c => !Char.IsWhiteSpace(c)));
                        if (family_name_record.ToLower() == family_name.ToLower())
                        {
                            SearchListBox.Items.Add(student_list[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check family name!");
                }
            }
            else
            {
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
            StudentListBox.Items.Clear();
            for (int i = 0; i < students.GetViewableList().Count; i++)
            {
                StudentListBox.Items.Add(students.GetViewableList()[i]);
            }
        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            Student Student_list_selected_student = new Student();
            Student Search_List_selected_student = new Student();
            Student_list_selected_student = (StudentListBox.SelectedItem) as Student;
            Search_List_selected_student = (SearchListBox.SelectedItem) as Student;
            SearchListBox.Items.Clear();
            if (Student_list_selected_student != null)
            {
                int required_group_id = Student_list_selected_student.group_id;
                for (int i = 0; i < groups.GetViewableList().Count; i++)
                {
                    if (required_group_id == groups.GetViewableList()[i].group_id)
                    {
                        SearchListBox.Items.Add(groups.GetViewableList()[i]);
                    }
                }
            }
            else if (Search_List_selected_student != null)
            {
                int required_group_id = Search_List_selected_student.group_id;
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
                MessageBox.Show("There is no student selected!");
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
                MessageBox.Show("Please check your student ID!");
            }
        }
    }
}

