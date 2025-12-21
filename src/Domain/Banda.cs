namespace ScreenSound.Domain;
internal class Banda
{
    //REGRAS DE NEGOCIO
    
    //ATRIBUTOS
    public string NomeDaBanda { get; private set; }
    public List<Musica> ListaDeMusicasDaBanda { get; private set; }
    public List<Album> ListaDeAlbunsDaBanda { get; private set; }

    //CONSTRUTOR
    public Banda(string nome)
    {
        NomeDaBanda = nome;
        ListaDeMusicasDaBanda = new List<Musica>();
        ListaDeAlbunsDaBanda = new List<Album>();
    }

    //MÉTODOS
    public void AtribuiMusicaAoArtista(Musica musica)
    {
        ListaDeMusicasDaBanda.Add(musica);
    }

    public void AtribuiAlbumAoArtista(Album album)
    {
        ListaDeAlbunsDaBanda.Add(album);
    }

    public void ExibirDiscografia()
    {
       //IMPLEMENTAR
    }
}