using System.Net;
using Screensound.Domain.Interfaces;

namespace ScreenSound.Domain;
internal class Album : IAvaliavel
{   
    #region Campos Privados (Backing Fields)
    private readonly List<Avaliacao> _avaliacoes = new();
    private readonly List<Musica> _musicasDoAlbum = new();
    #endregion

    #region Atributos e Propriedades
    public string NomeDoAlbum { get; private set; }
    public Banda BandaDoAlbum { get; private set; } 
    public int AnoDeLancamento { get; private set; }

    public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.AsReadOnly();
    public IReadOnlyCollection<Musica> MusicasDoAlbum => _musicasDoAlbum.AsReadOnly();

    public double AvaliacaoMedia => _avaliacoes.Any() ? _avaliacoes.Average(a => a.Nota) : 0.0;
    #endregion

    #region Construtor
    public Album(string albumName, Banda banda, int anoDeLancamento)
    {
        if (string.IsNullOrWhiteSpace(albumName)) throw new ArgumentException("O nome do álbum não pode ser vazio.");
        NomeDoAlbum = albumName;
        BandaDoAlbum = banda ?? throw new ArgumentNullException(nameof(banda));
        if (anoDeLancamento <= 0) throw new ArgumentException("O ano de lançamento deve ser um número positivo.");
        AnoDeLancamento = anoDeLancamento;
    }
    #endregion

    #region Métodos
    public void AdicionaMusicaAoAlbum(Musica musica)
    {
        _musicasDoAlbum.Add(musica);
    }
    public void AtribuiAvaliacao(Avaliacao avaliacao)
    {
        _avaliacoes.Add(avaliacao);
    }
    #endregion
}