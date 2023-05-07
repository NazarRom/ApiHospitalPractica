using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiHospitalPractica.Models
{
    [Table("Hospital")]
    public class Hospital
    {
        [Key]
        [Column("hospital_cod")]
        public int Hospital_cod { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Direccion")]
        public string Direccion { get; set; }
        [Column("Telefono")]
        public string Telelfono { get; set; }
        [Column("NUM_CAMA")]
        public int Num_cama { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
    }
}
