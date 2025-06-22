using DNATestingSystem.Repository.TienDM.Models;
using DNATestingSystem.Repository.TienDM.ModelExtensions;
using DNATestingSystem.Services.TienDM;

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

                // Get existing appointment
                var existingAppointment = await _serviceProviders.AppointmentsTienDmService.GetByIdAsync(appointmentDto.AppointmentsTienDmid);
                if (existingAppointment == null || existingAppointment.AppointmentsTienDmid == 0)
                {
                    return 0;
                }

                // Update entity with DTO data using mapper
                existingAppointment.UpdateFromDto(appointmentDto);

                var result = await _serviceProviders.AppointmentsTienDmService.UpdateAsync(existingAppointment);
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
    }
}
