using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Dtos.Comment;
using FirstApi.Extensions;
using FirstApi.Interfaces;
using FirstApi.Mappers;
using FirstApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepo;
        private readonly IFMPService _fmpService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentRepository commentRepository, 
                                 IStockRepository stockRepository,
                                 IFMPService fmpService, 
                                 UserManager<AppUser> userManager)
        {
            _commentRepository = commentRepository;
            _stockRepo = stockRepository;
            _fmpService = fmpService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comments = await _commentRepository.GetAllAsync();

            var commentsDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var comment = await _commentRepository.GetByIdAsync(id);

            if(comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{symbol:alpha}")]
        public async Task<IActionResult> Create([FromRoute] string symbol, CreateCommentDto commentDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockRepo.GetBySymbolAsync(symbol);

            if(stock == null)
            {
                stock = await _fmpService.FindStockBySymbolAsync(symbol);

                if(stock == null)
                {
                    return BadRequest("This stock does not exist");
                }
                else
                {
                    await _stockRepo.CreateAsync(stock);
                }
            }

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            
            var commentModel = commentDto.ToCommentFromCreate(stock.Id);
            commentModel.AppUserId = appUser.Id;
            
            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new {id = commentModel.Id}, commentModel.ToCommentDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateCommentDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepository.UpdateAsync(id, updateCommentDto.ToCommentFromUpdate());

            if(comment == null)
            {
                return NotFound("Comment not found");
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepository.DeleteAsync(id);

            if(comment == null)
            {
                return NotFound("Comment not found");
            }

            return NoContent();
        }
    }
}