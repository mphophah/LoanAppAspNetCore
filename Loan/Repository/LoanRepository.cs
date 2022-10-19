using AMS.Contracts;
using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository
{
    public class LoanRepository : GenericRepository<Loan>, ILoan
    {
        private readonly ApplicationDbContext _db;

        public LoanRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public Task<ICollection<Loan>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Loan> FindById(int id)
        {
            throw new System.NotImplementedException();
        }


        public Task<bool> isExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Loan>> mpho()
        {
            var loans = _db.Loans.Include(x => x.Customer).ToListAsync();

            return await loans;
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IRepositoryBase<Loan>.Create(Loan entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepositoryBase<Loan>.Delete(Loan entity)
        {
            throw new NotImplementedException();
        }


        Task<bool> IRepositoryBase<Loan>.Update(Loan entity)
        {
            throw new NotImplementedException();
        }
    }
}
