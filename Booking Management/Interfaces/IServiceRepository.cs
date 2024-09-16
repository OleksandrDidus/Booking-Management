using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task<Service> CreateServiceAsync(Service service);
        Task<Service> UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
        Task<IEnumerable<Service>> GetServicesByIdsAsync(IEnumerable<int> ids);
    }
}
