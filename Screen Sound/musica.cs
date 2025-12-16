using System.Diagnostics;

class Musica
{
    //propriedades publicas
    public string Nome { get; private set; } 
    public string Artista { get; private set;}
    public int Duracao { get; private set; }
    public bool Disponivel { get; private set; }

    //construtor 
    public Musica(string nome, string artista, int duracao)
    {
        Nome = nome;
        Artista = artista;
        Duracao = duracao;
        Disponivel = true;
    }

    public void TornaDisponivel()
    {
        Disponivel = true;
    }

    public void TornaIndisponivel()
    {
        Disponivel = false;
    }

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
}