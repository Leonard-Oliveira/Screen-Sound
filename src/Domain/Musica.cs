namespace ScreenSound.Domain;
internal class Musica
{
    //ATRIBUTOS
    public string NomeDaMusica { get; private set; } 
    public Banda BandaDaMusica { get; private set; }
    public int Duracao { get; private set; }
    public bool Disponivel { get; private set; }
    public Genero GeneroDaMusica { get; private set; }
    
    //propriedade de leitura
    public string DescricaoResumida => $"A música {NomeDaMusica} pertence ao artista {BandaDaMusica.NomeDaBanda}";

    //CONSTRUTOR
    public Musica(string nomeDaMusica, Banda bandaDaMusica, int duracao, Genero genero)
    {
        this.NomeDaMusica = nomeDaMusica;
        this.BandaDaMusica = bandaDaMusica;
        this.Duracao = duracao;
        this.Disponivel = true;
        this.GeneroDaMusica = genero;
    }
    
    //MÉTODOS
    public void ExibirFichaTecnica()
    {
        Console.WriteLine("Nome da Música: {0}", NomeDaMusica);
        Console.WriteLine("Artista: {0}", BandaDaMusica.NomeDaBanda);
        Console.WriteLine("Duração: {0}", Duracao);
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        }
        else
        {
            Console.WriteLine("Adquira o plano plus+.");
        }
    }

    public void ExibeArtista()
    {
        Console.WriteLine($"Música / Artista: {NomeDaMusica} - {BandaDaMusica.NomeDaBanda}");
    }
}