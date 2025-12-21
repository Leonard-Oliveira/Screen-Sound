namespace ScreenSound.Application;
using ScreenSound.Domain;
internal class SystemContext
{
    public static string ApplicationName = "Screen Sound";
    public static string Version = "1.0.0";

    // BANCO DE DADOS TEMPORARIO
    public List<Banda> ListaDeTodasAsBandas = new List<Banda>();
    public List<Genero> ListaDeTodosOsGeneros = new List<Genero>();
    public List<Musica> ListaDeTodasAsMusicas = new List<Musica>();
    public List<Podcast> ListaDeTodosOsPodcasts = new List<Podcast>();
    public List<Album> ListaDeTodosOsAlbuns = new List<Album>();
}