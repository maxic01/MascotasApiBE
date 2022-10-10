using MascotasApiBE.Models;
using Microsoft.EntityFrameworkCore;

namespace MascotasApiBE.Repository
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly AplicationDbContext _context;
        public MascotaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task editarMascota(Mascota mascota)
        {
            var mascotaItem = await _context.Mascotas.FirstOrDefaultAsync(x => x.IdMascota == mascota.IdMascota);
            if(mascotaItem != null)
            {
                mascotaItem.Nombre = mascota.Nombre;
                mascotaItem.Raza = mascota.Raza;
                mascotaItem.Tipo = mascota.Tipo;
                mascotaItem.Peso = mascota.Peso;
                await _context.SaveChangesAsync();
            }            
        }

        public async Task eliminarMascota(Mascota mascota)
        {
            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
        }

        public async Task<Mascota> guardarMascota(Mascota mascota)
        {
            _context.Add(mascota);
            await _context.SaveChangesAsync();
            return mascota;
        }

        public async Task<List<Mascota>> obtenerListMascotas()
        {
           return await _context.Mascotas.ToListAsync();
        }

        public async Task<Mascota> obtenerMascota(int id)
        {
            return await _context.Mascotas.FindAsync(id);
        }

    }
}
