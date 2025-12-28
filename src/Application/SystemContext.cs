using System.Text.Json;
using System.Text.Json.Serialization;
using ScreenSound.Domain;
using ScreenSound.DTOs;

namespace ScreenSound.Application;

internal class SystemContext
{
    public static string ApplicationName = "Screen Sound";
    public static string Version = "1.0.0";
    public static bool IsDebugMode = false;

    public List<Banda> ListaDeTodasAsBandas = new();
    public List<Genero> ListaDeTodosOsGeneros = new();
    public List<Musica> ListaDeTodasAsMusicas = new();
    public List<Podcast> ListaDeTodosOsPodcasts = new();
    public List<Album> ListaDeTodosOsAlbuns = new();

    public void SemeiaDados()
    {
        try
        {
            string nomeArquivo = "Data/bandas.json";
            if (!File.Exists(nomeArquivo))
            {
                Console.WriteLine($"ERRO: Arquivo {nomeArquivo} não encontrado!");
                return;
            }

            string jsonString = File.ReadAllText(nomeArquivo);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var bandasDTO = JsonSerializer.Deserialize<List<BandaDTO>>(jsonString, options);

            if (bandasDTO != null)
            {
                foreach (var dto in bandasDTO)
                {
                    // 1. Criar a Banda (Domínio)
                    var bandaReal = new Banda(dto.NomeDaBanda);

                    // 2. Mapear Avaliações
                    if (dto.Avaliacoes != null)
                    {
                        foreach (var avDto in dto.Avaliacoes)
                        {
                            bandaReal.AtribuiAvaliacao(new Avaliacao(avDto.Nota));
                        }
                    }

                    // 3. Mapear Álbuns e Músicas
                    if (dto.ListaDeAlbunsDaBanda != null)
                    {
                        foreach (var albumDto in dto.ListaDeAlbunsDaBanda)
                        {
                            var albumReal = new Album(albumDto.NomeDoAlbum, bandaReal, albumDto.AnoDeLancamento);

                            foreach (var musicaDto in albumDto.MusicasDoAlbum)
                            {
                                var generoPadrao = new Genero("Rock");

                                var musicaReal = new Musica(
                                    musicaDto.NomeDaMusica,
                                    bandaReal,
                                    musicaDto.Duracao,
                                    generoPadrao
                                );

                                albumReal.AdicionaMusicaAoAlbum(musicaReal);

                                // --- ESTA LINHA CONECTA A MÚSICA À BANDA DIRETAMENTE ---
                                bandaReal.AtribuiMusicaAoArtista(musicaReal);
                                // ------------------------------------------------------

                                this.ListaDeTodasAsMusicas.Add(musicaReal);
                            }
                            bandaReal.AtribuiAlbumAoArtista(albumReal);
                            this.ListaDeTodosOsAlbuns.Add(albumReal);
                        }
                    }

                    this.ListaDeTodasAsBandas.Add(bandaReal);
                }
                Console.WriteLine($"DEBUG: {this.ListaDeTodasAsBandas.Count} bandas e suas músicas carregadas com sucesso!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRO CRÍTICO no SemeiaDados: {ex.Message}");
        }
    }
}