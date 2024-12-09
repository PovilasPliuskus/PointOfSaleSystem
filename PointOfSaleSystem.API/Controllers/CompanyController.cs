﻿using Microsoft.AspNetCore.Mvc;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Services.Interfaces;

namespace PointOfSaleSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("company")]
        public async Task<IActionResult> CreateCompany()
        {
            return Ok();
        }

        [HttpGet("company")]
        public async Task<IActionResult> GetCompanies()
        {
            List<Company> companies = _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetCompany(Guid companyId)
        {
            Company company = _companyService.GetCompany(companyId);
            return Ok(company);
        }

        [HttpPut("company/{companyId}")]
        public async Task<IActionResult> UpdateCompany()
        {
            return Ok();
        }

        [HttpDelete("company/{companyId}")]
        public async Task<IActionResult> DeleteCompany()
        {
            return Ok();
        }
    }
}