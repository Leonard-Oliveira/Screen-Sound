using ScreenSound.Application;
using ScreenSound.Domain;
using ScreenSound.Utils;

internal class MenuAvaliarAlbum : MenuComContexto<AlbumService>
{
    public MenuAvaliarAlbum(SystemContext context, AlbumService service) : base(context, service) {}

    protected override void ExibirConteudo()
    {
        ExibirTituloDoMenu("Avaliar Album");

        string albumSelecionado = ConsoleUtils.SolicitaTexto("Qual album voce quer avaliar?");
        var albumExistente = Service.BuscarAlbumPorNome(albumSelecionado);
        
        if (albumExistente != null)
        {
            int nota = ConsoleUtils.SolicitaInteiro("Qual nota voce atribui ao album?");
            albumExistente.AtribuiAvaliacao(new Avaliacao(nota));
            Console.WriteLine(
                $"Nota {nota} atribuída ao album {albumExistente.NomeDoAlbum} com sucesso!");
            LoadingTransicao();
        } 
        else
        {
            Console.WriteLine("Album não cadastrado no sistema!");
            Console.Write("Pressione qualquer tecla para sair");
            Console.Read();
            LoadingTransicao();
        }
    }
}