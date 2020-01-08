using ControleJogos.Domain.Interface.Arguments;

namespace ControleJogos.Domain.Arguments.Jogador
{
    public class AdicionarJogadorRequest : IRequest
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
