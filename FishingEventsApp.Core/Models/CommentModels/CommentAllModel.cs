namespace FishingEventsApp.Core.Models.CommentModels
{
    public class CommentAllModel
    {
        public int Id { get; set; }
        public string CommentText { get; set; } = null!;
        public string CreatedOn { get; set; } = null!;
        public string AuthorId { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public int FishingEventId { get; set; }
        public bool IsAuthor { get; set; }
    }
}
