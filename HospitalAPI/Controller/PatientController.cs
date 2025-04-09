using HospitalAPI.Abstractions;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Entities;
using HospitalAPI.Errors;
using HospitalAPI.Features.Patient.DeletePatientByPesel;
using HospitalAPI.Features.Patient.GetAllPatients;
using HospitalAPI.Features.Patient.GetPatientByPesel;
using HospitalAPI.Features.Patient.InsertPatient;
using HospitalAPI.Features.Patient.UpdatePatientByPesel;
using HospitalAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Route("api/patient")]
    public class PatientController : ApiController
    {
        public PatientController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            var result = await _mediator.Send(new GetAllPatientsQuery());
            return Ok(result.Value);
        }
        [HttpGet("{pesel}")]
        public async Task<ActionResult<Patient>> GetPatientByPesel([FromRoute]string pesel)
        {
            var result = await _mediator.Send(new GetPatientByPeselQuery(pesel));
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return Ok(result.Value);
        }
        [HttpDelete("{pesel}")]
        public async Task<ActionResult> DeletePatientByPesel([FromRoute]string pesel)
        {
            var result = await _mediator.Send(new DeletePatientByPeselCommand(pesel));
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Patient>>> InsertPatient([FromBody]InsertPatientCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return HandleFailure(result);
            }
            return CreatedAtAction(nameof(GetPatientByPesel), new {command.Pesel}, null);
        }
        [HttpPut("{pesel}")]
        public async Task<ActionResult> UpdatePatientByPesel([FromBody]UpdatePatientByPeselCommand command, [FromRoute]string pesel)
        {
            var result = await _mediator.Send(command with { Pesel = pesel});
            if (result.IsFailure)
            {
                return HandleFailure(result);
            }
            return NoContent();
        }
    }
}
