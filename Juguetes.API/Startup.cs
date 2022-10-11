using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Juguetes.BL.Data;

namespace Juguetes.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configura el db Context para usarlo como unica instancia por request
            app.CreatePerOwinContext(JuguetesContext.Create);
        }
    }
}
