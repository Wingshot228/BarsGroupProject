﻿using Core.Models;
using Core.RepositoryInterfaces;

namespace Core.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ArticleService(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
    {
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Article>> GetCategoryArticlesAsync(IArticleService.Category category, IArticleService.Period period, int first, int count)
    {
        return await _articleRepository.GetCategoryArticlesAsync(category, period, first, count);
    }

    public async Task<List<Article>> GetUserArticlesAsync(int userId, int first, int count)
    {
        return await _articleRepository.GetUserArticlesAsync(userId, first, count);
    }

    public async Task<Article> GetArticleByIdAsync(int articleId)
    {
        return await _articleRepository.GetArticleByIdAsync(articleId);
    }

    //TODO добавить валидацию
    public async Task CreateArticleAsync(string title, string shortDescription, string text, string? pictureLink, int userId)
    {
        var article = new Article
        {
            Title = title,
            ShortDescription = shortDescription,
            Text = text,
            PictureLink = pictureLink,
            UploadDate = DateTime.Now,
            UserId = userId
        };

        await _articleRepository.CreateArticleAsync(article);
        await _unitOfWork.SaveChangesAsync();
    }

    //TODO добавить валидацию
    public async Task EditArticleAsync(int articleId, string title, string shortDescription, string text, string? pictureLink)
    {
        var article = new Article
        {
            Id = articleId,
            Title = title,
            ShortDescription = shortDescription,
            Text = text,
            PictureLink = pictureLink,
        };

        await _articleRepository.UpdateArticleAsync(article);
        await _unitOfWork.SaveChangesAsync();
    }
}