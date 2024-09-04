using Daydream.BAL.Constants;
using Daydream.BAL.Model;
using Daydream.BAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using static Daydream.BAL.Constants.Constants;

namespace Daydream.BAL.Service
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly CommonFunctions _commonFunctions;

        public UserService(IConfiguration configuration, CommonFunctions commonFunctions)
        {
            _configuration = configuration;
            _commonFunctions = commonFunctions;
        }

        public async Task<JsonResponse> AddUpdateUser(User user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id",user.Id),
                new SqlParameter("@FirstName",user.FirstName),
                new SqlParameter("@LastName",user.LastName),
                new SqlParameter("@EmailId",user.EmailId),
                new SqlParameter("@MobileNumber",user.MobileNumber),
                new SqlParameter("@Password",user.Password)
            };
            DataSet dataSet = _commonFunctions.ExcecuteProcedures(Procedures.ADD_UPDATE_USER, parameters, _configuration);
            DataRow? dataRow = dataSet?.Tables[0]?.Rows[0];
            JsonResponse response = new();
            if (dataRow != null)
            {
                response.Status = Convert.ToString(dataRow["STATUS"]);
                response.Message = Convert.ToString(dataRow["MESSAGE"]);
            }
            else
            {
                response.Status = ResponseStatus.FAILURE;
                response.Message = ResponseMessage.FAILURE;
            }
            return response;
        }

        public async Task<JsonResponse> Login(string? username, string? password)
        {
            DataSet dataSet = new DataSet();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", username),
                new SqlParameter("Password",password)
            };
            dataSet = _commonFunctions.ExcecuteProcedures(Procedures.LOGIN, parameters, _configuration);
            DataRow dataRow = dataSet.Tables[0].Rows[0];
            JsonResponse response = new JsonResponse
            {
                Status = Convert.ToString(dataRow["STATUS"]),
                Message = Convert.ToString(dataRow["MESSAGE"]),
                Data = Convert.ToString(dataRow["Name"])
            };
            return response;
        }
    }
}
