using SQLite;
using SQLiteJossuePalacios.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteJossuePalacios
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Estudiante> _tabalEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var Resultado = await _conn.Table<Estudiante>().ToListAsync();
            _tabalEstudiante = new ObservableCollection<Estudiante>(Resultado);
            ListaUsuarios.ItemsSource = _tabalEstudiante;
            base.OnAppearing();

        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(ID));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}