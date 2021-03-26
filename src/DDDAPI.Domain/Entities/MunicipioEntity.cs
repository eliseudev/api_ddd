using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Entities
{
    public class MunicipioEntity
    {
        [Key]
        public uint Id { get; set; }

        public int CodIBGE { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        public uint UFId { get; set; }

        public UFEntity UF { get; set; }

        public IEnumerable<CEPEntity> CEPs { get; set; }
    }
}
