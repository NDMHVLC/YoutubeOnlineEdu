using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validators.BlogCategory
{
	public class CreateBlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
	{
		public CreateBlogCategoryValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Blog category Adı Boş Geçilemez");
			RuleFor(x => x.Name).MaximumLength(30).WithMessage("Blog category Adı En Fazla 30 Karakter Olmalıdır");
		}
	}

}
