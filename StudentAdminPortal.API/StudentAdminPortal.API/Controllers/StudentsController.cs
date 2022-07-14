using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using dm = StudentAdminPortal.API.DataModel;
namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private readonly IImageRepository imageRepository;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper,
            IImageRepository imageRepository)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.imageRepository = imageRepository;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<Student>>(students));
        }
        [HttpGet]
        [Route("[controller]/{studentId:guid}"),ActionName("GetStudentAsync")]
        public async Task<IActionResult>GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudentAsync(studentId);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Student>(student));
        }
        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId,
            [FromBody] UpdateStudentRequest request)
        {
            
            if(await studentRepository.Exists(studentId))
            {
                var updateStudent = await studentRepository.UpdateStudentAsync(studentId, mapper.Map<DataModel.Student>(request));
                if(updateStudent != null)
                {
                    return Ok(mapper.Map<Student>( updateStudent));
                }
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public  async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if(await studentRepository.Exists(studentId))
            {
                var student = await studentRepository.DeleteStudent(studentId);
                return Ok(mapper.Map<Student>(student));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody]AddStudentRequest request)
        {
            var student = await studentRepository.AddStudentRequest(mapper.Map<dm.Student>(request));
            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = student.Id},
                mapper.Map<Student>(student));
        }
        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImageAsync([FromRoute]Guid studentId,IFormFile profileImage)
        {
            if(profileImage != null && profileImage.Length>0)
            {
                var validExtension = new List<string>{
                    ".jpeg",
                    ".jpg",
                    ".png",
                    ".jfif",
                    ".gif"
                };
                var extension =Path.GetExtension(profileImage.FileName);
                if (validExtension.Contains(extension))
                {
                    if (await studentRepository.Exists(studentId))
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);
                        await imageRepository.Upload(profileImage, fileName);
                        var fileImagePath = await imageRepository.Upload(profileImage, fileName);
                        if (await studentRepository.UpdateProfileImage(studentId, fileImagePath))
                        {
                            return Ok(fileImagePath);
                        }
                        return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
                    }
                }

                return BadRequest("Please use another extension");
            }
            return NotFound();
        }
    }
    

   
}
