using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {         
        [Required (ErrorMessage = "Informe o nome do município")] 
        [MaxLength(60, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código IBGE inválido")]
        public int CodIBGE { get; set; }
        
        [Required (ErrorMessage = "Informe o código do IBGE")]
        public uint UFId { get; set; }
    }
}
