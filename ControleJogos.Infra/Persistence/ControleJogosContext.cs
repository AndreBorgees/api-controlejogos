using ControleJogos.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ControleJogos.Infra.Persistence
{
    public class ControleJogosContext : DbContext
    {
        //Construtor herdando a string de conexão
        public ControleJogosContext() : base("ControleJogosConnectionString")
        {
            //Desabilita proxy
            Configuration.ProxyCreationEnabled = false;

            //Traz objetos aninhados usando o intelisense
            Configuration.LazyLoadingEnabled = false;

        }

        //Nome usado pra poder acessas os dados da tabela
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Seta o Schema default
            //modelBuilder.HasDefaultSchema("Apoio");

            //Remove a pluralização automatica dos nomes da tabela que é feita em ingles
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            //Remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Seta para usar varchar ao invés de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("Varchar"));

            //Caso eu esqueça o tamanho do campo ele ira colocar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Mapeia as entidades, classe onde vai ter configurações diversas, realcionamentos valdidações e afins
            //modelBuilder.Configurations.Add(new JogadorMap());

            //Adiciona as entidades mapeadas automaticamente atraves do assembly
            #region Adicionado entidades mapeasdas - Automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(ControleJogosContext).Assembly);
            #endregion

            //Adiciona as entidades mapeadas automaticamente atraves do NameSpace
            #region Adiciona entidades mapeadas - Automaticamente via NameSpace
            //Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => type.Namespace == "controleJogos.Domain.Entities.Jogador")
            //    .ToList()
            //    .ForEach(type =>
            //    {
            //        dynamic instance = Activator.CreateInstance(type);
            //        modelBuilder.Configurations.Add(instance);
            //    });
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
