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
    /// Interaction logic for stronaWlasciciela.xaml
    /// </summary>
    public partial class stronaWlasciciela : Page
    {

        Konta Konto = new Konta();
        public stronaWlasciciela()
        {
            InitializeComponent();
        }
        private void CzyszczenieZawartosci()
        {
            pobierzLoginWlasciciela.Text = "";
            pobierzHasloWlasciciela.Password = "";
            pobierzKluczWlasciciela.Password = "";
        }
        private void ZarejestrujWlasciciela(object sender, RoutedEventArgs e)
        {
            Konto.dodajWlasciciela(pobierzLoginWlasciciela.Text, pobierzHasloWlasciciela.Password, pobierzKluczWlasciciela.Password);
            CzyszczenieZawartosci();

        }
    }
}
