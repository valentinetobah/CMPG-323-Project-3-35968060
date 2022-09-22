using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceManagement_WebApp.Repositories
{
    public class DevicesRepository: GenericRepository<Device>, IDevicesRepository
    {
        protected readonly ConnectedOfficeContext _context;
        public DevicesRepository(ConnectedOfficeContext context): base(context)
        {
            _context = context;
        }
        public Device GetById(Guid? id)
        {
            return _context.Device.Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefault(m => m.DeviceId == id); 
        }

        public IEnumerable<Device> GetAll()
        {
            var device = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return device.ToList();
        }
        public ConnectedOfficeContext GetContext()
        {
            return _context;
        }
    }
}
