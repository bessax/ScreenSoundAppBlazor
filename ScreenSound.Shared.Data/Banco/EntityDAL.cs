using ScreenSound.Shared.Context;

namespace ScreenSound.Shared.Banco;
public class EntityDAL<T> where T : class
{
    private readonly ScreenSoundContext context;

    public EntityDAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    public virtual IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }
    public virtual void Adicionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        context.SaveChanges();
    }

    public virtual void Deletar(T objeto)
    {
        context.Set<T>().Remove(objeto);
        context.SaveChanges();
        Console.WriteLine($"{typeof(T)} removido com sucesso.");
        
    }

    public virtual void Atualizar(T objeto)
    {

        context.Set<T>().Update(objeto);
        context.SaveChanges();
        Console.WriteLine($"{typeof(T)} atualizado com sucesso.");

    }

    public virtual T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

    public virtual IEnumerable<T> ListarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().Where(condicao);
    }

}
