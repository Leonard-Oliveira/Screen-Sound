using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;
using Screensound.Domain.Interfaces;

namespace ScreenSound.Domain;

internal class Musica : IAvaliavel
{
    #region Campos Privados (Backing Fields)
    private readonly List<Avaliacao> _avaliacoes = new();

    #endregion

    #region Atributos e Propriedades
    public string NomeDaMusica { get; private set; }
    public int Duracao { get; private set; }
    public bool Disponivel { get; private set; } = false;
    public string DescricaoResumida => $"A música {NomeDaMusica} pertence ao artista {BandaDaMusica.NomeDaBanda}";
    public Banda BandaDaMusica { get; private set; }
    public Genero GeneroDaMusica { get; private set; }
   
    public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.AsReadOnly();

    public double AvaliacaoMedia => _avaliacoes.Any() ? _avaliacoes.Average(a => a.Nota) : 0.0;
    #endregion

    #region Construtor
    public Musica(string nomeDaMusica, Banda bandaDaMusica, int duracao, Genero genero)
    {
        // Fail-fast: impede a criação de objetos inválidos
        NomeDaMusica = String.IsNullOrWhiteSpace(nomeDaMusica) ? 
            throw new ArgumentException("O nome da música não pode ser vazio.") : nomeDaMusica;

        BandaDaMusica = bandaDaMusica ?? throw new ArgumentNullException(nameof(bandaDaMusica));

        Duracao = duracao > 0 ? duracao : throw new ArgumentException(
            "A duração deve ser maior que zero.");

        GeneroDaMusica = genero ?? throw new ArgumentNullException(nameof(genero));
    }
    #endregion

    #region Métodos
    public void AtribuiAvaliacao(Avaliacao nota)
    {
        _avaliacoes.Add(nota);
    }

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
    #endregion
}