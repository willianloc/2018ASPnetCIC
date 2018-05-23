using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _2205Aula.Models.DAL
{
    public class MeuContexto :DbContext
    {
        public MeuContexto() : base("strConn")
        {
            //Database.SetInitializer<DropCreateDatabaseAlways>
            Database.SetInitializer<MeuContexto>(new DropCreateDatabaseIfModelChanges<MeuContexto>());
        }
        
        
    }
}