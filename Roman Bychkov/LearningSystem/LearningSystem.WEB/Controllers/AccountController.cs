
namespace LearningSystem.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private IUsersServices _service;
        private IConfiguration _configuration;
        private IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, IUsersServices service, IConfiguration configuration, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            ViewBag.Active = "login";
            return View();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            ViewBag.Active = "login";

            if (await _service.GetValueByСonditionAsync(u => u.UserName, model.UserName) is null)
            {
                ModelState.AddModelError(nameof(model.UserName), "Такого акаунта не існує");
                return View(model);
            }
            var user = await _service.GetUserByLoginPasswordAsync(model.UserName, model.Password);
            if (user is null)
            {
                ModelState.AddModelError(nameof(model.Password), "Пароль не вірний");
                return View(model);
            }
            if (ModelState.IsValid)
            {

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                }),
                    Expires = DateTime.UtcNow.AddDays(3),
                    Issuer = "myapp",
                    Audience = "myapp",
                    SigningCredentials = new SigningCredentials(
                     new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt_Key"])),
                     SecurityAlgorithms.HmacSha512Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                HttpContext.Session.SetString("Token", jwtToken);

                _logger.LogInformation("{User} is logged. code-{Code}", User.Identity.Name, RepoLogEvents.LoginUser);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            ViewBag.Active = "registration";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            ViewBag.Active = "registration";

            if (await _service.GetValueByСonditionAsync(u => u.Email, model.Email) != null)
            {
                ModelState.AddModelError(nameof(model.Email), "Користувач з такою поштою вже існує");
                return View(model);
            }
            if (await _service.GetValueByСonditionAsync(u => u.UserName, model.UserName) != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "Користувач з таким іменем вже існує");
                return View(model);
            }


            if (ModelState.IsValid)
            {
                var user = new User();
                user = _mapper.Map<User>(model);
                await _service.AddAsync(user);
                _logger.LogInformation("{User} has registered. code-{Code}", User.Identity.Name, RepoLogEvents.RegistrationUser);
                return await Login(new LoginModel() { UserName = model.UserName, Password = model.Password });
            }
            else
                return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Profile(string name)
        {
            if (name == User.Identity.Name)
            {
                ViewBag.Owner = true;
            }
            var user = await _service.GetValueByСonditionAsync(u => u.UserName, name);
            if (user == null)
                return NotFound();
            return View(user);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upload()
        {
            MyLogger.CheckFreeSpaceOnDisk(_logger);
              
          
            var files = Request.Form.Files;
            var file = files[0];
            string type = Path.GetExtension(file.FileName);
            if (!(type == ".jpeg" || type == ".jpg" || type == ".png"))
            { 
                return BadRequest("Допустимі формати: png, jpg, jpeg");
            }


            if (file.Length > 500000 || file.Length == 0)
            {
                return BadRequest("Файл повинен бути розміром до 500КБ");
            }

            var result = await _service.AddImage("imageProfile", User?.Identity?.Name, file);
            _logger.LogInformation("{User} added image to profile. code-{Code}", User.Identity.Name, RepoLogEvents.UploadImageProfile);
            return Ok(result);
        }

    }
}