using System;
namespace WebPasarelaNiubiz.Models
{
    public class RequestTokenSession
    {
        public string channel { get; set; }
        public decimal amount { get; set; }
        public Antifraud antifraud { get; set; }
    }

    public class Antifraud
    {
        public string ClientIp { get; set; }
        public MerchantDefineData MerchantDefineData { get; set; }
    }

    public class MerchantDefineData
    {
        public string MDD15 { get; set; }
        public string MDD20 { get; set; }
        public string MDD33 { get; set; }
    }

}

