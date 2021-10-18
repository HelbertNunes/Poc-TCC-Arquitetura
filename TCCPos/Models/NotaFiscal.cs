using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCPos.Data;

namespace TCCPos.Models
{
    public class NotaFiscal
    {
        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public List<Item> Itens { get; set; }
        public float ValorTotal { get; set; }
        public DateTime DataEmissao { get; set; }

        public NotaFiscal()
        {

        }
        public bool EmitirNotaFiscal(NotaFiscal notaFiscal) { return true; }
        public bool Cancelar(Guid id) { return true; }
        public bool RemoveItem(int quantidade) { return true; }
        public bool AdicionaItem(int quantidade) { return true; }

    }
}
