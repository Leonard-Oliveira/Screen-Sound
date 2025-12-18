namespace ScreenSound.Domain;
public class Artista
{
    public static List<Artista> listaDeTodosOsArtistas = new List<Artista>();

    //ATRIBUTOS
    public string Nome { get; private set; }
    public List<Musica> ListaDeMusicasDoArtista { get; private set; }

    //CONSTRUTOR
    public Artista(string nome)
    {
    this.Nome = nome;
    this.ListaDeMusicasDoArtista = new List<Musica>();

    //sempre que instancia um artista, adiciona na lista
    listaDeTodosOsArtistas.Add(this);
    }

    //MÉTODOS
    public void AtribuiMusicaAoArtista(Musica musica)
    {
        ListaDeMusicasDoArtista.Add(musica);
    }
}