namespace EventHandler.DTO
{
    public class ResourceDTO
    {
        public ResourceDTO(string id, string locale, string text)
        {
            Id = id;
            Locale = locale;
            Text = text;
        }

        public string Id { get; set; }
        public string Locale { get; set; }
        public string Text { get; set; }
    }
}
