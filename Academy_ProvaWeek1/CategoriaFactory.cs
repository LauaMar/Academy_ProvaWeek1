using Academy_ProvaWeek1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_ProvaWeek1
{
    public class CategoriaFactory
    {
        public Spesa CurrSpesa { get; set; }

        public CategoriaFactory()
        {

        }
        public CategoriaFactory(Spesa spesa)
        {
            CurrSpesa = spesa;
        }

        public ICategoria CatRimborso()
        {
            ICategoria categoria = null;
            switch (CurrSpesa.Categoria)
            {
                case Categoria.Viaggio:
                    categoria = new Viaggio();
                    break;
                case Categoria.Alloggio:
                    categoria = new Alloggio();
                    break;
                case Categoria.Vitto:
                    categoria = new Vitto();
                    break;
                case Categoria.Altro:
                    categoria = new Altro();
                    break;
            }

            return categoria;
        }
    }
}
