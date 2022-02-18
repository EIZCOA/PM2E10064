using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2E10064.Models;
using Plugin.Media;
using System.IO;

namespace PM2E10064
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        byte[] imgToSave;

        private async void add_Clicked(object sender, EventArgs e)
        {
            //Metodo para agregar los datos del sitio

            //Mapeo los datos de mis entrys con los de mi clase 
            var Sitio = new Sitios
            {
                latitud = "1,0005",//latitud.Text,
                longitud = "85533,-5656", //longitud.Text,
                descripcion = descri.Text,
                imagen = imgToSave
            };

            var resultado = await App.BaseDatos.SitioGuardar(Sitio);

            //Valido el resultado obtenido
            if (resultado != 0)
            {
                await DisplayAlert("Aviso", "Sitio ingresado exitosamente", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
            }

            await Navigation.PopAsync();

        }

        private async void list_Clicked(object sender, EventArgs e)
        {
            //Llamo mi listado de sitios
            var listado = new Vistas.SitiosPage();
            await Navigation.PushAsync(listado);
        }

        private void close_Clicked(object sender, EventArgs e)
        {

        }

        private async void btn_fotografiar_Clicked(object sender, EventArgs e)
        {
            var takepic = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "PhotoApp",
                Name = DateTime.Now.ToString() + "_Pic.jpg",
                SaveToAlbum = true
            });

            await DisplayAlert("Ubicacion de la foto: ", takepic.Path, "Ok");

            if (takepic != null)
            {
                imgToSave = null;
                MemoryStream memoryStream = new MemoryStream();

                takepic.GetStream().CopyTo(memoryStream);
                imgToSave = memoryStream.ToArray();

                img.Source = ImageSource.FromStream(() => { return takepic.GetStream(); });
            }

        }

        private byte[] GetImageBytes(Stream stream)
        {
            byte[] ImageBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                stream.CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }
    }
    
}
