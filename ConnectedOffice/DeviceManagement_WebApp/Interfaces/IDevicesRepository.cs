using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Interfaces
{
    public interface IDevicesRepository : IGenericRepository<Device>
    {
        ConnectedOfficeContext GetContext();
    }
}
