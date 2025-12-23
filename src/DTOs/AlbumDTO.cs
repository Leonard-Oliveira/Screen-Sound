namespace ScreenSound.DTOs;
using System.Text.Json.Serialization;

internal class AlbumDTO
{   
    public string NomeDoAlbum { get; set; }

    public BandaDTO? BandaDoAlbum { get; set; } 

    public int AnoDeLancamento { get; set; }
    public List<MusicaDTO> MusicasDoAlbum { get; set; }

    [JsonConstructor]
    public AlbumDTO(string nomeDoAlbum, int anoDeLancamento)
    {
        NomeDoAlbum = nomeDoAlbum;
        AnoDeLancamento = anoDeLancamento;
        MusicasDoAlbum = new List<MusicaDTO>();
    }
}