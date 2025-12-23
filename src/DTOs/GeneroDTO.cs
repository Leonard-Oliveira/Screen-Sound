namespace ScreenSound.DTOs;
using System.Text.Json.Serialization;
internal class GeneroDTO
{

    public string NomeDoGenero { get; set; }
    public List<MusicaDTO> _listaDeMusicasDoGenero { get; set; } = new();

    [JsonConstructor]
    public GeneroDTO(string nomeDoGenero)
    {
        NomeDoGenero = nomeDoGenero;
    }
}