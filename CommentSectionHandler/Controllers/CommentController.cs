﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using ChatSystem.Hubs;
using Microsoft.AspNetCore.Identity;
using CommentSectionHandler.Models;
using System.Diagnostics.CodeAnalysis;

namespace ChatSystem.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly IHubContext<CommentHub> _commentHub;

        public CommentController([NotNull] IHubContext<CommentHub> commentHub)
        {
            _commentHub = commentHub;
        }


        //[HttpGet("/test")]
        //public string dunno()
        //{
        //    return "hey";
        //}

        [HttpPost("messages")]
        public async Task<IActionResult> Create([FromBody]ChatMessage message)
        {
            await _commentHub.Clients.All.SendAsync("ReceiveMessage", message);

            return Ok();
        }

    }
}
