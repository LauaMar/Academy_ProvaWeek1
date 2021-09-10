using Academy_ProvaWeek1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_ProvaWeek1.Handler_Approvazione
{
   public class OpManagerHandler: AbstractHandler
    {
        public override string Handle(Spesa spesa)
        {
            if(spesa.Importo>400 && spesa.Importo<=1000)
            {
                spesa.Approvata = true;
                spesa.LvlApprovazione = "Operational Manager";
                return "APPROVATA dall' Operational Manager";
            }
            return base.Handle(spesa);
        }

    }
}
