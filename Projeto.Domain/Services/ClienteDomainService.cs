using Projeto.Domain.Contracts.CrossCutting;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class ClienteDomainService : IClienteDomainService
    {
        private IClienteRepository clienteRepository;
        private IEmailMessage emailMessage;

        public ClienteDomainService(IClienteRepository clienteRepository, IEmailMessage emailMessage)
        {
            this.clienteRepository = clienteRepository;
            this.emailMessage = emailMessage;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            var clientePorCpf = clienteRepository.ObterPorCpf(cliente.Cpf); 

            if (clientePorCpf.Cpf != null && clientePorCpf.IdCliente != cliente.IdCliente)
            {
                throw new Exception("Erro, o CPF informado já encontra-se cadastrado.");
            }

            var clientePorEmail = clienteRepository.ObterPorEmail(cliente.Email);

            if (clientePorEmail != null && clientePorEmail.IdCliente != cliente.IdCliente)
            {
                throw new Exception("Erro, o email informado já encontra-se cadastrado.");
            }

            clienteRepository.Alterar(cliente);

            //var mailTo = cliente.Email;
            //var subject = "Cliente atualizado.";
            //var body = "";

            //emailMessage.SendMessage(mailTo, subject, body);
        }

        public void CadastrarCliente(Cliente cliente)
        {
            if (clienteRepository.ObterPorCpf(cliente.Cpf) != null)
            {
                throw new Exception("Erro, o CPF informado já encontra-se cadastrado.");
            }

            if (clienteRepository.ObterPorEmail(cliente.Email) != null)
            {
                throw new Exception("Erro, o email informado já encontra-se cadastrado.");
            }

            clienteRepository.Inserir(cliente);

            //var mailTo = cliente.Email;
            //var subject = "Bem vindo ao Sistema.";
            //var body = "";

            //emailMessage.SendMessage(mailTo, subject, body);
        }

        public List<Cliente> ConsultarPorNome(string nome)
        {
            return clienteRepository.ConsultarPorNome(nome);
        }

        public List<Cliente> ConsultarTodos()
        {
            return clienteRepository.Consultar();
        }

        public void ExcluirCliente(Cliente cliente)
        {

            clienteRepository.Excluir(cliente);

            //var mailTo = cliente.Email;
            //var subject = "Cliente excluído.";
            //var body = "";

            //emailMessage.SendMessage(mailTo, subject, body);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return clienteRepository.ObterPorEmail(email);
        }

        public Cliente ObterPorId(int id)
        {
            return clienteRepository.ObterPorId(id);
        }
    }
}
