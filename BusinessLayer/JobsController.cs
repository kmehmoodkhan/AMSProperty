using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
    public class JobsController
    {
        public JobsController() { }

        #region Jobs
        public DataSet JobsSelectByJobId(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelectByJobId", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        public DataSet JobsSelectByJobIdForEdit(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelectByJobIdForEdit", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        public DataSet JobsHistorySelectByJobId(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsHistorySelectByJobId", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public DataSet JobsSelectCreatedBy(Int64 CreatedBy, string Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[0].Value = CreatedBy;

                sqlParameter[1] = new SqlParameter("@Status", SqlDbType.NVarChar);
                sqlParameter[1].Value = Status;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        public DataSet JobsSelectForClient(Int64 CreatedBy, string Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[0].Value = CreatedBy;

                sqlParameter[1] = new SqlParameter("@Status", SqlDbType.NVarChar);
                sqlParameter[1].Value = Status;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelectForClient", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        public DataSet JobsSelectForValuationManager(string Status, string IsEditRequest, 
            string JobId, string Street, string Client, string Suburb, string ValuerId,int purposeId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[8];
            try
            {
                sqlParameter[0] = new SqlParameter("@Status", SqlDbType.NVarChar);
                sqlParameter[0].Value = Status;

                sqlParameter[1] = new SqlParameter("@IsEditRequest", SqlDbType.NVarChar);
                sqlParameter[1].Value = IsEditRequest;

                sqlParameter[2] = new SqlParameter("@JobId", SqlDbType.NVarChar);
                sqlParameter[2].Value = JobId;

                sqlParameter[3] = new SqlParameter("@Street", SqlDbType.NVarChar);
                sqlParameter[3].Value = Street;

                sqlParameter[4] = new SqlParameter("@Client", SqlDbType.NVarChar);
                sqlParameter[4].Value = Client;

                sqlParameter[5] = new SqlParameter("@Suburb", SqlDbType.NVarChar);
                sqlParameter[5].Value = Suburb;

                sqlParameter[6] = new SqlParameter("@ValuerId", SqlDbType.NVarChar);
                sqlParameter[6].Value = ValuerId;


                sqlParameter[7] = new SqlParameter("@PurposeId", SqlDbType.Int);
                sqlParameter[7].Value = purposeId;



                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelectForValuationManager", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        public DataSet JobsSelectForValuationManagerDownloadReports(string Start, string End, string Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@Start", SqlDbType.NVarChar);
                sqlParameter[0].Value = Start;

                sqlParameter[1] = new SqlParameter("@End", SqlDbType.NVarChar);
                sqlParameter[1].Value = End;

                sqlParameter[2] = new SqlParameter("@Status", SqlDbType.NVarChar);
                sqlParameter[2].Value = Status;


                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelectForValuationManagerDownloadReports", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        public DataSet JobsSelectForValuationManagerDownloadClients(string Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@Status", SqlDbType.NVarChar);
                sqlParameter[0].Value = Status;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelectForValuationManagerDownloadClients", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        public DataSet JobsSelectForValuationCompany(Int64 ValuationCompanyAssignedId, string Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@ValuationCompanyAssignedId", SqlDbType.BigInt);
                sqlParameter[0].Value = ValuationCompanyAssignedId;

                sqlParameter[1] = new SqlParameter("@Status", SqlDbType.NVarChar);
                sqlParameter[1].Value = Status;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelectForValuationCompany", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public DataSet JobsSelectForValuer(Int64 ValuerId, string Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@ValuerId", SqlDbType.BigInt);
                sqlParameter[0].Value = ValuerId;

                sqlParameter[1] = new SqlParameter("@Status", SqlDbType.NVarChar);
                sqlParameter[1].Value = Status;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelectForValuers", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public DataSet JobsSelectForReviewer(Int64 ReviewerId, string Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@ReviewerId", SqlDbType.BigInt);
                sqlParameter[0].Value = ReviewerId;

                sqlParameter[1] = new SqlParameter("@Status", SqlDbType.NVarChar);
                sqlParameter[1].Value = Status;


                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsSelectForReviewers", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 JobsEdit(Int64 JobId, Int64 ClientId, Int64 UserId, Int64 InstructedBy, Int64 PreparedFor,
        string LoanReference, string CustomerFullName, string CustomerPhoneNumber, string CustomerMobilePhoneNumber,
        string CustomerAdditionalPhoneNumber, Int64 AccessArangementsVia, string NameOfPersonToContactForAccess,
        string PhoneNumber, string MobilePhoneNumber, string AdditionalPhoneNumber, string AdditionalNotes,
        string UnitLot, string StreetNumber, string StreetName, string StreetType, string Suburb, string Postcode,
        string PriorJobreference, string ContractPrice, DateTime? ContractDate, string EstimatedPrice, Int64 ServiceType,
        Int64 ValuationType, Int64 PropertyType, Int64 Purpose, Int64 TransactionType, Int64 Urgency, string QuoteFee,
        Int64 CreatedBy, Int64 ModifiedBy, Int64 Status, string Option, string EmailAddress, string ClientName,
        string CreatedByType, string State, string ClientAddress, string EmailAddress1, string ValuationInstruction,
        string PropertyReport, string Overlays, string Title)
        {
            SqlParameter[] sqlParameter = new SqlParameter[48];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@ClientId", SqlDbType.BigInt);
                sqlParameter[1].Value = ClientId;

                sqlParameter[2] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[2].Value = UserId;

                sqlParameter[3] = new SqlParameter("@InstructedBy", SqlDbType.BigInt);
                sqlParameter[3].Value = InstructedBy;

                sqlParameter[4] = new SqlParameter("@PreparedFor", SqlDbType.BigInt);
                sqlParameter[4].Value = PreparedFor;

                sqlParameter[5] = new SqlParameter("@LoanReference", SqlDbType.NVarChar);
                sqlParameter[5].Value = LoanReference;

                sqlParameter[6] = new SqlParameter("@CustomerFullName", SqlDbType.NVarChar);
                sqlParameter[6].Value = CustomerFullName;

                sqlParameter[7] = new SqlParameter("@CustomerPhoneNumber", SqlDbType.NVarChar);
                sqlParameter[7].Value = CustomerPhoneNumber;

                sqlParameter[8] = new SqlParameter("@CustomerMobilePhoneNumber", SqlDbType.NVarChar);
                sqlParameter[8].Value = CustomerMobilePhoneNumber;

                sqlParameter[9] = new SqlParameter("@CustomerAdditionalPhoneNumber", SqlDbType.NVarChar);
                sqlParameter[9].Value = CustomerAdditionalPhoneNumber;

                sqlParameter[10] = new SqlParameter("@AccessArangementsVia", SqlDbType.BigInt);
                sqlParameter[10].Value = AccessArangementsVia;

                sqlParameter[11] = new SqlParameter("@NameOfPersonToContactForAccess", SqlDbType.NVarChar);
                sqlParameter[11].Value = NameOfPersonToContactForAccess;

                sqlParameter[12] = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar);
                sqlParameter[12].Value = PhoneNumber;

                sqlParameter[13] = new SqlParameter("@MobilePhoneNumber", SqlDbType.NVarChar);
                sqlParameter[13].Value = MobilePhoneNumber;

                sqlParameter[14] = new SqlParameter("@AdditionalPhoneNumber", SqlDbType.NVarChar);
                sqlParameter[14].Value = AdditionalPhoneNumber;

                sqlParameter[15] = new SqlParameter("@AdditionalNotes", SqlDbType.NVarChar);
                sqlParameter[15].Value = AdditionalNotes;

                sqlParameter[16] = new SqlParameter("@UnitLot", SqlDbType.NVarChar);
                sqlParameter[16].Value = UnitLot;

                sqlParameter[17] = new SqlParameter("@StreetNumber", SqlDbType.NVarChar);
                sqlParameter[17].Value = StreetNumber;

                sqlParameter[18] = new SqlParameter("@StreetName", SqlDbType.NVarChar);
                sqlParameter[18].Value = StreetName;

                sqlParameter[19] = new SqlParameter("@StreetType", SqlDbType.NVarChar);
                sqlParameter[19].Value = StreetType;

                sqlParameter[20] = new SqlParameter("@Suburb", SqlDbType.NVarChar);
                sqlParameter[20].Value = Suburb;

                sqlParameter[21] = new SqlParameter("@Postcode", SqlDbType.NVarChar);
                sqlParameter[21].Value = Postcode;

                sqlParameter[22] = new SqlParameter("@PriorJobreference", SqlDbType.NVarChar);
                sqlParameter[22].Value = PriorJobreference;

                sqlParameter[23] = new SqlParameter("@ContractPrice", SqlDbType.NVarChar);
                sqlParameter[23].Value = ContractPrice;
                if (ContractDate != null)
                {
                    sqlParameter[24] = new SqlParameter("@ContractDate", SqlDbType.DateTime);
                    sqlParameter[24].Value = ContractDate;
                }
                else
                {
                    sqlParameter[24] = new SqlParameter("@ContractDate", SqlDbType.DateTime);
                    sqlParameter[24].Value = DBNull.Value;
                }

                sqlParameter[25] = new SqlParameter("@EstimatedPrice", SqlDbType.NVarChar);
                sqlParameter[25].Value = EstimatedPrice;

                sqlParameter[26] = new SqlParameter("@ServiceType", SqlDbType.BigInt);
                sqlParameter[26].Value = ServiceType;

                sqlParameter[27] = new SqlParameter("@ValuationType", SqlDbType.BigInt);
                sqlParameter[27].Value = ValuationType;

                sqlParameter[28] = new SqlParameter("@PropertyType", SqlDbType.BigInt);
                sqlParameter[28].Value = PropertyType;

                sqlParameter[29] = new SqlParameter("@Purpose", SqlDbType.BigInt);
                sqlParameter[29].Value = Purpose;

                sqlParameter[30] = new SqlParameter("@TransactionType", SqlDbType.BigInt);
                sqlParameter[30].Value = TransactionType;

                sqlParameter[31] = new SqlParameter("@Urgency", SqlDbType.BigInt);
                sqlParameter[31].Value = Urgency;

                sqlParameter[32] = new SqlParameter("@QuoteFee", SqlDbType.NVarChar);
                sqlParameter[32].Value = QuoteFee;

                sqlParameter[33] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[33].Value = CreatedBy;

                sqlParameter[34] = new SqlParameter("@ModifiedBy", SqlDbType.BigInt);
                sqlParameter[34].Value = ModifiedBy;

                sqlParameter[35] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[35].Value = Status;

                sqlParameter[36] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[36].Value = Option;

                sqlParameter[37] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[37].Direction = ParameterDirection.Output;

                sqlParameter[38] = new SqlParameter("@EmailAddress", SqlDbType.NVarChar);
                sqlParameter[38].Value = EmailAddress;

                sqlParameter[39] = new SqlParameter("@ClientName", SqlDbType.NVarChar);
                sqlParameter[39].Value = ClientName;

                sqlParameter[40] = new SqlParameter("@CreatedByType", SqlDbType.NVarChar);
                sqlParameter[40].Value = CreatedByType;

                sqlParameter[41] = new SqlParameter("@State", SqlDbType.NVarChar);
                sqlParameter[41].Value = State;

                sqlParameter[42] = new SqlParameter("@ClientAddress", SqlDbType.NVarChar);
                sqlParameter[42].Value = ClientAddress;

                sqlParameter[43] = new SqlParameter("@EmailAddress1", SqlDbType.NVarChar);
                sqlParameter[43].Value = EmailAddress1;

                sqlParameter[44] = new SqlParameter("@ValuationInstruction", SqlDbType.NVarChar);
                sqlParameter[44].Value = ValuationInstruction;

                sqlParameter[45] = new SqlParameter("@PropertyReport", SqlDbType.NVarChar);
                sqlParameter[45].Value = PropertyReport;

                sqlParameter[46] = new SqlParameter("@Overlays", SqlDbType.NVarChar);
                sqlParameter[46].Value = Overlays;

                sqlParameter[47] = new SqlParameter("@Title", SqlDbType.NVarChar);
                sqlParameter[47].Value = Title;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobsEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[37].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public Int64 JobHistoryEdit(Int64 Id, Int64 JobId, Int64 UserId, string Title, string Comment,
        string HistoryType, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[8];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                sqlParameter[2] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[2].Value = UserId;

                sqlParameter[3] = new SqlParameter("@Title", SqlDbType.NVarChar);
                sqlParameter[3].Value = Title;

                sqlParameter[4] = new SqlParameter("@Comment", SqlDbType.NVarChar);
                sqlParameter[4].Value = Comment;

                sqlParameter[5] = new SqlParameter("@HistoryType", SqlDbType.NVarChar);
                sqlParameter[5].Value = HistoryType;

                sqlParameter[6] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[6].Value = Option;

                sqlParameter[7] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[7].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobHistoryEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[7].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public Int64 JobEditReject(Int64 Id, Int64 JobId, Int64 UserId, Int64 Status, decimal NewFee, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[7];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                sqlParameter[2] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[2].Value = UserId;

                sqlParameter[3] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[3].Value = Status;

                sqlParameter[4] = new SqlParameter("@NewFee", SqlDbType.Decimal);
                sqlParameter[4].Value = NewFee;

                sqlParameter[5] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[5].Value = Option;

                sqlParameter[6] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[6].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobEditReject", sqlParameter);
                return Convert.ToInt64(sqlParameter[6].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }
        public int JobStatusEdit(Int64 JobId, Int64 Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[1].Value = Status;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobStatusEdit", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public int JobAppointmentAndInspectedDateSetEdit(Int64 JobId, DateTime AppointmentDate,
        DateTime InspectedOn, Int64 Status, string InspectedEmailSendToClient, string Option, string AppointmentSetTime)
        {
            SqlParameter[] sqlParameter = new SqlParameter[7];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@AppointmentDate", SqlDbType.DateTime);
                sqlParameter[1].Value = AppointmentDate;

                sqlParameter[2] = new SqlParameter("@InspectedOn", SqlDbType.DateTime);
                sqlParameter[2].Value = InspectedOn;

                sqlParameter[3] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[3].Value = Status;

                sqlParameter[4] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[4].Value = Option;

                sqlParameter[5] = new SqlParameter("@InspectedEmailSendToClient", SqlDbType.NVarChar);
                sqlParameter[5].Value = InspectedEmailSendToClient;

                sqlParameter[6] = new SqlParameter("@AppointmentSetTime", SqlDbType.NVarChar);
                sqlParameter[6].Value = AppointmentSetTime;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobAppointmentSetEdit", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public int JobEditFinalReportSubmit(Int64 JobId, string ReportUpload, string AccountUpload,
        string FieldNoteUpload, Int64 Status, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[6];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@ReportUpload", SqlDbType.NVarChar);
                sqlParameter[1].Value = ReportUpload;

                sqlParameter[2] = new SqlParameter("@AccountUpload", SqlDbType.NVarChar);
                sqlParameter[2].Value = AccountUpload;

                sqlParameter[3] = new SqlParameter("@FieldNoteUpload", SqlDbType.NVarChar);
                sqlParameter[3].Value = FieldNoteUpload;

                sqlParameter[4] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[4].Value = Status;

                sqlParameter[5] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[5].Value = Option;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobEditFinalReportSubmit", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public int JobEditFinalReportGenerate(Int64 JobId, string ReportUpload, Int64 Status)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@ReportUpload", SqlDbType.NVarChar);
                sqlParameter[1].Value = ReportUpload;

                sqlParameter[2] = new SqlParameter("@Status", SqlDbType.BigInt);
                sqlParameter[2].Value = Status;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobEditFinalReportGenerate", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public int JobsEditAssignToValuationCompany(Int64 JobId, Int64 ValuationCompanyAssignedId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@ValuationCompanyAssignedId", SqlDbType.BigInt);
                sqlParameter[1].Value = ValuationCompanyAssignedId;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobsEditAssignToValuationCompany", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public int JobsEditReAssignToValuationCompany(Int64 JobId, Int64 ValuationCompanyAssignedId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@ValuationCompanyAssignedId", SqlDbType.BigInt);
                sqlParameter[1].Value = ValuationCompanyAssignedId;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobsEditReAssignToValuationCompany", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public int JobsEditAssignToValuer(Int64 JobId, Int64 ValuerId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@ValuerId", SqlDbType.BigInt);
                sqlParameter[1].Value = ValuerId;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobsEditAssignToValuer", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }
        public int JobsEditAssignToReviewer(Int64 JobId, Int64 ReviewerId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@ReviewerId", SqlDbType.BigInt);
                sqlParameter[1].Value = ReviewerId;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobsEditAssignToReviewer", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }
        public int JobsEditPaymentStatusCompleted(Int64 JobId, string PaymentStatus)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@PaymentStatus", SqlDbType.NVarChar);
                sqlParameter[1].Value = PaymentStatus;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobsEditPaymentStatusCompleted", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }
        public Int64 JobEditRequestsEdit(Int64 Id, Int64 JobId, string RequestTitle, string RequestDetails,
            string CreatedByName, string CreatedByType, Int64 CreatedById, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[9];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                sqlParameter[2] = new SqlParameter("@RequestTitle", SqlDbType.NVarChar);
                sqlParameter[2].Value = RequestTitle;

                sqlParameter[3] = new SqlParameter("@RequestDetails", SqlDbType.NVarChar);
                sqlParameter[3].Value = RequestDetails;

                sqlParameter[4] = new SqlParameter("@CreatedByName", SqlDbType.NVarChar);
                sqlParameter[4].Value = CreatedByName;

                sqlParameter[5] = new SqlParameter("@CreatedByType", SqlDbType.NVarChar);
                sqlParameter[5].Value = CreatedByType;

                sqlParameter[6] = new SqlParameter("@CreatedById", SqlDbType.NVarChar);
                sqlParameter[6].Value = CreatedById;

                sqlParameter[7] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[7].Value = Option;

                sqlParameter[8] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[8].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobEditRequestsEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[8].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }
        public int JobDeleteByJobId(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobDeleteByJobId", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }
        public DataSet JobEditRequestsSelect(Int64 Id, Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;


                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobEditRequestsSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        public int JobOtherNoteEdit(Int64 JobId, string OtherNote)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@OtherNote", SqlDbType.NVarChar);
                sqlParameter[1].Value = OtherNote;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobsOtherNoteEdit", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }
        public int JobDocumentEdit(Int64 JobId, string DocumentName,string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@DocumentName", SqlDbType.NVarChar);
                sqlParameter[1].Value = DocumentName;

                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobsDocumentEdit", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }
        public int JobDocumentsEdit(Int64 Id, Int64 JobId, string DocumentName, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                sqlParameter[2] = new SqlParameter("@DocumentName", SqlDbType.NVarChar);
                sqlParameter[2].Value = DocumentName;

                sqlParameter[3] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[3].Value = Option;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobDocumentsEdit", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }
        public DataSet JobDocumentsSelect(Int64 Id, Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;


                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobDocumentsSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public static int JobsEditIsClientReportEdit(Int64 JobId, int IsClientReportEdit)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@IsClientReportEdit", SqlDbType.Int);
                sqlParameter[1].Value = IsClientReportEdit;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_JobsEditIsClientReportEdit", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public static Int64 EmailHistoryEdit(Int64 Id, Int64 JobId, Int64 UserId, string EmailType,
             string ToEmail, string Subject, string FromEmail, string ReplyTo, string EmailFile, 
            string IPAddress, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[12];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                sqlParameter[2] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[2].Value = UserId;

                sqlParameter[3] = new SqlParameter("@EmailType", SqlDbType.NVarChar);
                sqlParameter[3].Value = EmailType;

                sqlParameter[4] = new SqlParameter("@ToEmail", SqlDbType.NVarChar);
                sqlParameter[4].Value = ToEmail;

                sqlParameter[5] = new SqlParameter("@Subject", SqlDbType.NVarChar);
                sqlParameter[5].Value = Subject;

                sqlParameter[6] = new SqlParameter("@FromEmail", SqlDbType.NVarChar);
                sqlParameter[6].Value = FromEmail;

                sqlParameter[7] = new SqlParameter("@ReplyTo", SqlDbType.NVarChar);
                sqlParameter[7].Value = ReplyTo;

                sqlParameter[8] = new SqlParameter("@EmailFile", SqlDbType.NVarChar);
                sqlParameter[8].Value = EmailFile;

                sqlParameter[9] = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
                sqlParameter[9].Value = IPAddress;

                sqlParameter[10] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[10].Value = Option;

                sqlParameter[11] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[11].Direction= ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_EmailHistoryEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[11].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public static DataSet EmailHistorySelect(Int64 Id, Int64 JobId, Int64 UserId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                sqlParameter[2] = new SqlParameter("@UserId", SqlDbType.BigInt);
                sqlParameter[2].Value = UserId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_EmailHistorySelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        #endregion
    }
}
