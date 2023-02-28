using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BabbyNanny.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BabbyNanny.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<WebUser> _signInManager;
        private readonly UserManager<WebUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<WebUser> userManager,
            SignInManager<WebUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }
        //Dropdown lists
        public List<SelectListItem> Cities { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "City", Text = "Choose City" },
            new SelectListItem { Value = "Ankara", Text = "Ankara" },
            new SelectListItem { Value = "İstanbul", Text = "İstanbul" },
            new SelectListItem { Value = "İzmir", Text = "İzmir"  },
            new SelectListItem { Value = "Antalya", Text = "Antalya"  },
            new SelectListItem { Value = "Balıkesir", Text = "Balıkesir"  },
            new SelectListItem { Value = "Bursa", Text = "Bursa"  },
            new SelectListItem { Value = "Çanakkale", Text = "Çanakkale"  },
            new SelectListItem { Value = "Giresun", Text = "Giresun"  },
            new SelectListItem { Value = "Mersin", Text = "Mersin"  },
            new SelectListItem { Value = "Muğla", Text = "Muğla"  },
            new SelectListItem { Value = "Rize", Text = "Rize"  },
            new SelectListItem { Value = "Trabzon", Text = "Trabzon"  },
        };

        public List<SelectListItem> Genders { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "C", Text = "Choose Gender" },
            new SelectListItem { Value = "F", Text = "Female" },
            new SelectListItem { Value = "M", Text = "Male" },
            new SelectListItem { Value = "N", Text = "Not specified"  },
        };


        [BindProperty]
        public SingleFileUpload FileUpload { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Full name")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Birth Date")]
            [DataType(DataType.Date)]
            public DateTime DOB { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Gender")]
            public string Gender { get; set; }


            [Display(Name = "Picture")]
            public byte[] Picture { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var memoryStream = new MemoryStream();
                await FileUpload.FormFile.CopyToAsync(memoryStream);
                var user = new WebUser
                {
                    Name = Input.Name,
                    DOB = Input.DOB,
                    Gender = Input.Gender,
                    City = Input.City,
                    Picture = memoryStream.ToArray(),
                    UserName = Input.Email,
                    Email = Input.Email
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
