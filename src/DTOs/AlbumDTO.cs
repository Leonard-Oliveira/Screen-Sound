namespace ScreenSound.DTOs;
using System.Text.Json.Serialization;

internal class AlbumDTO
{   
    [JsonPropertyName("NomeDoAlbum")]
    public string NomeDoAlbum { get; set; }

    public BandaDTO? BandaDoAlbum { get; set; } 

    [JsonPropertyName("AnoDeLancamento")]
    public int AnoDeLancamento { get; set; }
    [JsonPropertyName("ListaDeMusicasDaBanda")]
    public List<MusicaDTO> MusicasDoAlbum { get; set; }

    [JsonConstructor]
    public AlbumDTO(string nomeDoAlbum, int anoDeLancamento)
    {
        NomeDoAlbum = nomeDoAlbum;
        AnoDeLancamento = anoDeLancamento;
        MusicasDoAlbum = new List<MusicaDTO>();
    }
}