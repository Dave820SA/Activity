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

[assembly: EdmRelationshipAttribute("SOPDocModel", "FK_SOP_SOP_Office_Bureau", "Office_Bureau", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(SOPBusinessLayer.Bureau), "SOP_SOP", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(SOPBusinessLayer.SOP), true)]
[assembly: EdmRelationshipAttribute("SOPDocModel", "FK_SOP_DocHistory_SOP_SOP", "SOP_SOP", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(SOPBusinessLayer.SOP), "SOP_DocHistory", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(SOPBusinessLayer.DocHistory), true)]

#endregion

namespace SOPBusinessLayer
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SAPDActivityEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new SAPDActivityEntities object using the connection string found in the 'SAPDActivityEntities' section of the application configuration file.
        /// </summary>
        public SAPDActivityEntities() : base("name=SAPDActivityEntities", "SAPDActivityEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SAPDActivityEntities object.
        /// </summary>
        public SAPDActivityEntities(string connectionString) : base(connectionString, "SAPDActivityEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SAPDActivityEntities object.
        /// </summary>
        public SAPDActivityEntities(EntityConnection connection) : base(connection, "SAPDActivityEntities")
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
        public ObjectSet<Bureau> Bureaux
        {
            get
            {
                if ((_Bureaux == null))
                {
                    _Bureaux = base.CreateObjectSet<Bureau>("Bureaux");
                }
                return _Bureaux;
            }
        }
        private ObjectSet<Bureau> _Bureaux;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<DocHistory> DocHistories
        {
            get
            {
                if ((_DocHistories == null))
                {
                    _DocHistories = base.CreateObjectSet<DocHistory>("DocHistories");
                }
                return _DocHistories;
            }
        }
        private ObjectSet<DocHistory> _DocHistories;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<SOP> SOPs
        {
            get
            {
                if ((_SOPs == null))
                {
                    _SOPs = base.CreateObjectSet<SOP>("SOPs");
                }
                return _SOPs;
            }
        }
        private ObjectSet<SOP> _SOPs;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<SOP_vCurrentDoc> SOP_vCurrentDoc
        {
            get
            {
                if ((_SOP_vCurrentDoc == null))
                {
                    _SOP_vCurrentDoc = base.CreateObjectSet<SOP_vCurrentDoc>("SOP_vCurrentDoc");
                }
                return _SOP_vCurrentDoc;
            }
        }
        private ObjectSet<SOP_vCurrentDoc> _SOP_vCurrentDoc;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Bureaux EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBureaux(Bureau bureau)
        {
            base.AddObject("Bureaux", bureau);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the DocHistories EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDocHistories(DocHistory docHistory)
        {
            base.AddObject("DocHistories", docHistory);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the SOPs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSOPs(SOP sOP)
        {
            base.AddObject("SOPs", sOP);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the SOP_vCurrentDoc EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSOP_vCurrentDoc(SOP_vCurrentDoc sOP_vCurrentDoc)
        {
            base.AddObject("SOP_vCurrentDoc", sOP_vCurrentDoc);
        }

        #endregion

        #region Function Imports
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="sOPID">No Metadata Documentation available.</param>
        /// <param name="docInfo">No Metadata Documentation available.</param>
        /// <param name="docPath">No Metadata Documentation available.</param>
        /// <param name="startDate">No Metadata Documentation available.</param>
        public int SOP_spInsertNew(Nullable<global::System.Int32> sOPID, global::System.String docInfo, global::System.String docPath, Nullable<global::System.DateTime> startDate)
        {
            ObjectParameter sOPIDParameter;
            if (sOPID.HasValue)
            {
                sOPIDParameter = new ObjectParameter("SOPID", sOPID);
            }
            else
            {
                sOPIDParameter = new ObjectParameter("SOPID", typeof(global::System.Int32));
            }
    
            ObjectParameter docInfoParameter;
            if (docInfo != null)
            {
                docInfoParameter = new ObjectParameter("DocInfo", docInfo);
            }
            else
            {
                docInfoParameter = new ObjectParameter("DocInfo", typeof(global::System.String));
            }
    
            ObjectParameter docPathParameter;
            if (docPath != null)
            {
                docPathParameter = new ObjectParameter("DocPath", docPath);
            }
            else
            {
                docPathParameter = new ObjectParameter("DocPath", typeof(global::System.String));
            }
    
            ObjectParameter startDateParameter;
            if (startDate.HasValue)
            {
                startDateParameter = new ObjectParameter("StartDate", startDate);
            }
            else
            {
                startDateParameter = new ObjectParameter("StartDate", typeof(global::System.DateTime));
            }
    
            return base.ExecuteFunction("SOP_spInsertNew", sOPIDParameter, docInfoParameter, docPathParameter, startDateParameter);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SOPDocModel", Name="Bureau")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Bureau : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Bureau object.
        /// </summary>
        /// <param name="bureauID">Initial value of the BureauID property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static Bureau CreateBureau(global::System.Int32 bureauID, global::System.String name)
        {
            Bureau bureau = new Bureau();
            bureau.BureauID = bureauID;
            bureau.Name = name;
            return bureau;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 BureauID
        {
            get
            {
                return _BureauID;
            }
            set
            {
                if (_BureauID != value)
                {
                    OnBureauIDChanging(value);
                    ReportPropertyChanging("BureauID");
                    _BureauID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("BureauID");
                    OnBureauIDChanged();
                }
            }
        }
        private global::System.Int32 _BureauID;
        partial void OnBureauIDChanging(global::System.Int32 value);
        partial void OnBureauIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NameCode
        {
            get
            {
                return _NameCode;
            }
            set
            {
                OnNameCodeChanging(value);
                ReportPropertyChanging("NameCode");
                _NameCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NameCode");
                OnNameCodeChanged();
            }
        }
        private global::System.String _NameCode;
        partial void OnNameCodeChanging(global::System.String value);
        partial void OnNameCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                OnModifiedDateChanging(value);
                ReportPropertyChanging("ModifiedDate");
                _ModifiedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ModifiedDate");
                OnModifiedDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _ModifiedDate;
        partial void OnModifiedDateChanging(Nullable<global::System.DateTime> value);
        partial void OnModifiedDateChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("SOPDocModel", "FK_SOP_SOP_Office_Bureau", "SOP_SOP")]
        public EntityCollection<SOP> SOP_SOP
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<SOP>("SOPDocModel.FK_SOP_SOP_Office_Bureau", "SOP_SOP");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<SOP>("SOPDocModel.FK_SOP_SOP_Office_Bureau", "SOP_SOP", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SOPDocModel", Name="DocHistory")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DocHistory : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new DocHistory object.
        /// </summary>
        /// <param name="docHistoryID">Initial value of the DocHistoryID property.</param>
        /// <param name="sOPID">Initial value of the SOPID property.</param>
        /// <param name="docPath">Initial value of the DocPath property.</param>
        /// <param name="startDate">Initial value of the StartDate property.</param>
        public static DocHistory CreateDocHistory(global::System.Int32 docHistoryID, global::System.Int32 sOPID, global::System.String docPath, global::System.DateTime startDate)
        {
            DocHistory docHistory = new DocHistory();
            docHistory.DocHistoryID = docHistoryID;
            docHistory.SOPID = sOPID;
            docHistory.DocPath = docPath;
            docHistory.StartDate = startDate;
            return docHistory;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 DocHistoryID
        {
            get
            {
                return _DocHistoryID;
            }
            set
            {
                if (_DocHistoryID != value)
                {
                    OnDocHistoryIDChanging(value);
                    ReportPropertyChanging("DocHistoryID");
                    _DocHistoryID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("DocHistoryID");
                    OnDocHistoryIDChanged();
                }
            }
        }
        private global::System.Int32 _DocHistoryID;
        partial void OnDocHistoryIDChanging(global::System.Int32 value);
        partial void OnDocHistoryIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 SOPID
        {
            get
            {
                return _SOPID;
            }
            set
            {
                OnSOPIDChanging(value);
                ReportPropertyChanging("SOPID");
                _SOPID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SOPID");
                OnSOPIDChanged();
            }
        }
        private global::System.Int32 _SOPID;
        partial void OnSOPIDChanging(global::System.Int32 value);
        partial void OnSOPIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String DocInfo
        {
            get
            {
                return _DocInfo;
            }
            set
            {
                OnDocInfoChanging(value);
                ReportPropertyChanging("DocInfo");
                _DocInfo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DocInfo");
                OnDocInfoChanged();
            }
        }
        private global::System.String _DocInfo;
        partial void OnDocInfoChanging(global::System.String value);
        partial void OnDocInfoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String DocPath
        {
            get
            {
                return _DocPath;
            }
            set
            {
                OnDocPathChanging(value);
                ReportPropertyChanging("DocPath");
                _DocPath = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("DocPath");
                OnDocPathChanged();
            }
        }
        private global::System.String _DocPath;
        partial void OnDocPathChanging(global::System.String value);
        partial void OnDocPathChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                OnStartDateChanging(value);
                ReportPropertyChanging("StartDate");
                _StartDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("StartDate");
                OnStartDateChanged();
            }
        }
        private global::System.DateTime _StartDate;
        partial void OnStartDateChanging(global::System.DateTime value);
        partial void OnStartDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                OnEndDateChanging(value);
                ReportPropertyChanging("EndDate");
                _EndDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EndDate");
                OnEndDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _EndDate;
        partial void OnEndDateChanging(Nullable<global::System.DateTime> value);
        partial void OnEndDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                OnModifiedDateChanging(value);
                ReportPropertyChanging("ModifiedDate");
                _ModifiedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ModifiedDate");
                OnModifiedDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _ModifiedDate;
        partial void OnModifiedDateChanging(Nullable<global::System.DateTime> value);
        partial void OnModifiedDateChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("SOPDocModel", "FK_SOP_DocHistory_SOP_SOP", "SOP_SOP")]
        public SOP SOP_SOP
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<SOP>("SOPDocModel.FK_SOP_DocHistory_SOP_SOP", "SOP_SOP").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<SOP>("SOPDocModel.FK_SOP_DocHistory_SOP_SOP", "SOP_SOP").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<SOP> SOP_SOPReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<SOP>("SOPDocModel.FK_SOP_DocHistory_SOP_SOP", "SOP_SOP");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<SOP>("SOPDocModel.FK_SOP_DocHistory_SOP_SOP", "SOP_SOP", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SOPDocModel", Name="SOP")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class SOP : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new SOP object.
        /// </summary>
        /// <param name="sOPID">Initial value of the SOPID property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="bureauID">Initial value of the BureauID property.</param>
        /// <param name="modifiedDate">Initial value of the ModifiedDate property.</param>
        public static SOP CreateSOP(global::System.Int32 sOPID, global::System.String name, global::System.Int32 bureauID, global::System.DateTime modifiedDate)
        {
            SOP sOP = new SOP();
            sOP.SOPID = sOPID;
            sOP.Name = name;
            sOP.BureauID = bureauID;
            sOP.ModifiedDate = modifiedDate;
            return sOP;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 SOPID
        {
            get
            {
                return _SOPID;
            }
            set
            {
                if (_SOPID != value)
                {
                    OnSOPIDChanging(value);
                    ReportPropertyChanging("SOPID");
                    _SOPID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("SOPID");
                    OnSOPIDChanged();
                }
            }
        }
        private global::System.Int32 _SOPID;
        partial void OnSOPIDChanging(global::System.Int32 value);
        partial void OnSOPIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 BureauID
        {
            get
            {
                return _BureauID;
            }
            set
            {
                OnBureauIDChanging(value);
                ReportPropertyChanging("BureauID");
                _BureauID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BureauID");
                OnBureauIDChanged();
            }
        }
        private global::System.Int32 _BureauID;
        partial void OnBureauIDChanging(global::System.Int32 value);
        partial void OnBureauIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                OnModifiedDateChanging(value);
                ReportPropertyChanging("ModifiedDate");
                _ModifiedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ModifiedDate");
                OnModifiedDateChanged();
            }
        }
        private global::System.DateTime _ModifiedDate;
        partial void OnModifiedDateChanging(global::System.DateTime value);
        partial void OnModifiedDateChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("SOPDocModel", "FK_SOP_SOP_Office_Bureau", "Office_Bureau")]
        public Bureau Office_Bureau
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Bureau>("SOPDocModel.FK_SOP_SOP_Office_Bureau", "Office_Bureau").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Bureau>("SOPDocModel.FK_SOP_SOP_Office_Bureau", "Office_Bureau").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Bureau> Office_BureauReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Bureau>("SOPDocModel.FK_SOP_SOP_Office_Bureau", "Office_Bureau");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Bureau>("SOPDocModel.FK_SOP_SOP_Office_Bureau", "Office_Bureau", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("SOPDocModel", "FK_SOP_DocHistory_SOP_SOP", "SOP_DocHistory")]
        public EntityCollection<DocHistory> SOP_DocHistory
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<DocHistory>("SOPDocModel.FK_SOP_DocHistory_SOP_SOP", "SOP_DocHistory");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<DocHistory>("SOPDocModel.FK_SOP_DocHistory_SOP_SOP", "SOP_DocHistory", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SOPDocModel", Name="SOP_vCurrentDoc")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class SOP_vCurrentDoc : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new SOP_vCurrentDoc object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="bureau">Initial value of the Bureau property.</param>
        /// <param name="sOP">Initial value of the SOP property.</param>
        /// <param name="startDate">Initial value of the StartDate property.</param>
        public static SOP_vCurrentDoc CreateSOP_vCurrentDoc(global::System.Int32 id, global::System.String bureau, global::System.String sOP, global::System.DateTime startDate)
        {
            SOP_vCurrentDoc sOP_vCurrentDoc = new SOP_vCurrentDoc();
            sOP_vCurrentDoc.ID = id;
            sOP_vCurrentDoc.Bureau = bureau;
            sOP_vCurrentDoc.SOP = sOP;
            sOP_vCurrentDoc.StartDate = startDate;
            return sOP_vCurrentDoc;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Bureau
        {
            get
            {
                return _Bureau;
            }
            set
            {
                if (_Bureau != value)
                {
                    OnBureauChanging(value);
                    ReportPropertyChanging("Bureau");
                    _Bureau = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Bureau");
                    OnBureauChanged();
                }
            }
        }
        private global::System.String _Bureau;
        partial void OnBureauChanging(global::System.String value);
        partial void OnBureauChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String SOP
        {
            get
            {
                return _SOP;
            }
            set
            {
                if (_SOP != value)
                {
                    OnSOPChanging(value);
                    ReportPropertyChanging("SOP");
                    _SOP = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("SOP");
                    OnSOPChanged();
                }
            }
        }
        private global::System.String _SOP;
        partial void OnSOPChanging(global::System.String value);
        partial void OnSOPChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SOPInfo
        {
            get
            {
                return _SOPInfo;
            }
            set
            {
                OnSOPInfoChanging(value);
                ReportPropertyChanging("SOPInfo");
                _SOPInfo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SOPInfo");
                OnSOPInfoChanged();
            }
        }
        private global::System.String _SOPInfo;
        partial void OnSOPInfoChanging(global::System.String value);
        partial void OnSOPInfoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                if (_StartDate != value)
                {
                    OnStartDateChanging(value);
                    ReportPropertyChanging("StartDate");
                    _StartDate = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("StartDate");
                    OnStartDateChanged();
                }
            }
        }
        private global::System.DateTime _StartDate;
        partial void OnStartDateChanging(global::System.DateTime value);
        partial void OnStartDateChanged();

        #endregion

    
    }

    #endregion

    
}
