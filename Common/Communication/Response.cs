namespace Common.Communication
{
    public class Response
    {
        public object Result { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
    }
}
