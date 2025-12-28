using ScreenSound.Application;

internal abstract class MenuComContexto<T> : Menu<T>
{
    protected SystemContext Context { get; }

    protected MenuComContexto(SystemContext context, T service) : base(service)
    {
        Context = context;
    }
}