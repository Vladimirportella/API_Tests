using FluentAssertions;
using Newtonsoft.Json;
using Projeto.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto.Tests
{
    public class DependenteTest
    {
        private AppContext appContext;
        private string endpoint;

        public DependenteTest()
        {
            appContext = new AppContext();
            endpoint = "/api/Dependente";
        }

        [Fact]
        public async Task Dependente_Post_ReturnsOk()
        {
            var random = new Random();

            var model = new DependenteCadastroModel();
            model.Nome = "Vladimir Portella";
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Sexo = "M";
            model.IdCliente = 2;

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            result.Mensagem.Should().Contain("Dependente cadastrado com sucesso");
            result.Dependente.Nome.Should().Equals(model.Nome);
            result.Dependente.DataNascimento.Should().Equals(model.DataNascimento);
            result.Dependente.Sexo.Should().Equals(model.Sexo);
            result.Dependente.IdCliente.Should().Equals(model.IdCliente);
           
        }

        [Fact]
        public async Task Dependente_Post_ReturnsBadRequest()
        {       
    
            var model = new DependenteCadastroModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Dependente_Put_ReturnsOk()
        {
            var random = new Random();

            var model = new DependenteCadastroModel();
            model.Nome = "Vladimir Portella";
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Sexo = "M";
            model.IdCliente = 2;

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var modelEdicao = new DependenteEdicaoModel();
            modelEdicao.IdDependente = result.Dependente.IdDependente;
            modelEdicao.Nome = "Vladimir Portella - EDIÇÃO";
            modelEdicao.DataNascimento = result.Dependente.DataNascimento;
            modelEdicao.Sexo = result.Dependente.Sexo;
            modelEdicao.IdCliente = result.Dependente.IdCliente;

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                         Encoding.UTF8, "application/json");

            var responseEdicao = await appContext.Client.PutAsync(endpoint, requestEdicao);

            responseEdicao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultEdicao = ObterDadosSucesso(responseEdicao);

            resultEdicao.Mensagem.Should().Contain("Dependente atualizado com sucesso");
            resultEdicao.Dependente.Nome.Should().Equals(modelEdicao.Nome);

        }

        [Fact]
        public async Task Dependente_Put_ReturnsBadRequest()
        {

            var model = new DependenteEdicaoModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PutAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Dependente_Delete_ReturnsOk()
        {
            var random = new Random();

            var model = new DependenteCadastroModel();
            model.Nome = "Vladimir Portella";
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Sexo = "M";
            model.IdCliente = 2;

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var responseExlcusao = await appContext.Client
                                         .DeleteAsync(endpoint + "/" + result.Dependente.IdDependente);

            responseExlcusao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultExclusao = ObterDadosSucesso(responseExlcusao);

            resultExclusao.Mensagem.Should().Contain("Dependente excluído com sucesso");
            resultExclusao.Dependente.Nome.Should().Equals(model.Nome);
            resultExclusao.Dependente.DataNascimento.Should().Equals(model.DataNascimento);
            resultExclusao.Dependente.Sexo.Should().Equals(model.Sexo);
            resultExclusao.Dependente.IdCliente.Should().Equals(model.IdCliente);

        }

        [Fact]
        public async Task Dependente_Delete_ReturnsBadRequest()
        {

            var responseExclusao = await appContext.Client.DeleteAsync(endpoint + "/99999");

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Dependente_GetAll_ReturnsOk() 
        {
            var response = await appContext.Client.GetAsync(endpoint);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Dependente_GetById_ReturnsOk()
        {
            var random = new Random();

            var model = new DependenteCadastroModel();
            model.Nome = "Vladimir Portella";
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Sexo = "M";
            model.IdCliente = 2;

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);


            var responseConsulta = await appContext.Client
                                         .DeleteAsync(endpoint + "/" + result.Dependente.IdDependente);

            responseConsulta.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Dependente_GetById_ReturnsBadRequest()
        {
            var response = await appContext.Client.GetAsync(endpoint + "/99999");

            response.StatusCode.Should().NotBe(HttpStatusCode.OK);
        }


        private DependenteSucessoModel ObterDadosSucesso(HttpResponseMessage response)
        {
            var result = string.Empty;
            using (var content = response.Content)
            {
                var r = content.ReadAsStringAsync();
                result += r.Result;
            }

            return JsonConvert.DeserializeObject<DependenteSucessoModel>(result);
        }


    }
}
