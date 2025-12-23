using ScreenSound.Application;
using ScreenSound.Domain;
using ScreenSound.Utils;

internal class MenuAvaliarBanda : Menu<BandaService>
{
    protected override void ExibirConteudo(BandaService bandaService)
    {
        ExibirTituloDoMenu("Avaliar Banda");

        string bandaInput = ConsoleUtils.SolicitaTexto("Qual o nome da banda que você quer avaliar? ");
        Banda? bandaEncontrada = bandaService.BuscarBandaPorNome(bandaInput);

        if (bandaEncontrada == null)
        {
            Console.WriteLine($"\n⚠️ Banda {bandaInput} nao Registrada no Sistema");
            string confirmacao = ConsoleUtils.SolicitaTexto("Deseja registra-la agora para avaliacao? (S/N)").ToUpper();

            if (confirmacao == "S")
            {
                bandaService.RegistraNovaBanda(bandaInput);
                // Reatribuição para garantir que o objeto exista para o restante do fluxo
                bandaEncontrada = bandaService.BuscarBandaPorNome(bandaInput);

                if (bandaEncontrada != null) Console.WriteLine("✅ Banda registrada com sucesso!");
            }
            else
            {
                Console.WriteLine("Encerrando operacao e retornando ao menu principal");
                LoadingTransicao();
                return;
            }
        }

        if (bandaEncontrada is not Banda banda)
        {
            Console.WriteLine("\n❌ Erro crítico: Não foi possível recuperar os dados da banda.");
            LoadingTransicao();
            return;
        }

        bool notaRegistradaComSucesso = false;
        do
        {
            try
            {
                int nota = ConsoleUtils.SolicitaInteiro($"Qual a nota da banda {banda.NomeDaBanda} (1-10)? ");

                // O construtor de Avaliacao valida se a nota está entre 1 e 10
                Avaliacao novaAvaliacao = new(nota);

                // O Service orquestra a atribuição da nota ao objeto Banda
                bandaService.AvaliaBanda(banda, novaAvaliacao);

                Console.WriteLine($"\n⭐ Sucesso! Você deu nota {nota} para a banda {banda.NomeDaBanda}.");
                notaRegistradaComSucesso = true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Captura o erro disparado pela classe Avaliacao se a nota for inválida
                Console.WriteLine($"\n⚠️ Erro de validação: {ex.Message}");
                Console.WriteLine("Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Captura qualquer outro erro inesperado
                Console.WriteLine($"\n❌ Ocorreu um erro inesperado: {ex.Message}");
                Console.ReadKey();
            }
        } while (!notaRegistradaComSucesso);
        // 4. Transição final
        LoadingTransicao();
    }
}
