using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using WebServiceUsers_WCF.DTOs;

namespace WebServiceUsers_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IWebServiceUser
    {
        [OperationContract]
        List<UserDTO> Get();

        [OperationContract]
        UserDTO GetUserById(int Id);

        [OperationContract]
        bool InsertUser(UserDTO User);

        [OperationContract]
        void UpdateUser(UserDTO User);

        [OperationContract]
        void DeleteUser(int Id);

    }


    
}
