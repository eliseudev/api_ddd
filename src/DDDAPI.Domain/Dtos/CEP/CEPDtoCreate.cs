using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Dtos.CEP
{
    public class CEPDtoCreate
    {
        [Required]
        public string CEP { get; set; }
        
        [Required]
        public string Logradouro { get; set; }
        
        [Required]
        public string Numero { get; set; }

        [Required]
        public uint MunicipioId { get; set; }
    }
}
