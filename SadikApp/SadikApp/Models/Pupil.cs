using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace SadikApp
{
    public partial class Pupil
    {
        public string FullName
        {
            get
            {
                return $"{Surname} {Name} {(string.IsNullOrWhiteSpace(Patronymic) ? "" : Patronymic)}";
            }
        }

        public Visibility VisibilityItem
        {
            get
            {
                return Deleted ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        public string PhotoPath
        {
            get
            {
                if (Photo != null)
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Images", Photo);
                return string.Empty;
            }
        }
    }
}
    