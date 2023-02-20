namespace Wiki.Api.Entities
{
    public class TextBlock
    {
        public int Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public string Header { get; set; } = string.Empty;
    }
}
