using System;
using ee.itcollege.krruub.Contracts.BLL.Base.Services;

namespace ee.itcollege.krruub.BLL.Base.Services
{
    public class BaseService : IBaseService
    {
        private readonly Guid _instanceId = Guid.NewGuid();
        public Guid InstanceId => _instanceId;
    }
}