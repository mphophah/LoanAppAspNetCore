using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Tenants.Controllers
{

    [Authorize(Roles ="Administrator")]
    public class CustomersController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CustomersController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IWebHostEnvironment webHostEnvironment

                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            var tenants = await _unitOfWork.Customers.FindAll();
            var model = _mapper.Map<List<Customer>, List<CustomerVM>>(tenants.ToList());
            return View(model);
        }


        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Customer/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Create(CustomerVM model)
        {
            try
            {
                
                var tenant = _mapper.Map<Customer>(model);


                await _unitOfWork.Customers.Create(tenant);

                await _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError(ex.Message,"");
                return View();
            }

        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Customers.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var tenant = await _unitOfWork.Customers.Find(q => q.Id == id);
            var model = _mapper.Map<CustomerVM>(tenant);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomerVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var tenant = _mapper.Map<Customer>(model);
                _unitOfWork.Customers.Update(tenant);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var tenant = await _unitOfWork.Customers.Find(expression: q => q.Id == id);
                if (tenant == null)
                {
                    return NotFound();
                }
                _unitOfWork.Customers.Delete(tenant);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Customers.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var tenant = await _unitOfWork.Customers.Find(q => q.Id == id);
            var model = _mapper.Map<CustomerVM>(tenant);
            return View(model);
        }


    }
}
