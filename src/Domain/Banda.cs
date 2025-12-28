using Screensound.Domain.Interfaces;
using ScreenSound.Application;

namespace ScreenSound.Domain;

internal class Banda : IAvaliavel
{
    #region Campos Privados (Backing Fields)
    private readonly List<Musica> _musicasDaBanda = new();
    private readonly List<Album> _albunsDaBanda = new();
    private readonly List<Avaliacao> _avaliacoes = new();
    #endregion

    #region Atributos e Propriedades
    public string NomeDaBanda { get; private set; }

    // Proteção: Ninguém de fora pode dar um .Add() ou .Clear() nessas listas
    public IReadOnlyCollection<Musica> ListaDeMusicasDaBanda => _musicasDaBanda.AsReadOnly();
    public IReadOnlyCollection<Album> ListaDeAlbunsDaBanda => _albunsDaBanda.AsReadOnly();
    public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.AsReadOnly();

    public double AvaliacaoMedia => _avaliacoes.Any() ? _avaliacoes.Average(a => a.Nota) : 0.0;
    #endregion

    #region Construtor
    public Banda(string nomeDaBanda)
    {
        if (String.IsNullOrWhiteSpace(nomeDaBanda)) throw new ArgumentException("Nome da Banda inválido.");
        NomeDaBanda = nomeDaBanda;
    }
    #endregion

    #region Métodos
    public void AtribuiMusicaAoArtista(Musica musica)
    {
        if (musica != null) _musicasDaBanda.Add(musica);
    }

    public void AtribuiAlbumAoArtista(Album album)
    {
        if (album != null) _albunsDaBanda.Add(album);
    }

    public void AtribuiAvaliacao(Avaliacao avaliacao)
    {
        if (avaliacao != null) _avaliacoes.Add(avaliacao);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"--- Discografia de {NomeDaBanda} ---");
        foreach (var musica in ListaDeMusicasDaBanda)
        {
            Console.WriteLine(musica.NomeDaMusica);
        }
    }
    #endregion
}