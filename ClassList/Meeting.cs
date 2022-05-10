using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassList
{
    public class Meeting
    {
        public int meeting_id { get; set; }
        public string? group_id { get; set; }
        public string? day { get; set; }
        public string? start { get; set; }
        public string? end { get; set; }
        public string? room { get; set; }

        public override string ToString()
        {
            return $"meeting_id: {meeting_id}, group_id:{group_id}, day: {day}, room: {room}";
        }
    }
}