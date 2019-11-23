using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLayer
{
    public class ReportController
    {
        public ReportController() { }

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

        #region Tab 1 Summary
        public Int64 Tab1_SummaryEdit(Int64 JobId, string MarketValue, string UnitLot, string StreetNumber, string StreetName,
        string StreetType, string Suburb,string Postcode, string State, string Purpose, string InstructedBy,
        DateTime? InspectionDate, DateTime? ValuationsDate, string ValueComponent, Int64 CreatedBy, string Option,
        string LandValue, string Improvements, string Client, string Instructions, int valuationApproach)
        {
            SqlParameter[] sqlParameter = new SqlParameter[22];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@MarketValue", SqlDbType.NVarChar);
                sqlParameter[1].Value = MarketValue;

                sqlParameter[2] = new SqlParameter("@UnitLot", SqlDbType.NVarChar);
                sqlParameter[2].Value = UnitLot;

                sqlParameter[3] = new SqlParameter("@StreetNumber", SqlDbType.NVarChar);
                sqlParameter[3].Value = StreetNumber;

                sqlParameter[4] = new SqlParameter("@StreetName", SqlDbType.NVarChar);
                sqlParameter[4].Value = StreetName;

                sqlParameter[5] = new SqlParameter("@StreetType", SqlDbType.NVarChar);
                sqlParameter[5].Value = StreetType;

                sqlParameter[6] = new SqlParameter("@Suburb", SqlDbType.NVarChar);
                sqlParameter[6].Value = Suburb;

                sqlParameter[7] = new SqlParameter("@Postcode", SqlDbType.NVarChar);
                sqlParameter[7].Value = Postcode;

                sqlParameter[8] = new SqlParameter("@State", SqlDbType.NVarChar);
                sqlParameter[8].Value = State;

                sqlParameter[9] = new SqlParameter("@Purpose", SqlDbType.NVarChar);
                sqlParameter[9].Value = Purpose;

                sqlParameter[10] = new SqlParameter("@InstructedBy", SqlDbType.NVarChar);
                sqlParameter[10].Value = InstructedBy;

                sqlParameter[11] = new SqlParameter("@InspectionDate", SqlDbType.DateTime);
                if(InspectionDate.HasValue)
                    sqlParameter[11].Value = InspectionDate;
                else
                    sqlParameter[11].Value = DBNull.Value;

                
                sqlParameter[12] = new SqlParameter("@ValuationsDate", SqlDbType.DateTime);
                if (ValuationsDate.HasValue)
                    sqlParameter[12].Value = ValuationsDate;
                else
                    sqlParameter[12].Value = DBNull.Value;

                sqlParameter[13] = new SqlParameter("@ValueComponent", SqlDbType.NVarChar);
                sqlParameter[13].Value = ValueComponent;

                sqlParameter[14] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[14].Value = CreatedBy;

                sqlParameter[15] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[15].Value = Option;

                sqlParameter[16] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[16].Direction = ParameterDirection.Output;

                sqlParameter[17] = new SqlParameter("@LandValue", SqlDbType.NVarChar);
                sqlParameter[17].Value = LandValue;

                sqlParameter[18] = new SqlParameter("@Improvements", SqlDbType.NVarChar);
                sqlParameter[18].Value = Improvements;

                sqlParameter[19] = new SqlParameter("@Client", SqlDbType.NVarChar);
                sqlParameter[19].Value = Client;

                sqlParameter[20] = new SqlParameter("@Instructions", SqlDbType.NVarChar);
                sqlParameter[20].Value = Instructions;

                sqlParameter[21] = new SqlParameter("@ValuationApproach", SqlDbType.Int);
                sqlParameter[21].Value = valuationApproach;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_Tab1_SummaryEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[16].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public DataSet Tab1_SummarySelect(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Tab1_SummarySelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        #endregion

        #region Tab 2 Land
        public Int64 Tab2_LandEdit(Int64 JobId, string PropertyType, string PropertyIdentification, string TitleSearch,
        string LotNumber, string PlanNumber, string Volume, string Folio, string RegisteredProprietors, string Encumbrances,
        string SiteArea, string LocalGovernmentArea, string Zoning, string Overlays, string ZoningEffect, string Shops,
        string Transport, string Schools, string CBD, string SiteLayout, string Services, string EnvironmentalHazards,
        string PestInfestation, Int64 CreatedBy, string Option, string SqmHectares, string PlanTitle)
        {
            SqlParameter[] sqlParameter = new SqlParameter[28];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@PropertyType", SqlDbType.NVarChar);
                sqlParameter[1].Value = PropertyType;

                sqlParameter[2] = new SqlParameter("@PropertyIdentification", SqlDbType.NVarChar);
                sqlParameter[2].Value = PropertyIdentification;

                sqlParameter[3] = new SqlParameter("@TitleSearch", SqlDbType.NVarChar);
                sqlParameter[3].Value = TitleSearch;

                sqlParameter[4] = new SqlParameter("@LotNumber", SqlDbType.NVarChar);
                sqlParameter[4].Value = LotNumber;

                sqlParameter[5] = new SqlParameter("@PlanNumber", SqlDbType.NVarChar);
                sqlParameter[5].Value = PlanNumber;

                sqlParameter[6] = new SqlParameter("@Volume", SqlDbType.NVarChar);
                sqlParameter[6].Value = Volume;

                sqlParameter[7] = new SqlParameter("@Folio", SqlDbType.NVarChar);
                sqlParameter[7].Value = Folio;

                sqlParameter[8] = new SqlParameter("@RegisteredProprietors", SqlDbType.NVarChar);
                sqlParameter[8].Value = RegisteredProprietors;

                sqlParameter[9] = new SqlParameter("@Encumbrances", SqlDbType.NVarChar);
                sqlParameter[9].Value = Encumbrances;

                sqlParameter[10] = new SqlParameter("@SiteArea", SqlDbType.NVarChar);
                sqlParameter[10].Value = SiteArea;

                sqlParameter[11] = new SqlParameter("@LocalGovernmentArea", SqlDbType.NVarChar);
                sqlParameter[11].Value = LocalGovernmentArea;

                sqlParameter[12] = new SqlParameter("@Zoning", SqlDbType.NVarChar);
                sqlParameter[12].Value = Zoning;

                sqlParameter[13] = new SqlParameter("@Overlays", SqlDbType.NVarChar);
                sqlParameter[13].Value = Overlays;

                sqlParameter[14] = new SqlParameter("@ZoningEffect", SqlDbType.NVarChar);
                sqlParameter[14].Value = ZoningEffect;

                sqlParameter[15] = new SqlParameter("@Shops", SqlDbType.NVarChar);
                sqlParameter[15].Value = Shops;

                sqlParameter[16] = new SqlParameter("@Transport", SqlDbType.NVarChar);
                sqlParameter[16].Value = Transport;

                sqlParameter[17] = new SqlParameter("@Schools", SqlDbType.NVarChar);
                sqlParameter[17].Value = Schools;

                sqlParameter[18] = new SqlParameter("@CBD", SqlDbType.NVarChar);
                sqlParameter[18].Value = CBD;

                sqlParameter[19] = new SqlParameter("@SiteLayout", SqlDbType.NVarChar);
                sqlParameter[19].Value = SiteLayout;

                sqlParameter[20] = new SqlParameter("@Services", SqlDbType.NVarChar);
                sqlParameter[20].Value = Services;

                sqlParameter[21] = new SqlParameter("@EnvironmentalHazards", SqlDbType.NVarChar);
                sqlParameter[21].Value = EnvironmentalHazards;

                sqlParameter[22] = new SqlParameter("@PestInfestation", SqlDbType.NVarChar);
                sqlParameter[22].Value = PestInfestation;

                sqlParameter[23] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[23].Value = CreatedBy;

                sqlParameter[24] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[24].Value = Option;

                sqlParameter[25] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[25].Direction = ParameterDirection.Output;

                sqlParameter[26] = new SqlParameter("@SqmHectares", SqlDbType.NVarChar);
                sqlParameter[26].Value = SqmHectares;

                sqlParameter[27] = new SqlParameter("@PlanTitle", SqlDbType.NVarChar);
                sqlParameter[27].Value = PlanTitle;


                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_Tab2_LandEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[25].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public DataSet Tab2_LandSelect(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Tab2_LandSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        #endregion

        #region Tab 3 Building & Improvements
        public Int64 Tab3_BuildingImprovementsEdit(Int64 JobId, string PropertyType, string PropertyStyle, string YearBuilt, string ExternalWalls,
        string Roof, string InteriorLinings, string MainFlooring, string WindowFrames, string InternalCondition, string ExternalCondition,
        string StreetAppeal, string PergolaVerandah, string Shedding, string Pools, string Gardens, string Fencing,
        string DrivewayPaving, string Outbuildings, Int64 CreatedBy, string Option, string AncillaryImprovements)
        {
            SqlParameter[] sqlParameter = new SqlParameter[23];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@PropertyType", SqlDbType.NVarChar);
                sqlParameter[1].Value = PropertyType;

                sqlParameter[2] = new SqlParameter("@PropertyStyle", SqlDbType.NVarChar);
                sqlParameter[2].Value = PropertyStyle;

                sqlParameter[3] = new SqlParameter("@YearBuilt", SqlDbType.NVarChar);
                sqlParameter[3].Value = YearBuilt;

                sqlParameter[4] = new SqlParameter("@ExternalWalls", SqlDbType.NVarChar);
                sqlParameter[4].Value = ExternalWalls;

                sqlParameter[5] = new SqlParameter("@Roof", SqlDbType.NVarChar);
                sqlParameter[5].Value = Roof;

                sqlParameter[6] = new SqlParameter("@InteriorLinings", SqlDbType.NVarChar);
                sqlParameter[6].Value = InteriorLinings;

                sqlParameter[7] = new SqlParameter("@MainFlooring", SqlDbType.NVarChar);
                sqlParameter[7].Value = MainFlooring;

                sqlParameter[8] = new SqlParameter("@WindowFrames", SqlDbType.NVarChar);
                sqlParameter[8].Value = WindowFrames;

                sqlParameter[9] = new SqlParameter("@InternalCondition", SqlDbType.NVarChar);
                sqlParameter[9].Value = InternalCondition;

                sqlParameter[10] = new SqlParameter("@ExternalCondition", SqlDbType.NVarChar);
                sqlParameter[10].Value = ExternalCondition;

                sqlParameter[11] = new SqlParameter("@StreetAppeal", SqlDbType.NVarChar);
                sqlParameter[11].Value = StreetAppeal;

                sqlParameter[12] = new SqlParameter("@PergolaVerandah", SqlDbType.NVarChar);
                sqlParameter[12].Value = PergolaVerandah;

                sqlParameter[13] = new SqlParameter("@Shedding", SqlDbType.NVarChar);
                sqlParameter[13].Value = Shedding;

                sqlParameter[14] = new SqlParameter("@Pools", SqlDbType.NVarChar);
                sqlParameter[14].Value = Pools;

                sqlParameter[15] = new SqlParameter("@Gardens", SqlDbType.NVarChar);
                sqlParameter[15].Value = Gardens;

                sqlParameter[16] = new SqlParameter("@Fencing", SqlDbType.NVarChar);
                sqlParameter[16].Value = Fencing;

                sqlParameter[17] = new SqlParameter("@DrivewayPaving", SqlDbType.NVarChar);
                sqlParameter[17].Value = DrivewayPaving;

                sqlParameter[18] = new SqlParameter("@Outbuildings", SqlDbType.NVarChar);
                sqlParameter[18].Value = Outbuildings;

                sqlParameter[19] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[19].Value = CreatedBy;

                sqlParameter[20] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[20].Value = Option;

                sqlParameter[21] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[21].Direction = ParameterDirection.Output;

                sqlParameter[22] = new SqlParameter("@AncillaryImprovements", SqlDbType.NVarChar);
                sqlParameter[22].Value = AncillaryImprovements;


                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_Tab3_BuildingImprovementsEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[21].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public DataSet Tab3_BuildingImprovementsSelect(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Tab3_BuildingImprovementsSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        #endregion

        #region Tab 4 Rooms & Fixtures
        public Int64 Tab4_RoomsFixturesEdit(Int64 JobId, string Rooms1, string Rooms2, string Rooms3, string Rooms4,
        string Bedroom, string Bathroom, string Ensuite, string Toilet, string Laundry, string Text1,
        string HeatingCooling, Int64 CreatedBy, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[15];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@Rooms1", SqlDbType.NVarChar);
                sqlParameter[1].Value = Rooms1;

                sqlParameter[2] = new SqlParameter("@Rooms2", SqlDbType.NVarChar);
                sqlParameter[2].Value = Rooms2;

                sqlParameter[3] = new SqlParameter("@Rooms3", SqlDbType.NVarChar);
                sqlParameter[3].Value = Rooms3;

                sqlParameter[4] = new SqlParameter("@Rooms4", SqlDbType.NVarChar);
                sqlParameter[4].Value = Rooms4;

                sqlParameter[5] = new SqlParameter("@Bedroom", SqlDbType.NVarChar);
                sqlParameter[5].Value = Bedroom;

                sqlParameter[6] = new SqlParameter("@Bathroom", SqlDbType.NVarChar);
                sqlParameter[6].Value = Bathroom;

                sqlParameter[7] = new SqlParameter("@Ensuite", SqlDbType.NVarChar);
                sqlParameter[7].Value = Ensuite;

                sqlParameter[8] = new SqlParameter("@Toilet", SqlDbType.NVarChar);
                sqlParameter[8].Value = Toilet;

                sqlParameter[9] = new SqlParameter("@Laundry", SqlDbType.NVarChar);
                sqlParameter[9].Value = Laundry;

                sqlParameter[10] = new SqlParameter("@Text1", SqlDbType.NVarChar);
                sqlParameter[10].Value = Text1;
                
                sqlParameter[11] = new SqlParameter("@HeatingCooling", SqlDbType.NVarChar);
                sqlParameter[11].Value = HeatingCooling;

                sqlParameter[12] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[12].Value = CreatedBy;

                sqlParameter[13] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[13].Value = Option;

                sqlParameter[14] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[14].Direction = ParameterDirection.Output;


                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_Tab4_RoomsFixturesEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[14].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public DataSet Tab4_RoomsFixtures(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Tab4_RoomsFixturesSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        #endregion

        #region Tab 5 Areas
        public Int64 Tab5_AreasEdit(Int64 JobId, string LivingArea, string Alfresco, string Balcony, string Pergola,
        string Verandah, string Garage, string Carport, string CarSpaces, Int64 CreatedBy, string Option, string SqmEq)
        {
            SqlParameter[] sqlParameter = new SqlParameter[13];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@LivingArea", SqlDbType.NVarChar);
                sqlParameter[1].Value = LivingArea;

                sqlParameter[2] = new SqlParameter("@Alfresco", SqlDbType.NVarChar);
                sqlParameter[2].Value = Alfresco;

                sqlParameter[3] = new SqlParameter("@Balcony", SqlDbType.NVarChar);
                sqlParameter[3].Value = Balcony;

                sqlParameter[4] = new SqlParameter("@Pergola", SqlDbType.NVarChar);
                sqlParameter[4].Value = Pergola;

                sqlParameter[5] = new SqlParameter("@Verandah", SqlDbType.NVarChar);
                sqlParameter[5].Value = Verandah;

                sqlParameter[6] = new SqlParameter("@Garage", SqlDbType.NVarChar);
                sqlParameter[6].Value = Garage;

                sqlParameter[7] = new SqlParameter("@Carport", SqlDbType.NVarChar);
                sqlParameter[7].Value = Carport;

                sqlParameter[8] = new SqlParameter("@CarSpaces", SqlDbType.NVarChar);
                sqlParameter[8].Value = CarSpaces;

                sqlParameter[9] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[9].Value = CreatedBy;

                sqlParameter[10] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[10].Value = Option;

                sqlParameter[11] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[11].Direction = ParameterDirection.Output;

                sqlParameter[12] = new SqlParameter("@SqmEq", SqlDbType.NVarChar);
                sqlParameter[12].Value = SqmEq;


                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_Tab5_AreasEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[11].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public DataSet Tab5_AreasSelect(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Tab5_AreasSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        #endregion

        #region Tab 6 Comments
        public Int64 Tab6_CommentsEdit(Int64 JobId, string Instructions, string Standard,
        string LastSaleofProperty, string Defects, string Methodology, Int64 CreatedBy, string Option, string Closing)
        {
            SqlParameter[] sqlParameter = new SqlParameter[10];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                sqlParameter[1] = new SqlParameter("@Instructions", SqlDbType.NVarChar);
                sqlParameter[1].Value = Instructions;

                sqlParameter[2] = new SqlParameter("@Standard", SqlDbType.NVarChar);
                sqlParameter[2].Value = Standard;

                sqlParameter[3] = new SqlParameter("@Defects", SqlDbType.NVarChar);
                sqlParameter[3].Value = Defects;

                sqlParameter[4] = new SqlParameter("@Methodology", SqlDbType.NVarChar);
                sqlParameter[4].Value = Methodology;

                sqlParameter[5] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[5].Value = CreatedBy;

                sqlParameter[6] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[6].Value = Option;

                sqlParameter[7] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[7].Direction = ParameterDirection.Output;

                sqlParameter[8] = new SqlParameter("@Closing", SqlDbType.NVarChar);
                sqlParameter[8].Value = Closing;

                sqlParameter[9] = new SqlParameter("@LastSaleofProperty", SqlDbType.NVarChar);
                sqlParameter[9].Value = LastSaleofProperty;


                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_Tab6_CommentsEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[7].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public DataSet Tab6_CommentsSelect(Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[1];
            try
            {
                sqlParameter[0] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[0].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Tab6_CommentsSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        #endregion

        #region Tab 7 Sales Evidence
        public Int64 Tab7_SalesEvidenceEdit(Int64 Id, Int64 JobId, string Address, DateTime SaleDate, string SalePrice,
        string Type, string Year, string Construction, string RoofType, string Bedrooms, string Bathrooms,
        string CarAccommodation, string LivingArea, string LandArea, string LandAreaOption, Int64 CreatedBy, string Option,
        string ImageOrFull, string ImageName,string SalesCategory)
        {
            SqlParameter[] sqlParameter = new SqlParameter[21];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                sqlParameter[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
                sqlParameter[2].Value = Address;

                sqlParameter[3] = new SqlParameter("@SaleDate", SqlDbType.DateTime);
                sqlParameter[3].Value = SaleDate;

                sqlParameter[4] = new SqlParameter("@SalePrice", SqlDbType.NVarChar);
                sqlParameter[4].Value = SalePrice;

                sqlParameter[5] = new SqlParameter("@Type", SqlDbType.NVarChar);
                sqlParameter[5].Value = Type;

                sqlParameter[6] = new SqlParameter("@Year", SqlDbType.NVarChar);
                sqlParameter[6].Value = Year;

                sqlParameter[7] = new SqlParameter("@Construction", SqlDbType.NVarChar);
                sqlParameter[7].Value = Construction;

                sqlParameter[8] = new SqlParameter("@RoofType", SqlDbType.NVarChar);
                sqlParameter[8].Value = RoofType;

                sqlParameter[9] = new SqlParameter("@Bedrooms", SqlDbType.NVarChar);
                sqlParameter[9].Value = Bedrooms;

                sqlParameter[10] = new SqlParameter("@Bathrooms", SqlDbType.NVarChar);
                sqlParameter[10].Value = Bathrooms;

                sqlParameter[11] = new SqlParameter("@CarAccommodation", SqlDbType.NVarChar);
                sqlParameter[11].Value = CarAccommodation;

                sqlParameter[12] = new SqlParameter("@LivingArea", SqlDbType.NVarChar);
                sqlParameter[12].Value = LivingArea;

                sqlParameter[13] = new SqlParameter("@LandArea", SqlDbType.NVarChar);
                sqlParameter[13].Value = LandArea;

                sqlParameter[14] = new SqlParameter("@LandAreaOption", SqlDbType.NVarChar);
                sqlParameter[14].Value = LandAreaOption;

                sqlParameter[15] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[15].Value = CreatedBy;

                sqlParameter[16] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[16].Value = Option;

                sqlParameter[17] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[17].Direction = ParameterDirection.Output;

                sqlParameter[18] = new SqlParameter("@ImageOrFull", SqlDbType.NVarChar);
                sqlParameter[18].Value = ImageOrFull;

                sqlParameter[19] = new SqlParameter("@ImageName", SqlDbType.NVarChar);
                sqlParameter[19].Value = ImageName;

                sqlParameter[20] = new SqlParameter("@SalesCategory", SqlDbType.NVarChar);
                sqlParameter[20].Value = SalesCategory;

                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_Tab7_SalesEvidenceEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[17].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public DataSet Tab7_SalesEvidenceSelect(Int64 Id, Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Tab7_SalesEvidenceSelect", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }

        public DataSet Tab7_SalesEvidenceSelectUnique(Int64 Id, Int64 JobId)
        {
            SqlParameter[] sqlParameter = new SqlParameter[2];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Tab7_SalesEvidenceSelectUnique", sqlParameter);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return null;
            }
        }
        #endregion

        #region Tab 8 Attachments
        public Int64 Tab8_AttachmentsEdit(Int64 Id, Int64 JobId, string ImageName, string ImageType,
        Int64 CreatedBy, string Option)
        {
            SqlParameter[] sqlParameter = new SqlParameter[7];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                sqlParameter[2] = new SqlParameter("@ImageName", SqlDbType.NVarChar);
                sqlParameter[2].Value = ImageName;

                sqlParameter[3] = new SqlParameter("@ImageType", SqlDbType.NVarChar);
                sqlParameter[3].Value = ImageType;

                sqlParameter[4] = new SqlParameter("@CreatedBy", SqlDbType.BigInt);
                sqlParameter[4].Value = CreatedBy;

                sqlParameter[5] = new SqlParameter("@Option", SqlDbType.NVarChar);
                sqlParameter[5].Value = Option;

                sqlParameter[6] = new SqlParameter("@RetVal", SqlDbType.BigInt);
                sqlParameter[6].Direction = ParameterDirection.Output;


                Database.ExecuteNonQuery(CommandType.StoredProcedure, "AMS_Tab8_AttachmentsEdit", sqlParameter);
                return Convert.ToInt64(sqlParameter[6].Value);
            }
            catch (Exception Exc)
            {
                throw Exc;
                return -1;
            }
        }

        public DataSet Tab8_AttachmentsSelect(Int64 Id, Int64 JobId, string ImageType)
        {
            SqlParameter[] sqlParameter = new SqlParameter[3];
            try
            {
                sqlParameter[0] = new SqlParameter("@Id", SqlDbType.BigInt);
                sqlParameter[0].Value = Id;

                sqlParameter[1] = new SqlParameter("@JobId", SqlDbType.BigInt);
                sqlParameter[1].Value = JobId;

                sqlParameter[2] = new SqlParameter("@ImageType", SqlDbType.NVarChar);
                sqlParameter[2].Value = ImageType;

                return Database.ExecuteDataset(CommandType.StoredProcedure, "AMS_Tab8_AttachmentsSelect", sqlParameter);
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
