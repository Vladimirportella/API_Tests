using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Dependente
    {
        public int IdDependente { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
