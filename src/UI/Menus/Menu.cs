using ScreenSound.Application;
using ScreenSound.Domain;
using ScreenSound.Utils;

internal abstract class Menu<T>
{
    public void Executar(T service)
    {
        ConsoleUtils.LimparTela();
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

    protected void LoadingTransicao(string mensagem = "Carregando")
    {
        Console.Write("\n" + mensagem);
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(300);
            Console.Write(".");
        }
        Thread.Sleep(400);
        ConsoleUtils.LimparTela();
    }
}