namespace ScreenSound.Domain;
internal class Album
{   
    public string NomeDoAlbum { get; private set; }

    public Banda BandaDoAlbum { get; private set; } 

    public int AnoDeLancamento { get; private set; }

    public List<Musica> MusicasDoAlbum { get; private set; }

    public Album(string albumName, Banda banda, int anoDeLancamento)
    {
        if (string.IsNullOrWhiteSpace(albumName)) throw new ArgumentException("O nome do álbum não pode ser vazio.");
        if (banda == null) throw new ArgumentNullException("A banda do álbum não pode ser nula.");
        if (anoDeLancamento <= 0) throw new ArgumentException("O ano de lançamento deve ser um número positivo.");
        
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