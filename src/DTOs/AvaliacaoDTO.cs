namespace ScreenSound.DTOs;
using System.Text.Json.Serialization;
internal class AvaliacaoDTO
{
    public int Nota { get; set; }
    
    [JsonConstructor]
    public AvaliacaoDTO(int nota)
    {
        Nota = nota;
    }
}