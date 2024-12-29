using GerenciadorDeTarefas.Integration.Response;

namespace GerenciadorDeTarefas.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetDatasViaCep(string cep);
    }
}
