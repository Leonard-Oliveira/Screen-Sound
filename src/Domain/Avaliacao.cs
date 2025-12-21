internal class Avaliacao
{
    public int Nota { get; private set; }

    // CONSTRUTOR
    public Avaliacao(int nota, string comentario)
    {
        if (nota < 1 || nota > 5) throw new ArgumentOutOfRangeException(nameof(nota), "A nota deve estar entre 1 e 5.");
        Nota = nota;
    }
}