namespace TeacherApp.Web.Models
{
    public enum ResponseTypes
    {
        Success,
        Danger
    }
    public class ResponseModel
    {
        public string ResponseMessage { get; set; }
        public ResponseTypes ResponseType { get; set; }
    }
}
