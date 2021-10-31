using PlanillaAPI.Datos;
using PlanillaAPI.Repositorys.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PlanillaContext db;

        public UsuarioRepository(PlanillaContext planillaContext)
        {
            db = planillaContext; 
        }
        public bool CreateUser(Usuario usuario)
        {
            usuario.Estado = 1;
            db.Usuarios.Add(usuario);
            return Save(); 
        }

        public bool DeleteUser(Usuario usuario)
        {
            usuario.Estado = 0;
            db.Usuarios.Update(usuario);
            return Save(); 
        }

        public bool ExisteUsuario(int usuarioId)
        {
            return db.Usuarios.Any(u => u.Idusuario == usuarioId);
        }

        public bool ExisteUsuario(string user)
        {
            return db.Usuarios.Any(u => u.User.ToLower().Trim() == user);
        }

        public Usuario GetUsuario(int usuarioId)
        {
            return db.Usuarios.FirstOrDefault(u => u.Idusuario == usuarioId); 
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return (from u in db.Usuarios where u.Estado == 1 select u).ToList(); 
        }

        public bool Save()
        {
            return db.SaveChanges() > 0; 
        }

        public bool UpdateUser(Usuario usuario)
        {
            db.Usuarios.Update(usuario);
            return Save(); 
        }
    }
}
