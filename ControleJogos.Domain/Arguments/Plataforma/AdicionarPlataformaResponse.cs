﻿using System;

namespace ControleJogos.Domain.Arguments.Plataforma
{
    public class AdicionarPlataformaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Mensagem { get; set; }
    }
}
