using AutoMapper;
using MascotasApiBE.Data.DTO;

namespace MascotasApiBE.Models.Profiles
{
    public class MascotasProfiles : Profile
    {
        public MascotasProfiles()
        {
            CreateMap<Mascota, MascotasDTO>();
            CreateMap<MascotasDTO, Mascota>();

        }
    }
}
