using System;
namespace WebPasarelaNiubiz.Models
{
	public class TokenCreated
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public Key[] keys { get; set; }
        public int expiresIn { get; set; }
        public object idToken { get; set; }
        public object tokenType { get; set; }
        public object[] groups { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Key
    {
        public string token { get; set; }
        public string baseKey { get; set; }
        public string iv { get; set; }
    }

    public class Attributes
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string given_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }
}

