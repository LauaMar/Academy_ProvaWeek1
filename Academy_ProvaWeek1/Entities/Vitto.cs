﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_ProvaWeek1.Entities
{
    public class Vitto : ICategoria
    {
        public void CalcolaRimborso(Spesa spesa)
        {
            spesa.ImportoRimborsato = spesa.Importo * 0.7;
        }
    }
}
