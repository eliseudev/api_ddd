using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Dtos.Login
{
    public class LoginDto
    {
        [Required (ErrorMessage = "O CNPJ é um campo obrigatório")]
        [MinLength(14, ErrorMessage = "O CNPJ deve ter {1} caracteres")]
        [MaxLength(14, ErrorMessage = "O CNPJ deve ter {1} caracteres.")]
        public string CNPJ { get; set; }
    }
}
