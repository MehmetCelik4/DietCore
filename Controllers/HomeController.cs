using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dietcore.Models;

using Armut.Iyzipay;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request.V2;
using Armut.Iyzipay.Model.V2;


namespace Dietcore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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



        public async Task<IActionResult> CreateSubMerchant(int id)
        {

            var options = new Options
            {
                ApiKey = "sandbox-pvY8iL8GbralWyf3rbzqqvP0SSouP6sQ",
                SecretKey = "sandbox-cVojNOhBjRqVjhhOThOFfv4cy35zKmC5",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };

            CreateSubMerchantRequest request = new CreateSubMerchantRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantExternalId = "mor1",
                SubMerchantType = SubMerchantType.PERSONAL.ToString(),
                Address = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ContactName = "John",
                ContactSurname = "Doe",
                Email = "email12@submerchantemail.com",
                GsmNumber = "+905350000013",
                Name = "memo's market",
                Iban = "TR180006200119000006672315",
                IdentityNumber = "31300861213",
                Currency = Currency.TRY.ToString()
            };

            SubMerchant subMerchant = await SubMerchant.CreateAsync(request, options);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> GetSubMerchant(int id)
        {
            var options = new Options
            {
                ApiKey = "sandbox-pvY8iL8GbralWyf3rbzqqvP0SSouP6sQ",
                SecretKey = "sandbox-cVojNOhBjRqVjhhOThOFfv4cy35zKmC5",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };


            RetrieveSubMerchantRequest request = new RetrieveSubMerchantRequest

            {
                Locale = Locale.TR.ToString(),
                SubMerchantExternalId = "mor1",
                ConversationId = "123456789"
            };

            SubMerchant subMerchant = await SubMerchant.RetrieveAsync(request, options);

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> UpdateSubMerchant(int id)
        {
            var options = new Options
            {
                ApiKey = "sandbox-pvY8iL8GbralWyf3rbzqqvP0SSouP6sQ",
                SecretKey = "sandbox-cVojNOhBjRqVjhhOThOFfv4cy35zKmC5",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };


            UpdateSubMerchantRequest request = new UpdateSubMerchantRequest


            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantKey = "0gO50jhx5bpKlvHp/SiLwlXVzGM=",
                Address = "Adana, Merdivenköy Mah. Bora Sok. No:1",
                ContactName = "John",
                ContactSurname = "Doe",
                Email = "email@submerchantemail.com",
                GsmNumber = "+905350000013",
                Name = "memo's market",
                Iban = "TR180006200119000006672315",
                IdentityNumber = "31300861213",
                Currency = Currency.TRY.ToString()
            };

            SubMerchant subMerchant = await SubMerchant.UpdateAsync(request, options);

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> ApproveSubMerchant(int id)
        {
            var options = new Options
            {
                ApiKey = "sandbox-pvY8iL8GbralWyf3rbzqqvP0SSouP6sQ",
                SecretKey = "sandbox-cVojNOhBjRqVjhhOThOFfv4cy35zKmC5",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };


            CreateApprovalRequest request = new CreateApprovalRequest

            {
                Locale = "tr",
                ConversationId = "123456789",
                PaymentTransactionId = "11807130"
            };

            Approval approval = await Approval.CreateAsync(request, options);

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> DisapproveSubMerchant(int id)
        {
            var options = new Options
            {
                ApiKey = "sandbox-pvY8iL8GbralWyf3rbzqqvP0SSouP6sQ",
                SecretKey = "sandbox-cVojNOhBjRqVjhhOThOFfv4cy35zKmC5",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };


            CreateApprovalRequest request = new CreateApprovalRequest

            {
                Locale = "tr",
                ConversationId = "123456789",
                PaymentTransactionId = "11807130"
            };

            Disapproval disapproval = await Disapproval.CreateAsync(request, options);

            return RedirectToAction(nameof(Index));

        }

    }
}
