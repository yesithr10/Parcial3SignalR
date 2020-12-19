using System;
using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class ArriendoContext: DbContext
    {
        public ArriendoContext(DbContextOptions options) : base(options){}
        public DbSet<ArriendoInmueble> ArriendosInmuebles { get; set; }
        public DbSet<Inmueble> Inmuebles { get; set; }
    }
}
