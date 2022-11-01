using Microsoft.AspNetCore.Mvc;
using RookiesWebAPI.Models;
using RookiesWebAPI.Service;

namespace RookiesWebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly ILogger<PersonController> _logger;
    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }
    [HttpGet("")]
    public IEnumerable<PersonDetailModel> GetAll()
    {
        var data = _personService.GetAll();
        return from item in data
               select new PersonDetailModel
               {
                   FirstName = item.FirstName,
                   LastName = item.LastName,
                   Gender = item.Gender,
                   DateOfBirth = item.DateOfBirth,
                   Phone = item.Phone,
                   BirthPlace = item.BirthPlace
               };
    }
    [HttpGet("{index:int}")]
    public IActionResult GetOne(int index)
    {
        try
        {
            var data = _personService.GetOne(index);
            if (data == null)
            {
                return NotFound();
            }
            return new JsonResult(new PersonDetailModel
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Gender = data.Gender,
                DateOfBirth = data.DateOfBirth,
                Phone = data.Phone,
                BirthPlace = data.BirthPlace
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPost("")]
    public IActionResult Create(PersonCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest();
        try
        {
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                Phone = model.Phone,
                BirthPlace = model.BirthPlace,
                IsGraduated = false
            };
            var result = _personService.Create(person);

            return StatusCode(StatusCodes.Status201Created, result);
        }
        catch (Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpPut("{index:int}")]
    public IActionResult Update(int index, PersonUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var data = _personService.GetOne(index);
            if (data == null) { return NotFound(); }

            data.FirstName = model.FirstName;
            data.LastName = model.LastName;
            data.Phone = model.Phone;
            data.BirthPlace = model.BirthPlace;

            var result = _personService.Update(index, data);

            return new JsonResult(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
    [HttpDelete("{index:int}")]
    public IActionResult Delete(int index)
    {
        try
        {
            var data = _personService.GetOne(index);
            if (data == null) { return NotFound(); }

            var result = _personService.Delete(index);

            return new JsonResult(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}