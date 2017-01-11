﻿using System;
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
    /// Interaction logic for OknoUzyskaniaDostepu.xaml
    /// </summary>
    public partial class OknoUzyskaniaDostepu : Window
    {
        Faktury Faktura = new Faktury();
        public OknoUzyskaniaDostepu()
        {
            InitializeComponent();
        }

        private void Anuluj(object sender, RoutedEventArgs e)
        {
            OknoPoZalogowaniu Okno = new OknoPoZalogowaniu();
            this.Close();
            Okno.Show();
        }

        private void Potwierdz(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pobierzKod.Password) || string.IsNullOrEmpty(pobierzLogin.Text))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola");
            }
            else
            {
                string Sciezka = Directory.GetCurrentDirectory();
                if (!Directory.Exists("Wlasciciele"))
                {
                    MessageBox.Show("Nie ma żadnego właściciela");
                }
                else
                {
                    Directory.SetCurrentDirectory("Wlasciciele");
                    if (!File.Exists(pobierzLogin.Text + ".txt"))
                    {
                        MessageBox.Show("Nie ma takiego użytkownika");
                        Directory.SetCurrentDirectory(Sciezka);
                    }
                    else
                    {
                        bool Rezultat = Faktura.sprawdzamDane(pobierzKod.Password, pobierzLogin.Text);
                        if (Rezultat == true)
                        {
                            MessageBox.Show("Uwierzytelnianie pomyślne");
                            OknoNowejAdnotacji Okno = new OknoNowejAdnotacji();
                            this.Close();
                            Okno.Show();

                        }
                        else
                            MessageBox.Show("Błędny login lub klucz");
                        Directory.SetCurrentDirectory(Sciezka);
                    }


                }
            }
            pobierzKod.Password = "";
            pobierzLogin.Text = "";

        }
    }
}