//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace B2BAISERA.Models.EFServer
{
    public partial class EProcEntities : ObjectContext
    {
        public const string ConnectionString = "name=EProcEntities";
        public const string ContainerName = "EProcEntities";
    
        #region Constructors
    
        public EProcEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public EProcEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public EProcEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<CUSTOM_DOWNLOAD_TRANSACTION> CUSTOM_DOWNLOAD_TRANSACTION
        {
            get { return _cUSTOM_DOWNLOAD_TRANSACTION  ?? (_cUSTOM_DOWNLOAD_TRANSACTION = CreateObjectSet<CUSTOM_DOWNLOAD_TRANSACTION>("CUSTOM_DOWNLOAD_TRANSACTION")); }
        }
        private ObjectSet<CUSTOM_DOWNLOAD_TRANSACTION> _cUSTOM_DOWNLOAD_TRANSACTION;
    
        public ObjectSet<CUSTOM_DOWNLOAD_TRANSACTIONDATA> CUSTOM_DOWNLOAD_TRANSACTIONDATA
        {
            get { return _cUSTOM_DOWNLOAD_TRANSACTIONDATA  ?? (_cUSTOM_DOWNLOAD_TRANSACTIONDATA = CreateObjectSet<CUSTOM_DOWNLOAD_TRANSACTIONDATA>("CUSTOM_DOWNLOAD_TRANSACTIONDATA")); }
        }
        private ObjectSet<CUSTOM_DOWNLOAD_TRANSACTIONDATA> _cUSTOM_DOWNLOAD_TRANSACTIONDATA;
    
        public ObjectSet<CUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL> CUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL
        {
            get { return _cUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL  ?? (_cUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL = CreateObjectSet<CUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL>("CUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL")); }
        }
        private ObjectSet<CUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL> _cUSTOM_DOWNLOAD_TRANSACTIONDATADETAIL;
    
        public ObjectSet<CUSTOMGR> CUSTOMGRs
        {
            get { return _cUSTOMGRs  ?? (_cUSTOMGRs = CreateObjectSet<CUSTOMGR>("CUSTOMGRs")); }
        }
        private ObjectSet<CUSTOMGR> _cUSTOMGRs;
    
        public ObjectSet<CUSTOMIR> CUSTOMIRs
        {
            get { return _cUSTOMIRs  ?? (_cUSTOMIRs = CreateObjectSet<CUSTOMIR>("CUSTOMIRs")); }
        }
        private ObjectSet<CUSTOMIR> _cUSTOMIRs;
    
        public ObjectSet<CUSTOM_S02006> CUSTOM_S02006
        {
            get { return _cUSTOM_S02006  ?? (_cUSTOM_S02006 = CreateObjectSet<CUSTOM_S02006>("CUSTOM_S02006")); }
        }
        private ObjectSet<CUSTOM_S02006> _cUSTOM_S02006;
    
        public ObjectSet<CUSTOM_VENDOR_TRANSACTION> CUSTOM_VENDOR_TRANSACTION
        {
            get { return _cUSTOM_VENDOR_TRANSACTION  ?? (_cUSTOM_VENDOR_TRANSACTION = CreateObjectSet<CUSTOM_VENDOR_TRANSACTION>("CUSTOM_VENDOR_TRANSACTION")); }
        }
        private ObjectSet<CUSTOM_VENDOR_TRANSACTION> _cUSTOM_VENDOR_TRANSACTION;
    
        public ObjectSet<CUSTOMPO> CUSTOMPOes
        {
            get { return _cUSTOMPOes  ?? (_cUSTOMPOes = CreateObjectSet<CUSTOMPO>("CUSTOMPOes")); }
        }
        private ObjectSet<CUSTOMPO> _cUSTOMPOes;
    
        public ObjectSet<CUSTOM_LOG> CUSTOM_LOG
        {
            get { return _cUSTOM_LOG  ?? (_cUSTOM_LOG = CreateObjectSet<CUSTOM_LOG>("CUSTOM_LOG")); }
        }
        private ObjectSet<CUSTOM_LOG> _cUSTOM_LOG;
    
        public ObjectSet<CUSTOM_USER> CUSTOM_USER
        {
            get { return _cUSTOM_USER  ?? (_cUSTOM_USER = CreateObjectSet<CUSTOM_USER>("CUSTOM_USER")); }
        }
        private ObjectSet<CUSTOM_USER> _cUSTOM_USER;

        #endregion
        #region Function Imports
        public ObjectResult<Nullable<int>> sp_UpdateS02008(string pONUMBER, Nullable<int> vERSIONPOSERA, Nullable<int> dATAVERSION, string sALESORDERNO, string nOCHASIS_INPUT, Nullable<System.DateTime> tGLMASUKKAROSERI)
        {
    
            ObjectParameter pONUMBERParameter;
    
            if (pONUMBER != null)
            {
                pONUMBERParameter = new ObjectParameter("PONUMBER", pONUMBER);
            }
            else
            {
                pONUMBERParameter = new ObjectParameter("PONUMBER", typeof(string));
            }
    
            ObjectParameter vERSIONPOSERAParameter;
    
            if (vERSIONPOSERA.HasValue)
            {
                vERSIONPOSERAParameter = new ObjectParameter("VERSIONPOSERA", vERSIONPOSERA);
            }
            else
            {
                vERSIONPOSERAParameter = new ObjectParameter("VERSIONPOSERA", typeof(int));
            }
    
            ObjectParameter dATAVERSIONParameter;
    
            if (dATAVERSION.HasValue)
            {
                dATAVERSIONParameter = new ObjectParameter("DATAVERSION", dATAVERSION);
            }
            else
            {
                dATAVERSIONParameter = new ObjectParameter("DATAVERSION", typeof(int));
            }
    
            ObjectParameter sALESORDERNOParameter;
    
            if (sALESORDERNO != null)
            {
                sALESORDERNOParameter = new ObjectParameter("SALESORDERNO", sALESORDERNO);
            }
            else
            {
                sALESORDERNOParameter = new ObjectParameter("SALESORDERNO", typeof(string));
            }
    
            ObjectParameter nOCHASIS_INPUTParameter;
    
            if (nOCHASIS_INPUT != null)
            {
                nOCHASIS_INPUTParameter = new ObjectParameter("NOCHASIS_INPUT", nOCHASIS_INPUT);
            }
            else
            {
                nOCHASIS_INPUTParameter = new ObjectParameter("NOCHASIS_INPUT", typeof(string));
            }
    
            ObjectParameter tGLMASUKKAROSERIParameter;
    
            if (tGLMASUKKAROSERI.HasValue)
            {
                tGLMASUKKAROSERIParameter = new ObjectParameter("TGLMASUKKAROSERI", tGLMASUKKAROSERI);
            }
            else
            {
                tGLMASUKKAROSERIParameter = new ObjectParameter("TGLMASUKKAROSERI", typeof(System.DateTime));
            }
            return base.ExecuteFunction<Nullable<int>>("sp_UpdateS02008", pONUMBERParameter, vERSIONPOSERAParameter, dATAVERSIONParameter, sALESORDERNOParameter, nOCHASIS_INPUTParameter, tGLMASUKKAROSERIParameter);
        }
        public ObjectResult<Nullable<int>> sp_UpdateS02006(string pONUMBER, string nOFAKTUR, string iNVNO, Nullable<System.DateTime> iNVDATE, string nOFAKTURPAJAK, string nOCHASIS_INPUT, Nullable<decimal> nETPRICE, string bUSINESSAREACODE, string cUSTOMERNO, string nOMORSPES, string sALESORDERNO, string sALESMANNUMBER, Nullable<int> vERSIONPOSERA, string kUITANSINOREF, Nullable<System.DateTime> kUITANSIDATEREF, Nullable<System.DateTime> dOWNLOADDATE)
        {
    
            ObjectParameter pONUMBERParameter;
    
            if (pONUMBER != null)
            {
                pONUMBERParameter = new ObjectParameter("PONUMBER", pONUMBER);
            }
            else
            {
                pONUMBERParameter = new ObjectParameter("PONUMBER", typeof(string));
            }
    
            ObjectParameter nOFAKTURParameter;
    
            if (nOFAKTUR != null)
            {
                nOFAKTURParameter = new ObjectParameter("NOFAKTUR", nOFAKTUR);
            }
            else
            {
                nOFAKTURParameter = new ObjectParameter("NOFAKTUR", typeof(string));
            }
    
            ObjectParameter iNVNOParameter;
    
            if (iNVNO != null)
            {
                iNVNOParameter = new ObjectParameter("INVNO", iNVNO);
            }
            else
            {
                iNVNOParameter = new ObjectParameter("INVNO", typeof(string));
            }
    
            ObjectParameter iNVDATEParameter;
    
            if (iNVDATE.HasValue)
            {
                iNVDATEParameter = new ObjectParameter("INVDATE", iNVDATE);
            }
            else
            {
                iNVDATEParameter = new ObjectParameter("INVDATE", typeof(System.DateTime));
            }
    
            ObjectParameter nOFAKTURPAJAKParameter;
    
            if (nOFAKTURPAJAK != null)
            {
                nOFAKTURPAJAKParameter = new ObjectParameter("NOFAKTURPAJAK", nOFAKTURPAJAK);
            }
            else
            {
                nOFAKTURPAJAKParameter = new ObjectParameter("NOFAKTURPAJAK", typeof(string));
            }
    
            ObjectParameter nOCHASIS_INPUTParameter;
    
            if (nOCHASIS_INPUT != null)
            {
                nOCHASIS_INPUTParameter = new ObjectParameter("NOCHASIS_INPUT", nOCHASIS_INPUT);
            }
            else
            {
                nOCHASIS_INPUTParameter = new ObjectParameter("NOCHASIS_INPUT", typeof(string));
            }
    
            ObjectParameter nETPRICEParameter;
    
            if (nETPRICE.HasValue)
            {
                nETPRICEParameter = new ObjectParameter("NETPRICE", nETPRICE);
            }
            else
            {
                nETPRICEParameter = new ObjectParameter("NETPRICE", typeof(decimal));
            }
    
            ObjectParameter bUSINESSAREACODEParameter;
    
            if (bUSINESSAREACODE != null)
            {
                bUSINESSAREACODEParameter = new ObjectParameter("BUSINESSAREACODE", bUSINESSAREACODE);
            }
            else
            {
                bUSINESSAREACODEParameter = new ObjectParameter("BUSINESSAREACODE", typeof(string));
            }
    
            ObjectParameter cUSTOMERNOParameter;
    
            if (cUSTOMERNO != null)
            {
                cUSTOMERNOParameter = new ObjectParameter("CUSTOMERNO", cUSTOMERNO);
            }
            else
            {
                cUSTOMERNOParameter = new ObjectParameter("CUSTOMERNO", typeof(string));
            }
    
            ObjectParameter nOMORSPESParameter;
    
            if (nOMORSPES != null)
            {
                nOMORSPESParameter = new ObjectParameter("NOMORSPES", nOMORSPES);
            }
            else
            {
                nOMORSPESParameter = new ObjectParameter("NOMORSPES", typeof(string));
            }
    
            ObjectParameter sALESORDERNOParameter;
    
            if (sALESORDERNO != null)
            {
                sALESORDERNOParameter = new ObjectParameter("SALESORDERNO", sALESORDERNO);
            }
            else
            {
                sALESORDERNOParameter = new ObjectParameter("SALESORDERNO", typeof(string));
            }
    
            ObjectParameter sALESMANNUMBERParameter;
    
            if (sALESMANNUMBER != null)
            {
                sALESMANNUMBERParameter = new ObjectParameter("SALESMANNUMBER", sALESMANNUMBER);
            }
            else
            {
                sALESMANNUMBERParameter = new ObjectParameter("SALESMANNUMBER", typeof(string));
            }
    
            ObjectParameter vERSIONPOSERAParameter;
    
            if (vERSIONPOSERA.HasValue)
            {
                vERSIONPOSERAParameter = new ObjectParameter("VERSIONPOSERA", vERSIONPOSERA);
            }
            else
            {
                vERSIONPOSERAParameter = new ObjectParameter("VERSIONPOSERA", typeof(int));
            }
    
            ObjectParameter kUITANSINOREFParameter;
    
            if (kUITANSINOREF != null)
            {
                kUITANSINOREFParameter = new ObjectParameter("KUITANSINOREF", kUITANSINOREF);
            }
            else
            {
                kUITANSINOREFParameter = new ObjectParameter("KUITANSINOREF", typeof(string));
            }
    
            ObjectParameter kUITANSIDATEREFParameter;
    
            if (kUITANSIDATEREF.HasValue)
            {
                kUITANSIDATEREFParameter = new ObjectParameter("KUITANSIDATEREF", kUITANSIDATEREF);
            }
            else
            {
                kUITANSIDATEREFParameter = new ObjectParameter("KUITANSIDATEREF", typeof(System.DateTime));
            }
    
            ObjectParameter dOWNLOADDATEParameter;
    
            if (dOWNLOADDATE.HasValue)
            {
                dOWNLOADDATEParameter = new ObjectParameter("DOWNLOADDATE", dOWNLOADDATE);
            }
            else
            {
                dOWNLOADDATEParameter = new ObjectParameter("DOWNLOADDATE", typeof(System.DateTime));
            }
            return base.ExecuteFunction<Nullable<int>>("sp_UpdateS02006", pONUMBERParameter, nOFAKTURParameter, iNVNOParameter, iNVDATEParameter, nOFAKTURPAJAKParameter, nOCHASIS_INPUTParameter, nETPRICEParameter, bUSINESSAREACODEParameter, cUSTOMERNOParameter, nOMORSPESParameter, sALESORDERNOParameter, sALESMANNUMBERParameter, vERSIONPOSERAParameter, kUITANSINOREFParameter, kUITANSIDATEREFParameter, dOWNLOADDATEParameter);
        }
        public ObjectResult<Nullable<int>> sp_UpdateS02004(string pONUMBER, Nullable<decimal> vERSIONPOSERA, Nullable<decimal> dATAVERSION, string sTATUS, string rEASONREJECTION)
        {
    
            ObjectParameter pONUMBERParameter;
    
            if (pONUMBER != null)
            {
                pONUMBERParameter = new ObjectParameter("PONUMBER", pONUMBER);
            }
            else
            {
                pONUMBERParameter = new ObjectParameter("PONUMBER", typeof(string));
            }
    
            ObjectParameter vERSIONPOSERAParameter;
    
            if (vERSIONPOSERA.HasValue)
            {
                vERSIONPOSERAParameter = new ObjectParameter("VERSIONPOSERA", vERSIONPOSERA);
            }
            else
            {
                vERSIONPOSERAParameter = new ObjectParameter("VERSIONPOSERA", typeof(decimal));
            }
    
            ObjectParameter dATAVERSIONParameter;
    
            if (dATAVERSION.HasValue)
            {
                dATAVERSIONParameter = new ObjectParameter("DATAVERSION", dATAVERSION);
            }
            else
            {
                dATAVERSIONParameter = new ObjectParameter("DATAVERSION", typeof(decimal));
            }
    
            ObjectParameter sTATUSParameter;
    
            if (sTATUS != null)
            {
                sTATUSParameter = new ObjectParameter("STATUS", sTATUS);
            }
            else
            {
                sTATUSParameter = new ObjectParameter("STATUS", typeof(string));
            }
    
            ObjectParameter rEASONREJECTIONParameter;
    
            if (rEASONREJECTION != null)
            {
                rEASONREJECTIONParameter = new ObjectParameter("REASONREJECTION", rEASONREJECTION);
            }
            else
            {
                rEASONREJECTIONParameter = new ObjectParameter("REASONREJECTION", typeof(string));
            }
            return base.ExecuteFunction<Nullable<int>>("sp_UpdateS02004", pONUMBERParameter, vERSIONPOSERAParameter, dATAVERSIONParameter, sTATUSParameter, rEASONREJECTIONParameter);
        }
        public ObjectResult<Nullable<int>> sp_UpdateCustomPOStatusPOId(string pONUMBER, string pOSTATUSID)
        {
    
            ObjectParameter pONUMBERParameter;
    
            if (pONUMBER != null)
            {
                pONUMBERParameter = new ObjectParameter("PONUMBER", pONUMBER);
            }
            else
            {
                pONUMBERParameter = new ObjectParameter("PONUMBER", typeof(string));
            }
    
            ObjectParameter pOSTATUSIDParameter;
    
            if (pOSTATUSID != null)
            {
                pOSTATUSIDParameter = new ObjectParameter("POSTATUSID", pOSTATUSID);
            }
            else
            {
                pOSTATUSIDParameter = new ObjectParameter("POSTATUSID", typeof(string));
            }
            return base.ExecuteFunction<Nullable<int>>("sp_UpdateCustomPOStatusPOId", pONUMBERParameter, pOSTATUSIDParameter);
        }

        #endregion
    }
}
