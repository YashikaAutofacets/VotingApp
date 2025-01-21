using Microsoft.AspNetCore.Mvc;
using VotingApp.Data;
using VotingApp.Models;

namespace VotingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotingController : ControllerBase
    {
        private readonly VotingContext _context;

        public VotingController(VotingContext context)
        {
            _context = context;
        }

        [HttpGet("voters")]
        public IActionResult GetVoters()
        {
            return Ok(_context.Voters.ToList());
        }

        [HttpGet("candidates")]
        public IActionResult GetCandidates()
        {
            return Ok(_context.Candidates.ToList());
        }

        [HttpPost("vote")]
        public IActionResult Vote(int voterId, int candidateId)
        {
            var voter = _context.Voters.Find(voterId);
            var candidate = _context.Candidates.Find(candidateId);

            if (voter == null || candidate == null || voter.HasVoted)
                return BadRequest();

            voter.HasVoted = true;
            candidate.Votes += 1;

            _context.SaveChanges();
            return Ok();
        }
    }
}