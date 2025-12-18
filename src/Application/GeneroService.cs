using System.Runtime.Serialization.Formatters;

namespace ScreenSound.Application;
class GeneroService
{
    private static List<Genero> _generosCadastrados = new List<Genero>();

    //funcao que retorna um objeto confirmando ou nao se o nomeDoGeneroProcurado corresponde a um Genero
    public Genero? BuscarGeneroPorNome(string nomeDoGeneroProcurado)
    {
        return _generosCadastrados.FirstOrDefault(g => g.NomeDoGenero.Equals(nomeDoGeneroProcurado, StringComparison.OrdinalIgnoreCase));
    }

    public void CriarGenero(string nomeDoGenero)
    {
        // Validações básicas de entrada
        //verifica se o parametro informado nao é nulo
        if (string.IsNullOrWhiteSpace(nomeDoGenero)) throw new ArgumentNullException("Gênero nao pode ser null");

        //verifica se o parametro informado já não está cadastrado. Nao podem ter dois generos iguais
        if (BuscarGeneroPorNome(nomeDoGenero) != null) throw new InvalidOperationException($"O gênero '{nomeDoGenero}' já está cadastrado.");

        //chama o construtor
        Genero novoGenero = new Genero(nomeDoGenero);

        _generosCadastrados.Add(novoGenero);
    }
}