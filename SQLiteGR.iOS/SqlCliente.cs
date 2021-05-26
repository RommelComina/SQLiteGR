using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

namespace SQLiteJossuePalacios.iOS
{
    class SqlCliente : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}