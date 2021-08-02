namespace Employees.Shared.Constants
{
    /// <summary>
    /// Constants class. Various useful constants that are shared between classes.
    /// </summary>
    public static class Constants
    {
        public const string BaseHostAdress = "https://gorest.co.in/public-api/users";
        public const string Bearer = "Bearer";
        public const string ResponseFormat = "application/json";
        public static string FirstPage = "1";
        public static string EditButtonAndColumName = "Edit";
        public static string DeleteButtonAndColumName = "Delete";
        public static int EditButtonColumn = 5;
        public static int DeleteButtonColumn = 6;
        public static int IdColumn = 0;
        public const string QuestionMarkHttpDelimeter = "?";
        public const string AndHttpDelimeter = "&";
        public const string EqualHttpDelimeter = "=";
        public const string SlashHttpDelimeter = "/";
        public const string ErrorMessageTitle = "Error Happened";
        public const int CacheKeyExpirationInSeconds = 10;
        public const string HttpConstantDelete = "DELETE";
        public const string MultipleNextLines = "\r\n \r\n \r\n";
    }
}