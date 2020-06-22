using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Models
{
    public class ClienteCadastroModel
    {
        [Required(ErrorMessage = "Por favor, infome o nome do cliente.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, infome o email do cliente.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, infome a data de nascimento do cliente.")]
        public DateTime DataNascimento { get; set; }

        [MaxLength(11,ErrorMessage ="Por favor, informe exatamente {1} dígitos numérios.")]
        [Required(ErrorMessage = "Por favor, infome o cpf do cliente.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, infome o telefone do cliente.")]
        public string Telefone { get; set; }
    }
}
