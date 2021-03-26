using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Entities
{
    public class UsuarioAPIEntity
    {
        [Key]        
        public string CNPJ { get; set; }
        
        public string Token { get; set; }
        
        public string UF { get; set; }
        
        public bool Dados { get; set; }
        
        public bool Imagens { get; set; }
        
        public string Senha { get; set; }
        
        public bool UsaSenha { get; set; }
        
        public bool Ativo { get; set; }

    }
}
