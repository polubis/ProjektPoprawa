using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    interface IZarzadzanieMenu
    {
        void DodajDanie(int ID, string Nazwa, double Cena, string Rodzaj);
    }
}
