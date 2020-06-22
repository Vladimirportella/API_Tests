using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        List<Cliente> ConsultarPorNome(string nome);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
    }
}
