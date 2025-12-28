using ScreenSound.Menus;
using ScreenSound.Application;

namespace ScreenSound.UI.Menus;

internal class MenuFactory
{
    private readonly SystemContext _context;

    public MenuFactory(SystemContext context)
    {
        _context = context;
    }

    public MenuAvaliarAlbum CriarMenuAvaliarAlbum()
    {
        var service = new AlbumService(_context);
        return new MenuAvaliarAlbum(_context, service);
    }

    public MenuExibirDetalhesComIA CriarMenuExibirDetalhesComIA()
    {
        var chatService = new ChatService(); 
        return new MenuExibirDetalhesComIA(_context, chatService);
    }
    
    public MenuRegistrarAlbum CriarMenuRegistrarAlbum()
    {
        var albumService = new AlbumService(_context);
        var bandaService = new BandaService(_context);
        return new MenuRegistrarAlbum(_context, albumService, bandaService);
    }

    public MenuDetalhesDaBanda CriarMenuDetalhesDaBanda()
    {
        // A fábrica resolve a dependência do serviço usando o contexto que ela já possui
        var service = new BandaService(_context);
        return new MenuDetalhesDaBanda(_context, service);
    }

    public MenuAvaliarBanda CriarMenuAvaliarBanda()
    {
        var service = new BandaService(_context);
        return new MenuAvaliarBanda(_context, service);
    }

    public MenuRegistrarBanda CriarMenuRegistrarBanda()
    {
        var service = new BandaService(_context);
        return new MenuRegistrarBanda(_context, service);
    }

    public MenuBandasRegistradas CriarMenuBandasRegistradas()
    {
        var service = new BandaService(_context);
        return new MenuBandasRegistradas(_context, service);
    }
    // Conforme você criar novos menus, adicione-os aqui
}