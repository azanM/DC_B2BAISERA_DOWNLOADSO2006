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

namespace B2BAISERA.Models.DataAccess
{
    public partial class DocumentFileType
    {
        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual string FileTypeName
        {
            get;
            set;
        }
    
        public virtual string CreatedWho
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> CreatedWhen
        {
            get;
            set;
        }
    
        public virtual string ChangedWho
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> ChangedWhen
        {
            get;
            set;
        }

        #endregion
    }
}
