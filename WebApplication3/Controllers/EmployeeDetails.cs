using CapitalPlacementProject.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApplication3.DTO;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetails : ControllerBase
    {
        private readonly CapitalDb _contextAccessor;

        public EmployeeDetails(CapitalDb contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HttpGet("GetTypeList")]
        public ActionResult GetTypeList()
        {
            try
            {
                var rng = _contextAccessor.EmployyeDetails.ToList();
                return Ok(rng.ToList());

            }
            catch (Exception ex)
            {
                
                return BadRequest($"Error: {ex.Message}");
            }
        }
        [HttpPost("AddEmployeeDetails")]
        public ActionResult AddEmployeeDetails([FromBody] EmployeeAdd model)
        {
            try
            {
                // Add the new EmpDetaild object to the database
                EmployyeDetail item = new EmployyeDetail();
                item.FirstName = model.FirstName;
                item.LastName   = model.LastName;
                item.Email = model.Email;
                item.Phone = model.Phone;
                item.Nationality = model.Nationality;
                item.CurrentResidence = model.CurrentResidence;
                item.Idnumber = model.Idnumber;
                item.DateOfbirth = model.DateOfbirth;
                item.Gender = model.Gender;
                
                _contextAccessor.EmployyeDetails.Add(item);

                // Save changes to the database
                _contextAccessor.SaveChanges();

                   foreach(var q in model.QueList)
                   {
                    
                           EmployeeAddition question = new EmployeeAddition();

                           question.QueId = q.QueId;
                           question.TypeId = q.TypeId;
                           question.EmpId = item.Id;
                               
                           _contextAccessor.EmployeeAdditions.Add(question);

                            // Save changes to the database
                           _contextAccessor.SaveChanges();
                    }

                return Ok("Data added successfully");
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpPost("AddQuestion")]
        public ActionResult AddQuestion([FromBody] QuestionDetail model)
        {
            try
            {
                
                Question item = new Question();
                item.Questions = model.Questions;
                item.TypeId = model.TypeId;
                item.CreatedDate = DateTime.Now;
                item.CreatedBy= model.CreatedBy;
                item.Deleted = 0;
                
                _contextAccessor.Questions.Add(item);

                // Save changes to the database
                _contextAccessor.SaveChanges();
                return Ok("Data added successfully");
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }
        [HttpPut("updateQuestion")]
        public ActionResult updateQuestion([FromBody] Question model)
        {
            try
            {
                var item = _contextAccessor.Questions.Where(x => x.Id == model.Id && x.Deleted == 0).FirstOrDefault();
                if (item != null)
                {
                    item.Questions = model.Questions;
                    item.TypeId = model.TypeId;
                    item.UpadtedDate = DateTime.Now;
                    item.UpadtedBy = model.CreatedBy;
                    item.Deleted = 0;
                }
                _contextAccessor.SaveChanges();
                

                return Ok("Data Updated successfully");
            }
            catch (Exception ex)
            {

                return BadRequest($"Error: {ex.Message}");
            }
        }
    }


}
