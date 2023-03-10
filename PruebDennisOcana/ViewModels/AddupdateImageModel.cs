using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using PruebDennisOcana.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebDennisOcana.Apis;
using System.Collections.ObjectModel;
using System.Net;

namespace PruebDennisOcana.ViewModels
{

    [QueryProperty(nameof(PhotoDetail), "PhotoDetail")]
    public partial class AddupdateImageModel : ObservableObject
    {
        [ObservableProperty]
        private Photo _PhotoDetail = new Photo();

        private readonly InterfazBDD photoService;
        public AddupdateImageModel(InterfazBDD OD)
        {
            this.photoService = OD;
        }

        [ICommand]
        public async void AddUpdatePhotoOD()
        {
            int response = -1;
            if (PhotoDetail.id > 0)
            {
                response = await photoService.UpdatePhotoOD(PhotoDetail);
            }
            else
            {
                response = await photoService.AddPhotoOd(new Apis.Photo
                {
                    img_src = PhotoDetail.img_src,
                    comentario = PhotoDetail.comentario,
                });
            }

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Comentario Guardado", "Registro guardado exitosamente", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("ERROR", "Algo fallo mientras se guardaba el registro", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }
    }
    
}
