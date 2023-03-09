using System;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    // this controller depends on the NorthwindRepository
    private NorthwindContext _dataContext;
    public HomeController(NorthwindContext db) => _dataContext = db;
    public ActionResult Index() => View(_dataContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now).Take(3));
}