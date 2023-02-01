using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebDennisOcana.Apis;

namespace PruebDennisOcana.Services
{
    public interface InterfazBDD
    {
        Task<List<Photo>> GetPhotoListOD();
        Task<int> AddPhotoOd(Photo foto);
        Task<int> DeletePhotoOD(Photo foto);
        Task<int> UpdatePhotoOD(Photo foto);
    }
}
