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
using System.IO.Packaging;




namespace Projekt_Poprawa
{
    class Adnotacje
    {
        public Adnotacje() { }
        public void TworzePlikAdnotacje(string Zawartosc)
        {
            string Sciezka = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory("Adnotacje");
            if (!File.Exists("Adnotacja_" + DateTime.Today.Day + ".txt"))
            {
                TextWriter Zapis = new StreamWriter("Adnotacja_" + DateTime.Today.Day + ".txt", true);
                DodajeAdnotacje(Zawartosc, Zapis);
                Directory.SetCurrentDirectory(Sciezka);
                MessageBox.Show("Dodano adnotacje");
            }
            else
            {
                TextWriter Zapis = new StreamWriter("Adnotacja_" + DateTime.Today.Day + ".txt", true);
                DodajeAdnotacje(Zawartosc, Zapis);
                Directory.SetCurrentDirectory(Sciezka);
                MessageBox.Show("Dodano adnotacje");
            }
            UsuwamStareAdnotacje();

        }
        public void DodajeAdnotacje(string Zawartosc, TextWriter Zapis)
        {
            string Czas = DateTime.Today.DayOfWeek + "," + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            using (Zapis)
            {
                Zapis.WriteLine(Czas);
                Zapis.WriteLine(Zawartosc);
                Zapis.Close();
            }
        }
        private void UsuwamStareAdnotacje()
        {
            int DataUsuniecia = Convert.ToInt32(DateTime.Today.Day) - 3;
            try
            {
                string[] Pliki = Directory.GetFiles("Adnotacje");
                for (int i = 0; i < Pliki.Length; i++)
                {
                    if (Pliki[i].Contains(DataUsuniecia.ToString()))
                        File.Delete(Pliki[i]);
                }
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }
        public void WyswietlAdnotacje(TextBox Text)
        {
            string[] Pliki = Directory.GetFiles("Adnotacje");
            string[] OdczytaneAdnotacje = new string[Pliki.Length];
            for (int i = 0; i < Pliki.Length; i++)
            {
                StreamReader Odczyt = new StreamReader(Pliki[i]);
                using (Odczyt)
                {
                    OdczytaneAdnotacje[i] = Odczyt.ReadToEnd();
                    Text.Text = OdczytaneAdnotacje[i];
                    Odczyt.Close();
                }
            }

        }
        public void UsunWszystkieAdnotacje(TextBox Text)
        {
            string[] Pliki = Directory.GetFiles("Adnotacje");
            if (Pliki.Length <= 0)
            {
                MessageBox.Show("Nie ma adnotacji do usunięcia");
            }
            else
            {
                for (int i = 0; i < Pliki.Length; i++)
                {
                    File.Delete(Pliki[i]);
                }
                Text.Text = "";
            }

        }
        public void UsunStarszeAdnotacje(TextBox Text)
        {
            string[] Pliki = Directory.GetFiles("Adnotacje");
            if (Pliki.Length <= 0)
            {
                MessageBox.Show("Nie ma adnotacji do usunięcia");
            }
            else
            {
                for (int i = 0; i < Pliki.Length; i++)
                {
                    if (!Pliki[i].Contains(DateTime.Today.Day.ToString()))
                    {
                        File.Delete(Pliki[i]);
                    }
                    else
                    {
                        MessageBox.Show("Nie ma starszych adnotacji");
                        break;
                    }
                }

            }
        }
        public void PokazDzisiejszeAdnotacje(TextBox Text)
        {
            string[] Pliki = Directory.GetFiles("Adnotacje");
            string[] OdczytaneAdnotacje = new string[Pliki.Length];
            for (int i = 0; i < Pliki.Length; i++)
            {
                if (Pliki[i].Contains(DateTime.Today.Day.ToString()))
                {
                    StreamReader Odczyt = new StreamReader(Pliki[i]);
                    using (Odczyt)
                    {
                        OdczytaneAdnotacje[i] = Odczyt.ReadToEnd();
                        Text.Text = OdczytaneAdnotacje[i];
                        Odczyt.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nie ma dzisiejszych adnotacji ");
                    break;
                }
            }
        }
        ~Adnotacje() { }


    }
}
