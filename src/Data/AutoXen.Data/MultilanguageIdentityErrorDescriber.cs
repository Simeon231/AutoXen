namespace AutoXen.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Localization;

    public class MultilanguageIdentityErrorDescriber : IdentityErrorDescriber
    {
        private readonly IStringLocalizer<MultilanguageIdentityErrorDescriber> localizer;

        public MultilanguageIdentityErrorDescriber(IStringLocalizer<MultilanguageIdentityErrorDescriber> localizer)
        {
            this.localizer = localizer;
        }

        public override IdentityError DefaultError()
        {
            return new IdentityError { Code = nameof(this.DefaultError), Description = $"An unknown failure has occurred." };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError { Code = nameof(this.PasswordMismatch), Description = "Incorrect password." };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError { Code = nameof(this.InvalidToken), Description = "Invalid token." };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError { Code = nameof(this.LoginAlreadyAssociated), Description = "A user with this login already exists." };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError { Code = nameof(this.InvalidUserName), Description = $"User name '{userName}' is invalid, can only contain letters or digits." };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError { Code = nameof(this.InvalidEmail), Description = $"Email '{email}' is invalid." };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = nameof(this.DuplicateUserName), Description = string.Format(this.localizer["UserName{0}Taken"], userName) };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = nameof(this.DuplicateEmail), Description = $"Email '{email}' is already taken." };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError { Code = nameof(this.InvalidRoleName), Description = $"Role name '{role}' is invalid." };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError { Code = nameof(this.DuplicateRoleName), Description = $"Role name '{role}' is already taken." };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError { Code = nameof(this.UserAlreadyHasPassword), Description = "User already has a password set." };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError { Code = nameof(this.UserAlreadyInRole), Description = $"User already in role '{role}'." };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError { Code = nameof(this.UserNotInRole), Description = $"User is not in role '{role}'." };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = nameof(this.PasswordTooShort), Description = $"Passwords must be at least {length} characters." };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError { Code = nameof(this.PasswordRequiresNonAlphanumeric), Description = "Passwords must have at least one non alphanumeric character." };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError { Code = nameof(this.PasswordRequiresDigit), Description = "Passwords must have at least one digit ('0'-'9')." };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = nameof(this.PasswordRequiresLower), Description = "Passwords must have at least one lowercase ('a'-'z')." };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = nameof(this.PasswordRequiresUpper), Description = "Passwords must have at least one uppercase ('A'-'Z')." };
        }
    }
}
