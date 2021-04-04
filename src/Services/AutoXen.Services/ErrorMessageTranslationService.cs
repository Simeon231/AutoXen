namespace AutoXen.Services
{
    using Microsoft.Extensions.Localization;

    // TODO add interface
    public class ErrorMessageTranslationService
    {
        private readonly IStringLocalizer<ErrorMessageTranslationService> sharedLocalizer;

        public ErrorMessageTranslationService(IStringLocalizer<ErrorMessageTranslationService> sharedLocalizer)
        {
            this.sharedLocalizer = sharedLocalizer;
        }

        public string GetLocalizedError(string errorKey)
        {
            return this.sharedLocalizer[errorKey];
        }
    }
}
