using System.ComponentModel.DataAnnotations;

namespace DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.Models
{
    /// <summary>
    /// Model specifically for UpdateAppointment GraphQL mutation
    /// This model maps directly to the mutation parameters
    /// </summary>
    public class UpdateAppointmentMutationDto
    {
        public string Address { get; set; } = string.Empty;
        public string AppointmentDate { get; set; } = string.Empty;
        public int AppointmentStatusesTienDmid { get; set; }
        public int AppointmentsTienDmid { get; set; }
        public string AppointmentTime { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string SamplingMethod { get; set; } = string.Empty;
        public int ServicesNhanVtid { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserAccountId { get; set; }
    }

    /// <summary>
    /// Extension methods to convert between DTOs
    /// </summary>
    public static class AppointmentMutationMapper
    {
        /// <summary>
        /// Convert UpdateAppointmentsTienDmDto to UpdateAppointmentMutationDto
        /// </summary>
        public static UpdateAppointmentMutationDto ToMutationDto(this UpdateAppointmentsTienDmDto updateDto)
        {
            return new UpdateAppointmentMutationDto
            {
                Address = updateDto.Address ?? string.Empty,
                AppointmentDate = updateDto.AppointmentDate.ToString("yyyy-MM-dd"),
                AppointmentStatusesTienDmid = updateDto.AppointmentStatusesTienDmid,
                AppointmentsTienDmid = updateDto.AppointmentsTienDmid,
                AppointmentTime = updateDto.AppointmentTime.ToString("HH:mm:ss"),
                ContactPhone = updateDto.ContactPhone,
                IsPaid = updateDto.IsPaid ?? false,
                Notes = updateDto.Notes ?? string.Empty,
                SamplingMethod = updateDto.SamplingMethod,
                ServicesNhanVtid = updateDto.ServicesNhanVtid,
                TotalAmount = updateDto.TotalAmount,
                UserAccountId = updateDto.UserAccountId
            };
        }
    }
}
