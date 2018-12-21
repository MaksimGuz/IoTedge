namespace StorageFacadeWebAPI.Services
{
    using System.Threading.Tasks;
    public interface IServicesOnEdge
    {
        Task RegisterInputMessageHandlers();
        Task RegisterMethodHandlers();
    }
}
