//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace B2BAISERA.Models.EFServer
{
    public partial class CUSTOM_S02006
    {
        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> TransactionDataID
        {
            get { return _transactionDataID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_transactionDataID != value)
                    {
                        if (CUSTOM_DOWNLOAD_TRANSACTIONDATA != null && CUSTOM_DOWNLOAD_TRANSACTIONDATA.ID != value)
                        {
                            CUSTOM_DOWNLOAD_TRANSACTIONDATA = null;
                        }
                        _transactionDataID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _transactionDataID;
    
        public virtual string BillingNo
        {
            get;
            set;
        }
    
        public virtual string KuitansiNo
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> KuitansiDate
        {
            get;
            set;
        }
    
        public virtual string CurrencyCode
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> AmountKuitansiDC
        {
            get;
            set;
        }
    
        public virtual string BusinessAreaCode
        {
            get;
            set;
        }
    
        public virtual string CustomerNo
        {
            get;
            set;
        }
    
        public virtual string NomorSpes
        {
            get;
            set;
        }
    
        public virtual string SalesOrderNo
        {
            get;
            set;
        }
    
        public virtual string SalesmanNumber
        {
            get;
            set;
        }
    
        public virtual string NomorFakturPajak
        {
            get;
            set;
        }
    
        public virtual string ChasisNumber
        {
            get;
            set;
        }
    
        public virtual string PONumberSERA
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> VersionPOSERA
        {
            get;
            set;
        }
    
        public virtual string KuitansiNoRef
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> KuitansiDateRef
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> DownloadDate
        {
            get;
            set;
        }
    
        public virtual string dibuatOleh
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> dibuatTanggal
        {
            get;
            set;
        }
    
        public virtual string diubahOleh
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> diubahTanggal
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual CUSTOM_DOWNLOAD_TRANSACTIONDATA CUSTOM_DOWNLOAD_TRANSACTIONDATA
        {
            get { return _cUSTOM_DOWNLOAD_TRANSACTIONDATA; }
            set
            {
                if (!ReferenceEquals(_cUSTOM_DOWNLOAD_TRANSACTIONDATA, value))
                {
                    var previousValue = _cUSTOM_DOWNLOAD_TRANSACTIONDATA;
                    _cUSTOM_DOWNLOAD_TRANSACTIONDATA = value;
                    FixupCUSTOM_DOWNLOAD_TRANSACTIONDATA(previousValue);
                }
            }
        }
        private CUSTOM_DOWNLOAD_TRANSACTIONDATA _cUSTOM_DOWNLOAD_TRANSACTIONDATA;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupCUSTOM_DOWNLOAD_TRANSACTIONDATA(CUSTOM_DOWNLOAD_TRANSACTIONDATA previousValue)
        {
            if (previousValue != null && previousValue.CUSTOM_S02006.Contains(this))
            {
                previousValue.CUSTOM_S02006.Remove(this);
            }
    
            if (CUSTOM_DOWNLOAD_TRANSACTIONDATA != null)
            {
                if (!CUSTOM_DOWNLOAD_TRANSACTIONDATA.CUSTOM_S02006.Contains(this))
                {
                    CUSTOM_DOWNLOAD_TRANSACTIONDATA.CUSTOM_S02006.Add(this);
                }
                if (TransactionDataID != CUSTOM_DOWNLOAD_TRANSACTIONDATA.ID)
                {
                    TransactionDataID = CUSTOM_DOWNLOAD_TRANSACTIONDATA.ID;
                }
            }
            else if (!_settingFK)
            {
                TransactionDataID = null;
            }
        }

        #endregion
    }
}
