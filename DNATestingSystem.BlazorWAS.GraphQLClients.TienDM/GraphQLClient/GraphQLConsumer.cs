using DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.Models;
using GraphQL.Client.Abstractions;
using GraphQL;
using static DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.Models.AppointmentsTienDm;

namespace DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.GraphQLClient
{
    public class GraphQLConsumer
    {
        private readonly IGraphQLClient _graphQLClient;

        public GraphQLConsumer(IGraphQLClient graphQLClient) => _graphQLClient = graphQLClient;        /// <summary>
                                                                                                       /// Get all appointments using display DTOs - optimized for UI display
                                                                                                       /// </summary>
        public async Task<List<AppointmentsTienDmDisplayDto>> GetAllAppointmentsDisplay()
        {
            try
            {
                var query = @"query appointmentsDisplay {
                    allAppointmentsDisplay {
                        appointmentsTienDmid
                        appointmentDate
                        appointmentTime
                        contactPhone
                        address
                        totalAmount
                        isPaid
                        samplingMethod
                        notes
                        statusName
                        serviceName
                        userName
                        userEmail
                        createdDate
                        modifiedDate
                    }
                }";

                var response = await _graphQLClient.SendQueryAsync<AppointmentsTienDmDisplayDtosGraphQLResponse>(query);
                var result = response?.Data?.allAppointmentsDisplay;

                return result ?? new List<AppointmentsTienDmDisplayDto>();
            }
            catch (Exception)
            {
                return new List<AppointmentsTienDmDisplayDto>();
            }
        }

        /// <summary>
        /// Get appointment by ID using display DTO
        /// </summary>
        public async Task<AppointmentsTienDmDisplayDto> GetAppointmentDisplayById(int id)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"query GetAppointmentDisplayById($id: Int!) {
                        appointmentDisplayById(id: $id) {
                            appointmentsTienDmid
                            userAccountId
                            servicesNhanVtid
                            appointmentStatusesTienDmid
                            appointmentDate
                            appointmentTime
                            samplingMethod
                            address
                            contactPhone
                            notes
                            totalAmount
                            isPaid
                            statusName
                            serviceName
                            userName
                            userEmail
                            createdDate
                            modifiedDate
                        }
                    }",
                    Variables = new { id = id }
                };

                var response = await _graphQLClient.SendQueryAsync<AppointmentsTienDmDisplayDtoGraphQLResponse>(graphQLRequest);
                var result = response?.Data?.appointmentDisplayById;

                return result ?? new AppointmentsTienDmDisplayDto();
            }
            catch (Exception)
            {
                return new AppointmentsTienDmDisplayDto();
            }
        }

        /// <summary>
        /// Create appointment using DTO - simplified input
        /// </summary>
        public async Task<int> CreateAppointmentDto(CreateAppointmentsTienDmDto appointmentDto)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"mutation CreateAppointment($appointmentDto: CreateAppointmentsTienDmDtoInput!) {
                        createAppointment(appointmentDto: $appointmentDto)
                    }",
                    Variables = new { appointmentDto = appointmentDto }
                };

                var response = await _graphQLClient.SendMutationAsync<CreateAppointmentDtoResponse>(graphQLRequest);
                var result = response?.Data?.createAppointment ?? 0;

                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Update appointment using DTO - simplified input
        /// </summary>
        public async Task<int> UpdateAppointmentDto(UpdateAppointmentsTienDmDto appointmentDto)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"mutation UpdateAppointment($appointmentDto: UpdateAppointmentsTienDmDtoInput!) {
                        updateAppointment(appointmentDto: $appointmentDto)
                    }",
                    Variables = new { appointmentDto = appointmentDto }
                };

                var response = await _graphQLClient.SendMutationAsync<UpdateAppointmentDtoResponse>(graphQLRequest);
                var result = response?.Data?.updateAppointment ?? 0;

                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Delete appointment by ID
        /// </summary>
        public async Task<bool> DeleteAppointment(int id)
        {
            try
            {
                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"mutation DeleteAppointment($id: Int!) {
                        deleteAppointment(id: $id)
                    }",
                    Variables = new { id = id }
                };

                var response = await _graphQLClient.SendMutationAsync<DeleteAppointmentResponse>(graphQLRequest);
                var result = response?.Data?.deleteAppointment ?? false;

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all appointments (original method for backward compatibility)
        /// </summary>
        public async Task<List<AppointmentsTienDm>> GetAllAppointments()
        {
            try
            {
                var displayAppointments = await GetAllAppointmentsDisplay();
                // Convert display DTOs to regular models
                var appointments = displayAppointments.Select(d => new AppointmentsTienDm
                {
                    AppointmentsTienDmid = d.AppointmentsTienDmid,
                    UserAccountId = d.UserAccountId,
                    ServicesNhanVtid = d.ServicesNhanVtid,
                    AppointmentStatusesTienDmid = d.AppointmentStatusesTienDmid,
                    AppointmentDate = d.AppointmentDate,
                    AppointmentTime = d.AppointmentTime,
                    SamplingMethod = d.SamplingMethod,
                    Address = d.Address,
                    ContactPhone = d.ContactPhone,
                    Notes = d.Notes,
                    TotalAmount = d.TotalAmount,
                    IsPaid = d.IsPaid,
                    CreatedDate = d.CreatedDate,
                    ModifiedDate = d.ModifiedDate
                }).ToList();

                return appointments;
            }
            catch (Exception)
            {
                return new List<AppointmentsTienDm>();
            }
        }

        // ...existing code...
    }

    // Response classes for GraphQL
    public class AppointmentsTienDmDisplayDtosGraphQLResponse
    {
        public List<AppointmentsTienDmDisplayDto> allAppointmentsDisplay { get; set; } = new();
    }

    public class AppointmentsTienDmDisplayDtoGraphQLResponse
    {
        public AppointmentsTienDmDisplayDto appointmentDisplayById { get; set; } = new();
    }

    public class CreateAppointmentDtoResponse
    {
        public int createAppointment { get; set; }
    }

    public class UpdateAppointmentDtoResponse
    {
        public int updateAppointment { get; set; }
    }

    public class DeleteAppointmentResponse
    {
        public bool deleteAppointment { get; set; }
    }
}