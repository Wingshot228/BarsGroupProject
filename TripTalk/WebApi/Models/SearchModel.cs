﻿using Core.Models;

namespace WebApi.Models;

public class SearchArticlesModel
{
    public List<Article> SearchedArticles { get; set; } = new();
}