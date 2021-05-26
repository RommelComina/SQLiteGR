using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteJossuePalacios.Droid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]

namespace SQLiteJossuePalacios.Droid
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