using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Entities
{
    public class UFEntity
    {
        [Key]
        public uint Id { get; set; }
        
        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        public string Sigla { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        public IEnumerable<MunicipioEntity> Municipios { get; set; }

    }
}
