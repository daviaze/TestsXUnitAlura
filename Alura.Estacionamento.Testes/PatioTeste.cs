using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste : IDisposable
    {
        private Patio patio;
        public ITestOutputHelper PatioConsoleTeste;

        public PatioTeste(ITestOutputHelper _patioConsoleTeste)
        {
            PatioConsoleTeste = _patioConsoleTeste;
            PatioConsoleTeste.WriteLine("Construtor sendo chamado");
            patio = new Patio();
        }

        [Fact]
        public void TestaFaturamento()
        {
            //Arrange
            Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = "Davi Azevedo";
            veiculo.Placa = "ASD-9999";
            veiculo.Cor = "Amarelo";
            veiculo.Tipo = TipoVeiculo.Automovel;

            string placa = veiculo.Placa;
            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(placa);

            //Act
            double faturamento = patio.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Sandra", "GFA-5252", "Prata")]
        [InlineData("João", "TDA-5522", "Vermelho")]
        [InlineData("Junior", "SID-4224", "Preto")]
        [InlineData("Milena", "GIF-0924", "Verde")]

        public void TestaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor)
        {
            //Arrange
            Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Tipo = TipoVeiculo.Automovel;

            string placadocarro = veiculo.Placa;
            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(placa);

            //Act
            double faturamento = patio.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Milena", "GIF-0924", "Verde")]
        public void TestaPesquisaVeiculoPorPlaca(string proprietario, string placa, string cor)
        {

            //Arrange
            Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Tipo = TipoVeiculo.Automovel;

            string placadocarro = veiculo.Placa;
            patio.RegistrarEntradaVeiculo(veiculo);

            //Act
            Veiculo pesquisa = patio.PesquisaVeiculoPorPlaca(placa);

            //Assert
            Assert.Equal(placa, pesquisa.Placa);
        }

        public void Dispose()
        {
            PatioConsoleTeste.WriteLine("Dispose sendo chamado");
        }
    }
}
