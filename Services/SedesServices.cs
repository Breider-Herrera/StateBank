using BancoEstatal.Helpers;
using BancoEstatal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEstatal.Services
{
    public class SedesServices : IServices2<sedes, SedesDTO>
    {
        bancoEstatalDB2Context db = new bancoEstatalDB2Context();

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<SedesDTO> GetAllDTO()
        {
            return (from T1 in db.sedes

                    join T2 in db.ciudades
                    on T1.seCiudad_fk equals T2.ciID

                    group T2 by new
                    {
                        T1.seID,
                        T1.seNombre,
                        T1.seDireccion,
                        T1.seTelefono,
                        T2.ciCiudad,
                    }
                     into g
                    select new SedesDTO()
                    {
                        seID = g.Key.seID,
                        seNombre = g.Key.seNombre,
                        seDireccion = g.Key.seDireccion,
                        seTelefono = g.Key.seTelefono,
                        ciCiudad = g.Key.ciCiudad
                    }
                ).ToList();
        }

        public sedes GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(sedes ob, string id)
        {
            throw new NotImplementedException();
        }
    }
}
