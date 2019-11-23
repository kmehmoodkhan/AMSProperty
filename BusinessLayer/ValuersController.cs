using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
    public class ValuersController
    {
        public ValuersController() { }

        #region Valuers
        public DataSet ValuersSelectAll(Int64 UserId, Int64 ValuationCompanyId, Int64 Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[0].Value = UserId;

                sqlParameter[1] = new SqlParameter("@ValuationCompanyId", SqlDbType.BigInt);
                sqlParameter[1].Value = ValuationCompanyId;

                sqlParameter[2] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[2].Value = Status;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_ValuersSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 ValuersEdit(Int64 Id, Int64 UserId, string CompanyName, string Email,
        string FirstName, string LastName, string Address, string Suburb, string State, string Postcode,
        string Phone1, string Phone2, string OtherDetails, string Fax,
        Int64 CreatedBy, Int64 ModifiedBy, Int64 Status, string Option,Int64 ValuationCompanyId,
        string Title, string Qualifications, string Experience, string MembershipStatus, string MembershipBody)
        {
            SqlParameter[] sqlParameter = new SqlParameter[25];
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

                sqlParameter[5] = new SqlParameter("@CompanyName", SqlDbType.NVarChar);
                sqlParameter[5].Value = CompanyName;

                sqlParameter[6] = new SqlParameter("@Address", SqlDbType.NVarChar);
                sqlParameter[6].Value = Address;

                sqlParameter[7] = new SqlParameter("@Suburb", SqlDbType.NVarChar);
                sqlParameter[7].Value = Suburb;

                sqlParameter[8] = new SqlParameter("@State", SqlDbType.NVarChar);
                sqlParameter[8].Value = State;

                sqlParameter[9] = new SqlParameter("@Postcode", SqlDbType.NVarChar);
                sqlParameter[9].Value = Postcode;

                sqlParameter[10] = new SqlParameter("@Phone1", SqlDbType.NVarChar);
                sqlParameter[10].Value = Phone1;

                sqlParameter[11] = new SqlParameter("@Phone2", SqlDbType.NVarChar);
                sqlParameter[11].Value = Phone2;

                sqlParameter[12] = new SqlParameter("@OtherDetails", SqlDbType.NVarChar);
                sqlParameter[12].Value = OtherDetails;

                sqlParameter[13] = new SqlParameter("@Fax", SqlDbType.NVarChar);
                sqlParameter[13].Value = Fax;

                sqlParameter[14] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[14].Value = CreatedBy;

                sqlParameter[15] = new SqlParameter("@ModifiedBy", SqlDbType.BigInt);
                sqlParameter[15].Value = ModifiedBy;

                sqlParameter[16] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[16].Value = Status;

                sqlParameter[17] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[17].Value = Option;

                sqlParameter[18] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[18].Direction = ParameterDirection.Output;

                sqlParameter[19] = new SqlParameter("@ValuationCompanyId", SqlDbType.BigInt);
                sqlParameter[19].Value = ValuationCompanyId;

                sqlParameter[20] = new SqlParameter("@Title", SqlDbType.NVarChar);
                sqlParameter[20].Value = Title;

                sqlParameter[21] = new SqlParameter("@Qualifications", SqlDbType.NVarChar);
                sqlParameter[21].Value = Qualifications;

                sqlParameter[22] = new SqlParameter("@Experience", SqlDbType.NVarChar);
                sqlParameter[22].Value = Experience;

                sqlParameter[23] = new SqlParameter("@MembershipStatus", SqlDbType.NVarChar);
                sqlParameter[23].Value = MembershipStatus;

                sqlParameter[24] = new SqlParameter("@MembershipBody", SqlDbType.NVarChar);
                sqlParameter[24].Value = MembershipBody;



                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ValuersEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[18].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }

        public Int64 ValuersLogoEdit(Int64 Id, Int64 UserId, string ValuerLogo)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[1].Value = UserId;

                sqlParameter[2] = new SqlParameter("@ValuerLogo", SqlDbType.NVarChar);
                sqlParameter[2].Value = ValuerLogo;

                sqlParameter[3] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[3].Direction = ParameterDirection.Output;


                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ValuersLogoEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[3].Value);
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
