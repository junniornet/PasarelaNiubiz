using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebPasarelaNiubiz.Complements;
using WebPasarelaNiubiz.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;
using System;
using System.Net;

namespace WebPasarelaNiubiz.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    [Route("SendData")]
    public ActionResult SendData(UserModel model)
    {
        if (!ModelState.IsValid)
            return View("Index", model);

        string AccessToken = string.Empty;
        string SessionToken = string.Empty;
        bool sent = false;
        int tryCount = 0;
        int tryCount2 = 0;
        bool sent2 = false;

        var merchantDefineData = new MerchantDefineData();
        var antifraud = new Antifraud();
        var requestTokenSession = new RequestTokenSession();

        merchantDefineData.MDD15 = "Valor MDD 15";
        merchantDefineData.MDD20 = "Valor MDD 20";
        merchantDefineData.MDD33 = "Valor MDD 33";
        antifraud.MerchantDefineData = merchantDefineData;
        try
        {
            antifraud.ClientIp = new WebClient().DownloadString("https://api.ipify.org");
        }
        catch
        {
            antifraud.ClientIp = "190.235.110.104";
        }
        requestTokenSession.antifraud = antifraud;
        requestTokenSession.channel = "web";
        requestTokenSession.amount = decimal.Parse("10.5");

        do
        {
            tryCount++;
            try
            {
                var bodyRequest = new { };
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(bodyRequest), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("integraciones@niubiz.com.pe:_7z3@8fF")));

                string url = "https://apisandbox.vnforappstest.com/api.security/v2/security/keys";

                if (string.IsNullOrEmpty(url))
                    throw new Exception("'Url' not found");

                var responseApi = client.PostAsync(url, content).Result;
                var responseString = responseApi.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<TokenCreated>(responseString);

                if (response != null && response.accessToken != null)
                {
                    AccessToken = response.accessToken;

                    do
                    {
                        tryCount2++;
                        try
                        {
                            client = new HttpClient();
                            content = new StringContent(JsonConvert.SerializeObject(requestTokenSession), Encoding.UTF8, "application/json");
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Add("Authorization", AccessToken);
                            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                            url = "https://apisandbox.vnforappstest.com/api.ecommerce/v2/ecommerce/token/session/456879856";

                            if (string.IsNullOrEmpty(url))
                                throw new Exception("'Url' not found");

                            responseApi = client.PostAsync(url, content).Result;
                            responseString = responseApi.Content.ReadAsStringAsync().Result;
                            var response2 = JsonConvert.DeserializeObject<AccessToken>(responseString);

                            if (response2 != null && response2.sessionKey != null)
                            {
                                SessionToken = response2.sessionKey;
                                sent = true;
                                sent2 = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Thread.Sleep(1000);
                        }
                    } while (tryCount2 <= 5 && !sent2);

                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
            }
        } while (tryCount <= 5 && !sent);

        ViewData["SessionToken"] = SessionToken;

        return View();
    }

    [HttpPost]
    [Route("ProcesaTransaccion")]
    public ActionResult ProcesaTransaccion(ResponseTransac responseTransac)
    {
        string AccessToken = string.Empty;
        bool sent = false;
        int tryCount = 0;
        int tryCount2 = 0;
        string respuestaFinal = string.Empty;
        OrderData order = new OrderData();
        order.tokenId = responseTransac.transactionToken;
        order.purchaseNumber = 2020100901;
        order.amount = decimal.Parse("10.5");
        order.currency = "PEN";
        RequestAuthorizationTransac requestAuthorizationTransac = new RequestAuthorizationTransac();
        requestAuthorizationTransac.channel = responseTransac.channel;
        requestAuthorizationTransac.captureType = "manual";
        requestAuthorizationTransac.countable = true;
        requestAuthorizationTransac.order = order;

        do
        {
            tryCount++;
            try
            {
                var bodyRequest = new { };
                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(bodyRequest), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("integraciones@niubiz.com.pe:_7z3@8fF")));

                string url = "https://apisandbox.vnforappstest.com/api.security/v2/security/keys";

                if (string.IsNullOrEmpty(url))
                    throw new Exception("'Url' not found");

                var responseApi = client.PostAsync(url, content).Result;
                var responseString = responseApi.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<TokenCreated>(responseString);

                if (response != null && response.accessToken != null)
                {
                    AccessToken = response.accessToken;

                    do
                    {
                        tryCount2++;
                        try
                        {
                            
                            client = new HttpClient();
                            content = new StringContent(JsonConvert.SerializeObject(requestAuthorizationTransac), Encoding.UTF8, "application/json");
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Add("Authorization", AccessToken);
                            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                            url = "https://apisandbox.vnforappstest.com/api.authorization/v3/authorization/ecommerce/456879856";

                            if (string.IsNullOrEmpty(url))
                                throw new Exception("'Url' not found");

                            responseApi = client.PostAsync(url, content).Result;
                            responseString = responseApi.Content.ReadAsStringAsync().Result;
                            var response2 = JsonConvert.DeserializeObject<AuthorizationTransaction>(responseString);

                            if (response2 != null && response2.DataMap.ACTION_DESCRIPTION != null)
                            {
                                respuestaFinal = response2.DataMap.ACTION_DESCRIPTION + " | " + response2.DataMap.ECI_DESCRIPTION + " | Transacción: " + response2.DataMap.TRANSACTION_ID;
                                sent = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Thread.Sleep(1000);
                        }
                    } while (tryCount2 <= 5 && !sent);

                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
            }
        } while (tryCount <= 5 && !sent);

        ViewData["RespuestaFinal"] = respuestaFinal;
        return View();
    }
}

