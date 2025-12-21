namespace ScreenSound.Domain;
internal class Album
{   
    // ATRIBUTOS
    public string NomeDoAlbum { get; private set; }
    public Banda BandaDoAlbum { get; private set; } 
    public int AnoDeLancamento { get; private set; }
    public List<Musica> MusicasDoAlbum { get; private set; }

    // CONSTRUTOR
    public Album(string albumName, Banda banda, int anoDeLancamento)
    {
        NomeDoAlbum = albumName;
        BandaDoAlbum = banda;
        AnoDeLancamento = anoDeLancamento;
        MusicasDoAlbum = new List<Musica>();
    }

    public void AdicionaMusicaAoAlbum(Musica musica)
    {
        MusicasDoAlbum.Add(musica);
    }
}