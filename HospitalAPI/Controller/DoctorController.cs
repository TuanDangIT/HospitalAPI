using HospitalAPI.Abstractions;
using HospitalAPI.Entities;
using HospitalAPI.Features.Doctor.DeleteDoctorByPesel;
using HospitalAPI.Features.Doctor.GetAllDoctorsWithNumbers;
using HospitalAPI.Features.Doctor.GetDoctorByPeselWithNumbers;
using HospitalAPI.Features.Doctor.InsertDoctor;
using HospitalAPI.Features.Doctor.UpdateDoctorByPesel;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Route("/api/doctor")]
    public class DoctorController : ApiController
    {
        public DoctorController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctorsWithNumbers()
        {
            var result = await _mediator.Send(new GetAllDoctorsWithNumbersQuery());
            return Ok(result.Value) ;
        }
        [HttpGet("{pesel}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorByPeselWithNumbers([FromRoute]string pesel)
        {
            var result = await _mediator.Send(new GetDoctorByPeselWithNumbersQuery(pesel));
            return Ok(result.Value);
        }
        [HttpPost]
        public async Task<ActionResult> InsertDoctor([FromBody]InsertDoctorCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return HandleFailure(result);
            }
            return CreatedAtAction(nameof(GetDoctorByPeselWithNumbers), new { command.Pesel }, null);
        }
        [HttpPut("{pesel}")]
        public async Task<ActionResult> UpdateDoctorByPesel([FromBody] UpdateDoctorByPeselCommand command, [FromRoute]string pesel)
        {
            var result = await _mediator.Send(command with { Pesel = pesel});
            if (result.IsFailure)
            {
                return HandleFailure(result);
            }
            return NoContent();
        }
        [HttpDelete("{pesel}")]
        public async Task<ActionResult> DeleteDoctorByPesel([FromRoute] string pesel)
        {
            var result = await _mediator.Send(new DeleteDoctorByPeselCommand(pesel));
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return NoContent();
        }
    }
}
