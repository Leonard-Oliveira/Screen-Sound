internal class Avaliacao
{
    public int Nota { get; private set; }

    // CONSTRUTOR
    public Avaliacao(int nota)
    {
        if (nota < 1 || nota > 10) throw new ArgumentOutOfRangeException(nameof(nota), "A nota deve estar entre 1 e 10.");
        Nota = nota;
    }
}