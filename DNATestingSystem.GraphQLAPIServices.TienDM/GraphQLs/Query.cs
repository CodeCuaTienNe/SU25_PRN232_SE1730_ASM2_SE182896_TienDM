using DNATestingSystem.Repository.TienDM.ModelExtensions;
using DNATestingSystem.Repository.TienDM.Models;
using DNATestingSystem.Services.TienDM;

namespace DNATestingSystem.GraphQLAPIServices.TienDM.GraphQLs
{
    public class Query
    {
        private readonly IServiceProviders _serviceProviders;

        public Query(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }
        public async Task<List<AppointmentsTienDm>> GetAllAppointments()
        {
            try
            {
                var result = await _serviceProviders.AppointmentsTienDmService.GetAllAsync();
                return result;
            }
            catch (Exception)
            {
                // Log the exception if needed
                return new List<AppointmentsTienDm>();
            }
        }

        //get appointments with pagination
        public async Task<PaginationResult<List<AppointmentsTienDm>>> GetAllAppointmentsPaginated(int page = 1, int pageSize = 10)
        {
            try
            {
                var result = await _serviceProviders.AppointmentsTienDmService.GetAllPaginatedAsync(page, pageSize);
                return result ?? new PaginationResult<List<AppointmentsTienDm>>();
            }
            catch (Exception)
            {
                // Log the exception if needed
                return new PaginationResult<List<AppointmentsTienDm>>();
            }
        }

        //search appointments with pagination
        public async Task<PaginationResult<List<AppointmentsTienDm>>> SearchAppointments(SearchAppointmentsTienDm searchRequest)
        {
            try
            {
                var result = await _serviceProviders.AppointmentsTienDmService.SearchAsync(searchRequest);
                return result ?? new PaginationResult<List<AppointmentsTienDm>>();
            }
            catch (Exception)
            {
                return new PaginationResult<List<AppointmentsTienDm>>();
            }
        }

        //get appointment by ID
        public async Task<AppointmentsTienDm> GetAppointmentById(int id)
        {
            try
            {
                var result = await _serviceProviders.AppointmentsTienDmService.GetByIdAsync(id);
                return result ?? new AppointmentsTienDm();
            }
            catch (Exception)
            {
                return new AppointmentsTienDm();
            }
        }
    }
}
