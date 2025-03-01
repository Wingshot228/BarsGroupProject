﻿using Core.CustomExceptions.Messages;
using FluentValidation;

namespace Core.Domains.Article.Validators;

public class ArticleValidator : AbstractValidator<Article>
{
    public ArticleValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty()
            .WithMessage(ValidationMessages.EmptyArticleTitle);
        RuleFor(a => a.Title)
            .MaximumLength(100)
            .WithMessage(ValidationMessages.TooLongArticleTitle);
        RuleFor(a => a.Title)
            .Matches(@"^[\w\s,.!?\""':;`\-\\/(\)]+$")
            .WithMessage(ValidationMessages.ArticleTitleContainsWrongSymbols);

        RuleFor(a => a.ShortDescription)
            .MaximumLength(400)
            .WithMessage(ValidationMessages.TooLongArticleDescription);

        RuleFor(a => a.Text)
            .NotEmpty()
            .WithMessage(ValidationMessages.EmptyArticleText);
        RuleFor(a => a.Text)
            .MinimumLength(500)
            .WithMessage(ValidationMessages.TooShortArticleText);
        RuleFor(a => a.Text)
            .MaximumLength(10000)
            .WithMessage(ValidationMessages.TooLongArticleText);
    }
}