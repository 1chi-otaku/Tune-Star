using AutoMapper;
using Soccer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tune_Star.BLL.DTO;
using Tune_Star.BLL.Interfaces;
using Tune_Star.DAL.Entities;

namespace Tune_Star.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task CreateUser(UserDTO userDto)
        {
            var user = new Users
            {
                Id = userDto.Id,
                Login = userDto.Login,
                Password = userDto.Password,
                Status = userDto.Status,
                Salt = userDto.Salt,
            };
            await Database.Users.Create(user);
            await Database.Save();
        }

        public async Task UpdateUser(UserDTO userDto)
        {
            var user = new Users
            {
                Id = userDto.Id,
                Login = userDto.Login,
                Password = userDto.Password,
                Status = userDto.Status,
                Salt = userDto.Salt,
            };
            Database.Users.Update(user);
            await Database.Save();
        }

        public async Task DeleteUser(int id)
        {
            await Database.Users.Delete(id);
            await Database.Save();
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var user = await Database.Users.Get(id);
            if (user == null)
                throw new Exception("Wrong user!");
            return new UserDTO
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Status = user.Status,
                Salt = user.Salt,
            };
        }

        // Automapper позволяет проецировать одну модель на другую, что позволяет сократить объемы кода и упростить программу.

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, IEnumerable<UserDTO>>(await Database.Users.GetAll());
        }

    }
}
