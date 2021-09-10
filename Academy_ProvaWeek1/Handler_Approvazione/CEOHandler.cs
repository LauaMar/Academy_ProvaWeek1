using Academy_ProvaWeek1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_ProvaWeek1.Handler_Approvazione
{
    public class CEOHandler: AbstractHandler
    {
        public override string Handle(Spesa spesa)
        {
            if (spesa.Importo > 1000 && spesa.Importo <= 2500)
            {
                spesa.Approvata = true;
                spesa.LvlApprovazione = "CEO";
                return "APPROVATA dal CEO";
            }
            return base.Handle(spesa);
        }
    }
}
