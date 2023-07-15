using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.Models.DTO;
using Movies.Models.Domain;
using Movies.Repositories.Abstract;

namespace Movies.Controllers
{
	public class UserAuthenticationController : Controller
	{
		private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
		{
			this.authService = authService;
		}
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            //if (!ModelState.IsValid) { return View(model); }
            var newmodel = new RegistrationModel
           {
                Email =model.Email,
                Username = model.Username,
                Name = model.Name,
                Password = model.Password,
                PasswordConfirm = model.Password,
                Role = "User"
            };
            var result = await authService.RegisterAsync(newmodel);
            if (result.StatusCode == 1)
                return RedirectToAction("Login", "UserAuthentication");
            else
            {
                TempData["msg"] = "Error Creating Account!.";
                return RedirectToAction(nameof(Registration));
            }
        }

        //since there is only one Admin this function is used to create an admin and than commented

        //public async Task<IActionResult> RegisterAdmin()
        //{
        //   var model = new RegistrationModel
        //   {
        //   Email = "admin@gmail.com",
        //    Username = "User",
        //   Name = "Mohammad",
        //    Password = "Admin@123",
        //    PasswordConfirm = "Admin@123",
        //   Role = "Admin"
        //};
        //var result = await authService.RegisterAsync(model);
        //return Ok(result.Message);
        //}
        public async Task<IActionResult> Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var result = await authService.LoginAsync(model);
			if (result.StatusCode == 1)
				return RedirectToAction("Index", "Home");
			else
			{
				TempData["msg"] = "Could not logged in..";
				return RedirectToAction(nameof(Login));
			}
		}

		public async Task<IActionResult> Logout()
		{
			await authService.LogoutAsync();
			return RedirectToAction(nameof(Login));
		}

	}
}
