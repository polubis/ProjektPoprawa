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
    /// Interaction logic for OknoPoZalogowaniu.xaml
    /// </summary>
    public partial class OknoPoZalogowaniu : Window
    {
        OknoMenu OknoMenu = new OknoMenu();
        public OknoPoZalogowaniu()
        {
            InitializeComponent();
        }

        private void DodajAdnotacje(object sender, RoutedEventArgs e)
        {
            OknoUzyskaniaDostepu Okno = new OknoUzyskaniaDostepu();
            Okno.Show();
            this.Close();
        }

        private void NowyRachunek(object sender, RoutedEventArgs e)
        {
            OknoNowegoRachunku Okno = new OknoNowegoRachunku();
            Okno.Show();
            this.Close();
        }
        private void PokazMenu(object sender, RoutedEventArgs e)
        {
            OknoMenu.Show();
            this.Close();
        }
        private void Wyloguj(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow Okno = new MainWindow();
            Okno.Show();
        }

        private void WyswietlFakture(object sender, RoutedEventArgs e)
        {

        }

        private void WyswietlAdnotacje(object sender, RoutedEventArgs e)
        {
            Adnotacje Adnotacja = new Adnotacje();
            string[] Pliki = Directory.GetFiles("Adnotacje");
            if (Pliki.Length <= 0)
            {
                MessageBox.Show("Nie masz żadnych adnotacji");
            }
            else
            {
                OknoWyswietlaniaAdnotacji OknoWyswietlania = new OknoWyswietlaniaAdnotacji();
                OknoWyswietlania.Show();
                this.Close();
            }


        }
    }
}
