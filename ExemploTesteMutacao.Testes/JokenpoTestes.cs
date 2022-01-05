using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;

namespace ExemploTesteMutacao.Testes
{
    public class JokenpoTestes
    {
        

        public static IEnumerable<object[]> JogadasJogador1 =>
            new List<object[]>
            {
                new object[] { Jogada.Pedra, Jogada.Tesoura },
                new object[] { Jogada.Papel, Jogada.Pedra },
                new object[] { Jogada.Tesoura, Jogada.Papel },
            };


        [Theory]
        [Trait("Jogo", "Jogador 1 ganha todas as jogadas")]
        [MemberData(nameof(JogadasJogador1))]
        public void Jogador1DeveGanharTodasAsJogadas(Jogada jogadaJogador1, Jogada jogadaJogador2)
        {
            var jokenpo = new Jokenpo("Fulano", "Ciclano");

            jokenpo.RegistraJogada(jogadaJogador1, jogadaJogador2);

            var ganhador = jokenpo.ObterGanhador();

            ganhador.Should().Be("Fulano");
        }


        public static IEnumerable<object[]> JogadasJogador2 =>
            new List<object[]>
            {
                new object[] { Jogada.Pedra, Jogada.Papel },
                new object[] { Jogada.Papel, Jogada.Tesoura },
                new object[] { Jogada.Tesoura, Jogada.Pedra },
            };

        [Theory]
        [Trait("Jogo", "Jogador 2 ganha todas as jogadas")]
        [MemberData(nameof(JogadasJogador2))]
        public void Jogador2DeveGanharTodasAsJogadas(Jogada jogadaJogador1, Jogada jogadaJogador2)
        {
            var jokenpo = new Jokenpo("Fulano", "Ciclano");

            jokenpo.RegistraJogada(jogadaJogador1, jogadaJogador2);

            var ganhador = jokenpo.ObterGanhador();

            ganhador.Should().Be("Ciclano");
        }


        public static IEnumerable<object[]> JogadasDeEmpate =>
            new List<object[]>
            {
                new object[] { Jogada.Pedra, Jogada.Pedra },
                new object[] { Jogada.Papel, Jogada.Papel },
                new object[] { Jogada.Tesoura, Jogada.Tesoura },
            };

        [Theory]
        [Trait("Jogo", "Jogadas de empate")]
        [MemberData(nameof(JogadasDeEmpate))]
        public void TodasAsJogadasDevemDarEmpate(Jogada jogadaJogador1, Jogada jogadaJogador2)
        {
            var jokenpo = new Jokenpo("Fulano", "Ciclano");

            jokenpo.RegistraJogada(jogadaJogador1, jogadaJogador2);

            var ganhador = jokenpo.ObterGanhador();

            ganhador.Should().Be("Empate");
        }


        [Fact]
        [Trait("Jogo", "Avaliador de jogada")]
        public void AvaliadorJogadaDeveNotificarPedraComoVencedor()
        {
            var jogadaVencedora = new Jokenpo.AvaliadorJogada(Jogada.Pedra, Jogada.Tesoura).ObterJogadaVencedora();
            jogadaVencedora.Should().Be(Resultado.Pedra);
        }

        [Fact]
        [Trait("Jogo", "Avaliador de jogada")]
        public void AvaliadorJogadaDeveNotificarPapelComoVencedor()
        {
            var jogadaVencedora = new Jokenpo.AvaliadorJogada(Jogada.Pedra, Jogada.Papel).ObterJogadaVencedora();
            jogadaVencedora.Should().Be(Resultado.Papel);
        }

        [Fact]
        [Trait("Jogo", "Avaliador de jogada")]
        public void AvaliadorJogadaDeveNotificarTesouraComoVencedor()
        {
            var jogadaVencedora = new Jokenpo.AvaliadorJogada(Jogada.Tesoura, Jogada.Papel).ObterJogadaVencedora();
            jogadaVencedora.Should().Be(Resultado.Tesoura);
        }

        [Fact]
        [Trait("Jogo", "Avaliador de jogada")]
        public void AvaliadorJogadaDeveNotificarUmEmpate()
        {
            var jogadaVencedora = new Jokenpo.AvaliadorJogada(Jogada.Pedra, Jogada.Pedra).ObterJogadaVencedora();
            jogadaVencedora.Should().Be(Resultado.Empate);
        }

        [Fact]
        [Trait("Jogo", "Avaliador de jogada")]
        public void DeveNotificarUmaException()
        {

            var jogada = Enum.Parse<Jogada>("5");
            
            Action act = () => new Jokenpo.AvaliadorJogada(jogada, jogada).ObterJogadaVencedora();

            act.Should().Throw<InvalidOperationException>();
        }


    }
}