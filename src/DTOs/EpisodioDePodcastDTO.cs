namespace ScreenSound.DTOs;
using System.Text.Json.Serialization;
internal class EpisodioDePodcastDTO
{   
    public int NumeroDoEpisodio { get; set; }
    public string TituloDoEpisodio { get; set; }
    public int Duracao { get; set; }
    public string ResumoDoEpisodio { get; set; }
    public List<string> ListaDeConvidados { get; set; } = new();

    public PodcastDTO? PodcastVinculado { get; set; }

    // CONSTRUTOR
    [JsonConstructor]
    public EpisodioDePodcastDTO(int numeroDoEpisodio, string tituloDoEpisodio, int duracao, string resumoDoEpisodio) 
    {
        NumeroDoEpisodio = numeroDoEpisodio;
        TituloDoEpisodio = tituloDoEpisodio;
        Duracao = duracao;
        ResumoDoEpisodio = resumoDoEpisodio;
    }
}