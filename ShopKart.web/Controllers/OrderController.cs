using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;

namespace ShopKart.web.Controllers
{
    public class OrderController : Controller
    {
        private TestDBEntities1 db = new TestDBEntities1();

        // GET: Order
        public async Task<ActionResult> Index()
        {
            return View(await db.Order_Table.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Table order_Table = await db.Order_Table.FindAsync(id);
            if (order_Table == null)
            {
                return HttpNotFound();
            }
            return View(order_Table);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Total_Price")] Order_Table order_Table)
        {
            if (ModelState.IsValid)
            {
                db.Order_Table.Add(order_Table);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(order_Table);
        }

        // GET: Order/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Table order_Table = await db.Order_Table.FindAsync(id);
            if (order_Table == null)
            {
                return HttpNotFound();
            }
            return View(order_Table);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Total_Price")] Order_Table order_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Table).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(order_Table);
        }

        // GET: Order/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Table order_Table = await db.Order_Table.FindAsync(id);
            if (order_Table == null)
            {
                return HttpNotFound();
            }
            return View(order_Table);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order_Table order_Table = await db.Order_Table.FindAsync(id);
            db.Order_Table.Remove(order_Table);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
