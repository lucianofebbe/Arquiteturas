namespace DTOs.Bases
{
    public record BaseResponse
    {
        public Guid guid { get; set; }
        public string Message { get; set; }
    }
}
