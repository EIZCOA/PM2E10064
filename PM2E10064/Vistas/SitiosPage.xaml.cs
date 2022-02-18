using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PM2E10064.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E10064.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SitiosPage : ContentPage
    {
        public SitiosPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //ListaPersonas.ItemsSource = await App.BaseDatos.listapersonas();

            var listasitios = await App.BaseDatos.listasitios();
            //Creamos un colleccion observable para que los cambios que se realizan en el modelo se reflejen de maner automatica
            //en la vista
            ObservableCollection<Sitios> observableCollectionFotos = new ObservableCollection<Sitios>();
            ListaSitios.ItemsSource = observableCollectionFotos;
            foreach (Sitios imagen in listasitios)
            {
                observableCollectionFotos.Add(imagen);
            }


        }

        private async void ListaSitios_ItemTapped_1(object sender, ItemTappedEventArgs e)
        {
            try
            {
                await DisplayAlert("Aviso", "Has dado clik en un sitio", "Ok");
                Sitios item = (Sitios)e.Item;
                var newpage = new Vistas.PageActualizaSitio();
                newpage.BindingContext = item;
                await Navigation.PushAsync(newpage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Aviso", ex.Message, "Ok");
            }
        }
    }
}