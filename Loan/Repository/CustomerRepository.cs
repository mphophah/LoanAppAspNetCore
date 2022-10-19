using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Customer entity)
        {
            await _db.Customers.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Customer entity)
        {
            _db.Customers.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Customer>> FindAll()
        {
             var tenants = await _db.Customers.ToListAsync();
             return tenants;
        }

        public Task<Customer> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update(Customer entity)
        {
            _db.Customers.Update(entity);
            return await Save();
        }
    }

}
