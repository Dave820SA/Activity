﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("SAPDActivityModel", "OfficerAuditHistrory", "Officer", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(IECAWeb.Models.Officer), "AuditHistrory", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(IECAWeb.Models.AuditHistrory), true)]

#endregion

namespace IECAWeb.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SAPDActivityEntities1 : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new SAPDActivityEntities1 object using the connection string found in the 'SAPDActivityEntities1' section of the application configuration file.
        /// </summary>
        public SAPDActivityEntities1() : base("name=SAPDActivityEntities1", "SAPDActivityEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SAPDActivityEntities1 object.
        /// </summary>
        public SAPDActivityEntities1(string connectionString) : base(connectionString, "SAPDActivityEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SAPDActivityEntities1 object.
        /// </summary>
        public SAPDActivityEntities1(EntityConnection connection) : base(connection, "SAPDActivityEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Officer> Officers
        {
            get
            {
                if ((_Officers == null))
                {
                    _Officers = base.CreateObjectSet<Officer>("Officers");
                }
                return _Officers;
            }
        }
        private ObjectSet<Officer> _Officers;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<AuditHistrory> AuditHistrories
        {
            get
            {
                if ((_AuditHistrories == null))
                {
                    _AuditHistrories = base.CreateObjectSet<AuditHistrory>("AuditHistrories");
                }
                return _AuditHistrories;
            }
        }
        private ObjectSet<AuditHistrory> _AuditHistrories;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Officers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToOfficers(Officer officer)
        {
            base.AddObject("Officers", officer);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the AuditHistrories EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAuditHistrories(AuditHistrory auditHistrory)
        {
            base.AddObject("AuditHistrories", auditHistrory);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SAPDActivityModel", Name="AuditHistrory")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class AuditHistrory : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new AuditHistrory object.
        /// </summary>
        /// <param name="iECAID">Initial value of the IECAID property.</param>
        /// <param name="appEntityID">Initial value of the AppEntityID property.</param>
        /// <param name="auditorID">Initial value of the AuditorID property.</param>
        public static AuditHistrory CreateAuditHistrory(global::System.Int32 iECAID, global::System.Int32 appEntityID, global::System.Int32 auditorID)
        {
            AuditHistrory auditHistrory = new AuditHistrory();
            auditHistrory.IECAID = iECAID;
            auditHistrory.AppEntityID = appEntityID;
            auditHistrory.AuditorID = auditorID;
            return auditHistrory;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IECAID
        {
            get
            {
                return _IECAID;
            }
            set
            {
                if (_IECAID != value)
                {
                    OnIECAIDChanging(value);
                    ReportPropertyChanging("IECAID");
                    _IECAID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("IECAID");
                    OnIECAIDChanged();
                }
            }
        }
        private global::System.Int32 _IECAID;
        partial void OnIECAIDChanging(global::System.Int32 value);
        partial void OnIECAIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 AppEntityID
        {
            get
            {
                return _AppEntityID;
            }
            set
            {
                OnAppEntityIDChanging(value);
                ReportPropertyChanging("AppEntityID");
                _AppEntityID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AppEntityID");
                OnAppEntityIDChanged();
            }
        }
        private global::System.Int32 _AppEntityID;
        partial void OnAppEntityIDChanging(global::System.Int32 value);
        partial void OnAppEntityIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> OfficeID
        {
            get
            {
                return _OfficeID;
            }
            set
            {
                OnOfficeIDChanging(value);
                ReportPropertyChanging("OfficeID");
                _OfficeID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OfficeID");
                OnOfficeIDChanged();
            }
        }
        private Nullable<global::System.Int32> _OfficeID;
        partial void OnOfficeIDChanging(Nullable<global::System.Int32> value);
        partial void OnOfficeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> CaseAuditFlag
        {
            get
            {
                return _CaseAuditFlag;
            }
            set
            {
                OnCaseAuditFlagChanging(value);
                ReportPropertyChanging("CaseAuditFlag");
                _CaseAuditFlag = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CaseAuditFlag");
                OnCaseAuditFlagChanged();
            }
        }
        private Nullable<global::System.Boolean> _CaseAuditFlag;
        partial void OnCaseAuditFlagChanging(Nullable<global::System.Boolean> value);
        partial void OnCaseAuditFlagChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String AuditNotes
        {
            get
            {
                return _AuditNotes;
            }
            set
            {
                OnAuditNotesChanging(value);
                ReportPropertyChanging("AuditNotes");
                _AuditNotes = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("AuditNotes");
                OnAuditNotesChanged();
            }
        }
        private global::System.String _AuditNotes;
        partial void OnAuditNotesChanging(global::System.String value);
        partial void OnAuditNotesChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 AuditorID
        {
            get
            {
                return _AuditorID;
            }
            set
            {
                OnAuditorIDChanging(value);
                ReportPropertyChanging("AuditorID");
                _AuditorID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AuditorID");
                OnAuditorIDChanged();
            }
        }
        private global::System.Int32 _AuditorID;
        partial void OnAuditorIDChanging(global::System.Int32 value);
        partial void OnAuditorIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> AuditDate
        {
            get
            {
                return _AuditDate;
            }
            set
            {
                OnAuditDateChanging(value);
                ReportPropertyChanging("AuditDate");
                _AuditDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AuditDate");
                OnAuditDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _AuditDate;
        partial void OnAuditDateChanging(Nullable<global::System.DateTime> value);
        partial void OnAuditDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastUpdate
        {
            get
            {
                return _LastUpdate;
            }
            set
            {
                OnLastUpdateChanging(value);
                ReportPropertyChanging("LastUpdate");
                _LastUpdate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastUpdate");
                OnLastUpdateChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastUpdate;
        partial void OnLastUpdateChanging(Nullable<global::System.DateTime> value);
        partial void OnLastUpdateChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("SAPDActivityModel", "OfficerAuditHistrory", "Officer")]
        public Officer Officer
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Officer>("SAPDActivityModel.OfficerAuditHistrory", "Officer").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Officer>("SAPDActivityModel.OfficerAuditHistrory", "Officer").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Officer> OfficerReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Officer>("SAPDActivityModel.OfficerAuditHistrory", "Officer");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Officer>("SAPDActivityModel.OfficerAuditHistrory", "Officer", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SAPDActivityModel", Name="Officer")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Officer : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Officer object.
        /// </summary>
        /// <param name="appEntityID">Initial value of the AppEntityID property.</param>
        /// <param name="rDID">Initial value of the RDID property.</param>
        /// <param name="rD">Initial value of the RD property.</param>
        /// <param name="workStatusID">Initial value of the WorkStatusID property.</param>
        /// <param name="officeID">Initial value of the OfficeID property.</param>
        /// <param name="officeLong">Initial value of the OfficeLong property.</param>
        /// <param name="officeShort">Initial value of the OfficeShort property.</param>
        public static Officer CreateOfficer(global::System.Int32 appEntityID, global::System.Int32 rDID, global::System.String rD, global::System.Int32 workStatusID, global::System.Int32 officeID, global::System.String officeLong, global::System.String officeShort)
        {
            Officer officer = new Officer();
            officer.AppEntityID = appEntityID;
            officer.RDID = rDID;
            officer.RD = rD;
            officer.WorkStatusID = workStatusID;
            officer.OfficeID = officeID;
            officer.OfficeLong = officeLong;
            officer.OfficeShort = officeShort;
            return officer;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 AppEntityID
        {
            get
            {
                return _AppEntityID;
            }
            set
            {
                if (_AppEntityID != value)
                {
                    OnAppEntityIDChanging(value);
                    ReportPropertyChanging("AppEntityID");
                    _AppEntityID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("AppEntityID");
                    OnAppEntityIDChanged();
                }
            }
        }
        private global::System.Int32 _AppEntityID;
        partial void OnAppEntityIDChanging(global::System.Int32 value);
        partial void OnAppEntityIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String First
        {
            get
            {
                return _First;
            }
            set
            {
                OnFirstChanging(value);
                ReportPropertyChanging("First");
                _First = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("First");
                OnFirstChanged();
            }
        }
        private global::System.String _First;
        partial void OnFirstChanging(global::System.String value);
        partial void OnFirstChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Last
        {
            get
            {
                return _Last;
            }
            set
            {
                OnLastChanging(value);
                ReportPropertyChanging("Last");
                _Last = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Last");
                OnLastChanged();
            }
        }
        private global::System.String _Last;
        partial void OnLastChanging(global::System.String value);
        partial void OnLastChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Badge
        {
            get
            {
                return _Badge;
            }
            set
            {
                OnBadgeChanging(value);
                ReportPropertyChanging("Badge");
                _Badge = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Badge");
                OnBadgeChanged();
            }
        }
        private global::System.String _Badge;
        partial void OnBadgeChanging(global::System.String value);
        partial void OnBadgeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String RankLong
        {
            get
            {
                return _RankLong;
            }
            set
            {
                OnRankLongChanging(value);
                ReportPropertyChanging("RankLong");
                _RankLong = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("RankLong");
                OnRankLongChanged();
            }
        }
        private global::System.String _RankLong;
        partial void OnRankLongChanging(global::System.String value);
        partial void OnRankLongChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Rank
        {
            get
            {
                return _Rank;
            }
            set
            {
                OnRankChanging(value);
                ReportPropertyChanging("Rank");
                _Rank = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Rank");
                OnRankChanged();
            }
        }
        private global::System.String _Rank;
        partial void OnRankChanging(global::System.String value);
        partial void OnRankChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 RDID
        {
            get
            {
                return _RDID;
            }
            set
            {
                OnRDIDChanging(value);
                ReportPropertyChanging("RDID");
                _RDID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RDID");
                OnRDIDChanged();
            }
        }
        private global::System.Int32 _RDID;
        partial void OnRDIDChanging(global::System.Int32 value);
        partial void OnRDIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String RD
        {
            get
            {
                return _RD;
            }
            set
            {
                OnRDChanging(value);
                ReportPropertyChanging("RD");
                _RD = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("RD");
                OnRDChanged();
            }
        }
        private global::System.String _RD;
        partial void OnRDChanging(global::System.String value);
        partial void OnRDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                OnStatusChanging(value);
                ReportPropertyChanging("Status");
                _Status = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Status");
                OnStatusChanged();
            }
        }
        private global::System.String _Status;
        partial void OnStatusChanging(global::System.String value);
        partial void OnStatusChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 WorkStatusID
        {
            get
            {
                return _WorkStatusID;
            }
            set
            {
                OnWorkStatusIDChanging(value);
                ReportPropertyChanging("WorkStatusID");
                _WorkStatusID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("WorkStatusID");
                OnWorkStatusIDChanged();
            }
        }
        private global::System.Int32 _WorkStatusID;
        partial void OnWorkStatusIDChanging(global::System.Int32 value);
        partial void OnWorkStatusIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 OfficeID
        {
            get
            {
                return _OfficeID;
            }
            set
            {
                OnOfficeIDChanging(value);
                ReportPropertyChanging("OfficeID");
                _OfficeID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OfficeID");
                OnOfficeIDChanged();
            }
        }
        private global::System.Int32 _OfficeID;
        partial void OnOfficeIDChanging(global::System.Int32 value);
        partial void OnOfficeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String OfficeLong
        {
            get
            {
                return _OfficeLong;
            }
            set
            {
                OnOfficeLongChanging(value);
                ReportPropertyChanging("OfficeLong");
                _OfficeLong = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("OfficeLong");
                OnOfficeLongChanged();
            }
        }
        private global::System.String _OfficeLong;
        partial void OnOfficeLongChanging(global::System.String value);
        partial void OnOfficeLongChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String OfficeShort
        {
            get
            {
                return _OfficeShort;
            }
            set
            {
                OnOfficeShortChanging(value);
                ReportPropertyChanging("OfficeShort");
                _OfficeShort = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("OfficeShort");
                OnOfficeShortChanged();
            }
        }
        private global::System.String _OfficeShort;
        partial void OnOfficeShortChanging(global::System.String value);
        partial void OnOfficeShortChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String FullName
        {
            get
            {
                return _FullName;
            }
            set
            {
                OnFullNameChanging(value);
                ReportPropertyChanging("FullName");
                _FullName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("FullName");
                OnFullNameChanged();
            }
        }
        private global::System.String _FullName;
        partial void OnFullNameChanging(global::System.String value);
        partial void OnFullNameChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("SAPDActivityModel", "OfficerAuditHistrory", "AuditHistrory")]
        public EntityCollection<AuditHistrory> AuditHistrories
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AuditHistrory>("SAPDActivityModel.OfficerAuditHistrory", "AuditHistrory");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AuditHistrory>("SAPDActivityModel.OfficerAuditHistrory", "AuditHistrory", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
