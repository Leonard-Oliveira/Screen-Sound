using ScreenSound.Application;
internal class MenuRegistrarAlbum : Menu<AlbumService>
{
    protected override void ExibirConteudo(AlbumService albumService)
    {
        // primeiro coleta os dados do album
        // nome do album, nome da banda, ano de lancamento
        Console.Clear();

        ExibirTituloDoMenu("Registrar Álbum");

        Console.Write("Nome do Album: ");
        string nomeDoAlbum = Console.ReadLine() ?? string.Empty;

        Console.Write("Nome da Banda: ");
        string bandaDoAlbum = Console.ReadLine() ?? string.Empty;

        Console.Write("Ano de lançamento: ");
        string anoDeLancamentoString = Console.ReadLine() ?? "0";
        int anoDeLancamento = int.Parse(anoDeLancamentoString);
        
        // depois manda pro service validar e registrar
        albumService.CriaERegistraAlbum(nomeDoAlbum, bandaDoAlbum, anoDeLancamento);

        Console.WriteLine($"\nÁlbum '{nomeDoAlbum}' registrado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}