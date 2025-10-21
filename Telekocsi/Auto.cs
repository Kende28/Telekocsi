using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    internal class Auto
    {

        public string Indulas { get; set; }
        public string Cel {  get; set; }
        public string RendSzam { get; set; }
        public string TelefonSzam { get; set; }
        public int Ferohely {  get; set; }

        public Auto(string indulas, string cel, string rendSzam, string telefonSzam, int ferohely)
        {
            Indulas = indulas;
            Cel = cel;
            RendSzam = rendSzam;
            TelefonSzam = telefonSzam;
            Ferohely = ferohely;
        }

        public override string ToString()
        {
            return $"{Indulas} - {Cel}: {RendSzam} | {TelefonSzam} | {Ferohely}";
        }
    }
}
