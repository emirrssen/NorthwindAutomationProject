using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        IReplyService _replyService;

        public RepliesController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        [HttpPost("Add")]
        public IActionResult AddReply(Reply reply)
        {
            var result = _replyService.AddReply(reply);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteReply(Reply reply)
        {
            var result = _replyService.DeleteReply(reply);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult UpdateReply(Reply reply)
        {
            var result = _replyService.UpdateReply(reply);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllReplies()
        {
            var result = _replyService.GetAllReplies();
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetReplyById(int replyId)
        {
            var result = _replyService.GetReplyById(replyId);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByCommentId")]
        public IActionResult GetRepliesByCommentId(int commentId)
        {
            var result = _replyService.GetRepliesByCommentId(commentId);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
