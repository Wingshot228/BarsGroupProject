﻿using Core;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Controllers;

public class ArticleController : Controller
{
    private const int ArticlesOnPage = 6;
    private readonly IArticleService _articleService;
    private readonly IUserService _userService;
    private readonly IRateService _rateService;
    private readonly IArticleCategoryService _articleCategoryService;
    private readonly ICommentService _commentService;

    public ArticleController(IArticleService articleService,
        IUserService userService,
        IRateService rateService,
        IArticleCategoryService articleCategoryService, 
        ICommentService commentService)
    {
        _articleService = articleService;
        _userService = userService;
        _rateService = rateService;
        _articleCategoryService = articleCategoryService;
        _commentService = commentService;
    }

    public async Task<ArticlePageModel> Index(int articleId)
    {
        var articleModel = new ArticlePageModel
        {
            Article = await _articleService.GetArticleByIdAsync(articleId),
            Comments = await _commentService.GetArticleCommentsAsync(articleId)
        };
        return articleModel;
    }

    [Authorize]
    public async Task Create(ArticleDto articleDto)
    {
        var user = User.Identity?.Name ?? throw new Exception(ErrorMessages.AuthError);
        var currentUserId = await _userService.GetUserIdByEmailAsync(user);
        await _articleService.CreateArticleAsync(articleDto.Title, articleDto.Text, currentUserId,
            articleDto.ShortDescription, articleDto.PictureLink);
    }

    [Authorize]
    public async Task AddRate(int articleId, Rate rate)
    {
        var user = User.Identity?.Name ?? throw new Exception(ErrorMessages.AuthError);
        var userId = await _userService.GetUserIdByEmailAsync(user);
        await _rateService.SetRateAsync(userId, articleId, rate);
    }


    //TODO добавить проверку, что пользователь является владельцем статьи
    [Authorize]
    public async Task<Article> Edit(int articleId)
    {
        return await _articleService.GetArticleByIdAsync(articleId);
    }

    //TODO добавить проверку, что пользователь является владельцем статьи
    [Authorize]
    [HttpPost]
    public async Task Edit(int articleId, ArticleDto article)
    {
        await _articleService.EditArticleAsync(articleId, article.Title, article.Text, article.ShortDescription,
            article.PictureLink);
    }

    public async Task<List<Article>> PopularArticles(CategoryArticleDto categoryDto) => 
        await GetCategoryArticles(Category.Popular, categoryDto);

    public async Task<List<Article>> BestArticles(CategoryArticleDto categoryDto) =>
        await GetCategoryArticles(Category.Best, categoryDto);

    public async Task<List<Article>> LatestArticles(CategoryArticleDto categoryDto) =>
        await GetCategoryArticles(Category.Last, categoryDto);

    private async Task<List<Article>> GetCategoryArticles(Category category, CategoryArticleDto categoryDto)
    {
        var firstElementIndex = ArticlesOnPage * (categoryDto.PageNumber - 1);
        return await _articleCategoryService.GetOrderedArticlesAsync(category, categoryDto.Period,
            ArticlesOnPage, firstElementIndex);
    }
}