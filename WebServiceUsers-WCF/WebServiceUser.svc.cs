using System;
using System.Collections.Generic;
using System.Linq;
using WebServiceUsers_WCF.DAL.Entities;
using WebServiceUsers_WCF.DTOs;

namespace WebServiceUsers_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WebServiceUser : IWebServiceUser
    {
        private readonly PruebasContext DBContext = new PruebasContext();

        public List<UserDTO> Get()
        {
                return DBContext.User.Select(
            s => new UserDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserName = s.UserName,
                Password = s.Password,
                EnrollmentDate = s.EnrollmentDate
            }
              ).ToList();
        }

        public UserDTO GetUserById(int Id)
        {
            return DBContext.User.Select(
            s => new UserDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                UserName = s.UserName,
                Password = s.Password,
                EnrollmentDate = s.EnrollmentDate
            })
        .FirstOrDefault(s => s.Id == Id);
        }

        public bool InsertUser(UserDTO User)
        {
            var entity = new User()
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                UserName = User.UserName,
                Password = User.Password,
                EnrollmentDate = User.EnrollmentDate
            };

            DBContext.User.Add(entity);
            DBContext.SaveChangesAsync();

            return true;
        }

        public void UpdateUser(UserDTO User)
        {
            var entity = DBContext.User.FirstOrDefault(s => s.Id == User.Id);

            entity.FirstName = User.FirstName;
            entity.LastName = User.LastName;
            entity.UserName = User.UserName;
            entity.Password = User.Password;
            entity.EnrollmentDate = User.EnrollmentDate;

            DBContext.SaveChangesAsync();
        }

        public void DeleteUser(int Id)
        {
            var entity = new User()
            {
                Id = Id
            };

            DBContext.User.Attach(entity);
            DBContext.User.Remove(entity);
            DBContext.SaveChangesAsync();
        }
    }
}
