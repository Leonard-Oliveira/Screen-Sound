namespace ScreenSound.Domain;
public class Album
{   
    public static List<Album> listaDeTodosOsAlbuns = new List<Album>();
    // ATRIBUTOS
    public string NomeDoAlbum { get; set; }
    public Artista ArtistaDoAlbum { get; set; } 
    public int AnoDeLancamento { get; set; }
    public List<Musica> MusicasDoAlbum { get; set; }

    // CONSTRUTOR
    public Album(string albumName, Artista artista, int anoDeLancamento)
    {
        this.NomeDoAlbum = albumName;
        this.ArtistaDoAlbum = artista;
        this.AnoDeLancamento = anoDeLancamento;
        this.MusicasDoAlbum = new List<Musica>();

        listaDeTodosOsAlbuns.Add(this);
    }

    public void AdicionaMusicaAoAlbum(Musica musica)
    {
        MusicasDoAlbum.Add(musica);
    }
}