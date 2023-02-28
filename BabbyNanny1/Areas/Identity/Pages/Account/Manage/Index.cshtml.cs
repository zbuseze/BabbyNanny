using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BabbyNanny.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BabbyNanny.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly SignInManager<WebUser> _signInManager;

        public IndexModel(
            UserManager<WebUser> userManager,
            SignInManager<WebUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        public byte[] ProfilePicture { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

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
        public SingleFileUploadUpdate FileUpload { get; set; }
        
        [BindProperty]
        public InputModel Input { get; set; }

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
            public byte[] Picture
            {
                get; set;
            }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }


        }

        private async Task LoadAsync(WebUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            ProfilePicture = user.Picture;
            Input = new InputModel
            {
                Name = user.Name,
                DOB = user.DOB,
                Gender = user.Gender,
                City = user.City,
                PhoneNumber = phoneNumber

            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }

            }

            //code without exception handling
            //var memoryStream = new MemoryStream();
            //await FileUpload.FormFile.CopyToAsync(memoryStream);
            //user.Picture = memoryStream.ToArray();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    await FileUpload.FormFile.CopyToAsync(memoryStream);
                    if (memoryStream.Length > 0 && memoryStream.ToArray() != user.Picture)
                    {
                        user.Picture = memoryStream.ToArray();
                    }
                }
                catch (NullReferenceException)
                {
                    //You can write error log to the database here
                }
            }
            
            if (Input.Name != user.Name)
            {
                user.Name = Input.Name;
            }

            if (Input.DOB != user.DOB)
            {
                user.DOB = Input.DOB;
            }

            if (Input.Gender != user.Gender)
            {
                user.Gender = Input.Gender;
            }

            if (Input.City != user.City)
            {
                user.City = Input.City;
            }

            //update database (newly added!)
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                StatusMessage = "Your profile has been updated";
            }
            return RedirectToPage();
        }
    }
}
