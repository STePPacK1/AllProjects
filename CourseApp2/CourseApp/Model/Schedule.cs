using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseApp
{
    public partial class Schedule
    {
        public string DisplayInfo
        {
            get
            {
                return $"{ DayOfWeek1.Name } { Time.ToString("HH:mm") } - { Course1.Name } - { Teacher1.FullName }";
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
