using AutoMapper;
using MascotasApiBE.Data.DTO;
using MascotasApiBE.Models;
using MascotasApiBE.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MascotasApiBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IMascotaRepository _mascotaRepository;
        public MascotaController(IMapper mapper, IMascotaRepository mascotaRepository)
        {           
            _mapper = mapper;
            _mascotaRepository = mascotaRepository;
        }
        
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> obtenerListMascota()
        {
            try
            {
                var lstMascotas = await _mascotaRepository.obtenerListMascotas();
                var lstMascotasDTO = _mapper.Map<IEnumerable<MascotasDTO>>(lstMascotas);
                return Ok(lstMascotasDTO);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> obtenerMascota( int id)
        {
            try
            {
                var mascota = await _mascotaRepository.obtenerMascota(id);
                if(mascota == null)
                {
                    return NotFound();
                }
                var mascotaDTO = _mapper.Map<MascotasDTO>(mascota);
                return Ok(mascotaDTO);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> eliminarMascota(int id)
        {
            try
            {
                var mascota = await _mascotaRepository.obtenerMascota(id);
                if(mascota == null)
                {
                    return NotFound();
                }
                await _mascotaRepository.eliminarMascota(mascota);
                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> guardarMascota(MascotasDTO mascotaDTO)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDTO);
                
                mascota.FechaRegistro = DateTime.Now;
                mascota = await _mascotaRepository.guardarMascota(mascota);
                var mascotaItemDTO = _mapper.Map<MascotasDTO>(mascota);
                return CreatedAtAction("obtenerMascota", new {id = mascotaItemDTO.IdMascota}, mascotaItemDTO);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);              
            }
        }
        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> editarMascota(int id, MascotasDTO mascotaDTO)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDTO);
                
                if(id != mascota.IdMascota)
                {
                    return BadRequest();
                }
                var mascotaItem = await _mascotaRepository.obtenerMascota(id);
                if(mascotaItem == null)
                {
                    return NotFound();
                }
                await _mascotaRepository.editarMascota(mascota);
                return NoContent();

            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
