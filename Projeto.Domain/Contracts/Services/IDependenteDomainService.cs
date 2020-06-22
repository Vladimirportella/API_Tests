using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IDependenteDomainService
    {
        void CadastrarDependente(Dependente dependente);
        void AtualizarDependente(Dependente dependente);
        void ExcluirDependente(Dependente dependente);
        List<Dependente> ConsultarTodos();
        Dependente ObterPorId(int id);
    }
}
