using Newtonsoft.Json;
using PruebDennisOcana.Apis;
using PruebDennisOcana.ViewModels;
using System.Net;

namespace PruebDennisOcana.Views;

public partial class AddUpdateImage : ContentPage
{
    public AddUpdateImage(AddupdateImageModel viewmodel)
    {
        InitializeComponent();
        this.BindingContext = viewmodel;


    }

    public void Frase_and_Image(object sender, EventArgs e)
    {
        WebRequest request1 = WebRequest.Create("https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&camera=fhaz&api_key=DEMO_KEY");
        request1.Headers.Add("Accept", "application/json");
        WebResponse response1 = request1.GetResponse();
        var client1 = new HttpClient();
        using (Stream dataStream = response1.GetResponseStream())
        {
            StreamReader reader1 = new StreamReader(dataStream);
            string responseFromServer1 = reader1.ReadToEnd();
            responseFromServer1 = responseFromServer1.Trim();
            var resultado1 = JsonConvert.DeserializeObject<Rootobject>(responseFromServer1);
            string imagen = resultado1.photos[1].img_src;
            label.Text = imagen;
            imageNasa.Source = imagen;
            src.Text = imagen;
        }

    }
}