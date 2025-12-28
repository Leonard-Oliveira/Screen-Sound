namespace Screensound.Domain.Interfaces;
using ScreenSound.Domain;

internal interface IAvaliavel
{
    // Obriga a classe a ter uma forma de ler as avaliações
    IReadOnlyCollection<Avaliacao> Avaliacoes { get; }

    void AtribuiAvaliacao(Avaliacao avaliacao);
    double AvaliacaoMedia { get; }
}