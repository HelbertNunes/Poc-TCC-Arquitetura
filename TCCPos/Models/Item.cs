using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCPos.Data
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set;}
        public float Peso { get; set; }
        public float Valor { get; set; }
    }
}
