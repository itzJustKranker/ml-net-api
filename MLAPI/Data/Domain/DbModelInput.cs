namespace MLAPI.Data.Models
{
    public class DbModelInput : BaseEntity
    {
        public bool Sentiment { get; set; }
        public string SentimentText { get; set; }
    }
}