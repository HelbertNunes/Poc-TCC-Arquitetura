using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCPos.Models
{
    public class FolhaDePagamento
    {
        public Funcionario Colaborador { get; set; }
        public Guid Id { get; set; }
        public int MesReferente { get; set; }
        public float Valor { get; set; }
        public DateTime UltimaAlteracao { get; set; }

        public FolhaDePagamento()
        {

        }

        public bool EnviarParaContabilidade(FolhaDePagamento folhaDePagamento) { return true; }
    }
}
