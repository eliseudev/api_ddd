using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Entities
{
    public class ItemEntity
    {
        public uint Codigo { get; set; }
        
        public string Descricao { get; set; }
        
        public string CodigoBarras { get; set; }
        
        public string NCM { get; set; }
        
        public string NCM_EX { get; set; }
        
        public string CEST { get; set; }

        public DateTime DataCadastro { get; set; }

        public uint UsuarioCadastro_codigo { get; set; }

        public DateTime DataEdicao { get; set; }

        public uint UsuarioEdicao_codigo { get; set; }

        public ItemPisCofinsEntity PisCofins { get; set; }

        public IEnumerable<ItemICMSEntity> ICMSs { get; set; }
    }
}
