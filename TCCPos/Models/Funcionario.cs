using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCPos.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public Administrador Gestor { get; set; }
    }
}
