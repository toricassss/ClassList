using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassList
{
    public class Group
    {
        public string? group_id { get; set; }
        public string? group_name { get; set; }

        public override string ToString()
        {
            return $"group_id: {group_id}, group_name: {group_name}";
        }
    }
}
