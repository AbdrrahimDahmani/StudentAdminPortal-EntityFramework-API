using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using dt=StudentAdminPortal.API.DataModel;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using genderl=StudentAdminPortal.API.DomainModels.Gender;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class GendersController : Controller
    {
        private readonly IStudentRepository studentRepository;

        private readonly IMapper mapper;
        private readonly IStudentGender genderRepository;

        public GendersController(IStudentRepository studentRepository,IMapper mapper, IStudentGender genderRepository)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.genderRepository = genderRepository;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await studentRepository.GetGenderAsync();
            if (genderList == null || !genderList.Any())
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<dt.Gender>>(genderList));
        }
        [HttpGet]
        [Route("[controller]/{id:guid}")]
        public async Task<IActionResult> GetGender([FromRoute] Guid id)
        {
            var gender = await this.genderRepository.Get1GenderAsync(id);
            if (gender == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Gender>(gender)) ;
        }
        [HttpPost]
        [Route("[controller]/AddGender")]
        public async Task<IActionResult> PostGender([FromBody] AddGenderRequest request)
        {
            var gender = await studentRepository.AddGenderRequest(mapper.Map<dt.Gender>(request));
           return Ok( CreatedAtAction(nameof(GetAllGenders), new {genderId=gender.Id}, mapper.Map<genderl>(gender)));
        }
    }
}
