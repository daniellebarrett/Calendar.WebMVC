using Calendar.Data;
using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Services
{
    public class BillService
    {
        private readonly Guid _userId;

        public BillService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBill(BillCreate model)
        {
            var entity =
                new Bill()
                {
                    OwnerID = _userId,
                    DateIssued = model.DateIssued,
                    DateDue = model.DateDue,
                    BillStatus = model.BillStatus,
                    BillAmount = model.BillAmount
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bills.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BillListItem> GetBills()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Bills
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                        e =>
                            new BillListItem
                            {
                                BillingID = e.BillingID,
                                BillStatus = e.BillStatus,
                                BillAmount = e.BillAmount,
                            }
                     );
                return query.ToArray();
            }
        }

        public BillDetail GetBillById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Bills
                    .Single(e => e.BillingID == id && e.OwnerID == _userId);
                return
                    new BillDetail
                    {
                        BillingID = entity.BillingID,
                        DateIssued = entity.DateIssued,
                        DateDue = entity.DateDue,
                        BillStatus = entity.BillStatus,
                        BillAmount = entity.BillAmount,
                    };
            }
        }

        public bool UpdateBill(BillEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Bills
                    .Single(e => e.BillingID == model.BillingID && e.OwnerID == _userId);
                entity.DateIssued = model.DateIssued;
                entity.DateDue = model.DateDue;
                entity.BillStatus = model.BillStatus;
                entity.BillAmount = model.BillAmount;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBill(int billingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bills
                        .Single(e => e.BillingID == billingId && e.OwnerID == _userId);

                ctx.Bills.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
