using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Projekt_Poprawa
{
    class Faktury
    {
        public Faktury() { }
        public bool sprawdzamDane(string Kod, string Login)
        {
            StreamReader Odczyt = new StreamReader(Login + ".txt");
            using (Odczyt)
            {
                Odczyt.ReadLine();
                string odczytanyKod = Odczyt.ReadLine();
                if (odczytanyKod == Kod)
                {
                    Odczyt.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
