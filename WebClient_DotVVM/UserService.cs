using ServiceUserReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient_DotVVM.Model;

namespace WebClient_DotVVM
{
    public class UserService
    {
        readonly WebServiceUserClient reference = new WebServiceUserClient();

        public List<UserListModel> GetAllUsers()
        {
            return reference.GetAsync().Result.Select(
                s => new UserListModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList();
        }

        public async Task<UserDetailModel> GetUserByIdAsync(int Id)
        {
            var result = await reference.GetUserByIdAsync(Id);

            return new UserDetailModel()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Username = result.UserName,
                Password = result.Password,
                EnrollmentDate = result.EnrollmentDate
            };
        }

        public async Task InsertUserAsync(UserDetailModel user)
        {
            UserDTO NewUser = new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Username,
                Password = user.Password,
                EnrollmentDate = user.EnrollmentDate
            };

            await reference.InsertUserAsync(NewUser);
        }

        public async Task UpdateUserAsync(UserDetailModel user)
        {
            UserDTO UserToUpdate = new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Username,
                Password = user.Password,
                EnrollmentDate = user.EnrollmentDate
            };

            await reference.UpdateUserAsync(UserToUpdate);
        }

        public async Task DeleteUserAsync(int Id)
        {
            await reference.DeleteUserAsync(Id);
        }
    }
}
