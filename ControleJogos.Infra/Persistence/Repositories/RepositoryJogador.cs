using ControleJogos.Domain.Entities;
using ControleJogos.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleJogos.Infra.Persistence.Repositories
{
    public class RepositoryJogador: IRepositoryJogador
    {
        //Interagir com o banco de dados através do nosso context
        protected readonly ControleJogosContext _context;

        public RepositoryJogador(ControleJogosContext context)
        {
            _context = context;
        }

        public Jogador AdicionarJogador(Jogador jogador)
        {
            _context.Jogadores.Add(jogador);
            _context.SaveChanges();
            return jogador;
        }

        public void AlterarJogador(Jogador jogador)
        {
            throw new NotImplementedException();
        }

        public Jogador AutenticarJogador(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogador> ListarJogador()
        {
            return _context.Jogadores.ToList();
        }

        public Jogador ObterJogadorPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        //IQueryable permite eu montar minhas consultas personlizadas com varios parametros pra depois ir ao banco de dados e armazenar o retorno em memoria(Monto a query em tempo de execução sem ir ao banco)
        //AsNoTracking serve para não mapear o objeto. O entity possui uma estrutura para saber se você alterou o objeto, então em consultas normais que não envolvem edição, que é só jogar os dados na tela, utilizar ele otimiza as consultas
        //AsParallel permite a utilização de mais de um núcleo ou processador, caso a maquina tenha, na hora de uma consulta no banco de dados. Dependendo do tipo da consulta(mais pesadas), pois ele é um processo custoso, ele é indicado.
    }
}
