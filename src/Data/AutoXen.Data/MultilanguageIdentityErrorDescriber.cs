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
            return new IdentityError { Code = nameof(this.DefaultError), Description = this.localizer["UnknownFailure"] };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError { Code = nameof(this.PasswordMismatch), Description = this.localizer["IncorrectPassword"] };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError { Code = nameof(this.InvalidToken), Description = this.localizer["InvalidToken"] };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError { Code = nameof(this.LoginAlreadyAssociated), Description = this.localizer["UserExist"] };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError { Code = nameof(this.InvalidEmail), Description = string.Format(this.localizer[$"InvalidEmail"], email) };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = nameof(this.DuplicateUserName), Description = string.Format(this.localizer["UserNameTaken"], userName) };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError { Code = nameof(this.DuplicateEmail), Description = string.Format(this.localizer["EmailTaken"], email) };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = nameof(this.PasswordTooShort), Description = string.Format(this.localizer["PasswordTooShort"], length) };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError { Code = nameof(this.PasswordRequiresNonAlphanumeric), Description = this.localizer["PasswordRequiresNonAlphanumeric"] };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError { Code = nameof(this.PasswordRequiresDigit), Description = this.localizer["PasswordRequiresDigit"] };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = nameof(this.PasswordRequiresLower), Description = this.localizer["PasswordRequiresLower"] };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = nameof(this.PasswordRequiresUpper), Description = this.localizer["PasswordRequiresUpper"] };
        }
    }
}
