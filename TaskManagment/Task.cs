using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Status status { get; set; }
        public DateTime? Deadline { get; set; }

        public Employee Employee { get; set; }




    }
}
