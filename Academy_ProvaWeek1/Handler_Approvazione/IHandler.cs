using Academy_ProvaWeek1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_ProvaWeek1.Handler_Approvazione
{
   public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        string Handle(Spesa spesa);
    }
}
