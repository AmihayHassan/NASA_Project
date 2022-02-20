using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_DAL
{

    /// <summary>
    /// To reset the db. Avoid mistakes when changing the model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NasaDBlInitializer<T> : DropCreateDatabaseAlways<NasaContext>
    {
        public override void InitializeDatabase(NasaContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        protected override void Seed(NasaContext context)
        {
            base.Seed(context);
        }
    }
}

