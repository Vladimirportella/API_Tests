using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository 
    {
        private DataContext dataContext;

        public ClienteRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;

        }
        public List<Cliente> ConsultarPorNome(string nome)
        {
                return dataContext.Cliente.Where(c => c.Nome.Contains(nome))
                                                 .OrderBy(c => c.Nome).ToList();
        }
        public Cliente ObterPorCpf(string cpf)
        {
            return dataContext.Cliente.Where(c => c.Cpf.Equals(cpf)).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return dataContext.Cliente.Where(c => c.Cpf.Equals(email)).FirstOrDefault();
        }
    }
}
