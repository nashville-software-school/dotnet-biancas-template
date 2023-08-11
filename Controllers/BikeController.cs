using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BiancasBikes.Data;
using BiancasBikes.Models;

namespace BiancasBikes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BikeController : ControllerBase
{
    private BiancasBikesDbContext _dbContext;

    public BikeController(BiancasBikesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Bikes.Include(b => b.Owner).ToList());
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Bike bike = _dbContext
            .Bikes
            .Include(b => b.Owner)
            .Include(b => b.BikeType)
            .Include(b => b.WorkOrders)
            .Where(b => b.Id == id)
            .SingleOrDefault();

        if (bike == null)
        {
            return NotFound();
        }

        return Ok(bike);
    }

    [HttpGet("inventory")]
    [Authorize]
    public IActionResult Inventory()
    {
        int inventory = _dbContext
        .Bikes
        .Where(b => b.WorkOrders.Any(wo => wo.DateCompleted == null))
        .Count();

        return Ok(inventory);
    }


}