using System;
using System.Collections.Generic;
using System.Linq;
//using B2BAISERA.Models.DataAccess;
//using B2BAISERA.Helper;
//using B2BAISERA.Logic;
using Microsoft.Practices.Unity;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using B2BAISERA.Models.EFServer;
using B2BAISERA.Helper;
using System.Data.EntityClient;
using System.Data;
using B2BAISERA.wsB2B;
using System.Globalization;

namespace B2BAISERA.Models.Providers
{
    public class TransactionProvider : DataAccessBase
    {
        public TransactionProvider()
            : base()
        {
        }

        public TransactionProvider(EProcEntities context)
            : base(context)
        {
        }

        #region MAIN
        //B2BAISERAEntities ctx = new B2BAISERAEntities(Repository.ConnectionStringEF);

        //public User GetUser(string userName, string password, string clientTag)
        //{
        //    var User = (from o in ctx.Users
        //                where o.UserName == userName && o.Password == password && o.ClientTag == clientTag
        //                select o).FirstOrDefault();

        //    return User;
        //}

        public CUSTOM_USER GetUser(string userName, string password, string clientTag)
        {
            var user = (from o in entities.CUSTOM_USER
                        where o.UserName == userName && o.Password == password && o.ClientTag == clientTag
                        select o).FirstOrDefault();

            return user;
        }

