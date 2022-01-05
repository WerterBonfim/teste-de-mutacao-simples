namespace ExemploTesteMutacao
{
    public class Jokenpo
    {
        private readonly string _nomeDoJogador1;
        private readonly string _nomeDoJogador2;
        private string _vencedorJogada;
        

        public void RegistraJogada(Jogada jogador1, Jogada jogador2)
        {
            var resultado = new AvaliadorJogada(jogador1, jogador2).ObterJogadaVencedora();

            if ((byte)resultado == (byte)jogador1)
            {
                _vencedorJogada = _nomeDoJogador1;
                return;
            }

            if ((byte)resultado == (byte)jogador2)
            {
                _vencedorJogada = _nomeDoJogador2;
                return;
            }

            _vencedorJogada = "Empate";
        }

        public string ObterGanhador() => _vencedorJogada;
        

        public Jokenpo(string nomeDoJogador1, string nomeDoJogador2)
        {
            _nomeDoJogador1 = nomeDoJogador1;
            _nomeDoJogador2 = nomeDoJogador2;
        }

        public struct AvaliadorJogada
        {
            private readonly Jogada _jogada1;
            private readonly Jogada _jogada2;

            public AvaliadorJogada(Jogada jogada1, Jogada jogada2)
            {
                _jogada1 = jogada1;
                _jogada2 = jogada2;
            }

            public Resultado ObterJogadaVencedora()
            {
                if (_jogada1 == Jogada.Pedra)
                {
                    if (_jogada2 == Jogada.Papel)
                        return Resultado.Papel;

                    if (_jogada2 == Jogada.Tesoura)
                        return Resultado.Pedra;

                    if (_jogada2 == Jogada.Pedra)
                        return Resultado.Empate;
                }


                if (_jogada1 == Jogada.Papel)
                {
                    if (_jogada2 == Jogada.Papel)
                        return Resultado.Empate;

                    if (_jogada2 == Jogada.Tesoura)
                        return Resultado.Tesoura;

                    if (_jogada2 == Jogada.Pedra)
                        return Resultado.Papel;
                }

                if (_jogada2 == Jogada.Papel)
                    return Resultado.Tesoura;

                if (_jogada2 == Jogada.Tesoura)
                    return Resultado.Empate;

                if (_jogada2 == Jogada.Pedra)
                    return Resultado.Pedra;


                throw new InvalidOperationException();

            }
        }

    }


    public enum Jogada : byte
    {
        Pedra,
        Papel,
        Tesoura
    }

    public enum Resultado : byte
    {
        Pedra,
        Papel,
        Tesoura,
        Empate
    }
}
