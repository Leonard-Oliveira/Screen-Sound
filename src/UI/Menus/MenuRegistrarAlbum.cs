using ScreenSound.Application;
using ScreenSound.Domain;
using ScreenSound.Utils;
internal class MenuRegistrarAlbum : MenuComContexto<AlbumService>
{
    // dependencia necessária para este menu específico
    private readonly BandaService _bandaService;

    public MenuRegistrarAlbum(SystemContext context, AlbumService albumService, BandaService bandaService) : base(context, albumService)
    {
        _bandaService = bandaService;
    }

    protected override void ExibirConteudo()
    {
        ExibirTituloDoMenu("Registrar Álbum");

        string bandaDoAlbum = ConsoleUtils.SolicitaTexto("Nome da Banda: ");
        Banda? bandaEncontrada = _bandaService.BuscarBandaPorNome(bandaDoAlbum);

        while (bandaEncontrada == null)
        {
            Console.WriteLine($"\n⚠️ A banda '{bandaDoAlbum}' não está cadastrada.");
            string opcao = ConsoleUtils.SolicitaTexto("Deseja cadastrá-la agora? (S/N): ").ToUpper();

            if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                _bandaService.RegistraNovaBanda(bandaDoAlbum);
                bandaEncontrada = _bandaService.BuscarBandaPorNome(bandaDoAlbum);
                Console.WriteLine("✅ Banda registrada!");
            }
            else
            {
                return; // Usuário desistiu, encerra o fluxo com segurança
            }
        }

        string nomeDoAlbum = ConsoleUtils.SolicitaTexto("Nome do Album: ");
        int anoDeLancamento = ConsoleUtils.SolicitaInteiro("Ano de lançamento: ");

        try
        {
            Service.RegistraAlbum(nomeDoAlbum, bandaEncontrada, anoDeLancamento);
            Console.WriteLine($"\n✅ Álbum '{nomeDoAlbum}' de {bandaEncontrada.NomeDaBanda} registrado com sucesso!");
        }
        catch (InvalidOperationException ex)
        {
            // Captura o erro de duplicidade que o Service lançou
            Console.WriteLine($"\n❌ Erro de Negócio: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Captura erros inesperados (ex: falha no sistema)
            Console.WriteLine($"\n❌ Erro Crítico: {ex.Message}");
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}