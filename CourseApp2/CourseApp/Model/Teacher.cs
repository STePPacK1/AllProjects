using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseApp
{
    public partial class Teacher
    {
        public string FullName
        {
            get
            {
                return $"{ LastName } { FirstName } { (string.IsNullOrWhiteSpace(Patronymic) ? Patronymic : "") }";
            }
        }

        public Visibility VisibilityItem
        {
            get
            {
                return Deleted ? Visibility.Collapsed : Visibility.Visible;
            }
        }
    }
}
