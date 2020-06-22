using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IClienteDomainService
    {
        void CadastrarCliente(Cliente cliente);   
        void AtualizarCliente(Cliente cliente);   
        void ExcluirCliente(Cliente cliente);
        List<Cliente> ConsultarTodos();
        Cliente ObterPorId(int id);
        List<Cliente> ConsultarPorNome(string nome);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);

    }
}
