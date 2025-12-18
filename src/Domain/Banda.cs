namespace ScreenSound.Domain;
public class Banda
{
    //ATRIBUTOS
    public string NomeDaBanda { get; private set; }
    public List<Musica> ListaDeMusicasDaBanda { get; private set; }

    //CONSTRUTOR
    public Banda(string nome)
    {
    this.NomeDaBanda = nome;
    this.ListaDeMusicasDaBanda = new List<Musica>();
    }

    //MÉTODOS
    public void AtribuiMusicaAoArtista(Musica musica)
    {
        ListaDeMusicasDaBanda.Add(musica);
    }
}