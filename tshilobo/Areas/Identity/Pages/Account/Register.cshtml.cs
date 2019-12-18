using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using tshilobo.Data;
using tshilobo.Data.Services.AuthenticationRelated;

/// <summary>
/// Author      :       Bondo Kalombo   
/// Date        :       06/11/2018
/// </summary>
namespace tshilobo.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<tshiloboUser> _signInManager;
        private readonly UserManager<tshiloboUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        protected readonly IListItem _listItem;

        public RegisterModel(
            IListItem listItem,
            UserManager<tshiloboUser> userManager,
            SignInManager<tshiloboUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _listItem = listItem;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public SelectList Gender { get; set; }
        public SelectList Day { get; set; }
        public SelectList Month { get; set; }
        public SelectList Year { get; set; }

        [TempData]
        public string RegistrationStatusMessage { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Please enter your name.")]
            [DataType(DataType.Text)]
            [Display(Name = "Name")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Please enter your surname")]
            [DataType(DataType.Text)]
            [Display(Name = "Surname")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
            public string LastName { get; set; }

            [Display(Name = "Gender")]
            [Required(ErrorMessage = "Please select your gender.")]
            public string GenderId { get; set; }

            [Display(Name = "Birth Date")]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }           // Combines Day, Month, & Year into a date format

            /// <summary>
            /// Note: The fields GenderId, Day, Month, & Year were changed from int
            /// to string, because int is "strongly typed" as a result I could not
            /// customize the ErrorMessage, because it was defaulting to "The value " is invalid"
            /// </summary>            
            [Display(Name = "Day")]
            [Required(ErrorMessage = "Please select your day of birth.")]
            public string Day { get; set; }

            [Display(Name = "Month")]
            [Required(ErrorMessage = "Please select your month of birth.")]
            public string Month { get; set; }

            [Display(Name = "Year")]
            [Required(ErrorMessage = "Please select your year of birth.")]
            public string BirthYear { get; set; }

            [Required(ErrorMessage = "Please enter your email address.")]
            [EmailAddress(ErrorMessage = "The email address is invalid.")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Please enter a password.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Please enter a confirmation password.")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The Password and Confirmation Password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            // Setting this to null here, so that it doesn't show the same error message from OnPostAsync
            RegistrationStatusMessage = null;

            if (Gender == null || Day == null || Month == null || Year == null)
                Gender = _listItem.GetGenderAsync(); Day = _listItem.GetDayAsync(); Month = _listItem.GetMonthAsync(); Year = _listItem.GetYearAsync();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (Gender == null || Day == null || Month == null || Year == null)
                Gender = _listItem.GetGenderAsync(); Day = _listItem.GetDayAsync(); Month = _listItem.GetMonthAsync(); Year = _listItem.GetYearAsync();

            if (ModelState.IsValid)
            {
                if (DOBValidator())
                {
                    var user = new tshiloboUser
                    {
                        UserName = Input.Email,
                        Email = Input.Email,
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        GenderId = Convert.ToInt32(Input.GenderId),
                        DisplayName = Input.FirstName + " " + Input.LastName,
                        DateOfBirth = new DateTime(Convert.ToInt32(Input.BirthYear), Convert.ToInt32(Input.Month), Convert.ToInt32(Input.Day), 0, 0, 0)
                    };

                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {


                        //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                        // Setting confirmation link
                        //var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        //    new { _userId = user.Id, token = token }, Request.Scheme);

                        //_logger.Log(LogLevel.Warning, confirmationLink);

                        // Add user to default role
                        await _userManager.AddToRoleAsync(user, "AppUser");

                        _logger.LogInformation("User Created A New Account With Password.");

                        // Generate e-mail confirmation token
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        // Setting confirmation link
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { userId = user.Id, code = code },
                            protocol: Request.Scheme);

                        _logger.Log(LogLevel.Warning, callbackUrl);

                        await _emailSender.SendEmailAsync(Input.Email, "Confirm Your Email",
                            $"Please Confirm Your Account By <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Clicking Here</a>.");

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
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
                else
                {
                    RegistrationStatusMessage = "You provided an invalid date of birth.";
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        // Validates the Date Of Birth (Provided) and returns a boolean value
        private bool DOBValidator()
        {
            if (Convert.ToInt32(Input.Day) <= 30 && (Convert.ToInt32(Input.Month) == 4 || Convert.ToInt32(Input.Month) == 6
                    || Convert.ToInt32(Input.Month) == 9 || Convert.ToInt32(Input.Month) == 11))
            {
                return true;
            }
            else if ((Convert.ToInt32(Input.Day) <= 29) && (Convert.ToInt32(Input.Month) == 2) && (Convert.ToInt32(Input.BirthYear) % 4 == 0))
            {
                return true;
            }
            else if ((Convert.ToInt32(Input.Day) <= 28) && (Convert.ToInt32(Input.Month) == 2))
            {
                return true;
            }
            else if (Convert.ToInt32(Input.Day) <= 31 && (Convert.ToInt32(Input.Month) == 1 || Convert.ToInt32(Input.Month) == 3
               || Convert.ToInt32(Input.Month) == 5 || Convert.ToInt32(Input.Month) == 7 || Convert.ToInt32(Input.Month) == 8
               || Convert.ToInt32(Input.Month) == 10 || Convert.ToInt32(Input.Month) == 12))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
