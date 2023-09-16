using BancoEstatal.Helpers;
using BancoEstatal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEstatal.Services
{
    public class EmpleadosServices : IServices2<empleados, EmpleadosDTO>
    {
        bancoEstatalDB2Context db = new bancoEstatalDB2Context();

        public void Delete(string id)
        {
            var D = db.empleados.Find(id);
            if (D != null)
            {
                db.empleados.Remove(D);
                db.SaveChanges();
            }
        }

        public List<EmpleadosDTO> GetAllDTO()
        {
            return (from T1 in db.empleados

                    join T2 in db.cargos
                    on T1.emCargos_fk equals T2.caID

                    join T3 in db.sedes
                    on T1.emSedes_fk equals T3.seID

                    join T4 in db.generos
                    on T1.emGenero_fk equals T4.geID

                    group T1 by new
                    {
                        T1.emCedula,
                        T1.emNombre,
                        T1.emApellido,
                        T1.emCorreo,
                        T1.emDireccion,
                        T1.emTelefono,
                        T2.caCargo,
                        T3.seNombre,
                        T4.genGenero,
                        T1.emFoto
                    }
                     into F
                    select new EmpleadosDTO()
                    {
                        emCedula = F.Key.emCedula,
                        emNombre = F.Key.emNombre,
                        emApellido = F.Key.emApellido,
                        emCorreo = F.Key.emCorreo,
                        emDireccion = F.Key.emDireccion,
                        emTelefono = F.Key.emTelefono,
                        caCargo = F.Key.caCargo,
                        seSedes = F.Key.seNombre,
                        geGenero = F.Key.genGenero,
                        emFoto = F.Key.emFoto
                    }
                ).ToList();
        }

        public empleados GetById(string id)
        {
            return db.empleados.Find(id);
        }

        public void Update(empleados ob, string id)
        {
            var U = db.empleados.Find(id);
            if(U != null)
            {
                db.Entry(U).CurrentValues.SetValues(ob);
                db.SaveChanges();
            }
        }

        public List<EmpleadosDTO> GetByCedula(String value)
        {
            return (from T1 in db.empleados
                    where T1.emCedula.Equals(value)

                    join T2 in db.cargos
                    on T1.emCargos_fk equals T2.caID

                    join T3 in db.sedes
                    on T1.emSedes_fk equals T3.seID

                    join T4 in db.generos
                    on T1.emGenero_fk equals T4.geID

                    group T1 by new
                    {
                        T1.emCedula,
                        T1.emNombre,
                        T1.emApellido,
                        T1.emCorreo,
                        T1.emDireccion,
                        T1.emTelefono,
                        T2.caCargo,
                        T3.seNombre,
                        T4.genGenero,
                        T1.emFoto
                    }
                     into F
                    select new EmpleadosDTO()
                    {
                        emCedula = F.Key.emCedula,
                        emNombre = F.Key.emNombre,
                        emApellido = F.Key.emApellido,
                        emCorreo = F.Key.emCorreo,
                        emDireccion = F.Key.emDireccion,
                        emTelefono = F.Key.emTelefono,
                        caCargo = F.Key.caCargo,
                        seSedes = F.Key.seNombre,
                        geGenero = F.Key.genGenero,
                        emFoto = F.Key.emFoto
                    }
                ).ToList();
        }

        public List<EmpleadosDTO> GetByEmail(String value)
        {
            return (from T1 in db.empleados
                    where T1.emCorreo.Contains(value)

                    join T2 in db.cargos
                    on T1.emCargos_fk equals T2.caID

                    join T3 in db.sedes
                    on T1.emSedes_fk equals T3.seID

                    join T4 in db.generos
                    on T1.emGenero_fk equals T4.geID

                    group T1 by new
                    {
                        T1.emCedula,
                        T1.emNombre,
                        T1.emApellido,
                        T1.emCorreo,
                        T1.emDireccion,
                        T1.emTelefono,
                        T2.caCargo,
                        T3.seNombre,
                        T4.genGenero,
                        T1.emFoto
                    }
                     into F
                    select new EmpleadosDTO()
                    {
                        emCedula = F.Key.emCedula,
                        emNombre = F.Key.emNombre,
                        emApellido = F.Key.emApellido,
                        emCorreo = F.Key.emCorreo,
                        emDireccion = F.Key.emDireccion,
                        emTelefono = F.Key.emTelefono,
                        caCargo = F.Key.caCargo,
                        seSedes = F.Key.seNombre,
                        geGenero = F.Key.genGenero,
                        emFoto = F.Key.emFoto
                    }
                ).ToList();
        }

        public List<EmpleadosDTO> GetBySedes(String Sede)
        {
            return (from T1 in db.empleados
                    
                    join T2 in db.cargos
                    on T1.emCargos_fk equals T2.caID

                    join T3 in db.sedes
                    on T1.emSedes_fk equals T3.seID
                    where T3.seNombre.Contains(Sede)

                    join T4 in db.generos
                    on T1.emGenero_fk equals T4.geID

                    group T1 by new
                    {
                        T1.emCedula,
                        T1.emNombre,
                        T1.emApellido,
                        T1.emCorreo,
                        T1.emDireccion,
                        T1.emTelefono,
                        T2.caCargo,
                        T3.seNombre,
                        T4.genGenero,
                        T1.emFoto
                    }
                     into F
                    select new EmpleadosDTO()
                    {
                        emCedula = F.Key.emCedula,
                        emNombre = F.Key.emNombre,
                        emApellido = F.Key.emApellido,
                        emCorreo = F.Key.emCorreo,
                        emDireccion = F.Key.emDireccion,
                        emTelefono = F.Key.emTelefono,
                        caCargo = F.Key.caCargo,
                        seSedes = F.Key.seNombre,
                        geGenero = F.Key.genGenero,
                        emFoto = F.Key.emFoto
                    }
                ).ToList();
        }
        public List<EmpleadosDTO> GetByCargo(String Cargo)
        {
            return (from T1 in db.empleados

                    join T2 in db.cargos
                    on T1.emCargos_fk equals T2.caID
                    where T2.caCargo.Contains(Cargo)

                    join T3 in db.sedes
                    on T1.emSedes_fk equals T3.seID
                    

                    join T4 in db.generos
                    on T1.emGenero_fk equals T4.geID
                    

                    group T1 by new
                    {
                        T1.emCedula,
                        T1.emNombre,
                        T1.emApellido,
                        T1.emCorreo,
                        T1.emDireccion,
                        T1.emTelefono,
                        T2.caCargo,
                        T3.seNombre,
                        T4.genGenero,
                        T1.emFoto
                    }
                     into F
                    select new EmpleadosDTO()
                    {
                        emCedula = F.Key.emCedula,
                        emNombre = F.Key.emNombre,
                        emApellido = F.Key.emApellido,
                        emCorreo = F.Key.emCorreo,
                        emDireccion = F.Key.emDireccion,
                        emTelefono = F.Key.emTelefono,
                        caCargo = F.Key.caCargo,
                        seSedes = F.Key.seNombre,
                        geGenero = F.Key.genGenero,
                        emFoto = F.Key.emFoto
                    }
                ).ToList();
        }
    }
}
