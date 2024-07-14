using AutoMapper;
using CycleSyncHub.Application.Bike.Commands.EditBike;
using CycleSyncHub.Application.Bike.Queries.GetAllBikes;
using CycleSyncHub.Application.Bike.Queries.GetBikeByEncodedName;
using CycleSyncHub.Application.BikeInfo.Commands;
using CycleSyncHub.Application.BikeInfo.Queries.GetBikeInfos;
using CycleSyncHub.Application.Commands.CreateBike;
using CycleSyncHub.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class BikeController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BikeController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var bikes = await _mediator.Send(new GetAllBikesQuery());
        return View(bikes);
    }

    [Route("Bike/{encodedName}/Details")]
    [Authorize]
    public async Task<IActionResult> Details(string encodedName)
    {
        var dto = await _mediator.Send(new GetBikeByEncodedNameQuery(encodedName));
        return View(dto);
    }

    [Route("Bike/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetBikeByEncodedNameQuery(encodedName));

        if (!dto.IsEditable)
        {
            return RedirectToAction("NoAccess", "Home");
        }

        EditBikeCommand model = _mapper.Map<EditBikeCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("Bike/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditBikeCommand command)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage); 
            }
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Owner")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Owner")]
    public async Task<IActionResult> Create(CreateBikeCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);

        this.SetNotification("success", $"Created bike: {command.Model}");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Authorize(Roles = "Owner")]
    [Route("Bike/BikeInfo")]
    public async Task<IActionResult> CreateBikeInfo(CreateBikeInfoCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _mediator.Send(command);

        return Ok();
    }

    [HttpGet]
    [Route("Bike/{encodedName}/BikeInfo")]
    public async Task<IActionResult> GetBikeInfos(string encodedName)
    {
        var data = await _mediator.Send(new GetBikeInfosQuery() { EncodedName = encodedName });
        return Ok(data);
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    [Route("Bike/{encodedName}/Delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        var bike = await _mediator.Send(new GetBikeByEncodedNameQuery(encodedName));
        if (bike == null)
        {
            return NotFound();
        }

        var model = new DeleteBikeCommand(encodedName);

        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = "Owner")]
    [Route("Bike/Delete")]
    public async Task<IActionResult> DeleteConfirmed(DeleteBikeCommand command)
    {
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}

