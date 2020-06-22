using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
        List<T> Consultar();
        T ObterPorId(int id);
    }
}
