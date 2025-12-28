namespace ScreenSound.DTOs;
using System.Text.Json.Serialization;

internal class BandaDTO
{
    [JsonPropertyName("Avaliacoes")]
    public List<AvaliacaoDTO> Avaliacoes { get; set; } = new();

    public string NomeDaBanda { get; set; }
    public List<MusicaDTO> ListaDeMusicasDaBanda { get; set; } = new();
    public List<AlbumDTO> ListaDeAlbunsDaBanda { get; set; } = new();

    [JsonIgnore]
    public double AvaliacaoMedia => Avaliacoes.Any() ? Avaliacoes.Average(a => a.Nota) : 0.0;

    [JsonConstructor]
    public BandaDTO(string nomeDaBanda)
    {
        NomeDaBanda = nomeDaBanda;
    }
}