namespace ScreenSound.DTOs;
using System.Text.Json.Serialization;
internal class PodcastDTO
{
    public string NomeDoPodcast { get; set; }
    public string Host { get; set; }
    public List<EpisodioDePodcastDTO> Episodios { get; set; }= new();

    [JsonConstructor]
    public PodcastDTO(string nomeDoPodcast, string host)
    {
        NomeDoPodcast = nomeDoPodcast;
        Host = host;
    }
}