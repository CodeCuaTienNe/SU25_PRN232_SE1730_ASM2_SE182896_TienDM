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

        /// <summary>
        /// Get all appointments as display DTOs - optimized for GraphQL queries
        /// </summary>
        public async Task<List<AppointmentsTienDmDisplayDto>> GetAllAppointmentsDisplay()
        {
            try
            {
                var result = await _serviceProviders.AppointmentsTienDmService.GetAllAsync();
                return result.ToDisplayDtos();
            }
            catch (Exception)
            {
                return new List<AppointmentsTienDmDisplayDto>();
            }
        }

        /// <summary>
        /// Get appointment by ID as display DTO
        /// </summary>
        public async Task<AppointmentsTienDmDisplayDto> GetAppointmentDisplayById(int id)
        {
            try
            {
                var result = await _serviceProviders.AppointmentsTienDmService.GetByIdAsync(id);
                return result?.ToDisplayDto() ?? new AppointmentsTienDmDisplayDto();
            }
            catch (Exception)
            {
                return new AppointmentsTienDmDisplayDto();
            }
        }


        public async Task<PaginationResult<List<AppointmentsTienDmDisplayDto>>> SearchAppointmentsDisplay(SearchAppointmentsTienDm searchRequest)
        {
            try
            {
                var result = await _serviceProviders.AppointmentsTienDmService.SearchAsync(searchRequest);
                if (result?.Items != null)
                {
                    return new PaginationResult<List<AppointmentsTienDmDisplayDto>>
                    {
                        TotalItems = result.TotalItems,
                        TotalPages = result.TotalPages,
                        CurrentPages = result.CurrentPages,
                        PageSize = result.PageSize,
                        Items = result.Items.ToDisplayDtos()
                    };
                }
                return new PaginationResult<List<AppointmentsTienDmDisplayDto>>();
            }
            catch (Exception)
            {
                return new PaginationResult<List<AppointmentsTienDmDisplayDto>>();
            }
        }
        //View status
        /// <summary>
        /// Get all appointment statuses for dropdown
        /// </summary>
        public async Task<List<AppointmentStatusesTienDm>> GetAllAppointmentStatuses()
        {
            try
            {
                var result = await _serviceProviders.AppointmentStatusesTienDmService.GetAllAsync();
                return result;
            }
            catch (Exception)
            {
                return new List<AppointmentStatusesTienDm>();
            }
        }


        public async Task<List<SystemUserAccount>> GetAllUsers()
        {
            try
            {
                var result = await _serviceProviders.SystemUserAccountService.GetAllAsync();
                return result;
            }
            catch (Exception)
            {
                return new List<SystemUserAccount>();
            }
        }

        public async Task<List<ServicesNhanVt>> GetAllServices()
        {
            try
            {
                var result = await _serviceProviders.ServicesNhanVtService.GetAllAsync();
                return result;
            }
            catch (Exception)
            {
                return new List<ServicesNhanVt>();
            }
        }

    }
}
