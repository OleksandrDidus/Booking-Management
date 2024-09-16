using Booking_Management.Data.Model;
using Booking_Management.Interfaces;

namespace Booking_Management.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _serviceRepository.GetAllServicesAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _serviceRepository.GetServiceByIdAsync(id);
        }

        public async Task<Service> CreateServiceAsync(Service service)
        {
            return await _serviceRepository.CreateServiceAsync(service);
        }

        public async Task<Service> UpdateServiceAsync(Service service)
        {
            return await _serviceRepository.UpdateServiceAsync(service);
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
        }
    }
}
