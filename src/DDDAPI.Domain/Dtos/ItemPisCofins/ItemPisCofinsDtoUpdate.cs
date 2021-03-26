using System;
using System.ComponentModel.DataAnnotations;

namespace DDDAPI.Domain.Dtos.ItemPisCofins
{
    public class ItemPisCofinsDtoUpdate
    {
        public string CST { get; set; }

        public string CodigoReceita { get; set; }

        public double PPisCumulativo { get; set; }

        public double PCofinsCumulativo { get; set; }

        public string PPisCofinsCumulativo_FundamentoLegal { get; set; }

        public double PPisNaoCumulativo { get; set; }

        public double PCofinsNaoCumulativo { get; set; }

        public string PPisCofinsNaoCumulativo_FundamentoLegal { get; set; }

        public DateTime DataEdicao { get; set; }

        public uint UsuarioEdicao_codigo { get; set; }
    }
}
