using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace TaskManagment
{
    public static class GlobalUser
    {
        // Static property to store the logged-in user
        public static User CurrentUser { get; set; }
    }
}
