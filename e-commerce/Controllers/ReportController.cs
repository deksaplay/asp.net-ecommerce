using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_commerce.Controllers
{
    public class ReportController : BaseController
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        
       
    }
}