using PlanillaAPI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanillaAPI.Repositorys.IRepositorys
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int usuarioId);
        bool ExisteUsuario(int usuarioId);
        bool ExisteUsuario(string user);
        bool CreateUser(Usuario usuario);
        bool UpdateUser(Usuario usuario);
        bool DeleteUser(Usuario usuario);
        bool Save(); 
    }
}
