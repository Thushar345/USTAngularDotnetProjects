using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingFromForm.Models;

namespace ModelBindingFromForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<UserModel> users = new List<UserModel>();
        [HttpGet]
        public ActionResult<List<UserModel>> GetUsers()
        {
            return Ok(users);
        }

        [HttpPost]
        // Handle the user data, e.g., save it to a database
        public async Task<IActionResult> CreateUser([FromForm] UserModel user)
        {
            if (user.ProfilePicture != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var filePath = Path.Combine(uploadsFolderPath, user.ProfilePicture.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await user.ProfilePicture.CopyToAsync(stream);
                }

                users.Add(user);
                // Handle the user data, e.g., save it to a database
                var response = new
                {
                    Success = true,
                    Message = $"User {user.Name} created successfully!",
                    ProfilePictureName = user?.ProfilePicture?.FileName,
                    Code = StatusCodes.Status200OK
                };
                return Ok(response);
            }
            return BadRequest(ModelState);
        }
    }
}
