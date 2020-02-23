using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Routine.Api.Entities;
using Routine.Api.Helpers;
using Routine.Api.Models;
using Routine.Api.Services;

namespace Routine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyCollectionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyCollectionController(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        [HttpGet("{ids}", Name = "GetCompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection(
            [FromRoute]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))]
            IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var entities = await _companyRepository.GetCompaniesAsync(ids);

            if (ids.Count() != entities.Count())
            {
                return NotFound();
            }

            var dto = _mapper.Map<IEnumerable<CompanyDto>>(entities);
            return Ok(dto);

        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> CreateCompany(IEnumerable<CompanyAddDto> companies)
        {
            var entities = _mapper.Map<IEnumerable<Company>>(companies);
            foreach (var company in entities)
            {
                _companyRepository.AddCompany(company);
            }

            await _companyRepository.SaveAsync();
            var dtoToReturn = _mapper.Map<IEnumerable<CompanyDto>>(entities);
            var idsString = string.Join(",", dtoToReturn.Select(x => x.Id));
            return CreatedAtRoute(nameof(GetCompanyCollection), new { ids = idsString }, dtoToReturn);
        }
    }
}