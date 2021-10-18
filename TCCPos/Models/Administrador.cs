using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCPos.Models
{
    public class Administrador
    {
        public Guid Id { get; set; }
        public List<Funcionario> Liderados { get; set; }
        public Administrador()
        {

        }

        public bool AdicionarLiderado(Guid id) { return true; }
        public bool RemoverLiderado(Guid id) { return true; }
    }
}
