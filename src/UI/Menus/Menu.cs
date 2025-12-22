using ScreenSound.Application;
using ScreenSound.Domain;

internal abstract class Menu<T>
{
    public void Executar(T service)
    {
        Console.Clear();
        ExibirConteudo(service);
    }

    protected abstract void ExibirConteudo(T service);
    protected void ExibirTituloDoMenu(string titulo)
    {
        int tamanhoDoTitulo = titulo.Length;
        string simbolo = string.Empty;
        Console.WriteLine(simbolo.PadLeft(tamanhoDoTitulo, '*'));
        Console.WriteLine(titulo);
        Console.WriteLine(simbolo.PadLeft(tamanhoDoTitulo, '*') + "\n");
    }

    // protected void TransicaoDeTelas(string mensagem = "Carregando")
    // {
    //     Console.Write("\n" + mensagem);
    //     for (int i = 0; i < 3; i++)
    //     {
    //         Thread.Sleep(300);
    //         Console.Write(".");
    //     }
    //     Thread.Sleep(400);
    //     Console.Clear();
    // }
}