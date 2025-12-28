namespace Screensound.Domain.Interfaces;
using ScreenSound.Domain;

internal interface IAvaliavel
{
    void AtribuiAvaliacao(Avaliacao avaliacao);
    double AvaliacaoMedia { get; }
}