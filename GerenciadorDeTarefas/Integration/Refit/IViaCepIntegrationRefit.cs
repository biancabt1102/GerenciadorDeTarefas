using GerenciadorDeTarefas.Integration.Response;
using Refit;

namespace GerenciadorDeTarefas.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json/")]
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string cep);
    }
}
