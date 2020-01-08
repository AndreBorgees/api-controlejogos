using ControleJogos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ControleJogos.Domain.Interface.Repositories
{
    public interface IRepositoryJogador
    {
        Jogador AutenticarJogador(string email, string senha);
        Jogador AdicionarJogador(Jogador jogador);
        IEnumerable<Jogador> ListarJogador();
        Jogador ObterJogadorPorId(Guid Id);
        void AlterarJogador(Jogador jogador);
    }
}
