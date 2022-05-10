﻿using Core.CustomExceptions;
using Core.Domains.Comment.Services.Interfaces;
using Core.Domains.User.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    private readonly IUserService _userService;

    public CommentController(ICommentService commentService, IUserService userService)
    {
        _commentService = commentService;
        _userService = userService;
    }

    [HttpPost("Add")]
    public async Task Add(AddCommentDto commentDto)
    {
        var nickname = HttpContext.Items["UserNickname"]?.ToString() ?? throw new AuthorizationException();
        var userId = await _userService.GetUserIdByNicknameAsync(nickname);
        await _commentService.CreateCommentAsync(commentDto.Message, userId, commentDto.ArticleId);
    }

    [HttpPut("Edit")]
    public async Task Edit(EditCommentDto commentDto)
    {
        var nickname = HttpContext.Items["UserNickname"]?.ToString() ?? throw new AuthorizationException();
        var userId = await _userService.GetUserIdByNicknameAsync(nickname);
        await _commentService.EditCommentAsync(commentDto.CommentId, commentDto.Message);
        //TODO передавать сюда userId и проверять == ли оно владельцу коммента
    }

    [HttpDelete("Delete/{commentId:int}")]
    public async Task Delete(int commentId)
    {
        var nickname = HttpContext.Items["UserNickname"]?.ToString() ?? throw new AuthorizationException();
        var userId = await _userService.GetUserIdByNicknameAsync(nickname);
        await _commentService.DeleteCommentAsync(commentId);
        //TODO передавать сюда userId и проверять == ли оно владельцу коммента
    }
}