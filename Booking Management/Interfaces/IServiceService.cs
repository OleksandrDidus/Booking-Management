using Booking_Management.Data.Model;

namespace Booking_Management.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task<Service> CreateServiceAsync(Service service);
        Task<Service> UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}
