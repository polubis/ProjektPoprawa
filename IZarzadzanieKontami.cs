using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    interface IZarzadzanieKontami
    {
        void dodajPracownika(string Login, string Haslo, string Funkcja);
        void dodajWlasciciela(string Login, string Haslo, string Klucz);
    }
}
