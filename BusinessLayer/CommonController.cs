using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using ExpertPdf.HtmlToPdf;
using ExpertPdf.HtmlToPdf.PdfDocument;
using System.Web;
using System.IO;
using System.Xml;
using System.Collections;
using System.Configuration;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public class CommonController
    {
        public CommonController() { }

        public static DataSet JobStatusAllSelect()
        {
            try
            {
                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_JobsStatusSelect", null);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        #region Transaction Type

        public DataSet SelectConfirmationofValuersAppointmentDetails(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_EmailConfirmationofValuersAppointmentDetails", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public DataSet TransactionTypeSelectAll(Int64 Id)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_TransactionTypeSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 TransactionTypeEdit(Int64 Id, string TransactionTypeName, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@TransactionTypeName", SqlDbType.NVarChar);
                sqlParameter[1].Value = TransactionTypeName;

                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;

                sqlParameter[3] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[3].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_TransactionTypeEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[3].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        #endregion

        #region AccessArangements Type
        public DataSet AccessArangementsTypeSelectAll(Int64 Id)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_AccessArangementsTypeSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 AccessArangementsTypeEdit(Int64 Id, string AccessArangementsTypeName, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@AccessArangementsTypeName", SqlDbType.NVarChar);
                sqlParameter[1].Value = AccessArangementsTypeName;

                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;

                sqlParameter[3] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[3].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_AccessArangementsTypeEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[3].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        #endregion

        #region Property Type
        public DataSet PropertyTypeSelectAll(Int64 Id)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_PropertyTypeSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 PropertyTypeEdit(Int64 Id, string PropertyTypeName, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@PropertyTypeName", SqlDbType.NVarChar);
                sqlParameter[1].Value = PropertyTypeName;

                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;

                sqlParameter[3] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[3].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_PropertyTypeEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[3].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        #endregion

        #region Property Type
        public DataSet PurposeSelectAll(Int64 Id)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_PurposeSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 PurposeEdit(Int64 Id, string PurposeName, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@PurposeName", SqlDbType.NVarChar);
                sqlParameter[1].Value = PurposeName;

                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;

                sqlParameter[3] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[3].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_PurposeEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[3].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        #endregion

        #region Lookup Type
        public DataSet LookupTypeSelectAll(Int64 lookupId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@LookupId", SqlDbType.BigInt);
                sqlParameter[0].Value = lookupId;


                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Lookupselect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 LookupTypeEdit(Int64 LookupId, string type, string name, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[5];
            try
            {
                sqlParameter[0] = new SqlParameter("@LookupId", SqlDbType.BigInt);
                sqlParameter[0].Value = LookupId;

                sqlParameter[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
                sqlParameter[1].Value = name;

                sqlParameter[2] = new SqlParameter("@Type", SqlDbType.NVarChar);
                sqlParameter[2].Value = type;

                sqlParameter[3] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[3].Value = Option;

                sqlParameter[4] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[4].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_lookup", sqlParameter);
                return Convert.ToInt64(sqlParameter[4].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }

        public DataSet getlist(string Listcode)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@ListCode", SqlDbType.NVarChar);
                sqlParameter[0].Value = Listcode;



                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_getlist", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public DataSet GetCustomList()
        {
            try
            {
                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_getCustomlist", null);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }


        #endregion

        #region Service Type
        public DataSet ServiceTypeSelectAll(Int64 Id)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_ServiceTypeSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 ServiceTypeEdit(Int64 Id, string ServiceTypeName, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@ServiceTypeName", SqlDbType.NVarChar);
                sqlParameter[1].Value = ServiceTypeName;

                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;

                sqlParameter[3] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[3].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ServiceTypeEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[3].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        #endregion

        #region Urgency
        public DataSet UrgencySelectAll(Int64 Id)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_UrgencySelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 UrgencyEdit(Int64 Id, string UrgencyName, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@UrgencyName", SqlDbType.NVarChar);
                sqlParameter[1].Value = UrgencyName;

                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;

                sqlParameter[3] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[3].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_UrgencyEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[3].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        #endregion

        #region ValuationType
        public DataSet ValuationTypeSelectAll(Int64 Id)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_ValuationTypeSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public Int64 ValuationTypeEdit(Int64 Id, string ValuationTypeName, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[4];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@ValuationTypeName", SqlDbType.NVarChar);
                sqlParameter[1].Value = ValuationTypeName;

                sqlParameter[2] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[2].Value = Option;

                sqlParameter[3] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[3].Direction = ParameterDirection.Output;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_ValuationTypeEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[3].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        #endregion

        #region Emails
        public void SendToClientForConfirmationofValuersInspected(string ToEmail, string ToEmail1, string ReplyTo,
            string FromEmail, string FromName, string Message, string AccountUpload, string Subject)
        {
            try
            {
                try
                {
                    CommonController.LogInsert("ToEmail:", ToEmail);
                    CommonController.LogInsert("ReplyTo:", ReplyTo);
                    CommonController.LogInsert("FromEmail:", FromEmail);
                    CommonController.LogInsert("FromName:", FromName);

                    string Username = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
                    //string FromName = System.Configuration.ConfigurationSettings.AppSettings["FromName"].ToString();
                    string SMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();
                    string Port = System.Configuration.ConfigurationSettings.AppSettings["Port"].ToString();
                    string Password = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();
                    //string FromEmail = System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();

                    MailMessage MailMsg = new MailMessage(new MailAddress(FromEmail, FromName), new MailAddress(ToEmail));

                    if (ToEmail1 != "")
                        MailMsg.Bcc.Add(ToEmail1);

                    MailAddress MAReplyTo = new MailAddress(ReplyTo);
                    MailMsg.ReplyTo = MAReplyTo;

                    MailMsg.Subject = Subject;
                    MailMsg.Body = Message;

                    MailMsg.Priority = MailPriority.High;
                    MailMsg.IsBodyHtml = true;

                    if (AccountUpload != "")
                    {
                        Attachment attach = new Attachment(AccountUpload);
                        MailMsg.Attachments.Add(attach);
                    }

                    if (Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailMode"]) == "Server")
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = SMTP;
                        smtp.Port = Convert.ToInt16(Port);
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(MailMsg);

                    }
                    else
                    {
                        SmtpClient SmtpMail = new SmtpClient(SMTP, Convert.ToInt16(Port));
                        SmtpMail.Credentials = new NetworkCredential(Username, Password);

                        ////Smtpclient to send the mail message
                        //SmtpClient SmtpMail = new SmtpClient();
                        //SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                        SmtpMail.Send(MailMsg);
                        //Message Successful   
                    }
                    CommonController.LogInsert("InspectedEmail:", "Sent");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendToClientForConfirmationofValuersAppointment(string ToEmail, string ToEmail1, string ReplyTo, string FromEmail,
            string FromName, string Message, string Subject)
        {
            try
            {
                try
                {
                    CommonController.LogInsert("ToEmail:", ToEmail);
                    CommonController.LogInsert("ReplyTo:", ReplyTo);
                    CommonController.LogInsert("FromEmail:", FromEmail);
                    CommonController.LogInsert("FromName:", FromName);

                    string Username = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
                    //string FromName = System.Configuration.ConfigurationSettings.AppSettings["FromName"].ToString();
                    string SMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();
                    string Port = System.Configuration.ConfigurationSettings.AppSettings["Port"].ToString();
                    string Password = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();
                    //string FromEmail = System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();
                    MailMessage MailMsg = new MailMessage(new MailAddress(FromEmail, FromName), new MailAddress(ToEmail));

                    if (ToEmail1 != "")
                        MailMsg.Bcc.Add(ToEmail1);

                    MailMsg.Subject = Subject;
                    MailMsg.Body = Message;
                    MailMsg.Priority = MailPriority.High;
                    MailMsg.IsBodyHtml = true;

                    MailAddress MAReplyTo = new MailAddress(ReplyTo);
                    MailMsg.ReplyTo = MAReplyTo;

                    if (Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailMode"]) == "Server")
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = SMTP;
                        smtp.Port = Convert.ToInt16(Port);
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(MailMsg);
                    }
                    else
                    {
                        SmtpClient SmtpMail = new SmtpClient(SMTP, Convert.ToInt16(Port));
                        SmtpMail.Credentials = new NetworkCredential(Username, Password);

                        ////Smtpclient to send the mail message
                        //SmtpClient SmtpMail = new SmtpClient();
                        //SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                        SmtpMail.Send(MailMsg);
                        //Message Successful
                    }
                    CommonController.LogInsert("AppontmentEmail:", "Sent");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendPDFReportEmailToClient(string ToEmail, string ToEmail1, string ReplyTo, string FromEmail, 
            string FromName, string Message, string ReportUpload,
            string AccountUpload, string FieldNoteUpload, string Subject)
        {
            try
            {
                try
                {
                    string Username = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
                    //string FromName = System.Configuration.ConfigurationSettings.AppSettings["FromName"].ToString();
                    string SMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();
                    string Port = System.Configuration.ConfigurationSettings.AppSettings["Port"].ToString();
                    string Password = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();
                    //string FromEmail = System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();

                    MailMessage MailMsg = new MailMessage(new MailAddress(FromEmail, FromName), new MailAddress(ToEmail));

                    if (ToEmail1 != "")
                        MailMsg.Bcc.Add(ToEmail1);

                    MailMsg.Subject = Subject;
                    MailMsg.Body = Message;
                    MailMsg.Priority = MailPriority.High;
                    MailMsg.IsBodyHtml = true;

                    MailAddress MAReplyTo = new MailAddress(ReplyTo);
                    MailMsg.ReplyTo = MAReplyTo;

                    Attachment attach = new Attachment(ReportUpload);
                    
                    MailMsg.Attachments.Add(attach);

                    if (Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailMode"]) == "Server")
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = SMTP;
                        smtp.Port = Convert.ToInt16(Port);
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(MailMsg);
                    }
                    else
                    {

                        if (AccountUpload != "")
                        {
                            attach = new Attachment(AccountUpload);
                            MailMsg.Attachments.Add(attach);
                        }

                        if (FieldNoteUpload != "")
                        {
                            attach = new Attachment(FieldNoteUpload);
                            MailMsg.Attachments.Add(attach);
                        }

                        SmtpClient SmtpMail = new SmtpClient(SMTP, Convert.ToInt16(Port));
                        SmtpMail.Credentials = new NetworkCredential(Username, Password);

                        ////Smtpclient to send the mail message
                        //SmtpClient SmtpMail = new SmtpClient();
                        //SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                        SmtpMail.Send(MailMsg);
                        //Message Successful    
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SendContactUs(string ToEmail, string FromEmail, string Message)
        {
            try
            {
                try
                {
                    FromEmail = System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();
                    string Username = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
                    string FromName = System.Configuration.ConfigurationSettings.AppSettings["FromName"].ToString();
                    string SMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();
                    string Port = System.Configuration.ConfigurationSettings.AppSettings["Port"].ToString();
                    string Password = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();


                    MailMessage MailMsg = new MailMessage(new MailAddress(FromEmail), new MailAddress(ToEmail));
                    MailMsg.Subject = "Inquiry Details";
                    MailMsg.Body = Message;
                    MailMsg.Priority = MailPriority.High;
                    MailMsg.IsBodyHtml = true;

                    if (Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailMode"]) == "Server")
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = SMTP;
                        smtp.Port = Convert.ToInt16(Port);
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(MailMsg);
                    }
                    else
                    {
                        SmtpClient SmtpMail = new SmtpClient(SMTP, Convert.ToInt16(Port));
                        SmtpMail.Credentials = new NetworkCredential(Username, Password);

                        ////Smtpclient to send the mail message
                        //SmtpClient SmtpMail = new SmtpClient();
                        //SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                        SmtpMail.Send(MailMsg);
                        //Message Successful                          

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendForgetPasswordEmail(string ToEmail, string Message)
        {
            try
            {
                try
                {
                    string Username = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
                    string FromName = System.Configuration.ConfigurationSettings.AppSettings["FromName"].ToString();
                    string SMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();
                    string Port = System.Configuration.ConfigurationSettings.AppSettings["Port"].ToString();
                    string Password = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();
                    string FromEmail = System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();

                    MailMessage MailMsg = new MailMessage(new MailAddress(FromEmail, FromName), new MailAddress(ToEmail));
                    MailMsg.Subject = "Your Login Details";
                    MailMsg.Body = Message;
                    MailMsg.Priority = MailPriority.High;
                    MailMsg.IsBodyHtml = true;


                    if (Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailMode"]) == "Server")
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = SMTP;
                        smtp.Port = Convert.ToInt16(Port);
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(MailMsg);
                    }
                    else
                    {
                        SmtpClient SmtpMail = new SmtpClient(SMTP, Convert.ToInt16(Port));
                        SmtpMail.Credentials = new NetworkCredential(Username, Password);
                        SmtpMail.Send(MailMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendReportEditByClient(string ToEmail, string ReplyTo, string FromEmail, string FromName, string Message)
        {
            try
            {
                try
                {
                    string Username = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
                    //string FromName = System.Configuration.ConfigurationSettings.AppSettings["FromName"].ToString();
                    string SMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();
                    string Port = System.Configuration.ConfigurationSettings.AppSettings["Port"].ToString();
                    string Password = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();
                    //string FromEmail = System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();

                    MailMessage MailMsg = new MailMessage(new MailAddress(FromEmail, FromName), new MailAddress(ToEmail));

                    
                    MailAddress MAReplyTo = new MailAddress(ReplyTo);
                    MailMsg.ReplyTo = MAReplyTo;

                    MailMsg.Subject = "Information Required For Property Valuation";
                    MailMsg.Body = Message;
                    MailMsg.Priority = MailPriority.High;
                    MailMsg.IsBodyHtml = true;
                    MailMsg.Bcc.Add("ndfd2008@gmail.com");

                    if (Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailMode"]) == "Server")
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = SMTP;
                        smtp.Port = Convert.ToInt16(Port);
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(MailMsg);
                    }
                    else
                    {
                        SmtpClient SmtpMail = new SmtpClient(SMTP, Convert.ToInt16(Port));
                        SmtpMail.Credentials = new NetworkCredential(Username, Password);
                        SmtpMail.Send(MailMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendReportEditByClientToAdmin(string ReplyTo, string FromEmail, string FromName, string Message)
        {
            try
            {
                try
                {
                    string Username = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
                    //string FromName = System.Configuration.ConfigurationSettings.AppSettings["FromName"].ToString();
                    string SMTP = System.Configuration.ConfigurationSettings.AppSettings["SMTP"].ToString();
                    string Port = System.Configuration.ConfigurationSettings.AppSettings["Port"].ToString();
                    string Password = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();
                    //string FromEmail = System.Configuration.ConfigurationSettings.AppSettings["FromEmail"].ToString();

                    MailMessage MailMsg = new MailMessage(new MailAddress(FromEmail, FromName), 
                        new MailAddress(System.Configuration.ConfigurationSettings.AppSettings["AdminEmail"].ToString()));

                    MailAddress MAReplyTo = new MailAddress(ReplyTo);
                    MailMsg.ReplyTo = MAReplyTo;

                    MailMsg.Bcc.Add("ndfd2008@gmail.com");
                    MailMsg.Subject = "Information Submitted For Property Valuation";
                    MailMsg.Body = Message;
                    MailMsg.Priority = MailPriority.High;
                    MailMsg.IsBodyHtml = true;


                    if (Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["EmailMode"]) == "Server")
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = SMTP;
                        smtp.Port = Convert.ToInt16(Port);
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(MailMsg);
                    }
                    else
                    {
                        SmtpClient SmtpMail = new SmtpClient(SMTP, Convert.ToInt16(Port));
                        SmtpMail.Credentials = new NetworkCredential(Username, Password);
                        SmtpMail.Send(MailMsg);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region GENERATE ACCOUNT PDF
        public void CreateAccountPdf(string strFilePath, string strPDFFile, string RetVal)
        {
            CommonController.LogInsert("strHtmlFile", strFilePath);
            CommonController.LogInsert("strPDFFile", strPDFFile);
            CommonController.LogInsert("RetVal", RetVal);

            PdfConverter pdfConverter = new PdfConverter();
            //pdfConverter.LicenseKey = "ACsxIDExIDYgOC4wIDMxLjEyLjk5OTk=";
            pdfConverter.LicenseKey = "+dLI2cjI2cvAydnIydfJ2crI18jL18DAwMA=";

            //pdfConverter.AuthenticationOptions.Username = "marketval";
            //pdfConverter.AuthenticationOptions.Password = "Haresh12345@";
            //StreamWriter sw = new StreamWriter(strPDFFile);

            // add header and footer
            //if (cbAddHeader.Checked)
            
            AddHeader(pdfConverter);
            
            //if (cbAddFooter.Checked)
            
            AddFooter(pdfConverter);
                                    
            // call the converter and get a Document object from URL
            CommonController.LogInsert("strFilePath:", "GetPdfDocumentObjectFromUrl Method");
            Document pdfDocument = pdfConverter.GetPdfDocumentObjectFromUrl(strFilePath);
            //Document pdfDocument = pdfConverter.GetPdfDocumentObjectFromHtmlFile(strFilePath);
            CommonController.LogInsert("End:", "GetPdfDocumentObjectFromUrl Method");

            //pdfMerge.LicenseKey = "ACsxIDExIDYgOC4wIDMxLjEyLjk5OTk=";
            //pdfSplitManager.LicenseKey = "ACsxIDExIDYgOC4wIDMxLjEyLjk5OTk=";

            // get the conversion summary object from the event arguments
            ConversionSummary conversionSummary = pdfConverter.ConversionSummary;

            // the PDF page where the previous conversion ended
            PdfPage lastPage = pdfDocument.Pages[conversionSummary.LastPageIndex];
            // the last rectangle in the last PDF page where the previous conversion ended
            RectangleF lastRectangle = conversionSummary.LastPageRectangle;

            // the result of adding an element to a PDF page
            // ofers the index of the PDF page where the rendering ended 
            // and the bounding rectangle of the rendered content in the last page
            //AddElementResult addResult = null;

            // the converter for the second URL
            //HtmlToPdfElement htmlToPdfURL2 = null;

            //if (cbStartOnNewPage.Checked)
            //{
            //    // render the HTML from the second URL on a new page after the first URL
            //    PdfPage newPage = pdfDocument.Pages.AddNewPage();
            //    htmlToPdfURL2 = new HtmlToPdfElement(0, 0, textBoxURL2.Text);
            //    addResult = newPage.AddElement(htmlToPdfURL2);
            //}
            //else
            //{
            //    // render the HTML from the second URL immediately after the first URL
            //    htmlToPdfURL2 = new HtmlToPdfElement(lastRectangle.Left, lastRectangle.Bottom, textBoxURL2.Text);
            //    addResult = lastPage.AddElement(htmlToPdfURL2);
            //}

            // the PDF page where the previous conversion ended
            // lastPage = pdfDocument.Pages[addResult.EndPageIndex];

            // add a HTML string after all the rendered content
            //HtmlToPdfElement htmlStringToPdf = new HtmlToPdfElement(addResult.EndPageBounds.Left, addResult.EndPageBounds.Bottom,
            //    "<b><i>The rendered content ends here</i></b>", null);

            //lastPage.AddElement(htmlStringToPdf);

            byte[] pdfBytes = null;

            try
            {
                pdfBytes = pdfDocument.Save();
                ByteArrayToFile(strPDFFile, pdfBytes);
                CommonController.LogInsert("pdfBytes", pdfBytes.ToString());
            }
            catch (Exception Ex)
            {
                CommonController.LogInsert("_ByteArray.Length", Ex.ToString());
                throw Ex;
            }
            finally
            {
                // close the Document to realease all the resources
                pdfDocument.Close();
            }

            // send the PDF document as a response to the browser for download
            //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            //response.Clear();
            //response.AddHeader("Content-Type", "binary/octet-stream");
            //response.AddHeader("Content-Disposition",
            //    "attachment; filename=ConversionResult.pdf; size=" + pdfBytes.Length.ToString());
            //response.Flush();
            //response.BinaryWrite(pdfBytes);
            //response.Flush();
            //response.End();

        }
        public void ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                // Writes a block of bytes to this stream using data from a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                // close file stream
                _FileStream.Close();

                //return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
                CommonController.LogInsert("ByteArrayToFile", _Exception.ToString());
                throw _Exception;
                //return false;
            }

            // error occured, return false

        }
        private void AddHeader(PdfConverter pdfConverter)
        {
            try
            {
                string thisPageURL = HttpContext.Current.Request.Url.AbsoluteUri;
                string headerAndFooterHtmlUrl = thisPageURL.Substring(0, thisPageURL.LastIndexOf('/')) + "/EmailTemplates/HeaderAndFooterHtml.htm";

                //enable header
                pdfConverter.PdfDocumentOptions.ShowHeader = true;
                // set the header height in points
                pdfConverter.PdfHeaderOptions.HeaderHeight = 60;
                pdfConverter.PdfHeaderOptions.HeaderBackColor = System.Drawing.Color.DarkBlue;
                // set the header HTML area
                //pdfConverter.PdfHeaderOptions.HtmlToPdfArea = new HtmlToPdfArea(0, 0, -1, pdfConverter.PdfHeaderOptions.HeaderHeight,
                //            headerAndFooterHtmlUrl, 1024, -1);
                //pdfConverter.PdfHeaderOptions.HtmlToPdfArea.FitHeight = true;
            }
            catch (Exception Ex)
            {
                CommonController.LogInsert("AddHeader Ex:", Ex.Message.ToString());
                throw;
            }
        }

        private void AddFooter(PdfConverter pdfConverter)
        {
            try
            {
                string thisPageURL = HttpContext.Current.Request.Url.AbsoluteUri;
                string headerAndFooterHtmlUrl = thisPageURL.Substring(0, thisPageURL.LastIndexOf('/')) + "/EmailTemplates/HeaderAndFooterHtml.htm";

                //enable footer
                pdfConverter.PdfDocumentOptions.ShowFooter = true;
                // set the footer height in points
                pdfConverter.PdfFooterOptions.FooterHeight = 60;
                pdfConverter.PdfFooterOptions.FooterBackColor = System.Drawing.Color.DarkBlue;
                //write the page number
                //pdfConverter.PdfFooterOptions.TextArea = new TextArea(0, 30, "This is page &p; of &P;  ",
                //    new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));
                //pdfConverter.PdfFooterOptions.TextArea.EmbedTextFont = true;
                //pdfConverter.PdfFooterOptions.TextArea.TextAlign = HorizontalTextAlign.Right;
                //// set the footer HTML area
                //pdfConverter.PdfFooterOptions.HtmlToPdfArea = new HtmlToPdfArea(0, 0, -1, pdfConverter.PdfFooterOptions.FooterHeight,
                //            headerAndFooterHtmlUrl, 1024, -1);
                //pdfConverter.PdfFooterOptions.HtmlToPdfArea.FitHeight = true;
            }
            catch (Exception Ex)
            {
                CommonController.LogInsert("AddFooter Ex:", Ex.Message.ToString());
                throw;
            }
        }
        #endregion



        #region LOGS
        public static int LogInsert(string Title, string LogDetails)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@Title", SqlDbType.NVarChar);
                sqlParameter[0].Value = Title;

                sqlParameter[1] = new SqlParameter("@LogDetails", SqlDbType.NVarChar);
                sqlParameter[1].Value = LogDetails;

                return Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_LogsUpdate", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -2;
            }
        }
        #endregion

        public static string GetConfigurationVal(string Code)
        {
            return System.Configuration.ConfigurationSettings.AppSettings[Code].ToString();
        }

        public static string Encrypt(string clearText)
        {
            //string EncryptionKey = "HARES73834";
            //byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            //using (Aes encryptor = Aes.Create())
            //{
            //    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            //    encryptor.Key = pdb.GetBytes(32);
            //    encryptor.IV = pdb.GetBytes(16);
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
            //        {
            //            cs.Write(clearBytes, 0, clearBytes.Length);
            //            cs.Close();
            //        }
            //        clearText = Convert.ToBase64String(ms.ToArray());
            //    }
            //}
            clearText = "OlnQbC"+clearText+"A%H$N";
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace("OlnQbC", "");
            cipherText = cipherText.Replace("A%H$N", "");

            //string EncryptionKey = "HARES73834";
            //byte[] cipherBytes = Convert.FromBase64String(cipherText);
            //using (Aes encryptor = Aes.Create())
            //{
            //    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            //    encryptor.Key = pdb.GetBytes(32);
            //    encryptor.IV = pdb.GetBytes(16);
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
            //        {
            //            cs.Write(cipherBytes, 0, cipherBytes.Length);
            //            cs.Close();
            //        }
            //        cipherText = Encoding.Unicode.GetString(ms.ToArray());
            //    }
            //}
            return cipherText;
        }
    }
}
