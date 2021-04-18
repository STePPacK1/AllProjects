using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseApp
{
    public partial class Account
    {
        public Visibility IsAdmin
        {
            get
            {
                return Teacher.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
            }
        }
    }
}
