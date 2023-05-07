using ApiHospitalPractica.Data;
using ApiHospitalPractica.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ApiHospitalPractica.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }
        //get all hospitals
        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            return await this.context.Hospitales.ToListAsync();
        }

        //get only one hospital

        public async Task<Hospital> FindospitalAsync(int id)
        {
            return await this.context.Hospitales.FirstOrDefaultAsync(x => x.Hospital_cod == id);
        }

        //insert Hospital

        public async Task InsertHospitalAsync(int hos_cod, string nombre, string direccion, string telefono, int num_cam, string imagen)
        {
            Hospital hospital = new Hospital();
            hospital.Hospital_cod = hos_cod;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telelfono = telefono;
            hospital.Num_cama = num_cam;
            hospital.Imagen = imagen;
            await this.context.Hospitales.AddAsync(hospital);
            await this.context.SaveChangesAsync();
        }

        //modify hospital 

        public async Task UpdateHospital(int hos_cod, string nombre, string direccion, string telefono, int num_cam, string imagen)
        {
            Hospital hospital = await this.FindospitalAsync(hos_cod);
            hospital.Hospital_cod = hos_cod;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telelfono = telefono;
            hospital.Num_cama = num_cam;
            hospital.Imagen = imagen;
            await this.context.SaveChangesAsync();
        }

        //delete Hospital 

        public async Task DeleteHospital(int id)
        {
            Hospital hospital = await this.FindospitalAsync(id);
            this.context.Hospitales.Remove(hospital);
            await this.context.SaveChangesAsync();
        }


        public async Task<Hospital> ExisteHospitalAsync(string nombre, int hospcod)
        {
            return await this.context.Hospitales.FirstOrDefaultAsync(x => x.Nombre == nombre && x.Hospital_cod == hospcod);
        }

    }
}
