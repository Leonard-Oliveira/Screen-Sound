namespace ScreenSound.Domain;
public class Artista
{
    //ATRIBUTOS
    public string Nome { get; private set; }
    public List<Musica> ListaDeMusicasDoArtista { get; private set; }

    //CONSTRUTOR
    public Artista(string nome)
    {
    this.Nome = nome;
    this.ListaDeMusicasDoArtista = new List<Musica>();
    }

    //MÉTODOS
    public void AtribuiMusicaAoArtista(Musica musica)
    {
        ListaDeMusicasDoArtista.Add(musica);
    }
}