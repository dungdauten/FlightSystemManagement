namespace FlightSystemManagementAPI.Models.DTO
{
    public class Response
    {
        public bool isSucess { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
