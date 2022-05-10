using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassList
{
    public class Meetings
    {
        private ObservableCollection<Meeting> meetings;

        public Meetings()
        {
            meetings = Meeting_db.LoadAll();
        }

        public ObservableCollection<Meeting> GetViewableList()
        {
            return meetings;
        }
    }
}
