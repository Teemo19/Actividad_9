using Actividad_9.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;



namespace Actividad_9
{
    public partial class MainPage : ContentPage
    {
        public bool tapped { get; set; }
        public int index { get; set; }
   
        public MainPage()
        {
            InitializeComponent();
            tapped = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                DisplayAlert("Error", "El nombre no debe ser vacio", "Aceptar");
            }
            else
            {
                App.Personas.Add(new Persona { Nombre = txtNombre.Text, Correo = txtCorreo.Text, Telefono = txtTelefono.Text });
                lstPersonas.ItemsSource = null;
                lstPersonas.ItemsSource = App.Personas;
            }
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            if (tapped)
            {
                App.Personas[index].Nombre = txtNombre.Text;
                App.Personas[index].Correo = txtCorreo.Text;
                App.Personas[index].Telefono = txtTelefono.Text;
                lstPersonas.ItemsSource = null;
                lstPersonas.ItemsSource = App.Personas;
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (tapped)
            {
                App.Personas.RemoveAt(index);
                lstPersonas.ItemsSource = null;
                lstPersonas.ItemsSource = App.Personas;
                tapped = false;
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }
        }

        private void lstPersonas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var myItem = myListView.SelectedItem;
            index = App.Personas.IndexOf(myItem);
            txtNombre.Text  = App.Personas[index].Nombre;
            txtCorreo.Text = App.Personas[index].Correo;
            txtTelefono.Text = App.Personas[index].Telefono;
            tapped = true;
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
        }
}
}
