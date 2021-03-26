using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Dtos.UF
{
    public class UFDto
    {
        public uint Id { get; set; }
        
        public string Sigla { get; set; }
        
        public string Nome { get; set; }
    }
}
