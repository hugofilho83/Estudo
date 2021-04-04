using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repository.Context;
using Backend.Repository.Contract;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class UsuarioRepository : IUsuarioRepository<Usuario>
    {
        private DataBaseContext _dataBase;
        public UsuarioRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task Add(Usuario Entity)
        {

            ValidarUsuario(Entity);

            if (Entity.Notifications.Count == 0)
            {
                Entity.Ativo = true;
                Entity.Senha = Configurations.RetornarMD5(Entity.Senha);
                _dataBase.Add(Entity);

                await _dataBase.SaveChangesAsync();
            }
        }

        public Task Delete(Usuario Entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Usuario> GetEntityById(int Id)
        {
            return await _dataBase.Usuarios.FindAsync(Id);
        }

        public async Task<List<Usuario>> List(PaginationFilter filter)
        {
            return await _dataBase.Usuarios.AsNoTracking()
                            .Skip((filter.PageNumber - 1) * filter.PageSize)
                            .Take(filter.PageSize)
                            .OrderBy(u => u.Id).ToListAsync();
        }

        public async Task Update(Usuario Entity)
        {

            ValidarUsuario(Entity);

            if (Entity.Notifications.Count == 0)
            {
                var usuario = await _dataBase.Usuarios.FindAsync(Entity.Id);

                if (usuario == null)
                {
                    Entity.AddNoficication("Usuário não localizado", "Usuarios");
                    return;
                }


                usuario.Name = Entity.Name;
                usuario.Email = Entity.Email;

                if (Entity.Senha != null)
                    usuario.Senha = Configurations.RetornarMD5(Entity.Senha);

                usuario.Login = Entity.Login;
                usuario.Ativo = Entity.Ativo;

                _dataBase.Update(usuario);

                await _dataBase.SaveChangesAsync();
            }
        }

        public Usuario Logar(string email, string senha)
        {
            var senhaCrypt = Configurations.RetornarMD5(senha);
            var usuario = _dataBase.Usuarios.Where(u => u.Email == email && u.Senha == senhaCrypt).FirstOrDefault();

            return usuario;
        }


        private void ValidarUsuario(Usuario usuario)
        {

            var emailValido = usuario.ValidationPropertyString(usuario.Email, nameof(usuario.Email));
            var nameValido = usuario.ValidationPropertyString(usuario.Name, nameof(usuario.Name));
            var senhaVAlida = true;

            if (usuario.Id == 0 || usuario.Senha != null)
                senhaVAlida = usuario.ValidationPropertyString(usuario.Senha, nameof(usuario.Senha));

            if (emailValido && nameValido && senhaVAlida)
            {
                var user = _dataBase.Usuarios.Where(u => u.Email == usuario.Email).FirstOrDefault();

                if (user != null && usuario.Id == 0)
                {
                    usuario.AddNoficication("Já existe um usuário como o email informado", nameof(usuario.Email));
                }
                else if (user != null && user.Id != usuario.Id)
                {
                    usuario.AddNoficication("Já existe um usuário como o email informado", nameof(usuario.Email));
                }
            }
        }

        public async Task<int> GetTotalRegister()
        {
            return await _dataBase.Usuarios.CountAsync();
        }
    }
}
