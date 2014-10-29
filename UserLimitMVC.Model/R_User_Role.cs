//------------------------------------------------------------------------------
// <auto-generated>
//     此代码是根据模板生成的。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，则所做更改将丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace UserLimitMVC.Model
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(BaseRole))]
    [KnownType(typeof(BaseUser))]
    public partial class R_User_Role: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region 基元属性
    
        [DataMember]
        public int ID
        {
            get { return _iD; }
            set
            {
                if (_iD != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("属性“ID”是对象键的一部分，不可更改。仅当未跟踪对象或对象处于“已添加”状态时，才能对键属性进行更改。");
                    }
                    _iD = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        private int _iD;
    
        [DataMember]
        public int UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    ChangeTracker.RecordOriginalValue("UserID", _userID);
                    if (!IsDeserializing)
                    {
                        if (BaseUser != null && BaseUser.ID != value)
                        {
                            BaseUser = null;
                        }
                    }
                    _userID = value;
                    OnPropertyChanged("UserID");
                }
            }
        }
        private int _userID;
    
        [DataMember]
        public int RoleID
        {
            get { return _roleID; }
            set
            {
                if (_roleID != value)
                {
                    ChangeTracker.RecordOriginalValue("RoleID", _roleID);
                    if (!IsDeserializing)
                    {
                        if (BaseRole != null && BaseRole.ID != value)
                        {
                            BaseRole = null;
                        }
                    }
                    _roleID = value;
                    OnPropertyChanged("RoleID");
                }
            }
        }
        private int _roleID;
    
        [DataMember]
        public Nullable<int> Enable
        {
            get { return _enable; }
            set
            {
                if (_enable != value)
                {
                    _enable = value;
                    OnPropertyChanged("Enable");
                }
            }
        }
        private Nullable<int> _enable;
    
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public Nullable<int> SortCode
        {
            get { return _sortCode; }
            set
            {
                if (_sortCode != value)
                {
                    _sortCode = value;
                    OnPropertyChanged("SortCode");
                }
            }
        }
        private Nullable<int> _sortCode;
    
        [DataMember]
        public Nullable<int> DeletionStateCode
        {
            get { return _deletionStateCode; }
            set
            {
                if (_deletionStateCode != value)
                {
                    _deletionStateCode = value;
                    OnPropertyChanged("DeletionStateCode");
                }
            }
        }
        private Nullable<int> _deletionStateCode;
    
        [DataMember]
        public Nullable<System.DateTime> CreateOn
        {
            get { return _createOn; }
            set
            {
                if (_createOn != value)
                {
                    _createOn = value;
                    OnPropertyChanged("CreateOn");
                }
            }
        }
        private Nullable<System.DateTime> _createOn;
    
        [DataMember]
        public string CreateUserID
        {
            get { return _createUserID; }
            set
            {
                if (_createUserID != value)
                {
                    _createUserID = value;
                    OnPropertyChanged("CreateUserID");
                }
            }
        }
        private string _createUserID;
    
        [DataMember]
        public string CreateBy
        {
            get { return _createBy; }
            set
            {
                if (_createBy != value)
                {
                    _createBy = value;
                    OnPropertyChanged("CreateBy");
                }
            }
        }
        private string _createBy;
    
        [DataMember]
        public Nullable<System.DateTime> ModifiedOn
        {
            get { return _modifiedOn; }
            set
            {
                if (_modifiedOn != value)
                {
                    _modifiedOn = value;
                    OnPropertyChanged("ModifiedOn");
                }
            }
        }
        private Nullable<System.DateTime> _modifiedOn;
    
        [DataMember]
        public string ModifiedUserID
        {
            get { return _modifiedUserID; }
            set
            {
                if (_modifiedUserID != value)
                {
                    _modifiedUserID = value;
                    OnPropertyChanged("ModifiedUserID");
                }
            }
        }
        private string _modifiedUserID;
    
        [DataMember]
        public string ModifiedBy
        {
            get { return _modifiedBy; }
            set
            {
                if (_modifiedBy != value)
                {
                    _modifiedBy = value;
                    OnPropertyChanged("ModifiedBy");
                }
            }
        }
        private string _modifiedBy;

        #endregion
        #region 导航属性
    
        [DataMember]
        public BaseRole BaseRole
        {
            get { return _baseRole; }
            set
            {
                if (!ReferenceEquals(_baseRole, value))
                {
                    var previousValue = _baseRole;
                    _baseRole = value;
                    FixupBaseRole(previousValue);
                    OnNavigationPropertyChanged("BaseRole");
                }
            }
        }
        private BaseRole _baseRole;
    
        [DataMember]
        public BaseUser BaseUser
        {
            get { return _baseUser; }
            set
            {
                if (!ReferenceEquals(_baseUser, value))
                {
                    var previousValue = _baseUser;
                    _baseUser = value;
                    FixupBaseUser(previousValue);
                    OnNavigationPropertyChanged("BaseUser");
                }
            }
        }
        private BaseUser _baseUser;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            BaseRole = null;
            BaseUser = null;
        }

        #endregion
        #region 关联修复
    
        private void FixupBaseRole(BaseRole previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.R_User_Role.Contains(this))
            {
                previousValue.R_User_Role.Remove(this);
            }
    
            if (BaseRole != null)
            {
                if (!BaseRole.R_User_Role.Contains(this))
                {
                    BaseRole.R_User_Role.Add(this);
                }
    
                RoleID = BaseRole.ID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BaseRole")
                    && (ChangeTracker.OriginalValues["BaseRole"] == BaseRole))
                {
                    ChangeTracker.OriginalValues.Remove("BaseRole");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BaseRole", previousValue);
                }
                if (BaseRole != null && !BaseRole.ChangeTracker.ChangeTrackingEnabled)
                {
                    BaseRole.StartTracking();
                }
            }
        }
    
        private void FixupBaseUser(BaseUser previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.R_User_Role.Contains(this))
            {
                previousValue.R_User_Role.Remove(this);
            }
    
            if (BaseUser != null)
            {
                if (!BaseUser.R_User_Role.Contains(this))
                {
                    BaseUser.R_User_Role.Add(this);
                }
    
                UserID = BaseUser.ID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BaseUser")
                    && (ChangeTracker.OriginalValues["BaseUser"] == BaseUser))
                {
                    ChangeTracker.OriginalValues.Remove("BaseUser");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BaseUser", previousValue);
                }
                if (BaseUser != null && !BaseUser.ChangeTracker.ChangeTrackingEnabled)
                {
                    BaseUser.StartTracking();
                }
            }
        }

        #endregion
    }
}
