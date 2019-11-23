using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
    public class ClientsBranchManagerController
    {
        public ClientsBranchManagerController() { }

        #region ClientsBranchManagerController
        public DataSet ClientsBranchManagerSelectAll(Int64 UserId, Int64 ClientId, Int64 CreatedBy)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[0].Value = UserId;

                sqlParameter[1] = new SqlParameter("@ClientId", SqlDbType.BigInt);
                sqlParameter[1].Value = ClientId;

                sqlParameter[2] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[2].Value = CreatedBy;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_ClientsBranchManagerSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 ClientsBranchManagerEdit(Int64 Id, Int64 UserId, Int64 ClientId, string Email, string FirstName,
        string LastName, string CompanyName, string Address, string Suburb, string State, string Postcode,
        string Phone1, string Phone2, string OtherDetails, string Fax,
        Int64 CreatedBy, Int64 ModifiedBy, Int64 Status, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[20];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[1].Value = UserId;

                sqlParameter[2] = new SqlParameter("@ClientId", SqlDbType.NVarChar);
                sqlParameter[2].Value = ClientId;

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

                sqlParameter[15] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[15].Value = CreatedBy;

                sqlParameter[16] = new SqlParameter("@ModifiedBy", SqlDbType.BigInt);
                sqlParameter[16].Value = ModifiedBy;

                sqlParameter[17] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[17].Value = Status;

                sqlParameter[18] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[18].Value = Option;

                sqlParameter[19] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[19].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ClientsBranchManagerEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[19].Value);
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
