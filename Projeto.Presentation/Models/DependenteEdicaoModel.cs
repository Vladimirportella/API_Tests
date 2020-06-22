using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Models
{
    public class DependenteEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do dependente.")]
        public int IdDependente { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do dependente.")]
        public string Nome { get; set; }

        [MaxLength(1, ErrorMessage = "Informe somente {1} caractere.")]
        [Required(ErrorMessage = "Por favor, informe o sexo do dependente.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do dependente.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do cliente.")]
        public int IdCliente { get; set; }
    }
}
