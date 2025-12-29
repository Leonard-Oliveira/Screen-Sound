namespace ScreenSound.Domain;
internal class Genero
{
    #region Propriedades Privadas
    private List<Musica> _listaDeMusicasDoGenero = new();
    #endregion

    #region Atributos
    public string NomeDoGenero { get; private set; }
    public IReadOnlyList<Musica> ListaDeMusicasDoGenero => _listaDeMusicasDoGenero.AsReadOnly();
    #endregion

    #region Construtor
    public Genero(string nomeDoGenero) { NomeDoGenero = nomeDoGenero; }
    #endregion

    #region Métodos
    public void AdicionaMusicaAoGenero(Musica musica)
    {
        _listaDeMusicasDoGenero.Add(musica);
    }

    public void ExibirMusicasDoGenero()
    {
        Console.WriteLine($"Músicas do gênero {NomeDoGenero}:");
        foreach (var musica in ListaDeMusicasDoGenero)
        {
            Console.WriteLine($"- {musica.NomeDaMusica} de {musica.BandaDaMusica.NomeDaBanda}");
        }
    }

    public int ObterQuantidadeDeMusicas()
    {
        return ListaDeMusicasDoGenero.Count;
    }
    #endregion
}