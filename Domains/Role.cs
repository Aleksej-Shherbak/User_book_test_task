using Domains.Abstract;

namespace Domains
{
    public class Role: IDomain<int>
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}