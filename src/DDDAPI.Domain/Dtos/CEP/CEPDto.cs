using System.ComponentModel.DataAnnotations;
using DDDAPI.Domain.Dtos.Municipio;

namespace DDDAPI.Domain.Dtos.CEP
{
    public class CEPDto
    {
        public uint Id { get; set; }
        
        public string CEP { get; set; }
        
        public string Logradouro { get; set; }
        
        public string Numero { get; set; }

        public uint MunicipioId { get; set; }

        public MunicipioDtoCompleto Municipio { get; set; }
    }
}
