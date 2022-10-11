using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Juguetes.BL.Models;

namespace Juguetes.BL.Data
{
    public class JuguetesContext : DbContext
    {
        private static JuguetesContext juguetesContext = null;
        public JuguetesContext() : base("JuguetesContext")
        {

        }
        public DbSet<Productos> Producto { get; set; }

        public static JuguetesContext Create()
        {
            if (juguetesContext == null)
                juguetesContext = new JuguetesContext();

            return juguetesContext;
        }
    }
}
