using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {

        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper _SaidaConsoleTeste)
        {
            SaidaConsoleTeste = _SaidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor sendo chamado");
            veiculo = new Veiculo();
        }
        //[Fact(DisplayName = "Teste 1�")]
        [Fact]
        //[Trait("Veiculo", "Acelerar")] -> Coloca uma flag no m�doto
        public void TestaVeiculoAcelerarComValor10()
        {
            //Arrange

            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        //[Fact(DisplayName = "Teste 2�")]
        [Fact]
        //[Trait("Veiculo", "Frear")] Coloca uma flag no m�doto
        public void TestaVeiculoFrearComValor10()
        {
            //Arrange

            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact (Skip = "Ainda n�o implementado, ignore")]
        public void TestaNomeProprietarioVeiculo()
        {

        }

        [Fact]
        public void TestaDadosVeiculo()
        {
            //Arrange
            Veiculo veiculo = new Veiculo()
            {
                Proprietario = "Davi Azevedo",
                Placa = "SAP-4443",
                Cor = "Dourado",
                Tipo = TipoVeiculo.Automovel,
                Modelo = "Slim"
            };

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Davi", dados);
        }

        /*[Fact]
        public void TestaExceptionNomePropriet�rioValidacao() //Testando exce��es
        {
            //Arrange
            string nome = "Da";
            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nome)
                );
        }*/

        [Fact]
        public void TestaExceptionMessagePlacaQuatroDigitos()
        {
            string placa = "SDAF-555";
            var mensagem = Assert.Throws<System.FormatException>(
                    () => new Veiculo().Placa = placa
                );

            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose sendo chamado");
        }
    }
}
