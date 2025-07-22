using DNATestingSystem.Repository.TienDM.Models;
using DNATestingSystem.Repository.TienDM.ModelExtensions;
using DNATestingSystem.Services.TienDM;

public class LoginResult
{
    public int UserAccountId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int RoleId { get; set; }
}

namespace DNATestingSystem.GraphQLAPIServices.TienDM.GraphQLs
{
    public class Mutation
    {
        private readonly IServiceProviders _serviceProviders;

        public Mutation(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }
        public async Task<int> CreateAppointment(CreateAppointmentsTienDmDto appointmentDto)
        {
            try
            {
                if (appointmentDto == null)
                {
                    return 0;
                }

                // Convert DTO to Entity using mapper
                var appointment = appointmentDto.ToEntity();

                var result = await _serviceProviders.AppointmentsTienDmService.CreateAsync(appointment);
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> UpdateAppointment(UpdateAppointmentsTienDmDto appointmentDto)
        {
            try
            {
                if (appointmentDto == null)
                {
                    return 0;
                }

                // Validate appointment exists before updating
                var existingAppointment = await _serviceProviders.AppointmentsTienDmService.GetByIdAsync(appointmentDto.AppointmentsTienDmid);
                if (existingAppointment == null || existingAppointment.AppointmentsTienDmid == 0)
                {
                    return 0;
                }

                var appointmentToUpdate = new AppointmentsTienDm
                {
                    AppointmentsTienDmid = appointmentDto.AppointmentsTienDmid
                };

                appointmentToUpdate.UpdateFromDto(appointmentDto);

                var result = await _serviceProviders.AppointmentsTienDmService.UpdateAsync(appointmentToUpdate);
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            try
            {
                var result = await _serviceProviders.AppointmentsTienDmService.DeleteAsync(id);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Login mutation: check username and password, return user info if valid, null if not
        /// </summary>
        public async Task<LoginResult?> Login(string username, string password)
        {
            try
            {
                var user = await _serviceProviders.SystemUserAccountService.GetUserAccount(username, password);
                if (user != null)
                {
                    return new LoginResult
                    {
                        UserAccountId = user.UserAccountId,
                        FullName = user.FullName,
                        RoleId = user.RoleId
                    };
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
