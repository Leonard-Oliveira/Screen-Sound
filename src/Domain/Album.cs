namespace ScreenSound.Domain;
public class Album
{   
    // ATRIBUTOS
    public string NomeDoAlbum { get; private set; }
    public Artista ArtistaDoAlbum { get; private set; } 
    public int AnoDeLancamento { get; private set; }
    public List<Musica> MusicasDoAlbum { get; private set; }

    // CONSTRUTOR
    public Album(string albumName, Artista artista, int anoDeLancamento)
    {
        this.NomeDoAlbum = albumName;
        this.ArtistaDoAlbum = artista;
        this.AnoDeLancamento = anoDeLancamento;
        this.MusicasDoAlbum = new List<Musica>();
    }

    public void AdicionaMusicaAoAlbum(Musica musica)
    {
        MusicasDoAlbum.Add(musica);
    }
}