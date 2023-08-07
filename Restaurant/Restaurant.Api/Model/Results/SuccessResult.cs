namespace Restaurant.Api
{
    public class SuccessResult
    {
        public string Message => ServiceResultMessages.Ok;
        public string Description { get; set; }

        public SuccessResult(string description)
        {
            Description = description;
        }

        public static SuccessResult Create(string description)
        {
            return new SuccessResult(description);
        }
    }
}