using System.Threading.Tasks;

namespace Framework.Core.Messageing
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task HandleAsync(T eventToHandle);
        void Handle(T eventToHandle);
    }
}
