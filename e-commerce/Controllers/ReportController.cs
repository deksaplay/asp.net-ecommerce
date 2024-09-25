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

        [HttpGet]
        public async Task<IEnumerable<Report>> GetAll()
        {
            return await _reportService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Report> GetById(int id)
        {
            return await _reportService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Report> Create([FromBody] Report report)
        {
            return await _reportService.CreateAsync(report);
        }

        [HttpPut("{id}")]
        public async Task<Report> Update(int id, [FromBody] Report report)
        {
            report.Id = id;
            return await _reportService.UpdateAsync(report);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reportService.DeleteAsync(id);
            return NoContent();
        }
    }
}