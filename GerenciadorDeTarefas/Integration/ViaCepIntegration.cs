using GerenciadorDeTarefas.Integration.Interfaces;
using GerenciadorDeTarefas.Integration.Refit;
using GerenciadorDeTarefas.Integration.Response;

namespace GerenciadorDeTarefas.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }
        public async Task<ViaCepResponse> GetDatasViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.GetDataViaCep(cep);

            if (responseData != null || responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            return null;

        }
    }
}
