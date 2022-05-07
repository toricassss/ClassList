using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassList
{
    public class Classes
    {
        private ObservableCollection<Class> classs;

        public Classes()
        {
            classs = Class_db.LoadAll();
        }

        public ObservableCollection<Class> GetViewableList()
        {
            return classs;
        }
    }
}
