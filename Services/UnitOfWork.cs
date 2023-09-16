using BancoEstatal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEstatal.Services
{
    public class UnitOfWork
    {
        public static Repository<cargos> Cargo = new Repository<cargos>();
        public static Repository<sedes> Sede = new Repository<sedes>();
        public static Repository<empleados> Empleado = new Repository<empleados>();
        public static Repository<ciudades> Ciudad = new Repository<ciudades>();
        public static Repository<generos> Genero = new Repository<generos>();

        public static SedesServices SedeS = new SedesServices();
        public static EmpleadosServices EmpleadosS = new EmpleadosServices();
    }
}
