namespace ScreenSound.Domain;
internal class Avaliacao
{
    #region Atributos e Propriedades
    public int Nota { get; private set; }
    #endregion
    
    #region Métodos
    public Avaliacao(int nota)
    {
        if (nota < 1 || nota > 10) throw new ArgumentOutOfRangeException(nameof(nota), "A nota deve estar entre 1 e 10.");
        Nota = nota;
    }
    #endregion
}