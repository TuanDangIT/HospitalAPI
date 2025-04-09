using HospitalAPI.Abstractions;
using HospitalAPI.Entities;
using HospitalAPI.Errors;
using HospitalAPI.Features.Visit.CreateVisit;
using HospitalAPI.Features.Visit.DeleteVisitById;
using HospitalAPI.Features.Visit.GetAllVisits;
using HospitalAPI.Features.Visit.UpdateVisitById;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("/api/visit")]
    public class VisitController : ApiController
    {
        public VisitController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> GetAllVisit([FromQuery]string pesel = "")
        {
            var result = await _mediator.Send(new GetAllVisitsQuery(pesel));
            return Ok(result.Value);
        }
        [HttpPost]
        public async Task<ActionResult> InsertVisit([FromBody]CreateVisitCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.IsFailure)
            {
                if(result.Error == PatientErrors.NotFound || result.Error == DoctorErrors.NotFound)
                {
                    return NotFound(result.Error);
                }
                return HandleFailure(result);
            }
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateVisit([FromRoute]int id,[FromBody]UpdateVisitByIdCommand command)
        {
            var result = await _mediator.Send(command with { Id = id});
            if (result.IsFailure)
            {
                if (result.Error == PatientErrors.NotFound || result.Error == DoctorErrors.NotFound || result.Error == VisitErrors.NotFound)
                {
                    return NotFound(result.Error);
                }
                return HandleFailure(result);
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteVisitById([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteVisitByIdCommand(id));
            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }
            return NoContent();
        }
        //[HttpGet("doctor/{pesel}")]
        //public async Task<ActionResult<Visit>> GetVisitByDoctorPesel([FromRoute]string pesel)
        //{

        //}
        //[HttpGet("patient/{pesel}")]
        //public async Task<ActionResult<Visit>> GetVisitByPatientPesel([FromRoute] string pesel)
        //{

        //}
    }
}
