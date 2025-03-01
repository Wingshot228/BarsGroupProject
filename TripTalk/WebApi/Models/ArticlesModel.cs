﻿using Core.Domains.Article;

namespace WebApi.Models;

public class ArticlesModel
{
    public List<Article> Articles { get; set; } = new();
    public int TotalCount { get; set; } = 0;
}