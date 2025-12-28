using Microsoft.Extensions.Configuration;
using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Types;

namespace ScreenSound.Application;

internal class ChatService
{
    #region Campos Privados
    private readonly GenerativeModel _model;
    #endregion

    #region Construtor
    public ChatService()
    {
        // 1. Localiza onde o executável está rodando
        var diretorioBase = Directory.GetCurrentDirectory();

        // 2. Monta o leitor de configurações para o appsettings.json
        var builder = new ConfigurationBuilder()
            .SetBasePath(diretorioBase)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        // 3. Busca a chave usando o caminho definido no JSON (Gemini -> ApiKey)
        string apiKey = configuration["Gemini:ApiKey"] 
            ?? throw new InvalidOperationException("API Key 'Gemini:ApiKey' não encontrada no appsettings.json.");

        // 4. Inicializa o modelo
        var googleAI = new GoogleAI(apiKey);
        _model = googleAI.GenerativeModel(Model.Gemini25Flash);
    }
    #endregion

    #region Métodos
    public async Task<string> ConsultarIA(string prompt)
    {
        try
        {
            var response = await _model.GenerateContent(prompt);
            return response.Text ?? "O Gemini não retornou conteúdo.";
        }
        catch (Exception ex)
        {
            return $"Erro ao acessar a inteligência artificial: {ex.Message}";
        }
    }
    #endregion
}