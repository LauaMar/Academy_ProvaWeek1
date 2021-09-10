using Academy_ProvaWeek1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_ProvaWeek1.Handler_Approvazione
{
    public class ManagerHandler: AbstractHandler
    {
        public override string Handle(Spesa spesa)
        {
            if(spesa.Importo<=400)
            {
                spesa.Approvata = true;
                spesa.LvlApprovazione = "Manager";
                return "APPROVATA dal Manager";
            }
            return base.Handle(spesa);
        }
    }
}
