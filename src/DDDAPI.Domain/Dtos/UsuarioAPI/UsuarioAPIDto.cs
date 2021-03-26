using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Dtos.UsuarioAPI
{
    public class UsuarioAPIDto
    {
        [Required (ErrorMessage = "O CNPJ é obrigatório")]    
        [MinLength(14, ErrorMessage = "O CNPJ deve ter {1} caracteres")] 
        [MaxLength(14, ErrorMessage = "O CNPJ deve ter {1} caracteres")]    
        public string CNPJ { get; set; }
        
        [Required (ErrorMessage = "A UF é obrigatório")]    
        [MinLength(2, ErrorMessage = "A UF deve ser informada com {1} caracteres")] 
        [MaxLength(2, ErrorMessage = "A UF deve ser informada com {1} caracteres")]    
        public string UF { get; set; }
        
        public bool Dados { get; set; }
        
        public bool Imagens { get; set; }
        
        public bool UsaSenha { get; set; }
        
        public bool Ativo { get; set; }
    }
}
