using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult ForgotPassword()
    {
        // Return the ForgotPassword view
        return View();
    }
}
