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
    public class NasaDBlInitializer<T> : DropCreateDatabaseAlways<NasaDB>
    {
        public override void InitializeDatabase(NasaDB context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        protected override void Seed(NasaDB context)
        {
            base.Seed(context);
        }
    }
}

