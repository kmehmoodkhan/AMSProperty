using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
    public class ValuationCompanyController
    {
        public ValuationCompanyController() { }

        #region ValuationCompany
        public DataSet ValuationCompanySelectAll(Int64 UserId, Int64 CreatedBy, Int64 Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[0].Value = UserId;

                sqlParameter[1] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[1].Value = CreatedBy;

                sqlParameter[2] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[2].Value = Status;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_ValuationCompanySelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 ValuationCompanyEdit(Int64 Id, Int64 UserId, string Email, string FirstName, 
        string LastName, string CompanyName, string Address, string Suburb, string State, string Postcode,
        string Phone1, string Phone2, string OtherDetails, string Fax,
        Int64 CreatedBy, Int64 ModifiedBy, Int64 Status,
        string ProfessionalIndemnityInsurancePolicy, DateTime StartDate, DateTime EndDate, string Option,
        bool AllowJobCreate, string CompanyLogo, string BankName, string BSB, string ACNumber, string ABN,
        string URL)
        {
            SqlParameter[] sqlParameter = new SqlParameter[29];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[1].Value = UserId;

                sqlParameter[2] = new SqlParameter("@CompanyName", SqlDbType.NVarChar);
                sqlParameter[2].Value = CompanyName;

                sqlParameter[3] = new SqlParameter("@Email", SqlDbType.NVarChar);
                sqlParameter[3].Value = Email;

                sqlParameter[4] = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                sqlParameter[4].Value = FirstName;

                sqlParameter[5] = new SqlParameter("@LastName", SqlDbType.NVarChar);
                sqlParameter[5].Value = LastName;

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

                sqlParameter[17] = new SqlParameter("@ProfessionalIndemnityInsurancePolicy", SqlDbType.NVarChar);
                sqlParameter[17].Value = ProfessionalIndemnityInsurancePolicy;

                sqlParameter[18] = new SqlParameter("@StartDate", SqlDbType.DateTime);
                sqlParameter[18].Value = StartDate;

                sqlParameter[19] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                sqlParameter[19].Value = EndDate;

                sqlParameter[20] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[20].Value = Option;

                sqlParameter[21] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[21].Direction = ParameterDirection.Output;

                sqlParameter[22] = new SqlParameter("@AllowJobCreate", SqlDbType.NVarChar);
                sqlParameter[22].Value = AllowJobCreate;

                sqlParameter[23] = new SqlParameter("@CompanyLogo", SqlDbType.NVarChar);
                sqlParameter[23].Value = CompanyLogo;

                sqlParameter[24] = new SqlParameter("@BankName", SqlDbType.NVarChar);
                sqlParameter[24].Value = BankName;

                sqlParameter[25] = new SqlParameter("@BSB", SqlDbType.NVarChar);
                sqlParameter[25].Value = BSB;

                sqlParameter[26] = new SqlParameter("@ACNumber", SqlDbType.NVarChar);
                sqlParameter[26].Value = ACNumber;

                sqlParameter[27] = new SqlParameter("@ABN", SqlDbType.NVarChar);
                sqlParameter[27].Value = ABN;

                sqlParameter[28] = new SqlParameter("@URL", SqlDbType.NVarChar);
                sqlParameter[28].Value = URL;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ValuationCompanyEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[21].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        public Int64 ValuationCompanyBankAndLogoEdit(Int64 UserId, string Option,
        string CompanyLogo, string BankName, string BSB, string ACNumber, string ABN)
        {
            SqlParameter[] sqlParameter = new SqlParameter[8];
            try
            {
                sqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[0].Value = UserId;

                sqlParameter[1] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[1].Value = Option;

                sqlParameter[2] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[2].Direction = ParameterDirection.Output;

                sqlParameter[3] = new SqlParameter("@CompanyLogo", SqlDbType.NVarChar);
                sqlParameter[3].Value = CompanyLogo;

                sqlParameter[4] = new SqlParameter("@BankName", SqlDbType.NVarChar);
                sqlParameter[4].Value = BankName;

                sqlParameter[5] = new SqlParameter("@BSB", SqlDbType.NVarChar);
                sqlParameter[5].Value = BSB;

                sqlParameter[6] = new SqlParameter("@ACNumber", SqlDbType.NVarChar);
                sqlParameter[6].Value = ACNumber;

                sqlParameter[7] = new SqlParameter("@ABN", SqlDbType.NVarChar);
                sqlParameter[7].Value = ABN;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ValuationCompanyBankAndLogoEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[2].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }

        public Int64 ValuationCompanyHFImageEdit(Int64 UserId, string HeaderImage, string FooterImage)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[0].Value = UserId;

                sqlParameter[1] = new SqlParameter("@HeaderImage", SqlDbType.NVarChar);
                sqlParameter[1].Value = HeaderImage;

                sqlParameter[2] = new SqlParameter("@FooterImage", SqlDbType.NVarChar);
                sqlParameter[2].Value = FooterImage;

                sqlParameter[3] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[3].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ValuationCompanyHFImageEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[3].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }

        public Int64 ValuationCompanyOtherEdit(Int64 Id, Int64 UserId, string TermsandCondition,
       string CertificationQualification, string FamilyLawCertification)
        {
            SqlParameter[] sqlParameter = new SqlParameter[6];
            try
            {

                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[1].Value = UserId;

                sqlParameter[2] = new SqlParameter("@TermsandCondition", SqlDbType.NText);
                sqlParameter[2].Value = TermsandCondition;

                sqlParameter[3] = new SqlParameter("@CertificationQualification", SqlDbType.NText);
                sqlParameter[3].Value = CertificationQualification;

                sqlParameter[4] = new SqlParameter("@FamilyLawCertification", SqlDbType.NText);
                sqlParameter[4].Value = FamilyLawCertification;

                sqlParameter[5] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[5].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ValuationCompanyOtherEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[5].Value);
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
