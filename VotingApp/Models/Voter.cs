namespace VotingApp.Models
{
    public class Voter
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool HasVoted { get; set; }
    }
}