        public string GetLastTicketNo(string fileType)
        {
            var result = "";
            try
            {
                var query = (entities.CUSTOM_LOG
                    .Where(log => (log.Acknowledge == true) && (log.FileType == fileType))
                    .Select(log => new LogViewModel
                    {
                        ID = log.ID,
                        WebServiceName = log.WebServiceName,
                        MethodName = log.MethodName,
                        TicketNo = log.TicketNo,
                        Message = log.Message
                    })
                    ).OrderByDescending(log => log.ID).FirstOrDefault();

                result = query != null ? Convert.ToString(query.TicketNo) : "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

        #region DOWNLOAD

        #region S02006
        public int InsertLogTransactionDownloadS02006(bool acknowledge, string ticketNo, string message, string transStatus, List<TransactionDataViewModel> listTransactionDataModel)
        {
            int result = 0;
            try
            {
                //insert into CUSTOM_DOWNLOAD_TRANSACTION
                CUSTOM_DOWNLOAD_TRANSACTION transaction = new CUSTOM_DOWNLOAD_TRANSACTION();
                transaction.Acknowledge = acknowledge;
                transaction.TicketNo = ticketNo;
                transaction.Message = message;
                EntityHelper.SetAuditForInsert(transaction, "SERA");
                entities.CUSTOM_DOWNLOAD_TRANSACTION.AddObject(transaction);

                for (int i = 0; i < listTransactionDataModel.Count; i++)
                {
                    //insert into CUSTOM_DOWNLOAD_TRANSACTIONDATA
                    CUSTOM_DOWNLOAD_TRANSACTIONDATA transactionData = new CUSTOM_DOWNLOAD_TRANSACTIONDATA();
                    transactionData.CUSTOM_DOWNLOAD_TRANSACTION = transaction;
                    transactionData.AIID = listTransactionDataModel[i].AIID;
                    transactionData.TransGUID = listTransactionDataModel[i].TransGUID;
                    transactionData.DocumentNumber = listTransactionDataModel[i].DocumentNumber;
                    transactionData.FileType = listTransactionDataModel[i].FileType;
                    transactionData.IPAddress = listTransactionDataModel[i].IPAddress;
                    transactionData.DestinationUser = listTransactionDataModel[i].DestinationUser;
                    transactionData.Key1 = listTransactionDataModel[i].Key1;
                    transactionData.Key2 = listTransactionDataModel[i].Key2;
                    transactionData.Key3 = listTransactionDataModel[i].Key3;
                    transactionData.DataLength = listTransactionDataModel[i].DataLength;
                    //transactionData.RowStatus = "";
                    EntityHelper.SetAuditForInsert(transactionData, "SERA");
                    entities.CUSTOM_DOWNLOAD_TRANSACTIONDATA.AddObject(transactionData);

                    for (int j = 0; j < listTransactionDataModel[i].Data.Length; j++)
                    {
                        //SPLITSTRING
                        S02006ViewModel modelSO2006 = SplitStringS02006(listTransactionDataModel[i].Data[j]);

                        if (modelSO2006 != null)
                        {
                            //insert into CUSTOM_S02006
                            CUSTOM_S02006 s02006 = new CUSTOM_S02006();
                            s02006.CUSTOM_DOWNLOAD_TRANSACTIONDATA = transactionData;
                            s02006.BillingNo = modelSO2006.BillingNo;
                            s02006.KuitansiNo = modelSO2006.KuitansiNo;
                            s02006.KuitansiDate = modelSO2006.KuitansiDate;
                            s02006.CurrencyCode = modelSO2006.CurrencyCode;
                            s02006.AmountKuitansiDC = modelSO2006.AmountKuitansiDC;
                            s02006.BusinessAreaCode = modelSO2006.BusinessAreaCode;
                            s02006.CustomerNo = modelSO2006.CustomerNo;
                            s02006.NomorSpes = modelSO2006.NomorSpes;
                            s02006.SalesOrderNo = modelSO2006.SalesOrderNo;
                            s02006.SalesmanNumber = modelSO2006.SalesmanNumber;
                            s02006.NomorFakturPajak = modelSO2006.NomorFakturPajak;
                            s02006.ChasisNumber = modelSO2006.ChasisNumber;
                            s02006.PONumberSERA = modelSO2006.PONumberSERA;
                            s02006.VersionPOSERA = modelSO2006.VersionPOSERA;
                            s02006.KuitansiNoRef = modelSO2006.KuitansiNoRef;
                            s02006.KuitansiDateRef = modelSO2006.KuitansiDateRef;
                            s02006.DownloadDate = modelSO2006.DownloadDate;
                            //start add by fhi 18.06.2014 : set owner
                            s02006.dibuatOleh = "system";
                            s02006.dibuatTanggal = DateTime.Now;
                            s02006.diubahOleh = "system";
                            s02006.diubahTanggal = DateTime.Now;
                            //end
                            entities.CUSTOM_S02006.AddObject(s02006);
                        }

                        //insert into CUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL
                        CUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL transactionDataDetail = new CUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL();
                        transactionDataDetail.CUSTOM_DOWNLOAD_TRANSACTIONDATA = transactionData;
                        transactionDataDetail.Data = listTransactionDataModel[i].Data[j];
                        entities.CUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL.AddObject(transactionDataDetail);
                    }
                }
                entities.SaveChanges();
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            return result;
        }

        private S02006ViewModel SplitStringS02006(string stringHS)
        {
            S02006ViewModel model = new S02006ViewModel();
            try
            {
                string[] words = stringHS.Split('|');
                //if (words.Length == 13)
                //{
                for (int i = 1; i < words.Length; i++)
                {
                    if (!string.IsNullOrEmpty(words[i]))
                    {
                        decimal decimalValue;
                        var date = words[i].Trim();
                        switch (i)
                        {
                            case 1:
                                model.BillingNo = words[i].Length > 22 ? words[i].Substring(0, 22).Trim() : words[i].Trim();
                                break;
                            case 2:
                                model.KuitansiNo = words[i].Length > 15 ? words[i].Substring(0, 15).Trim() : words[i].Trim();
                                break;
                            case 3:
                                if (date.Length == 8)
                                {
                                    //if (date.Substring(0, 2) == "20")
                                    //{
                                    var dateFormat = Convert.ToDateTime(date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2), new CultureInfo("id-ID"));
                                    model.KuitansiDate = dateFormat;
                                    //}
                                }
                                //model.KuitansiDate = !string.IsNullOrEmpty(words[i]) ? Convert.ToDateTime(words[i], new CultureInfo("id-ID")) : Convert.ToDateTime("1900-01-01", new CultureInfo("id-ID"));
                                break;
                            case 4:
                                model.CurrencyCode = words[i].Length > 3 ? words[i].Substring(0, 3).Trim() : words[i].Trim();
                                break;
                            case 5:
                                if (Decimal.TryParse(words[i], out decimalValue))
                                {
                                    model.AmountKuitansiDC = Convert.ToDecimal(words[i]);
                                }
                                break;
                            case 6:
                                model.BusinessAreaCode = words[i].Length > 4 ? words[i].Substring(0, 4).Trim() : words[i].Trim();
                                break;
                            case 7:
                                model.CustomerNo = words[i].Length > 10 ? words[i].Substring(0, 10).Trim() : words[i].Trim();
                                break;
                            case 8:
                                model.NomorSpes = words[i].Length > 35 ? words[i].Substring(0, 35).Trim() : words[i].Trim();
                                break;
                            case 9:
                                model.SalesOrderNo = words[i].Length > 15 ? words[i].Substring(0, 15).Trim() : words[i].Trim();
                                break;
                            case 10:
                                model.SalesmanNumber = words[i].Length > 10 ? words[i].Substring(0, 10).Trim() : words[i].Trim();
                                break;
                            case 11:
                                model.NomorFakturPajak = words[i].Length > 21 ? words[i].Substring(0, 21).Trim() : words[i].Trim();
                                break;
                            case 12:
                                model.ChasisNumber = words[i].Length > 18 ? words[i].Substring(0, 18).Trim() : words[i].Trim();
                                break;
                            case 13:
                                model.PONumberSERA = words[i].Length > 50 ? words[i].Substring(0, 50).Trim() : words[i].Trim();
                                break;
                            case 14:
                                if (Decimal.TryParse(words[i], out decimalValue))
                                {
                                    model.VersionPOSERA = Convert.ToDecimal(words[i]);
                                }
                                break;
                            case 15:
                                model.KuitansiNoRef = words[i].Length > 15 ? words[i].Substring(0, 15).Trim() : words[i].Trim();
                                break;
                            case 16:
                                if (date.Length == 8)
                                {
                                    //if (date.Substring(0, 2) == "20")
                                    //{
                                    var dateFormat = Convert.ToDateTime(date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2), new CultureInfo("id-ID"));
                                    model.KuitansiDateRef = dateFormat;
                                    //}
                                }
                                //model.KuitansiDateRef = !string.IsNullOrEmpty(words[i]) ? Convert.ToDateTime(words[i], new CultureInfo("id-ID")) : Convert.ToDateTime("1900-01-01", new CultureInfo("id-ID"));
                                break;
                            case 17:
                                var lastWord = words[i].Remove(words[i].IndexOf('}')).Trim();

                                if (lastWord.Length == 17) //format YYYYMMDD hh:mm:ss
                                {
                                    //if (date.Substring(0, 2) == "20")
                                    //{
                                    var dateFormat = Convert.ToDateTime(lastWord.Substring(0, 4) + "-" + lastWord.Substring(4, 2) + "-" + lastWord.Substring(6, 2) + lastWord.Substring(8, 9), new CultureInfo("id-ID"));
                                    model.DownloadDate = dateFormat;
                                    //}
                                }
                                //model.DownloadDate = !string.IsNullOrEmpty(lastWord) ? Convert.ToDateTime(lastWord, new CultureInfo("id-ID")) : Convert.ToDateTime("1900-01-01", new CultureInfo("id-ID"));
                                break;
                            default:
                                break;
                        }
                    }
                }
                //}                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public int UpdateTransactionS02006(List<TransactionDataViewModel> listTransactionDataModel)
        {
            int result = 0;
            try
            {
                for (int i = 0; i < listTransactionDataModel.Count; i++)
                {
                    for (int j = 0; j < listTransactionDataModel[i].Data.Length; j++)
                    {
                        //SPLITSTRING
                        S02006ViewModel modelSO2006 = SplitStringS02006(listTransactionDataModel[i].Data[j]);

                        //UPDATE CUSTOMGR
                        CUSTOMGR customGR = entities.CUSTOMGRs.SingleOrDefault(x => x.PONUMBER == modelSO2006.PONumberSERA);

                        //modify by iyan : 01Nov2013
                        ////UPDATE CUSTOMBPKB
                        //CUSTOMBPKB customBPKB = entities.CUSTOMBPKBs.SingleOrDefault(x => x.PONUMBER == modelSO2006.PONumberSERA);
                        //UPDATE CUSTOMPO
                        CUSTOMPO customPO = entities.CUSTOMPOes.SingleOrDefault(x => x.PONUMBER == modelSO2006.PONumberSERA);
                        //end modify

                        //UPDATE CUSTOMIR
                        var customIR = entities.CUSTOMIRs.Where(x => x.PONUMBER == modelSO2006.PONumberSERA).Take(1).ToList();

                        //UPDATE CUSTOM_VENDOR_TRANSACTION
                        CUSTOM_VENDOR_TRANSACTION customVendorTransaction = entities.CUSTOM_VENDOR_TRANSACTION.SingleOrDefault(x => x.PONumber == modelSO2006.PONumberSERA);

                        //jika di 4 table ada,
                        if (customGR != null && customPO != null && customIR.Count > 0 && customVendorTransaction != null)
                        {
                            //cek DownloadDate di custVendorTrans, jika tidak null, cek lagi
                            if (customVendorTransaction.DownloadDate != null)
                            {
                                //cek DownloadDate di custVendorTrans apakah yang baru lebih besar tanggalnya.
                                if (modelSO2006.DownloadDate >= customVendorTransaction.DownloadDate)
                                {
                                    //call sp_UpdateS02006
                                    result = UpdateS02006(modelSO2006);
                                }
                            }
                            //jika null, langsung update
                            else
                            {
                                //call sp_UpdateS02006
                                result = UpdateS02006(modelSO2006);
                            }                            
                        }
                    }
                }

                //result = 1;
            }
            catch (Exception ex)
            {
                return result = 0;
            }
            return result;
        }

        public int UpdateS02006(S02006ViewModel model)
        {
            int result;
            try
            {
                EntityCommand cmd = new EntityCommand("EProcEntities.sp_UpdateS02006", entityConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PONUMBER", DbType.String).Value = model.PONumberSERA;
                cmd.Parameters.Add("NOFAKTUR", DbType.String).Value = model.BillingNo; //mapping to CUSTOMPO.DONUMBER 01NOV2013
                cmd.Parameters.Add("INVNO", DbType.String).Value = model.KuitansiNo;
                cmd.Parameters.Add("INVDATE", DbType.DateTime).Value = model.KuitansiDate;
                cmd.Parameters.Add("NOFAKTURPAJAK", DbType.String).Value = model.NomorFakturPajak;
                cmd.Parameters.Add("NOCHASIS_INPUT", DbType.String).Value = model.ChasisNumber;
                cmd.Parameters.Add("NETPRICE", DbType.Decimal).Value = model.AmountKuitansiDC;
                //CUSTOM_VENDOR_TRANSACTION
                cmd.Parameters.Add("BUSINESSAREACODE", DbType.String).Value = model.BusinessAreaCode;
                cmd.Parameters.Add("CUSTOMERNO", DbType.String).Value = model.CustomerNo;
                cmd.Parameters.Add("NOMORSPES", DbType.String).Value = model.NomorSpes;
                cmd.Parameters.Add("SALESORDERNO", DbType.String).Value = model.SalesOrderNo;
                cmd.Parameters.Add("SALESMANNUMBER", DbType.String).Value = model.SalesmanNumber;
                cmd.Parameters.Add("VERSIONPOSERA", DbType.Int32).Value = Convert.ToInt32(model.VersionPOSERA);
                cmd.Parameters.Add("KUITANSINOREF", DbType.String).Value = model.KuitansiNoRef;
                cmd.Parameters.Add("KUITANSIDATEREF", DbType.String).Value = model.KuitansiDateRef;
                cmd.Parameters.Add("DOWNLOADDATE", DbType.DateTime).Value = model.DownloadDate;
                OpenConnection();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        #endregion

        #endregion

        public int UpdateCustomPOStatusPOId(string poNumber, string poStatusId)
        {
            int result;
            try
            {
                EntityCommand cmd = new EntityCommand("EProcEntities.sp_UpdateCustomPOStatusPOId", entityConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PONUMBER", DbType.String).Value = poNumber;
                cmd.Parameters.Add("POSTATUSID", DbType.String).Value = poStatusId;
                OpenConnection();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                result = 0;
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
    }
}