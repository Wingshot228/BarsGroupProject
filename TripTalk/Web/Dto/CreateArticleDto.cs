﻿namespace Web.Dto;

public class CreateArticleDto
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Text { get; set; }
    public string? PictureLink { get; set; }
}   