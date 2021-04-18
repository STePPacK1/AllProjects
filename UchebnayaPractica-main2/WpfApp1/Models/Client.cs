using System;
using System.IO;

namespace WpfApp1
{
    public partial class Client
    {
        public string PhotoPath
        {
            get
            {
                if (Photo != null)
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Images", Photo);
                return string.Empty;
            }
        }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstName + " " + Patronymic;
            }
        }
    }
}
