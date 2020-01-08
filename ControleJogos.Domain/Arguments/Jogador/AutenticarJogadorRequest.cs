﻿using ControleJogos.Domain.Interface.Arguments;

namespace ControleJogos.Domain.Arguments.Jogador
{
    public class AutenticarJogadorRequest: IRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
