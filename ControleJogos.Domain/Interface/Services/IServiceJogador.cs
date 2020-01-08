using ControleJogos.Domain.Arguments.Jogador;
using ControleJogos.Domain.Interface.Arguments;
using System.Collections.Generic;

namespace ControleJogos.Domain.Interface.Services
{
    public interface IServiceJogador: IResponse
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);
        AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request);
        AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request);
        IEnumerable<JogadorResponse> ListarJogador();
    }
}
