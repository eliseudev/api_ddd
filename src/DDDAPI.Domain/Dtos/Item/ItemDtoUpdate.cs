using System;
using System.ComponentModel.DataAnnotations;
using DDDAPI.Domain.Dtos.ItemPisCofins;

namespace DDDAPI.Domain.Dtos.Item
{
    public class ItemDtoUpdate
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

        public ItemPisCofinsDto PisCofins { get; set; }
    }
}
