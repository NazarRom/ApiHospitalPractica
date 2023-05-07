using ApiHospitalPractica.Models;
using ApiHospitalPractica.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHospitalPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private RepositoryHospital repo;
        public HospitalController(RepositoryHospital repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Hospital>>> GetHospitales()
        {
            return await this.repo.GetHospitalesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital>> Details(int id)
        {
            return await this.repo.FindospitalAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> InsertHospital(Hospital hospital)
        {
            await this.repo.InsertHospitalAsync(hospital.Hospital_cod, hospital.Nombre, hospital.Direccion, hospital.Telelfono, hospital.Num_cama);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHospital(Hospital hospital)
        {
            await this.repo.UpdateHospital(hospital.Hospital_cod, hospital.Nombre, hospital.Direccion, hospital.Telelfono, hospital.Num_cama);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHospital(int id)
        {
            await this.repo.DeleteHospital(id);
            return Ok();
        }
    }
}
