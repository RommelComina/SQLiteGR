﻿using SQLite;
using SQLiteJossuePalacios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteJossuePalacios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DatosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
                _conn.InsertAsync(DatosRegistro);
                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtContrasena.Text = "";
                DisplayAlert("Alerta", "Ingreso Satisfactorio", "Ok");
            }
            catch (Exception ex)
            {

            }
        }
    }
}