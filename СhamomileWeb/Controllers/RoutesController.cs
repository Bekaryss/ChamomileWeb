using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using СhamomileWeb.Data;
using СhamomileWeb.Models.Entities;

namespace СhamomileWeb.Controllers
{
    public class RoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Routes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Routes.ToListAsync());
        }

        public async Task<IActionResult> Table()
        {
            List<RouteTable> table = new List<RouteTable>();
            var orders = await _context.Orders.ToListAsync();
            var routes = await _context.Routes.ToListAsync();
            foreach(var routeItem in routes)
            {
                int Completed = 0;
                int Canceled = 0;
                int Refunded = 0;
                int count = 0;
                foreach (var item in orders)
                {
                    if (item.RouteId == routeItem.Id)
                    {
                        if(item.State == State.Completed)
                        {
                            Completed++;
                        }else if (item.State == State.Cancelled)
                        {
                            Canceled++;
                        }
                        else if (item.State == State.Refunded)
                        {
                            Refunded++;
                        }
                    }
                    count++;
                }
                table.Add(TableAdd(routeItem, count, Completed, Canceled, Refunded));
            }
            
            return View(table);
        }

        public RouteTable TableAdd(Route route, int count, int Completed, int Canceled, int Refunded )
        {
            RouteTable rt = new RouteTable();
            rt.Id = route.Id;
            rt.StartDate = route.StartDate;
            rt.Price = route.Price;
            rt.Delivery = route.Delivery;
            rt.Dispatch = route.Dispatch;
            rt.Distance = route.Distance;
            rt.OrderCount = count;
            rt.CompletedCount = Completed;
            rt.CanceledCount = Canceled;
            rt.RefundedCount = Refunded;
            rt.Percent = Completed / count * 100;
            return rt;
        }

        // GET: Routes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Routes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dispatch,Delivery,Distance,Price,StartDate,FinishDate")] Route route)
        {
            if (ModelState.IsValid)
            {
                _context.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // GET: Routes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes.SingleOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dispatch,Delivery,Distance,Price,StartDate,FinishDate")] Route route)
        {
            if (id != route.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.Id))
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
            return View(route);
        }

        // GET: Routes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var route = await _context.Routes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(int id)
        {
            return _context.Routes.Any(e => e.Id == id);
        }
    }
}
