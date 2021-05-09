#nullable enable

namespace Cryptage.Commons.Util
{
    public struct Error
    {
        public readonly string Message;
        public readonly string Source;
        public readonly string? Details;

        public readonly bool IsDetails;


        public Error(string message, string source, string? details)
        {
            this.Message = message;
            this.Source = source;
            this.Details = details;

            this.IsDetails = details is not null;
        }
    }
}