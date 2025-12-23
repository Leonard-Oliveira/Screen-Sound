using System.Text.Json.Serialization;
namespace ScreenSound.DTOs;
internal class MusicaDTO
{
    public string NomeDaMusica { get; set; } 
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }

    public GeneroDTO? GeneroDaMusica { get; set; }
    public BandaDTO? BandaDaMusica { get;  set; }

    [JsonConstructor]
    public MusicaDTO(string nomeDaMusica, int duracao)
    {
        NomeDaMusica = nomeDaMusica;
        Duracao = duracao;
    }
}