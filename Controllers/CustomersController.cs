using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dietcore.Data;
using Dietcore.Models;
using Armut.Iyzipay;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request.V2;
using Armut.Iyzipay.Model.V2;

namespace Dietcore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customer.Include(c => c.Dietitian);


            var options = new Options
            {
                ApiKey = "sandbox-7xSIEv7d8wZc2BiX2nGEQnhhdDg6wm30",
                SecretKey = "sandbox-XKXfOIBvPLCwqo5xgn1zmDJUWvjVjB1v",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };



            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.TRY.ToString(),
                BasketId = "B67832",
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = "http://localhost:5000/Customers/Onay/"
            };

            List<int> enabledInstallments = new List<int> { 2, 3, 6, 9 };
            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer
            {
                Id = "BY789",
                Name = "Mehmet",
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
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "0.3"
            };
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem
            {
                Id = "BI102",
                Name = "Game code",
                Category1 = "Game",
                Category2 = "Online Game Items",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = "0.5"
            };
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem
            {
                Id = "BI103",
                Name = "Usb",
                Category1 = "Electronics",
                Category2 = "Usb / Cable",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "0.2"
            };
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            CheckoutFormInitialize checkoutFormInitialize = await CheckoutFormInitialize.CreateAsync(request, options);
            ViewData["Greeting"] = checkoutFormInitialize.CheckoutFormContent;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Dietitian)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }
            var options = new Options
            {
                ApiKey = "sandbox-7xSIEv7d8wZc2BiX2nGEQnhhdDg6wm30",
                SecretKey = "sandbox-XKXfOIBvPLCwqo5xgn1zmDJUWvjVjB1v",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };

            var request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = "B67832",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                 CallbackUrl = "http://localhost:5000/Customers/"

        };

            var paymentCard = new PaymentCard
            {
                CardHolderName = "John Doe",
                CardNumber = "9792030000000000",
                ExpireMonth = "12",
                ExpireYear = "2030",
                Cvc = "123",
                RegisterCard = 0
            };

            request.PaymentCard = paymentCard;

            var buyer = new Buyer
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
            request.Buyer.Ip = buyer.Ip;


            var shippingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };

            request.ShippingAddress = shippingAddress;

            var billingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };

            request.BillingAddress = billingAddress;

            var firstBasketItem = new BasketItem
            {
                Id = "BI101",
                Name = "Binocular",
                Category1 = "Collectibles",
                Category2 = "Accessories",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "0.3"
            };

            var secondBasketItem = new BasketItem
            {
                Id = "BI102",
                Name = "Game code",
                Category1 = "Game",
                Category2 = "Online Game Items",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = "0.5"
            };

            var thirdBasketItem = new BasketItem
            {
                Id = "BI103",
                Name = "Usb",
                Category1 = "Electronics",
                Category2 = "Usb / Cable",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "0.2"
            };

            var basketItems = new List<BasketItem>
        {
            firstBasketItem,
            secondBasketItem,
            thirdBasketItem
        };

            request.BasketItems = basketItems;

            // Payment payment = await Payment.CreateAsync(request, options);

            ThreedsInitialize threedsInitialize = await ThreedsInitialize.CreateAsync(request, options);

            ViewData["Greeting"] = threedsInitialize.HtmlContent;

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["DietitianID"] = new SelectList(_context.Dietitian, "ID", "FullName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,EnrollmentDate,DietitianID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DietitianID"] = new SelectList(_context.Dietitian, "ID", "FullName", customer.DietitianID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["DietitianID"] = new SelectList(_context.Dietitian, "ID", "FullName", customer.DietitianID);
            return View(customer);
        }
        // GET: Customers/Edit/5
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Onay([FromForm] string token)
        {
            var options = new Options
            {
                ApiKey = "sandbox-7xSIEv7d8wZc2BiX2nGEQnhhdDg6wm30",
                SecretKey = "sandbox-XKXfOIBvPLCwqo5xgn1zmDJUWvjVjB1v",
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };

            RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest
            {
                ConversationId = "123",
                Token = token
            };

            CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, options);
            ViewData["Greeting"] = checkoutForm.PaymentStatus;
            if (checkoutForm.PaymentStatus == "SUCCESS")
            {
                return View("Suc");
            }
            return View();
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName,EnrollmentDate,DietitianID")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DietitianID"] = new SelectList(_context.Dietitian, "ID", "FullName", customer.DietitianID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Dietitian)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.ID == id);
        }
    }
}
