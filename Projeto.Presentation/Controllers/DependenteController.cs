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
    public class DependenteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(DependenteCadastroModel model, [FromServices] IDependenteDomainService dependenteDomainService)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dependente = new Dependente();
                    dependente.Nome = model.Nome;
                    dependente.DataNascimento = model.DataNascimento;
                    dependente.IdCliente = model.IdCliente;
                    dependente.Sexo = model.Sexo;

                    dependenteDomainService.CadastrarDependente(dependente);

                    var result = new DependenteSucessoModel();
                    result.Mensagem = "Dependente cadastrado com sucesso";
                    result.Dependente = dependente;

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
        public IActionResult Put(DependenteEdicaoModel model, [FromServices] IDependenteDomainService dependenteDomainService)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dependente = dependenteDomainService.ObterPorId(model.IdDependente);

                    if (dependente != null)
                    {
                        dependente.Nome = model.Nome;
                        dependente.DataNascimento = model.DataNascimento;
                        dependente.IdCliente = model.IdCliente;
                        dependente.Sexo = model.Sexo;

                        dependenteDomainService.AtualizarDependente(dependente);

                        var result = new DependenteSucessoModel();
                        result.Mensagem = "Dependente atualizado com sucesso";
                        result.Dependente = dependente;

                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest("dependente não encontrado");
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
        public IActionResult Delete(int id, [FromServices] IDependenteDomainService dependenteDomainService)
        {
            try
            {
                var dependente = dependenteDomainService.ObterPorId(id);
                if (dependente != null)
                {
                    dependenteDomainService.ExcluirDependente(dependente);

                    var result = new DependenteSucessoModel();
                    result.Mensagem = "Dependente excluído com sucesso";
                    result.Dependente = dependente;

                    return Ok(result);
                }
                else
                {
                    return BadRequest("Dependente não encontrado");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IDependenteDomainService dependenteDomainService)
        {
            try
            {
                return Ok(dependenteDomainService.ConsultarTodos());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromServices] IDependenteDomainService dependenteDomainService)
        {
            try
            {
                var dependente = dependenteDomainService.ObterPorId(id);
                if (dependente != null)
                {
                    return Ok(dependente);
                }
                else
                {
                    return BadRequest("Dependente não encontrado.");
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}