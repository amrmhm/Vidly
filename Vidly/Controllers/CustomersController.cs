using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Runtime.Caching;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            // Memory Caching => Data Caching 
            //if(MemoryCache.Default["Genres"] == null )
            //{
            //    MemoryCache.Default["Genres"] = _context.Genres.ToList();
            //}
            //var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;


            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

           
            return View(customer);
                
        }
        
        public ActionResult CustomerForm()
        {

            var memberShipType = _context.MemberShipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer () ,
                MemberShipType = memberShipType
            };
            return View(viewModel);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Save(Customer customer)

        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MemberShipType = _context.MemberShipTypes.ToList()
                };
                return View(nameof(CustomerForm), viewModel);
            }
            if (customer.Id == 0)
            {

                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        } 
        public ActionResult Edit(int id )
        {

            var customer = _context.Customers.SingleOrDefault(c =>c.Id == id );
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipType = _context.MemberShipTypes.ToList()
            }; 
            
            return View(nameof(CustomerForm),viewModel);
        }
      
     
    }
    
}