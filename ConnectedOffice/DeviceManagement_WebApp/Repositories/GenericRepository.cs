using DeviceManagement_WebApp.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq;
using NuGet.Protocol.Plugins;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement_WebApp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChangesAsync();
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(Guid? id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChangesAsync();
        }
        public bool DoesEntityAlreadyExist(Guid id)
        {
            T entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                return false;
            }

            if(entity.GetType() == typeof(Device))
            {
                var device = entity as Device;
                return AreTheSame(id, device.DeviceId);

            } else if (entity.GetType() == typeof(Zone))
            {
                var zone = entity as Zone;
                return AreTheSame(id, zone.ZoneId);

            } else if (entity.GetType() == typeof(Category))
            {
                var categgory = entity as Category;
                return AreTheSame(id, categgory.CategoryId);
            }
            else
            {
                return false;
            }

        }
        public bool AreTheSame(Guid id, Guid entityID)
        {
            if(entityID == id)
            {
                return true;
            }

            return false;
        }

    }
}
