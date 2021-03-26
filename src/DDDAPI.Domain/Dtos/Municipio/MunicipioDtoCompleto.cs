using DDDAPI.Domain.Dtos.UF;

namespace DDDAPI.Domain.Dtos.Municipio
{
    public class MunicipioDtoCompleto
    {        
        public uint Id { get; set; }
        
        public string Nome { get; set; }

        public int CodIBGE { get; set; }
        
        public uint UFId { get; set; }

        public UFDto UF { get; set; }
    }
}
