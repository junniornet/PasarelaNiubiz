using System;
namespace WebPasarelaNiubiz.Models
{
	public class ResponseTransac
	{
        public string transactionToken { get; set; }
        public string? customerEmail { get; set; }
        public string? channel { get; set; }
        public string? url { get; set; }
    }
}

