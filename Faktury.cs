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
    class Faktury
    {
        
        public string Nazwa { get; set; }
       
        private List<Faktury> ListaFaktur;
        private List<Faktury> ListaPoWyszukaniu;
        public Faktury() { ListaFaktur = new List<Faktury>(); ListaPoWyszukaniu = new List<Faktury>(); }
        public List<Faktury> ZwracamListeFaktur()
        {
            return ListaFaktur;
        }
        public List<Faktury> ZwracamListePoWyszukaniu()
        {
            return ListaPoWyszukaniu;
        }
        public Faktury(string Nazwa)
        {
            this.Nazwa = Nazwa;
       
        }
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
        public void WyswietlamWszystkieFaktury(ListView Lista)
        {
            
            string Sciezka = Directory.GetCurrentDirectory();
            if(Directory.Exists("Faktury_" + DateTime.Now.Year.ToString()))
            {
                    string[] NazwyPlikow = Directory.GetFiles("Faktury_" + DateTime.Now.Year.ToString());
                    for(int i=0;i<NazwyPlikow.Length;i++)
                    {
                        ListaFaktur.Add(new Faktury(PrzycinamSciezke(NazwyPlikow[i])));
                        
                    }
                    Directory.SetCurrentDirectory(Sciezka);
                    Lista.ItemsSource = ListaFaktur;
                    CollectionViewSource.GetDefaultView(Lista.ItemsSource).Refresh();
            }
            
        }
        public string PrzycinamSciezke(string Sciezka)
        {
            string Nowy = Sciezka.Remove(0, 13);
            return Nowy;
        }
        public void SzukamPoRoku(string Rok,string Miesiac,string Dzien,ListView Lista)
        {
            string Sciezka = Directory.GetCurrentDirectory();
            if(!Directory.Exists("Faktury_"+Rok))
            {
               MessageBox.Show("Nie ma faktur z roku: " + Rok);
            }
            else
            {
                Directory.SetCurrentDirectory("Faktury_" + Rok);
                if (!File.Exists(Miesiac+"_"+Dzien+".txt"))
                {
                    MessageBox.Show("Nie ma faktur z tego dnia");
                }
                else
                {
                    Directory.SetCurrentDirectory(Sciezka);
                    string[] NazwyPlikow = Directory.GetFiles("Faktury_" + Rok);
                    ListaPoWyszukaniu.Add(new Faktury(Miesiac+"_"+Dzien+".txt"));
                    Lista.ItemsSource = ListaPoWyszukaniu;
                    
                }
                
            }
            Directory.SetCurrentDirectory(Sciezka);
        }
        
       
       
    }
}
