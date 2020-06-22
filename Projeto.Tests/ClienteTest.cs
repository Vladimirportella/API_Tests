using FluentAssertions;
using Newtonsoft.Json;
using Projeto.Domain.Entities;
using Projeto.Presentation.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto.Tests
{
    public class ClienteTest
    {
        private AppContext appContext;
        private string endpoint;

        public ClienteTest()
        {
            appContext = new AppContext();
            endpoint = "/api/Cliente";
        }

        [Fact]
        public async Task Cliente_Post_ReturnsOk()
        {
            var random = new Random();

            var model = new ClienteCadastroModel();
            model.Nome = "Vladimir Portella";
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Telefone = "981373216";
            model.Cpf = random.Next(99999999, 999999999).ToString();
            model.Email = $"vladimir{random.Next(99,9999)}@gmail.com";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            result.Mensagem.Should().Contain("Cliente cadastrado com sucesso");
            result.Cliente.Nome.Should().Equals(model.Nome);
            result.Cliente.DataNascimento.Should().Equals(model.DataNascimento);
            result.Cliente.Telefone.Should().Equals(model.Telefone);
            result.Cliente.Cpf.Should().Equals(model.Cpf);
            result.Cliente.Email.Should().Equals(model.Email);

        }


        [Fact]
        public async Task Cliente_Post_ReturnsBadRequest() 
        {
            var model = new ClienteCadastroModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                           Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Cliente_Put_ReturnsOk()
        {
            var random = new Random();

            var model = new ClienteCadastroModel();
            model.Nome = "Vladimir Portella";
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Telefone = "981373216";
            model.Cpf = random.Next(99999999, 999999999).ToString();
            model.Email = $"vladimir{random.Next(99, 9999)}@gmail.com";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var modelEdicao = new ClienteEdicaoModel();
            modelEdicao.IdCliente = result.Cliente.IdCliente;
            modelEdicao.Nome = "Vladimir Portella - Edição";
            modelEdicao.Telefone = result.Cliente.Telefone;
            modelEdicao.Cpf = result.Cliente.Cpf;
            modelEdicao.Email = result.Cliente.Email;
            modelEdicao.DataNascimento = result.Cliente.DataNascimento;

            var requestEdicao = new StringContent(JsonConvert.SerializeObject(modelEdicao),
                           Encoding.UTF8, "application/json");

            var responseEdicao = await appContext.Client.PutAsync(endpoint, requestEdicao);

            responseEdicao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultEdicao = ObterDadosSucesso(responseEdicao);

            resultEdicao.Mensagem.Should().Contain("Cliente atualizado com sucesso");
            resultEdicao.Cliente.Nome.Should().Equals(modelEdicao.Nome);

        }

        [Fact]
        public async Task Cliente_Put_ReturnsBadRequest()
        {
            var model = new ClienteEdicaoModel();

            var request = new StringContent(JsonConvert.SerializeObject(model),
                           Encoding.UTF8, "application/json");

            var response = await appContext.Client.PutAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Cliente_Delete_ReturnsOk()
        {
            var random = new Random();

            var model = new ClienteCadastroModel();
            model.Nome = "Vladimir Portella";
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Telefone = "981373216";
            model.Cpf = random.Next(99999999, 999999999).ToString();
            model.Email = $"vladimir{random.Next(99, 9999)}@gmail.com";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var responseExclusao = await appContext.Client
                                         .DeleteAsync(endpoint + "/" + result.Cliente.IdCliente);

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.OK);

            var resultExclusao = ObterDadosSucesso(responseExclusao);


            resultExclusao.Mensagem.Should().Contain("Cliente excluído com sucesso");
            resultExclusao.Cliente.Nome.Should().Equals(model.Nome);
            resultExclusao.Cliente.Telefone.Should().Equals(model.Telefone);
            resultExclusao.Cliente.Cpf.Should().Equals(model.Cpf);
            resultExclusao.Cliente.Email.Should().Equals(model.Email);
            resultExclusao.Cliente.DataNascimento.Should().Equals(model.DataNascimento);

        }

        [Fact]
        public async Task Cliente_Delete_ReturnsBadRequest()
        {
            var responseExclusao = await appContext.Client
                                       .DeleteAsync(endpoint + "/99999" );

            responseExclusao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Cliente_GetAll_ReturnsOk() 
        {
            var response = await appContext.Client.GetAsync(endpoint);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Cliente_GetById_ReturnsOk()
        {
            var random = new Random();

            var model = new ClienteCadastroModel();
            model.Nome = "Vladimir Portella";
            model.DataNascimento = new DateTime(1994, 10, 25);
            model.Telefone = "981373216";
            model.Cpf = random.Next(99999999, 999999999).ToString();
            model.Email = $"vladimir{random.Next(99, 9999)}@gmail.com";

            var request = new StringContent(JsonConvert.SerializeObject(model),
                            Encoding.UTF8, "application/json");

            var response = await appContext.Client.PostAsync(endpoint, request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = ObterDadosSucesso(response);

            var responseConsulta = await appContext.Client
                                         .GetAsync(endpoint + "/" + result.Cliente.IdCliente);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Cliente_GetById_ReturnsBadRequest()
        {
            var response = await appContext.Client
                                       .DeleteAsync(endpoint + "/99999");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    
        private ClienteSucessoModel ObterDadosSucesso(HttpResponseMessage response) 
        {
            var result = string.Empty;
            using(var content = response.Content) 
            {
                var r = content.ReadAsStringAsync();
                result += r.Result;
            }

            return JsonConvert.DeserializeObject<ClienteSucessoModel>(result);
        }
    }
}
