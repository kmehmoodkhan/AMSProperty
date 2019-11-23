using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
    public class ComplianceController
    {
        public ComplianceController() { }

        #region Compliance
        public DataSet ComplianceSelectAll(Int64 UserId, Int64 CreatedBy)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[0].Value = UserId;

                sqlParameter[1] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[1].Value = CreatedBy;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_ComplianceSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 ComplianceEdit(Int64 Id, Int64 UserId, string Email, string FirstName, string LastName,
        string Address, string Suburb, string State, string Postcode,
        string Phone1, string Phone2, string OtherDetails, string Fax,
        Int64 CreatedBy, Int64 ModifiedBy, Int64 Status, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[18];
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

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ComplianceEdit", sqlParameter);
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
