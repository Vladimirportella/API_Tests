using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class DependenteDomainService : IDependenteDomainService
    {
        private IDependenteRepository dependenteRepository;

        public DependenteDomainService(IDependenteRepository dependenteRepository)
        {
            this.dependenteRepository = dependenteRepository;
        }

        public void AtualizarDependente(Dependente dependente)
        {
            dependenteRepository.Alterar(dependente);
        }

        public void CadastrarDependente(Dependente dependente)
        {
            dependenteRepository.Inserir(dependente);
        }

        public List<Dependente> ConsultarTodos()
        {
            return dependenteRepository.Consultar();
        }

        public void ExcluirDependente(Dependente dependente)
        {
            dependenteRepository.Excluir(dependente);
        }

        public Dependente ObterPorId(int id)
        {
            return dependenteRepository.ObterPorId(id);
        }
    }
}
