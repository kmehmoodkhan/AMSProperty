using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
    public class ClientsController
    {
        public ClientsController() { }

        #region Clients
        public DataSet ClientsSelectAll(Int64 UserId, string ClientType, Int64 CreatedBy)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[0].Value = UserId;

                sqlParameter[1] = new SqlParameter("@ClientType", SqlDbType.NVarChar);
                sqlParameter[1].Value = ClientType;

                sqlParameter[2] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[2].Value = CreatedBy;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_ClientsSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 ClientsEdit(Int64 Id, Int64 UserId, string ClientType, string Email, string FirstName,
        string LastName, string CompanyName, string Address, string Suburb, string State, string Postcode,
        string Phone1, string Phone2, string OtherDetails, string Fax, string ABN,
        Int64 CreatedBy, Int64 ModifiedBy, Int64 Status, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[21];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[1].Value = UserId;

                sqlParameter[2] = new SqlParameter("@ClientType", SqlDbType.NVarChar);
                sqlParameter[2].Value = ClientType;

                sqlParameter[3] = new SqlParameter("@Email", SqlDbType.NVarChar);
                sqlParameter[3].Value = Email;

                sqlParameter[4] = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                sqlParameter[4].Value = FirstName;

                sqlParameter[5] = new SqlParameter("@LastName", SqlDbType.NVarChar);
                sqlParameter[5].Value = LastName;

                sqlParameter[6] = new SqlParameter("@CompanyName", SqlDbType.NVarChar);
                sqlParameter[6].Value = CompanyName;

                sqlParameter[7] = new SqlParameter("@Address", SqlDbType.NVarChar);
                sqlParameter[7].Value = Address;

                sqlParameter[8] = new SqlParameter("@Suburb", SqlDbType.NVarChar);
                sqlParameter[8].Value = Suburb;

                sqlParameter[9] = new SqlParameter("@State", SqlDbType.NVarChar);
                sqlParameter[9].Value = State;

                sqlParameter[10] = new SqlParameter("@Postcode", SqlDbType.NVarChar);
                sqlParameter[10].Value = Postcode;

                sqlParameter[11] = new SqlParameter("@Phone1", SqlDbType.NVarChar);
                sqlParameter[11].Value = Phone1;

                sqlParameter[12] = new SqlParameter("@Phone2", SqlDbType.NVarChar);
                sqlParameter[12].Value = Phone2;

                sqlParameter[13] = new SqlParameter("@OtherDetails", SqlDbType.NVarChar);
                sqlParameter[13].Value = OtherDetails;

                sqlParameter[14] = new SqlParameter("@Fax", SqlDbType.NVarChar);
                sqlParameter[14].Value = Fax;

                sqlParameter[15] = new SqlParameter("@ABN", SqlDbType.NVarChar);
                sqlParameter[15].Value = ABN;

                sqlParameter[16] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[16].Value = CreatedBy;

                sqlParameter[17] = new SqlParameter("@ModifiedBy", SqlDbType.BigInt);
                sqlParameter[17].Value = ModifiedBy;

                sqlParameter[18] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[18].Value = Status;

                sqlParameter[19] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[19].Value = Option;

                sqlParameter[20] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[20].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ClientsEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[20].Value);
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
