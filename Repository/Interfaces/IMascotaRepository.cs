using MascotasApiBE.Models;

namespace MascotasApiBE.Repository
{
    public interface IMascotaRepository
    {
        Task<List<Mascota>> obtenerListMascotas();
        Task<Mascota> obtenerMascota(int id);
        Task eliminarMascota(Mascota mascota);
        Task<Mascota> guardarMascota(Mascota mascota);
        Task editarMascota(Mascota mascota);

    }
}
