using Microsoft.AspNetCore.Mvc;

public class CustomerController : Controller
{
    private NorthwindContext _northwindContext;
    public CustomerController(NorthwindContext db) => _northwindContext = db;

    public IActionResult Register() => View();

    [HttpPost]
    // [ValidateAntiForgeryToken]
    public IActionResult Register(Customer customer)
    {
        if (ModelState.IsValid)
        {
            if (_northwindContext.Customers.Any(c => c.CompanyName == customer.CompanyName))
            {
                ModelState.AddModelError("", "'Company Name' must be unique");
            }
            else
            {
                _northwindContext.Add(customer);
                _northwindContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
        return View();
    }
}