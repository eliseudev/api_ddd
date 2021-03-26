using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Entities
{
    public class CEPEntity
    {
        [Key]
        public uint Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(60)]
        public string Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        /* Quando estamos referenciando fica o nome da classe seguido da Key */
        [Required]
        public uint MunicipioId { get; set; }

        public MunicipioEntity Municipio { get; set; }
    }
}
