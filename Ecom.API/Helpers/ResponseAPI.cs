namespace Ecom.API.Helpers
{
    public class ResponseAPI
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ResponseAPI(int statusCode,string message=null)
        {
            StatusCode=statusCode;
            Message = message?? GetMessageByStatusCode(statusCode);
        }

        public String GetMessageByStatusCode(int SCode)
        {
            return SCode switch
            {
                200 => "Done",
                404 =>"NotFouned",
                400 =>"BadRequest",
                401 =>"Un Athorized",
                500 =>"Server Error",
                _=>"0"
            };
        }
    }
}
