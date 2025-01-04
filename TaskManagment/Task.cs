using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TaskManagment
{
    public class Task
    {
        public Task ()
        { }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Status status { get; set; }
        public DateTime? Deadline { get; set; }

        public Employee Employee { get; set; }


        public override string ToString()
        {
            return $"Task : {Title} - status : {status} - Description : {Description}"; // Custom format for display
        }

    }
}
