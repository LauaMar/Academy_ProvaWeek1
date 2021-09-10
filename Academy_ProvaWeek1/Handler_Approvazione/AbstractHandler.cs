using Academy_ProvaWeek1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_ProvaWeek1.Handler_Approvazione
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public virtual string Handle(Spesa spesa)
        {
            if(_nextHandler!=null)
            {
                return _nextHandler.Handle(spesa);
            }
            return "RESPINTA";
        }


        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return _nextHandler;
        }
    }
}
