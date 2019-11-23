using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
    public class UsersController
    {
        public UsersController() { }

        #region Users
        public DataSet UsersLogin(string Username, string Password, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@Username", SqlDbType.NVarChar);
                sqlParameter[0].Value = Username;

                sqlParameter[1] = new SqlParameter("@Password", SqlDbType.NVarChar);
                sqlParameter[1].Value = Password;

                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_UsersLogin", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 UsersLoginCreate(string Username, string Password, string UserType, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[5];
            try
            {
                sqlParameter[0] = new SqlParameter("@Username", SqlDbType.NVarChar);
                sqlParameter[0].Value = Username;

                sqlParameter[1] = new SqlParameter("@Password", SqlDbType.NVarChar);
                sqlParameter[1].Value = Password;

                sqlParameter[2] = new SqlParameter("@UserType", SqlDbType.NVarChar);
                sqlParameter[2].Value = UserType;

                sqlParameter[3] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[3].Value = Option;

                sqlParameter[4] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[4].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_UsersLoginCreate", sqlParameter);
                return Convert.ToInt64(sqlParameter[4].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }

        public Int64 UsersPasswordEdit(Int64 UserId, string Password, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[0].Value = UserId;

                sqlParameter[1] = new SqlParameter("@Password", SqlDbType.NVarChar);
                sqlParameter[1].Value = Password;
                               
                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;                               

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_UsersPasswordEdit", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }

        public DataSet UsersSelect(Int64 Id)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_UsersSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public DataSet SuperAdministratorSelect(Int64 UserId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[0].Value = UserId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_SuperAdministratorSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 SuperAdministratorEdit(Int64 Id, Int64 UserId, string Email,
        string FirstName, string LastName, string Address, string Suburb, string State, string Postcode,
        string Phone1, string Phone2, string OtherDetails, string Fax,
        Int64 CreatedBy, Int64 ModifiedBy, Int64 Status, string Option, string Username, string Password)
        {
            SqlParameter[] sqlParameter = new SqlParameter[20];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[1].Value = UserId;

                sqlParameter[2] = new SqlParameter("@Email", SqlDbType.NVarChar);
                sqlParameter[2].Value = Email;

                sqlParameter[3] = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                sqlParameter[3].Value = FirstName;

                sqlParameter[4] = new SqlParameter("@LastName", SqlDbType.NVarChar);
                sqlParameter[4].Value = LastName;
                
                sqlParameter[5] = new SqlParameter("@Address", SqlDbType.NVarChar);
                sqlParameter[5].Value = Address;

                sqlParameter[6] = new SqlParameter("@Suburb", SqlDbType.NVarChar);
                sqlParameter[6].Value = Suburb;

                sqlParameter[7] = new SqlParameter("@State", SqlDbType.NVarChar);
                sqlParameter[7].Value = State;

                sqlParameter[8] = new SqlParameter("@Postcode", SqlDbType.NVarChar);
                sqlParameter[8].Value = Postcode;

                sqlParameter[9] = new SqlParameter("@Phone1", SqlDbType.NVarChar);
                sqlParameter[9].Value = Phone1;

                sqlParameter[10] = new SqlParameter("@Phone2", SqlDbType.NVarChar);
                sqlParameter[10].Value = Phone2;

                sqlParameter[11] = new SqlParameter("@OtherDetails", SqlDbType.NVarChar);
                sqlParameter[11].Value = OtherDetails;

                sqlParameter[12] = new SqlParameter("@Fax", SqlDbType.NVarChar);
                sqlParameter[12].Value = Fax;

                sqlParameter[13] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[13].Value = CreatedBy;

                sqlParameter[14] = new SqlParameter("@ModifiedBy", SqlDbType.BigInt);
                sqlParameter[14].Value = ModifiedBy;

                sqlParameter[15] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[15].Value = Status;

                sqlParameter[16] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[16].Value = Option;

                sqlParameter[17] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[17].Direction = ParameterDirection.Output;

                sqlParameter[18] = new SqlParameter("@Username", SqlDbType.NVarChar);
                sqlParameter[18].Value = Username;

                sqlParameter[19] = new SqlParameter("@Password", SqlDbType.NVarChar);
                sqlParameter[19].Value = Password;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_SuperAdministratorEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[17].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        #endregion
    }
}
