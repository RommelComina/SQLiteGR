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
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento(int id)
        {
            _conn = DependencyService.Get<Database>().GetConnection();
            IdSeleccionado = id;
            InitializeComponent();
        }
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE from Estudiante where Id= ?", id);
        }

        
        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, IdSeleccionado);
            }
            catch(Exception ex)
            {
                DisplayAlert("ALERTA", "ERROR" + ex.Message, "Ok");
            }
        }
        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre= ?, Usuario= ?," + "Contrasena = ? where Id= ?", nombre, usuario, contrasena, id);
        }



        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("ALERTA", "Se elimino correctamente", "Ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "Ok");
            }
        }
    }
}