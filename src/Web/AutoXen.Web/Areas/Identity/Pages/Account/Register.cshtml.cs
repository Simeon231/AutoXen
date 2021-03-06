﻿namespace AutoXen.Web.Areas.Identity.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using AutoXen.Data.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Logging;

    [AllowAnonymous]
    public class Register : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<Register> logger;
        private readonly IEmailSender emailSender;

        public Register(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<Register> logger,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= this.Url.Content("~/");
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = this.Input.Email,
                    Email = this.Input.Email,
                    FirstName = this.Input.FirstName,
                    SurName = this.Input.SurName,
                    MiddleName = this.Input.MiddleName,
                    PhoneNumber = this.Input.PhoneNumber,
                    Address = this.Input.Address,
                };

                var result = await this.userManager.CreateAsync(user, this.Input.Password);
                if (result.Succeeded)
                {
                    this.logger.LogInformation("User created a new account with password.");

                    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = this.Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code, returnUrl },
                        protocol: this.Request.Scheme);

                    await this.emailSender.SendEmailAsync(
                        this.Input.Email,
                        "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (this.userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return this.RedirectToPage("RegisterConfirmation", new { email = this.Input.Email, returnUrl });
                    }
                    else
                    {
                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        return this.LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "EmailRequired")]
            [EmailAddress(ErrorMessage = "NotValidEmail")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "PasswordRequired")]
            [StringLength(100, ErrorMessage = "PasswordLength", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "ConfirmPassword")]
            [Compare("Password", ErrorMessage = "PasswordNotSame")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "FirstNameRequired")]
            [MinLength(2, ErrorMessage = "FirstNameMinLength")]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "SurNameRequired")]
            [MinLength(2, ErrorMessage = "SurNameMinLength")]
            [Display(Name = "SurName")]
            public string SurName { get; set; }

            [Required(ErrorMessage = "MiddleNameRequired")]
            [MinLength(2, ErrorMessage = "MiddleNameMinLength")]
            [Display(Name = "MiddleName")]
            public string MiddleName { get; set; }

            [Required(ErrorMessage = "PhoneNumberRequired")]
            [Phone(ErrorMessage = "NotValidPhoneNumber")]
            [Display(Name = "PhoneNumber")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "AddressRequired")]
            [MinLength(6, ErrorMessage = "AddressMinLength")]
            [Display(Name = "Address")]
            public string Address { get; set; }
        }
    }
}
