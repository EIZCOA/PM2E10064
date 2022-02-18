using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E10064.Controlador;
using System.IO;

namespace PM2E10064
{
    public partial class App : Application
    {

        //Inicializo mi DB

        static ExamenDB basedatos;

        //Verifico existencia de mi BD en esta APP

        public static ExamenDB BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new ExamenDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ExamenDB.db3"));
                }
                return basedatos;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new PM2E10064.MainPage());
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
