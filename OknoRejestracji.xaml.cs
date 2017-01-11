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

namespace Projekt_Poprawa
{
    /// <summary>
    /// Interaction logic for OknoRejestracji.xaml
    /// </summary>
    public partial class OknoRejestracji : Window, IZarzadzanieOkienkami
    {
        stronaPracownika StronaPracownika = new stronaPracownika();
        stronaWlasciciela StronaWlasciciela = new stronaWlasciciela();
        public OknoRejestracji()
        {
            InitializeComponent();

        }
        public void Przelacz(int Indeks)
        {
            if (Indeks == 0)
            {
                this.ramkaDoStron.NavigationService.Navigate(StronaWlasciciela);
            }
            else
            {
                this.ramkaDoStron.NavigationService.Navigate(StronaPracownika);
            }
        }
        private void wyborRodzajuKonta(object sender, SelectionChangedEventArgs e)
        {

            int wybranaWartosc = rodzajKonta.SelectedIndex;
            Przelacz(wybranaWartosc);

        }
        private void AnulujRejestracje(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
