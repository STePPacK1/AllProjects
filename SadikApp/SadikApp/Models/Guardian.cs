using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SadikApp
{
    public partial class Guardian
    {
        public string FullNameG
        {
            get
            {
                return $" {Surname} {Name} {(string.IsNullOrWhiteSpace(Patronymic) ? "" : Patronymic)}";
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
