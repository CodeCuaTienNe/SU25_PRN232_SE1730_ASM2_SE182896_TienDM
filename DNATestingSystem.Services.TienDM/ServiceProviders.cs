using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATestingSystem.Services.TienDM
{
    public class ServiceProviders : IServiceProviders
    {
        private readonly DNATestingSystem.Repository.TienDM.IUnitOfWork _unitOfWork = new DNATestingSystem.Repository.TienDM.UnitOfWork();
        private SystemUserAccountService? _systemUserAccountService;
        private AppointmentsTienDmService? _appointmentsTienDmService;
        private AppointmentStatusesTienDmService? _appointmentStatusesTienDmService;
        private ServicesNhanVtService? _servicesNhanVtService;

        public ServiceProviders() { }

        public SystemUserAccountService SystemUserAccountService
        {
            get { return _systemUserAccountService ??= new SystemUserAccountService(_unitOfWork); }
        }

        public AppointmentsTienDmService AppointmentsTienDmService
        {
            get { return _appointmentsTienDmService ??= new AppointmentsTienDmService(_unitOfWork); }
        }

        public AppointmentStatusesTienDmService AppointmentStatusesTienDmService
        {
            get { return _appointmentStatusesTienDmService ??= new AppointmentStatusesTienDmService(_unitOfWork); }
        }

        public ServicesNhanVtService ServicesNhanVtService
        {
            get { return _servicesNhanVtService ??= new ServicesNhanVtService(_unitOfWork); }
        }
    }
}
