using ApplicationLayer.Validations;
using FluentValidation;

namespace ApplicationLayer.Features.Students.Helper
{
    public class AddInfoDTOValidator : BaseInfoValidator<InfoDTO>
    {
        #region Fields
        //private readonly IPersonExistsService _service;

        #endregion

        #region Constructor(s)
        /* public AddInfoDTOValidator(IPersonExistsService service) : base()
         {
             _service = service;

             ApplyAddValidationrules();

         }*/
        public AddInfoDTOValidator() : base()
        {


            ApplyAddValidationrules();

        }

        #endregion

        #region Actions
        public void ApplyAddValidationrules()
        {

            NationalNoValidation();

            // UniqueNationalNoConstraint();

            ImagePathValidation();

        }

        private void NationalNoValidation()
           => RuleFor(c => c.NationalNO).ApplyNumericRuleWithFixedLength(10).ApplyNotEmptyRule().ApplyNotNullableRule();

        // Apply the following rules only if ImagePath is not null
        private void ImagePathValidation()
        {
            RuleFor(x => x.ImagePath)
             .Cascade(CascadeMode.Stop)
             .Must(path => path == null || IsValidPathFormat(path))
             .WithMessage("ImagePath must start with a valid path structure (e.g., drive letter followed by ':/').")
             .When(x => x.ImagePath != null)
             .Matches(@"^[A-Za-z0-9/:./_-]*$").WithMessage("ImagePath contains invalid characters.")
             .Must(path => path == null || HasValidImageExtension(path))
             .WithMessage("ImagePath must end with a valid image extension (.jpg, .jpeg, .png, .gif, .bmp, .tiff).");

        }

        // Move to service layer
        // begin
        //private void UniqueNationalNoConstraint()
        //    => RuleFor(c => c.NationalNO)
        //    .MustAsync
        //    (
        //        async (NationalNo, cancellationToken)
        //        => !await _service.IsExistsByNationalNo(NationalNo)

        //    ).WithMessage(c => $"A National No number {c.NationalNO} already exists!");
        // end

        #endregion

        #region Abstraction 

        private bool IsValidPathFormat(string path)
            => System.Text.RegularExpressions.Regex.IsMatch(path, @"^[A-Za-z0-9]:/");

        private bool HasValidImageExtension(string path)
        {
            // Define allowed image extensions in a HashSet for fast lookup
            var validExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff"
            };

            // Check if the path ends with any valid extension
            return validExtensions.Any(ext => path.EndsWith(ext));
        }

        #endregion

    }
}
