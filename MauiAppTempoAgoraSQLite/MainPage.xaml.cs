using System.Diagnostics;
using MauiAppTempoAgoraSQLite.Models;
using MauiAppTempoAgoraSQLite.Services;
namespace MauiAppTempoAgoraSQLite
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private async void GetCidade(double lat, double lon)
        {
            try
            {
                IEnumerable<Placemark> places = await Geocoding.Default.GetPlacemarksAsync(lat, lon);

                Placemark? place = places.FirstOrDefault();

                if (place != null)
                {
                    txt_cidade.Text = place.Locality;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro: Obtenção do nome da Cidade", ex.Message, "OK");
            }

        }


        private async void Previsao_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"Nascer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.sunset} \n" +
                                         $"Temp Máx: {t.temp_max} \n" +
                                         $"Temp Min: {t.temp_min} \n";

                        lbl_res.Text = dados_previsao;

                        await App.Db.Insert(t);

                    }
                    else
                    {

                        lbl_res.Text = "Sem dados de Previsão";
                    }// fecha if t=null
                }
                else
                {
                    lbl_res.Text = "Preencha a cidade.";
                }// fecha if string is null or empty
            }
            catch (Exception ex)
            {
                Debug.WriteLine("-------------------------------------------------");
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine("-------------------------------------------------");

                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }

}

}
