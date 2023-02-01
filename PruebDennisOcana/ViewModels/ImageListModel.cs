using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebDennisOcana.Apis;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using PruebDennisOcana.Services;
using PruebDennisOcana.Views;

namespace PruebDennisOcana.ViewModels
{
    
        public partial class ImageListModel : ObservableObject
        {
            public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

            private readonly InterfazBDD _noteService;

            public ImageListModel(InterfazBDD phServ)
            {
                _noteService = phServ;
            }

            [ICommand]
            public async void GetPhotoListOD()
            {
                Photos.Clear();
                var PhotoList = await _noteService.GetPhotoListOD();
                if (PhotoList?.Count > 0)
                {
                    PhotoList = PhotoList.OrderBy(f => f.img_src).ToList();
                    foreach (var Photo in PhotoList)
                    {
                        Photos.Add(Photo);
                    }

                }
            }

            [ICommand]
            public async void AddUpdatePhotoOD()
            {
                await AppShell.Current.GoToAsync(nameof(AddUpdateImage));
            }

            [ICommand]
            public async void MostrarAccionOD(Photo photoModel)
            {
                var response = await AppShell.Current.DisplayActionSheet("Seleccione Opcion", "OK", null, "Editar", "Borrar");
                if (response == "Editar")
                {
                    var navParam = new Dictionary<string, object>
                {
                    { "PhotoDetail", photoModel }
                };
                    await AppShell.Current.GoToAsync(nameof(AddUpdateImage), navParam);
                }

                else if (response == "Borrar")
                {
                    var delResponse = await _noteService.DeletePhotoOD(photoModel);
                    if (delResponse > 0)
                    {
                        GetPhotoListOD();
                    }
                }
            }
        }
    
}
