namespace ScreenSound.Utils;
public static class ConsoleUtils
{
    public static string SolicitaTexto(string pergunta)
    {
        string? entradaDoUsuario;

        do
        {
            Console.Write(pergunta);
            entradaDoUsuario = Console.ReadLine();

            if (string.IsNullOrEmpty(entradaDoUsuario))
            {
                Console.WriteLine("\n⚠️ Entrada inválida. Por favor, tente novamente.\n");
            }
        } while (string.IsNullOrWhiteSpace(entradaDoUsuario));

        return entradaDoUsuario;
    }

    public static int SolicitaInteiro(string pergunta)
    {
        bool sucesso;
        int entradaConvertida;

        do
        {
            Console.Write(pergunta);
            sucesso = int.TryParse(Console.ReadLine(), out entradaConvertida);

            if (!sucesso)
                Console.WriteLine("\n⚠️ Entrada inválida. Por favor, tente novamente.\n");

        } while (!sucesso);

        return entradaConvertida;
    }
}