namespace ScreenSound.Application;
using ScreenSound.Domain;

public class MusicaService
{
    // Esta função centraliza a regra: "Para criar uma música, primeiro resolva o artista"
    public void CriarERegistrarMusica(string nomeMusica, string nomeArtista, int duracao)
    {
        // 1. Lógica de busca (que antes estava no construtor da Musica)
        Artista? artistaEncontrado = Artista.listaDeTodosOsArtistas
            .FirstOrDefault(a => a.Nome.Equals(nomeArtista, StringComparison.OrdinalIgnoreCase));

        // 2. Se não existir, cria o artista novo
        Artista artistaFinal = artistaEncontrado ?? new Artista(nomeArtista);

        // 3. Instancia a Música (agora o construtor da música pode ser simples!)
        Musica novaMusica = new Musica(nomeMusica, artistaFinal, duracao);

        // 4. Aqui você poderia salvar em uma lista global ou banco de dados
        Console.WriteLine($"✅ Sucesso: '{novaMusica.NomeDaMusica}' foi vinculada a '{artistaFinal.Nome}'.");
    }
}