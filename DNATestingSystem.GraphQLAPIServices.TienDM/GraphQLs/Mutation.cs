using DNATestingSystem.Repository.TienDM.Models;
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

        public async Task<int> CreateAppointment(AppointmentsTienDm appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return 0;
                }

                appointment.CreatedDate = DateTime.Now;
                appointment.ModifiedDate = DateTime.Now;

                var result = await _serviceProviders.AppointmentsTienDmService.CreateAsync(appointment);
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> UpdateAppointment(AppointmentsTienDm appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return 0;
                }

                appointment.ModifiedDate = DateTime.Now;

                var result = await _serviceProviders.AppointmentsTienDmService.UpdateAsync(appointment);
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
