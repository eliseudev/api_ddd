using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Dtos.Municipio
{
    public class MunicipioDto
    {
        public uint Id { get; set; }
        
        public string Nome { get; set; }

        public int CodIBGE { get; set; }

        [Required]
        public uint UFId { get; set; }
    }
}
