using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Interfaces;

namespace DeviceManagement_WebApp.Repositories
{
    public class ZonesRepository: GenericRepository<Zone>, IZonesRepository
    {
        public ZonesRepository(ConnectedOfficeContext context): base(context)
        {

        }
    }
}
