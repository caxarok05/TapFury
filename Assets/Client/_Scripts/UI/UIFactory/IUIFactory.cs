using System.Threading.Tasks;

namespace Scripts.Infrastructure.States
{
    public interface IUIFactory
    {
        Task CreateUIMenuRoot();
    }
}