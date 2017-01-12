using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;

namespace Projekt_Poprawa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OknoRejestracji Okno = new OknoRejestracji();
        Konta konto = new Konta();


        public MainWindow()
        {
            InitializeComponent();

        }

        private void przyciskWyjscia(object sender, RoutedEventArgs e)
        {
            if(File.Exists("confirmed.txt"))
            {
                File.Delete("confirmed.txt");
            }
            Application.Current.Shutdown();
        }

        private void przyciskRejestracji(object sender, RoutedEventArgs e)
        {
            try
            {
                Okno.Show();
            }
            catch
            {
                MessageBox.Show("Można zakładać tylko jedno konto na jedno uruchomienie aplikacji!");
            }
        }

        private void Zaloguj(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists("Adnotacje"))
            {
                Directory.CreateDirectory("Adnotacje");
            }
            string Login = pobierzLogin.Text;
            string Haslo = pobierzHaslo.Password;
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Haslo))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
            }
            else
            {
                string Powrot = Directory.GetCurrentDirectory();
                if (!Directory.Exists("Wlasciciele"))
                {
                    MessageBox.Show("Nie ma takiego użytkownika");
                }
                else
                {
                    Directory.SetCurrentDirectory("Wlasciciele");
                    SzukaniePlikuTxt(Login + ".txt", Login + Haslo);
                    Directory.SetCurrentDirectory(Powrot);
                    if (Directory.Exists("Pracownicy"))
                    {
                        Directory.SetCurrentDirectory("Pracownicy");
                        SzukaniePlikuTxt(Login + ".txt", Login + Haslo);
                        Directory.SetCurrentDirectory(Powrot);
                    }
                    konto.TworzeLogi(pobierzLogin.Text);

                }


            }
        }
        private void SzukaniePlikuTxt(string Nazwa, string Zawartosc)
        {

            if (File.Exists(Nazwa))
            {
                StreamReader Odczyt = new StreamReader(Nazwa);
                using (Odczyt)
                {
                    if (Odczyt.ReadLine() == Zawartosc)
                    {
                        OknoPoZalogowaniu Okno = new OknoPoZalogowaniu();
                        Okno.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Błędne dane logowania");
                    }
                }
            }
        }
    }
}
