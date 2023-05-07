using ApiHospitalPractica.Models;
using ApiHospitalPractica.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

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

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Hospital>> PerfilHospital()
        {
            //DEBEMOS BUSCAR EL CLAIM DEL EMPLEADO
            Claim claim = HttpContext.User.Claims
                .SingleOrDefault(x => x.Type == "UserData");
            string jsonHospital =
                claim.Value;
            Hospital Hospital = JsonConvert.DeserializeObject<Hospital>
                (jsonHospital);
            return Hospital;
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
            await this.repo.InsertHospitalAsync(hospital.Hospital_cod, hospital.Nombre, hospital.Direccion, hospital.Telelfono, hospital.Num_cama, hospital.Imagen);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateHospital(Hospital hospital)
        {
            await this.repo.UpdateHospital(hospital.Hospital_cod, hospital.Nombre, hospital.Direccion, hospital.Telelfono, hospital.Num_cama, hospital.Imagen);
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
