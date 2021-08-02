using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegrador.Models;


namespace ProyectoIntegrador.Models
{
    public class ProyectoIntegradorContext : DbContext //Clase DbContext, conexion con SQL
    {   
        //Constructor
        //pasar opciones por default para inicializarlas
        //Creando un tipo opciones donde la clase sera dbcontextOptions le pasamos un tipo de datos TurnosContext
        public ProyectoIntegradorContext(DbContextOptions<ProyectoIntegradorContext> opciones)
        : base(opciones) //Heredar las opcines base a la clase TurnosContext
        {
            
        }

        //Agregar la entidad o tabla que generara en SQL
        //              🡻 objeto Dispositivo de tipo DbSet[Entidad o tabla]
                                    //🡻Tipo Dispositivo es el modelo Dispositivo Estructura de la tabla
        public DbSet<Dispositivo> Dispositivo {get; set;}
        public DbSet<Usuario> Usuario {get; set;}
        public DbSet<Rol> Rol {get; set;}
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<UsuarioDispositivo> UsuarioDispositivo { get; set;}

        public DbSet<AdministradorRol> AdministradorRol { get; set;}
        public DbSet<Login> Login { get; set;}
       

        //Especificar Caracteristicas adicionales a nuestra entidad Dispositivo. Modificar las opcines genericas o estandar.
        //🡻 Solo se puede usar en esta clase
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //                               🡻   Parametro entidad
            modelBuilder.Entity<Dispositivo>(entidad =>
            {   
//===============================================================================================================================================================
                //Tabla Dispositivo-Datos
                entidad.ToTable("Dispositivo");
                //le decimos que nuestra primary key de la tabla dispositivo
                entidad.HasKey(d => d.IdDispositivo);
            
                entidad.Property(d =>d.Nombre)
                .IsRequired() //Is not null, al igual que esa funcion en SQL
                .HasMaxLength(20)//Maximo de caracteres permitidos en la tabla
                .IsUnicode(false);//Propiedad por defecto

                entidad.Property(d =>d.Codigo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(d =>d.Ubicacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(d =>d.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                //Al hacer una migracion con MIGRATIONS, la tabla Dispositivo se actualizara con los nuevos datos.
            });
//===============================================================================================================================================================
            //Tabla Usuario-datos
            modelBuilder.Entity<Usuario>(entidad =>
            {
                entidad.ToTable("Usuario");

                entidad.HasKey(p => p.IdUsuario);

                entidad.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });
//===============================================================================================================================================================
            //Tabla Rol-datos
            modelBuilder.Entity<Rol>(entidad =>
            {
                entidad.ToTable("Rol");

                entidad.HasKey(r => r.IdRol);

                entidad.Property(r => r.Descripcion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            });
 //===============================================================================================================================================================       
            //Tabla Administrador-Datos
            modelBuilder.Entity<Administrador>(entidad =>
            {
                entidad.ToTable("Administrador");
                entidad.HasKey(p => p.IdAdministrador);

                entidad.Property(d => d.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(d => d.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(d => d.Direccion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entidad.Property(d => d.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });


//===============================================================================================================================================================
            //Definir una clave primaria compuesta.
            //definir una restriccion sobre la Usuario y UsuarioDispositivo

            modelBuilder.Entity<UsuarioDispositivo>().HasKey(x => new { x.IdUsuario, x.IdDispositivo});
            //Definiendo una relacion de uno a muchos
            //Nos dice que un Usuario puede tener muchas especialidades
            modelBuilder.Entity<UsuarioDispositivo>().HasOne(x => x.Usuario)
            .WithMany(p => p.UsuarioDispositivo)
            //esta sera la llave foranea dentro de la tabla UsuarioDispositivo, a traves de EntityFramework
            .HasForeignKey(p => p.IdUsuario);

             //Nos dice que un Dispositivo puede tener muchos Usuarios
            modelBuilder.Entity<UsuarioDispositivo>().HasOne(x => x.Dispositivo)
            .WithMany(p => p.UsuarioDispositivo)
            //esta sera la llave foranea dentro de la tabla UsuarioDispositivo, a traves de EntityFramework
            .HasForeignKey(p => p.IdDispositivo);

            //Definiendo las propiedades sobre la tabla UsuarioDispositivo pero 



             modelBuilder.Entity<AdministradorRol>().HasKey(x => new { x.IdAdministrador, x.IdRol});
            //Definiendo una relacion de uno a muchos
            //Nos dice que un Usuario puede tener muchas especialidades
            modelBuilder.Entity<AdministradorRol>().HasOne(x => x.Administrador)
            .WithMany(p => p.AdministradorRol)
            //esta sera la llave foranea dentro de la tabla UsuarioDispositivo, a traves de EntityFramework
            .HasForeignKey(p => p.IdAdministrador);

             //Nos dice que un Dispositivo puede tener muchos Usuarios
            modelBuilder.Entity<AdministradorRol>().HasOne(x => x.Rol)
            .WithMany(p => p.AdministradorRol)
            //esta sera la llave foranea dentro de la tabla UsuarioDispositivo, a traves de EntityFramework
            .HasForeignKey(p => p.IdRol);
            



//===============================================================================================================================================================
            modelBuilder.Entity<Login>(entidad =>
            {
                entidad.ToTable("Login");

                entidad.HasKey(l => l.LoginId );
                
                entidad.Property(l => l.Usuario)
                .IsRequired();//Propiedad Not Null en SQL

                entidad.Property(l => l.Password)
                .IsRequired();
            });
















        }
        //🡹 Solo se puede usar en esta clase
        //Especificar Caracteristicas adicionales a nuestra entidad Dispositivo. Modificar las opcines genericas o estandar.
        
//===============================================================================================================================================================
        



    }
}