﻿using System;
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

        public readonly Options option;

        [BindProperty]
        public MerchantViewModel MerchantVM { get; set; }
        public HomeController()
        {
            Options config = new Options
            {
                ApiKey = "sandbox-pvY8iL8GbralWyf3rbzqqvP0SSouP6sQ",
                SecretKey = "sandbox-cVojNOhBjRqVjhhOThOFfv4cy35zKmC5",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };
            option = config;


            MerchantVM = new MerchantViewModel()
            {
                SubMerchant = new SubMerchant()
            };

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateSubMerchant(int id)
        {

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

            SubMerchant subMerchant = await SubMerchant.CreateAsync(request, option);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> GetSubMerchant(int id)
        {

            RetrieveSubMerchantRequest request = new RetrieveSubMerchantRequest

            {
                Locale = Locale.TR.ToString(),
                SubMerchantExternalId = "mor1",
                ConversationId = "123456789"
            };

            MerchantVM.SubMerchant = await SubMerchant.RetrieveAsync(request, option);
            return View(MerchantVM);


        }
        public async Task<IActionResult> UpdateSubMerchant(int id)
        {

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

            SubMerchant subMerchant = await SubMerchant.UpdateAsync(request, option);

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> ApproveSubMerchant(int id)
        {

            CreateApprovalRequest request = new CreateApprovalRequest

            {
                Locale = "tr",
                ConversationId = "123456789",
                PaymentTransactionId = "11807130"
            };

            Approval approval = await Approval.CreateAsync(request, option);

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> DisapproveSubMerchant(int id)
        {

            CreateApprovalRequest request = new CreateApprovalRequest

            {
                Locale = "tr",
                ConversationId = "123456789",
                PaymentTransactionId = "11807130"
            };

            Disapproval disapproval = await Disapproval.CreateAsync(request, option);

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> StartCheckout(int id)
        {

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "100.72",
                PaidPrice = "110.72",
                Currency = Currency.TRY.ToString(),
                BasketId = "B67832",
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = "http://localhost:5000/Home/Onay/"
            };

            List<int> enabledInstallments = new List<int> { 2, 3, 6, 9 };
            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer
            {
                Id = "BY789",
                Name = "John",
                Surname = "Doe",
                GsmNumber = "+905350000000",
                Email = "email@email.com",
                IdentityNumber = "74300864791",
                LastLoginDate = "2015-10-05 12:43:35",
                RegistrationDate = "2013-04-21 15:12:09",
                RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                Ip = "85.34.78.112",
                City = "Istanbul",
                Country = "Turkey",
                ZipCode = "34732"
            };
            request.Buyer = buyer;

            Address shippingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem
            {
                Id = "BI101",
                Name = "Binocular",
                Category1 = "Collectibles",
                Category2 = "Accessories",
                SubMerchantKey = "0gO50jhx5bpKlvHp/SiLwlXVzGM=",
                SubMerchantPrice = "20.12",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "40.21"
            };
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem
            {
                Id = "BI102",
                Name = "Game code",
                Category1 = "Game",
                Category2 = "Online Game Items",
                SubMerchantKey = "0gO50jhx5bpKlvHp/SiLwlXVzGM=",
                SubMerchantPrice = "30.12",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = "60.51"
            };
            basketItems.Add(secondBasketItem);

            request.BasketItems = basketItems;
            request.ForceThreeDS = 1;

            CheckoutFormInitialize checkoutFormInitialize = await CheckoutFormInitialize.CreateAsync(request, option);
            ViewData["Checkout"] = checkoutFormInitialize.CheckoutFormContent;

            return View();

        }

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Onay([FromForm] string token)
        {

            RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest
            {
                ConversationId = "123",
                Token = token
            };

            CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, option);
            ViewData["Approval"] = checkoutForm.PaymentStatus;
            if (checkoutForm.PaymentStatus == "SUCCESS")
            {
                return View("Success");
            }
            else if (checkoutForm.PaymentStatus == "FAILURE")
            {

                return View("Fail");
            }

            return View();
        }

    }
}
