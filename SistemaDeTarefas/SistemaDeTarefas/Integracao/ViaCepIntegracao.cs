using SistemaDeTarefas.Integracao.Interfaces;
using SistemaDeTarefas.Integracao.Refit;
using SistemaDeTarefas.Integracao.Response;

namespace SistemaDeTarefas.Integracao
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;
        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntegracaoRefit)
        {
            _viaCepIntegracaoRefit = viaCepIntegracaoRefit;
        }
        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var reponseData = await _viaCepIntegracaoRefit.ObterDadosViaCep(cep);

            if(reponseData != null && reponseData.IsSuccessStatusCode)
            {
                return reponseData.Content;
            }
            return null;
        }
    }
}
