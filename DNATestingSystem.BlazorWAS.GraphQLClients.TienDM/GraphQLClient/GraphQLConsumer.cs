using DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.Models;
using GraphQL.Client.Abstractions;
using GraphQL;
using static DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.Models.AppointmentsTienDm;

namespace DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.GraphQLClient
{
    public class GraphQLConsumer
    {
        private readonly IGraphQLClient _graphQLClient;

        public GraphQLConsumer(IGraphQLClient graphQLClient) => _graphQLClient = graphQLClient;

        public async Task<List<AppointmentsTienDm>> GetAllAppointments()
        {
            try
            {                // Get Query String from GraphQL API
                var query = @"query appointment {
                    allAppointments {
                        address
                        appointmentDate
                        appointmentStatusesTienDmid
                        appointmentsTienDmid
                        appointmentTime
                        contactPhone
                        createdDate
                        isPaid
                        modifiedDate
                        notes
                        samplingMethod
                        servicesNhanVtid
                        totalAmount
                        userAccountId
                    }
                }"; var response = await _graphQLClient.SendQueryAsync<AppointmentsTienDmsGraphQLResponses>(query);
                var result = response?.Data?.allAppointments;

                return result ?? new List<AppointmentsTienDm>();
            }
            catch (Exception) { }

            return new List<AppointmentsTienDm>();
        }

        public async Task<AppointmentsTienDm> GetAppointmentById(int id)
        {
            try
            {
                #region GraphQL Request

                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"query GetAppointmentById($id: Int!) {
                        appointmentById(id: $id) {
                            address
                            appointmentDate
                            appointmentStatusesTienDmid
                            appointmentsTienDmid
                            appointmentTime
                            contactPhone
                            createdDate
                            isPaid
                            modifiedDate
                            notes
                            samplingMethod
                            servicesNhanVtid
                            totalAmount
                            userAccountId
                        }
                    }",
                    Variables = new { id = id }
                };
                #endregion

                var response = await _graphQLClient.SendQueryAsync<AppointmentsTienDmsGraphQLResponse>(graphQLRequest);
                var result = response?.Data?.appointmentsTienDm;

                return result ?? new AppointmentsTienDm();
            }
            catch (Exception)
            {
                return new AppointmentsTienDm();
            }
        }

        public async Task<int> CreateAppointment(AppointmentsTienDm appointment)
        {
            try
            {
                #region GraphQL Mutation

                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"mutation CreateAppointment($appointment: AppointmentsTienDmInput!) {
                        createAppointment(appointment: $appointment)
                    }",
                    Variables = new { appointment = appointment }
                };
                #endregion

                var response = await _graphQLClient.SendMutationAsync<CreateAppointmentResponse>(graphQLRequest);
                var result = response?.Data?.createAppointment ?? 0;

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
                #region GraphQL Mutation

                var graphQLRequest = new GraphQLRequest
                {
                    Query = @"mutation UpdateAppointment($appointment: AppointmentsTienDmInput!) {
                        updateAppointment(appointment: $appointment)
                    }",
                    Variables = new { appointment = appointment }
                };
                #endregion

                var response = await _graphQLClient.SendMutationAsync<UpdateAppointmentResponse>(graphQLRequest);
                var result = response?.Data?.updateAppointment ?? 0;

                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
