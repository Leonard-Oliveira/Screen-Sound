using System.Diagnostics;

class Musica(string nome, string artista, int duracao)
{
    //propriedades publicas
    public string Nome { get; private set; } = nome;
    public string Artista { get; private set; } = artista;
    public int Duracao { get; private set; } = duracao;
    public bool Disponivel { get; private set; } = true;
    public string DescricaoResumida => $"A música {Nome} pertence ao artista {Artista}";

    public void ExibirFichaTecnica()
    {
        Console.WriteLine("Nome da Música: {0}", Nome);
        Console.WriteLine("Artista: {0}", Artista);
        Console.WriteLine("Duração: {0}", Duracao);
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        } else
        {
            Console.WriteLine("Adquira o plano plus+");
        }
    }

    public void ExibeArtista()
    {
        Console.WriteLine($"Música / Artista: {Nome} - {Artista}");
    }
}