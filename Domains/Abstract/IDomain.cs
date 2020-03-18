namespace Domains.Abstract
{
    public interface IDomain<T>
    {
        T Id { get; set; }
    }
}