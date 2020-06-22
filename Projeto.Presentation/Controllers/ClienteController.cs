using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model, [FromServices] IClienteDomainService clienteDomainService)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = new Cliente();
                    cliente.Nome = model.Nome;
                    cliente.Email = model.Email;
                    cliente.Cpf = model.Cpf;
                    cliente.DataNascimento = model.DataNascimento;
                    cliente.Telefone = model.Telefone;
                    cliente.DataCadastro = DateTime.Now;

                    clienteDomainService.CadastrarCliente(cliente);

                    var result = new ClienteSucessoModel();
                    result.Mensagem = "Cliente cadastrado com sucesso";
                    result.Cliente = cliente;

                    return Ok(result);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model, [FromServices] IClienteDomainService clienteDomainService)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = clienteDomainService.ObterPorId(model.IdCliente);

                    if (cliente != null)
                    {
                        cliente.Nome = model.Nome;
                        cliente.Email = model.Email;
                        cliente.Cpf = model.Cpf;
                        cliente.Telefone = model.Telefone;
                        cliente.DataNascimento = model.DataNascimento;

                        clienteDomainService.AtualizarCliente(cliente);

                        var result = new ClienteSucessoModel();
                        result.Mensagem = "Cliente atualizado com sucesso";
                        result.Cliente = cliente;

                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest("Cliente não encontrado");
                    }
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IClienteDomainService clienteDomainService)
        {
            try
            {
                var cliente = clienteDomainService.ObterPorId(id);
                if (cliente != null)
                {
                    clienteDomainService.ExcluirCliente(cliente);

                    var result = new ClienteSucessoModel();
                    result.Mensagem = "Cliente excluído com sucesso";
                    result.Cliente = cliente;

                    return Ok(result);
                }
                else
                {
                    return BadRequest("Cliente não encontrado");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IClienteDomainService clienteDomainService)
        {
            try
            {
                return Ok(clienteDomainService.ConsultarTodos());  
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromServices] IClienteDomainService clienteDomainService)
        {
            try
            {
                var cliente = clienteDomainService.ObterPorId(id);
                if (cliente != null)
                {
                    
                    return Ok(cliente);
                }
                else
                {
                    return BadRequest("Cliente não encontrado");
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}