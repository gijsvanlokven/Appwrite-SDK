using System;

namespace AppwriteSDK.Models
{
    public class AppwriteException : Exception
    {
        private int? _code;
        private string _response = null;

        public AppwriteException(string message = null, int? code = null, string response = null)
            : base(message)
        {
            this._code = code;
            this._response = response;
        }

        public AppwriteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}