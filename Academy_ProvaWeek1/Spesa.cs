using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_ProvaWeek1.Entities
{
    public enum Categoria
    {
        Viaggio,
        Alloggio,
        Vitto,
        Altro
    }
  public class Spesa
    {
        public DateTime Data { get; set; }
        public Categoria Categoria { get; set; }
        public string Descrizione { get; set; }
        public double Importo { get; set; }
        public bool Approvata { get; set; }
        public string LvlApprovazione { get; set; }
        public double ImportoRimborsato { get; set; }


        public override string ToString()
        {
            return $"{Data.ToShortDateString()};{Categoria};{Descrizione};{Importo}";
        }
    }
}
