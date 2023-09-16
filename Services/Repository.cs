using BancoEstatal.Model;
using BancoEstatal.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEstatal.Services
{
    public class Repository<J> : IServices<J>
        where J : class
    {
        bancoEstatalDB2Context db = new bancoEstatalDB2Context();
        public void Add(J ob)
        {
            db.Set<J>().Add(ob);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var d = db.Set<J>().Find(id);
            if(d != null)
            {
                db.Set<J>().Remove(d);
                db.SaveChanges();
            }
        }

        public List<J> GetAll()
        {
            return db.Set<J>().ToList();
        }

        public J GetById(int id)
        {
            return db.Set<J>().Find(id);
        }

        public void Update(J ob, int id)
        {
            var d = db.Set<J>().Find(id);
            if (d != null)
            {
                db.Entry(d).CurrentValues.SetValues(ob);
                db.SaveChanges();
            }
        }
    }
}
