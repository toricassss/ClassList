using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassList
{
    public class Students
    {
        private ObservableCollection<Student> students;

        public Students()
        {
            students = Student_db.LoadAll();
        }

        public ObservableCollection<Student> GetViewableList()
        {
            return students;
        }
    }
}
