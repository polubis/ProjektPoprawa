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
    /// <summary>
    /// Interaction logic for OknoWyswietlaniaAdnotacji.xaml
    /// </summary>
    public partial class OknoWyswietlaniaAdnotacji : Window
    {
        Adnotacje Adnotacja = new Adnotacje();
        public OknoWyswietlaniaAdnotacji()
        {
            InitializeComponent();
            Adnotacja.WyswietlAdnotacje(wyswietlaczAdnotacji);

        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            OknoPoZalogowaniu Okno = new OknoPoZalogowaniu();
            Okno.Show();
            this.Close();
        }

        private void Zamknij(object sender, RoutedEventArgs e)
        {
            if (File.Exists("confirmed.txt"))
            {
                File.Delete("confirmed.txt");
            }
            Application.Current.Shutdown();
        }

        private void PokazDzisiejsze(object sender, RoutedEventArgs e)
        {
            Adnotacja.PokazDzisiejszeAdnotacje(wyswietlaczAdnotacji);
        }
    }
}
