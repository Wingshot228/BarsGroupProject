﻿using Core.Models;

namespace Core.RepositoryInterfaces;

public interface IArticleRepository
{
    public Task<List<Article>> GetOrderedArticlesAsync(Category category, Period period, int count, int firstIndex);

    public Task<List<Article>> GetFilteredArticlesAsync(string searchLine, List<string>? tags, int count, int firstIndex);

    public Task<List<Article>> GetUserArticlesAsync(int userId, int count, int firstIndex);

    public Task<Article> GetArticleByIdAsync(int id);

    public Task AddArticleAsync(Article article);

    public Task UpdateArticleAsync(Article article);

    public Task RemoveArticleAsync(int id);
}