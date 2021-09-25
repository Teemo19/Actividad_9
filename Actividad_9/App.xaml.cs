using System;
using System.Collections.Generic;
using Actividad_9.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Actividad_9
{
    public partial class App : Application
    {

        public static List<Persona> Personas { get; set; }
        public App()
        {
            InitializeComponent();
            Personas = new List<Persona>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
