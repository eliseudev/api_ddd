using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDAPI.Domain.Entities
{
    public class ItemPisCofinsEntity
    {
        public uint Item_codigo { get; set; }

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
        
        public virtual ItemEntity Item { get; set; }
    }
}
