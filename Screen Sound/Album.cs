class Album(string nomeDoAlbum, Artista artista, int ano, List<Musica> listaDeMusicasDoAlbum)
{
    public string AlbumName { get; set; } = nomeDoAlbum;
    public Artista Artista { get; set; } = artista;
    public int AnoDeLancamento { get; set; } = ano;
    public List<Musica> MusicasDoAlbum { get; set; } = listaDeMusicasDoAlbum;
}