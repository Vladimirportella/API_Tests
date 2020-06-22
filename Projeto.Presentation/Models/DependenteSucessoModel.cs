using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Models
{
    public class DependenteSucessoModel
    {
        public string Mensagem { get; set; }

        public Dependente Dependente { get; set; }
    }
}
