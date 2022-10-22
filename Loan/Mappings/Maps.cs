using AutoMapper;
using AMS.Data;
using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Loan, LoanVM>().ReverseMap();
            CreateMap<Loan, EditLoanVM>().ReverseMap();
        }
    }
}
