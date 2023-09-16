using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEstatal.Services.Abstracts
{
    public interface IServices<J>
        where J: class

    {
        void Add(J ob);
        void Delete(int id);
        void Update(J ob, int id);
        List<J> GetAll();
        J GetById(int id);
    }
}
