using System;
namespace WebPasarelaNiubiz.Models
{
    public class RequestAuthorizationTransac
    {
        public string channel { get; set; }
        public string captureType { get; set; }
        public bool countable { get; set; }
        public OrderData order { get; set; }
    }

    public class OrderData
    {
        public string tokenId { get; set; }
        public int purchaseNumber { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

}

