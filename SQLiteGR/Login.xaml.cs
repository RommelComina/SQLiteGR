using SQLite;
using SQLiteJossuePalacios.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteJossuePalacios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();

        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where usuario= ? and contrasena = ? ", usuario, contrasena);

        } 


        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());

        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasepath);

                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsusario.Text, txtContrasena.Text);
                if(resultado.Count()>0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Datos erroneos", "Ok");
                }
            }
            catch(Exception ex)
            {

            }

        }
    }
}