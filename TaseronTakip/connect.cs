using System;
using System.Collections.Generic;
using System.Text;

namespace TaseronTakip
{
    public class connect : IDisposable
    {
        public static string connectroad = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Veritabani\\Data.mdb;Jet OLEDB:Database Password=admin_taseron;";
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
