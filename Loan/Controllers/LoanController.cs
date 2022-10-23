using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Microsoft.AspNetCore.Identity;

namespace AMS.Controllers
{
    [Authorize]
    public class LoanController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public LoanController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
           // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Loans.Include(x => x.Customer).ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var Customers = await _unitOfWork.Customers.FindAll();

            var CustomersD = Customers.Select(q => new SelectListItem
            {
                Text = q.FirstName + " " + q.LastName,
                Value = q.Id.ToString()
            });

            var model = new LoanVM
            {
                CustomerList = CustomersD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoanVM model)
        {
            decimal totalAmount = 0;
            double interestRate = 0;
            string loanType = model.LoanType;

            if (loanType == "personal")
                interestRate = 0.25;
            else if (loanType == "home")
                interestRate = 0.10;
            else if (loanType == "vehicle")
                interestRate = 0.15;
            else
                interestRate = 0;

            totalAmount = model.Amount + (decimal)(interestRate) * model.Amount;

            try
            {

                var LoanModel = new LoanVM
                {
                    LoanType = model.LoanType,
                    LoanTerm = model.LoanTerm,
                    InterestRate = (decimal)(interestRate)*100,
                    Amount = model.Amount,
                    TotalAmount = totalAmount,
                    CustomerId = model.CustomerId,

                };

                var loans = _mapper.Map<Loan>(LoanModel);
                await _unitOfWork.Loans.Create(loans);
                await _unitOfWork.Save();


                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "");
                return View(model);
            }
        }

        // GET: Loan/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var loanApp = await _unitOfWork.Loans.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer));
       
            var model = _mapper.Map<EditLoanVM>(loanApp);

            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "FirstName", model.CustomerId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( LoanVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                // var record = await _unitOfWork.Loans.Find(q => q.Id == model.Id, includes: q => q.Include(x => x.Customer));
              //  var record = await _unitOfWork.Loans.Find(q => q.Id == model.Id);
                var loans = _mapper.Map<Loan>(model);
                _unitOfWork.Loans.Update(loans);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

      /*  // GET: LeaveAllocation/Details/5
        public async Task<ActionResult> Details(string id)
        {

            var records = await _unitOfWork.Loans.FindAll(
                expression: q => q.CustomerId.ToString() == id,
                includes: q => q.Include(x => x.LeaveType));

            var allocations = _mapper.Map<List<LoanVM>>
                    (records);

            var model = new ViewAllocationsVM
            {
                Employee = employee,
                LeaveAllocations = allocations
            };
            return View(model);
        }
      */

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var loans = await _unitOfWork.Loans.Find(expression: q => q.Id == id);
                if (loans == null)
                {
                    return NotFound();
                }
                _unitOfWork.Loans.Delete(loans);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Loan/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Loans.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var loans = await _unitOfWork.Loans.Find(q => q.Id == id);
            var model = _mapper.Map<LoanVM>(loans);
            return View(model);
        }


    }
}
