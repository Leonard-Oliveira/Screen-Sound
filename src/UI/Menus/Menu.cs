using ScreenSound.Application;

internal abstract class Menu
{   
    // todos os menus acessam as informacoes de contexto do sistema
    // facilita a refatoracao e implementacao de novos dados
    public abstract void Executar(SystemContext context);

    // Exibe o título do menu com formatação
    protected void ExibirTituloDoMenu(string titulo)
    {
        int tamanhoDoTitulo = titulo.Length;
        string simbolo = string.Empty;
        Console.WriteLine(simbolo.PadLeft(tamanhoDoTitulo, '*'));
        Console.WriteLine(titulo);
        Console.WriteLine(simbolo.PadLeft(tamanhoDoTitulo, '*') + "\n");
    }
}