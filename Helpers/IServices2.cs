using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEstatal.Helpers
{
    public interface IServices2<J,J2>
        where J: class
        where J2: class
    {
        void Delete(string id);
        void Update(J ob, string id);
        List<J2> GetAllDTO();
        J GetById(string id);
    }
}
