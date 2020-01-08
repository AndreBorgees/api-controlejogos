using ControleJogos.Domain.Arguments.Plataforma;
using ControleJogos.Domain.Interface.Arguments;

namespace ControleJogos.Domain.Interface.Services
{
    public interface IServicePlataforma: IResponse
    {
        AdicionarPlataformaResponse AdicionarPlataforma(AdicionarPlataformaRequest request);
    }
}
