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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_Poprawa
{
    /// <summary>
    /// Strona umozliwa zarejestrowanie sie pracownikowi.
    /// </summary>
    public partial class stronaPracownika : Page
    {
        Konta Konto = new Konta();

        public stronaPracownika()
        {
            InitializeComponent();


        }
        private void CzyszczenieZawartosci()
        {
            pobierzLoginPracownika.Text = "";
            PobierzHasloPracownika.Password = "";
            pobierzFunkcjePracownika.Text = "";
        }
        private void ZarejestrujPracownika(object sender, RoutedEventArgs e)
        {
            Konto.dodajPracownika(pobierzLoginPracownika.Text, PobierzHasloPracownika.Password, pobierzFunkcjePracownika.Text);
            CzyszczenieZawartosci();

        }
    }
}
