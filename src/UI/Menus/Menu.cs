using ScreenSound.Utils;

internal abstract class Menu<T>
{
    protected T Service { get; }
    
    protected Menu(T service)
    {
        Service = service;
    }

    public virtual async Task Executar()
    {
        ConsoleUtils.LimparTela();
        await ExibirConteudo();
    }

    protected abstract Task ExibirConteudo();
    
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