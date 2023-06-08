using System;
namespace WebPasarelaNiubiz.Models
{
    public class AuthorizationTransaction
    {
        public Header Header { get; set; }
        public Fulfillment Fulfillment { get; set; }
        public Order Order { get; set; }
        public DataMap DataMap { get; set; }
    }

    public class Header
    {
        public string EcoreTransactionUUID { get; set; }
        public long EcoreTransactionDate { get; set; }
        public int Millis { get; set; }
    }

    public class Fulfillment
    {
        public string Channel { get; set; }
        public string MerchantId { get; set; }
        public string TerminalId { get; set; }
        public string CaptureType { get; set; }
        public bool Countable { get; set; }
        public bool FastPayment { get; set; }
        public string Signature { get; set; }
    }

    public class Order
    {
        public string TokenId { get; set; }
        public string PurchaseNumber { get; set; }
        public decimal Amount { get; set; }
        public int Installment { get; set; }
        public string Currency { get; set; }
        public decimal AuthorizedAmount { get; set; }
        public string AuthorizationCode { get; set; }
        public string ActionCode { get; set; }
        public string TraceNumber { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionId { get; set; }
    }

    public class DataMap
    {
        public string TERMINAL { get; set; }
        public string BRAND_ACTION_CODE { get; set; }
        public string BRAND_HOST_DATE_TIME { get; set; }
        public string TRACE_NUMBER { get; set; }
        public string CARD_TYPE { get; set; }
        public string ECI_DESCRIPTION { get; set; }
        public string SIGNATURE { get; set; }
        public string CARD { get; set; }
        public string MERCHANT { get; set; }
        public string STATUS { get; set; }
        public string ACTION_DESCRIPTION { get; set; }
        public string ID_UNICO { get; set; }
        public string AMOUNT { get; set; }
        public string AUTHORIZATION_CODE { get; set; }
        public string YAPE_ID { get; set; }
        public string CURRENCY { get; set; }
        public string TRANSACTION_DATE { get; set; }
        public string ACTION_CODE { get; set; }
        public string CVV2_VALIDATION_RESULT { get; set; }
        public string ECI { get; set; }
        public string ID_RESOLUTOR { get; set; }
        public string BRAND { get; set; }
        public string ADQUIRENTE { get; set; }
        public string BRAND_NAME { get; set; }
        public string PROCESS_CODE { get; set; }
        public string TRANSACTION_ID { get; set; }
    }

}

