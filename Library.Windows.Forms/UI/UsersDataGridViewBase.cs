
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract Users typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class UsersDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<UsersDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.Users _currentUsers = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxUsersDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxUsersErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxUsersBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UserName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUserNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Password property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPasswordDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Last_Login property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLast_LoginDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Last_Logout property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLast_LogoutDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Is_Online property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIs_OnlineDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Is_Active property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIs_ActiveDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Is_Admin property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIs_AdminDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the UserType_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxUserType_IDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the First_Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxFirst_NameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Last_Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLast_NameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Email property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEmailDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Country property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCountryDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the City property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCityDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Address property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Mobile property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxMobileDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Phone property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPhoneDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Postion property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPostionDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Is_Deleted property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIs_DeletedDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CreatedOn property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCreatedOnDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the CreatedBy property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCreatedByDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UpdatedOn property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUpdatedOnDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the UpdatedBy property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUpdatedByDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DeletedOn property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDeletedOnDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DeletedBy property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDeletedByDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private BLL.TList<BLL.UserType> _UserType_IDList;
		
		/// <summary> 
		/// The list of selectable UserType
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public BLL.TList<BLL.UserType> UserType_IDList
		{
			get {return this._UserType_IDList;}
			set 
			{
				this._UserType_IDList = value;
				this.uxUserType_IDDataGridViewColumn.DataSource = null;
				this.uxUserType_IDDataGridViewColumn.DataSource = this._UserType_IDList;
			}
		}
		
		private bool _allowNewItemInUserType_IDList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of UserType
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInUserType_IDList
		{
			get { return _allowNewItemInUserType_IDList;}
			set
			{
				this._allowNewItemInUserType_IDList = value;
				this.uxUserType_IDDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.Users> _UsersList;
				
		/// <summary> 
		/// The list of Users to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.Users> UsersList
		{
			get {return this._UsersList;}
			set
			{
				this._UsersList = value;
				this.uxUsersBindingSource.DataSource = null;
				this.uxUsersBindingSource.DataSource = value;
				this.uxUsersDataGridView.DataSource = null;
				this.uxUsersDataGridView.DataSource = this.uxUsersBindingSource;				
				//this.uxUsersBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxUsersBindingSource_ListChanged);
				this.uxUsersBindingSource.CurrentItemChanged += new System.EventHandler(OnUsersBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnUsersBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentUsers = uxUsersBindingSource.Current as BLL.Users;
			
			if (_currentUsers != null)
			{
				_currentUsers.Validate();
			}
			//_Users.Validate();
			OnCurrentEntityChanged();
		}

		//void uxUsersBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.Users"/> instance.
		/// </summary>
		public BLL.Users SelectedUsers
		{
			get {return this._currentUsers;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxUsersDataGridView.VirtualMode;}
			set
			{
				this.uxUsersDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxUsersDataGridView.AllowUserToAddRows;}
			set {this.uxUsersDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxUsersDataGridView.AllowUserToDeleteRows;}
			set {this.uxUsersDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxUsersDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxUsersDataGridView.Columns; }
		}
		
		#endregion
		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	
		#region Constructor
	
		/// <summary>
		/// Initializes a new instance of the <see cref="UsersDataGridViewBase"/> class.
		/// </summary>
		public UsersDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxUsersDataGridView = new System.Windows.Forms.DataGridView();
			this.uxUsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxUsersErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUserNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPasswordDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLast_LoginDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLast_LogoutDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIs_OnlineDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxIs_ActiveDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxIs_AdminDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxUserType_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxFirst_NameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLast_NameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEmailDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCountryDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddressDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMobileDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPhoneDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPostionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIs_DeletedDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxCreatedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCreatedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUpdatedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUpdatedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDeletedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDeletedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxUserType_IDBindingSource = new UserTypeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxUserType_IDBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUsersDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUsersBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUsersErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxUsersErrorProvider
			// 
			this.uxUsersErrorProvider.ContainerControl = this;
			this.uxUsersErrorProvider.DataSource = this.uxUsersBindingSource;						
			// 
			// uxUsersDataGridView
			// 
			this.uxUsersDataGridView.AutoGenerateColumns = false;
			this.uxUsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxUsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxUserNameDataGridViewColumn,
		this.uxPasswordDataGridViewColumn,
		this.uxLast_LoginDataGridViewColumn,
		this.uxLast_LogoutDataGridViewColumn,
		this.uxIs_OnlineDataGridViewColumn,
		this.uxIs_ActiveDataGridViewColumn,
		this.uxIs_AdminDataGridViewColumn,
		this.uxUserType_IDDataGridViewColumn,
		this.uxFirst_NameDataGridViewColumn,
		this.uxLast_NameDataGridViewColumn,
		this.uxEmailDataGridViewColumn,
		this.uxCountryDataGridViewColumn,
		this.uxCityDataGridViewColumn,
		this.uxAddressDataGridViewColumn,
		this.uxMobileDataGridViewColumn,
		this.uxPhoneDataGridViewColumn,
		this.uxPostionDataGridViewColumn,
		this.uxIs_DeletedDataGridViewColumn,
		this.uxCreatedOnDataGridViewColumn,
		this.uxCreatedByDataGridViewColumn,
		this.uxUpdatedOnDataGridViewColumn,
		this.uxUpdatedByDataGridViewColumn,
		this.uxDeletedOnDataGridViewColumn,
		this.uxDeletedByDataGridViewColumn			});
			this.uxUsersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxUsersDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxUsersDataGridView.Name = "uxUsersDataGridView";
			this.uxUsersDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxUsersDataGridView.TabIndex = 0;	
			this.uxUsersDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxUsersDataGridView.EnableHeadersVisualStyles = false;
			this.uxUsersDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnUsersDataGridViewDataError);
			this.uxUsersDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnUsersDataGridViewCellValueNeeded);
			this.uxUsersDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnUsersDataGridViewCellValuePushed);
			
			//
			// uxIDDataGridViewColumn
			//
			this.uxIDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIDDataGridViewColumn.DataPropertyName = "ID";
			this.uxIDDataGridViewColumn.HeaderText = "ID";
			this.uxIDDataGridViewColumn.Name = "uxIDDataGridViewColumn";
			this.uxIDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIDDataGridViewColumn.ReadOnly = true;		
			//
			// uxUserNameDataGridViewColumn
			//
			this.uxUserNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUserNameDataGridViewColumn.DataPropertyName = "UserName";
			this.uxUserNameDataGridViewColumn.HeaderText = "UserName";
			this.uxUserNameDataGridViewColumn.Name = "uxUserNameDataGridViewColumn";
			this.uxUserNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUserNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUserNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxPasswordDataGridViewColumn
			//
			this.uxPasswordDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPasswordDataGridViewColumn.DataPropertyName = "Password";
			this.uxPasswordDataGridViewColumn.HeaderText = "Password";
			this.uxPasswordDataGridViewColumn.Name = "uxPasswordDataGridViewColumn";
			this.uxPasswordDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPasswordDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPasswordDataGridViewColumn.ReadOnly = false;		
			//
			// uxLast_LoginDataGridViewColumn
			//
			this.uxLast_LoginDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLast_LoginDataGridViewColumn.DataPropertyName = "Last_Login";
			this.uxLast_LoginDataGridViewColumn.HeaderText = "Last_Login";
			this.uxLast_LoginDataGridViewColumn.Name = "uxLast_LoginDataGridViewColumn";
			this.uxLast_LoginDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLast_LoginDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLast_LoginDataGridViewColumn.ReadOnly = false;		
			//
			// uxLast_LogoutDataGridViewColumn
			//
			this.uxLast_LogoutDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLast_LogoutDataGridViewColumn.DataPropertyName = "Last_Logout";
			this.uxLast_LogoutDataGridViewColumn.HeaderText = "Last_Logout";
			this.uxLast_LogoutDataGridViewColumn.Name = "uxLast_LogoutDataGridViewColumn";
			this.uxLast_LogoutDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLast_LogoutDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLast_LogoutDataGridViewColumn.ReadOnly = false;		
			//
			// uxIs_OnlineDataGridViewColumn
			//
			this.uxIs_OnlineDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIs_OnlineDataGridViewColumn.DataPropertyName = "Is_Online";
			this.uxIs_OnlineDataGridViewColumn.HeaderText = "Is_Online";
			this.uxIs_OnlineDataGridViewColumn.Name = "uxIs_OnlineDataGridViewColumn";
			this.uxIs_OnlineDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIs_OnlineDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIs_OnlineDataGridViewColumn.ReadOnly = false;		
			//
			// uxIs_ActiveDataGridViewColumn
			//
			this.uxIs_ActiveDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIs_ActiveDataGridViewColumn.DataPropertyName = "Is_Active";
			this.uxIs_ActiveDataGridViewColumn.HeaderText = "Is_Active";
			this.uxIs_ActiveDataGridViewColumn.Name = "uxIs_ActiveDataGridViewColumn";
			this.uxIs_ActiveDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIs_ActiveDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIs_ActiveDataGridViewColumn.ReadOnly = false;		
			//
			// uxIs_AdminDataGridViewColumn
			//
			this.uxIs_AdminDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIs_AdminDataGridViewColumn.DataPropertyName = "Is_Admin";
			this.uxIs_AdminDataGridViewColumn.HeaderText = "Is_Admin";
			this.uxIs_AdminDataGridViewColumn.Name = "uxIs_AdminDataGridViewColumn";
			this.uxIs_AdminDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIs_AdminDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIs_AdminDataGridViewColumn.ReadOnly = false;		
			//
			// uxUserType_IDDataGridViewColumn
			//
			this.uxUserType_IDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUserType_IDDataGridViewColumn.DataPropertyName = "UserType_ID";
			this.uxUserType_IDDataGridViewColumn.HeaderText = "UserType_ID";
			this.uxUserType_IDDataGridViewColumn.Name = "uxUserType_IDDataGridViewColumn";
			this.uxUserType_IDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUserType_IDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUserType_IDDataGridViewColumn.ReadOnly = false;		
			//
			// uxFirst_NameDataGridViewColumn
			//
			this.uxFirst_NameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFirst_NameDataGridViewColumn.DataPropertyName = "First_Name";
			this.uxFirst_NameDataGridViewColumn.HeaderText = "First_Name";
			this.uxFirst_NameDataGridViewColumn.Name = "uxFirst_NameDataGridViewColumn";
			this.uxFirst_NameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFirst_NameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFirst_NameDataGridViewColumn.ReadOnly = false;		
			//
			// uxLast_NameDataGridViewColumn
			//
			this.uxLast_NameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLast_NameDataGridViewColumn.DataPropertyName = "Last_Name";
			this.uxLast_NameDataGridViewColumn.HeaderText = "Last_Name";
			this.uxLast_NameDataGridViewColumn.Name = "uxLast_NameDataGridViewColumn";
			this.uxLast_NameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLast_NameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLast_NameDataGridViewColumn.ReadOnly = false;		
			//
			// uxEmailDataGridViewColumn
			//
			this.uxEmailDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEmailDataGridViewColumn.DataPropertyName = "Email";
			this.uxEmailDataGridViewColumn.HeaderText = "Email";
			this.uxEmailDataGridViewColumn.Name = "uxEmailDataGridViewColumn";
			this.uxEmailDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEmailDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEmailDataGridViewColumn.ReadOnly = false;		
			//
			// uxCountryDataGridViewColumn
			//
			this.uxCountryDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCountryDataGridViewColumn.DataPropertyName = "Country";
			this.uxCountryDataGridViewColumn.HeaderText = "Country";
			this.uxCountryDataGridViewColumn.Name = "uxCountryDataGridViewColumn";
			this.uxCountryDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCountryDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCountryDataGridViewColumn.ReadOnly = false;		
			//
			// uxCityDataGridViewColumn
			//
			this.uxCityDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCityDataGridViewColumn.DataPropertyName = "City";
			this.uxCityDataGridViewColumn.HeaderText = "City";
			this.uxCityDataGridViewColumn.Name = "uxCityDataGridViewColumn";
			this.uxCityDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCityDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCityDataGridViewColumn.ReadOnly = false;		
			//
			// uxAddressDataGridViewColumn
			//
			this.uxAddressDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressDataGridViewColumn.DataPropertyName = "Address";
			this.uxAddressDataGridViewColumn.HeaderText = "Address";
			this.uxAddressDataGridViewColumn.Name = "uxAddressDataGridViewColumn";
			this.uxAddressDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressDataGridViewColumn.ReadOnly = false;		
			//
			// uxMobileDataGridViewColumn
			//
			this.uxMobileDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxMobileDataGridViewColumn.DataPropertyName = "Mobile";
			this.uxMobileDataGridViewColumn.HeaderText = "Mobile";
			this.uxMobileDataGridViewColumn.Name = "uxMobileDataGridViewColumn";
			this.uxMobileDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxMobileDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxMobileDataGridViewColumn.ReadOnly = false;		
			//
			// uxPhoneDataGridViewColumn
			//
			this.uxPhoneDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPhoneDataGridViewColumn.DataPropertyName = "Phone";
			this.uxPhoneDataGridViewColumn.HeaderText = "Phone";
			this.uxPhoneDataGridViewColumn.Name = "uxPhoneDataGridViewColumn";
			this.uxPhoneDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPhoneDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPhoneDataGridViewColumn.ReadOnly = false;		
			//
			// uxPostionDataGridViewColumn
			//
			this.uxPostionDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPostionDataGridViewColumn.DataPropertyName = "Postion";
			this.uxPostionDataGridViewColumn.HeaderText = "Postion";
			this.uxPostionDataGridViewColumn.Name = "uxPostionDataGridViewColumn";
			this.uxPostionDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPostionDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPostionDataGridViewColumn.ReadOnly = false;		
			//
			// uxIs_DeletedDataGridViewColumn
			//
			this.uxIs_DeletedDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIs_DeletedDataGridViewColumn.DataPropertyName = "Is_Deleted";
			this.uxIs_DeletedDataGridViewColumn.HeaderText = "Is_Deleted";
			this.uxIs_DeletedDataGridViewColumn.Name = "uxIs_DeletedDataGridViewColumn";
			this.uxIs_DeletedDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIs_DeletedDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIs_DeletedDataGridViewColumn.ReadOnly = false;		
			//
			// uxCreatedOnDataGridViewColumn
			//
			this.uxCreatedOnDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCreatedOnDataGridViewColumn.DataPropertyName = "CreatedOn";
			this.uxCreatedOnDataGridViewColumn.HeaderText = "CreatedOn";
			this.uxCreatedOnDataGridViewColumn.Name = "uxCreatedOnDataGridViewColumn";
			this.uxCreatedOnDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCreatedOnDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCreatedOnDataGridViewColumn.ReadOnly = false;		
			//
			// uxCreatedByDataGridViewColumn
			//
			this.uxCreatedByDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCreatedByDataGridViewColumn.DataPropertyName = "CreatedBy";
			this.uxCreatedByDataGridViewColumn.HeaderText = "CreatedBy";
			this.uxCreatedByDataGridViewColumn.Name = "uxCreatedByDataGridViewColumn";
			this.uxCreatedByDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCreatedByDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCreatedByDataGridViewColumn.ReadOnly = false;		
			//
			// uxUpdatedOnDataGridViewColumn
			//
			this.uxUpdatedOnDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUpdatedOnDataGridViewColumn.DataPropertyName = "UpdatedOn";
			this.uxUpdatedOnDataGridViewColumn.HeaderText = "UpdatedOn";
			this.uxUpdatedOnDataGridViewColumn.Name = "uxUpdatedOnDataGridViewColumn";
			this.uxUpdatedOnDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUpdatedOnDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUpdatedOnDataGridViewColumn.ReadOnly = false;		
			//
			// uxUpdatedByDataGridViewColumn
			//
			this.uxUpdatedByDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUpdatedByDataGridViewColumn.DataPropertyName = "UpdatedBy";
			this.uxUpdatedByDataGridViewColumn.HeaderText = "UpdatedBy";
			this.uxUpdatedByDataGridViewColumn.Name = "uxUpdatedByDataGridViewColumn";
			this.uxUpdatedByDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUpdatedByDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUpdatedByDataGridViewColumn.ReadOnly = false;		
			//
			// uxDeletedOnDataGridViewColumn
			//
			this.uxDeletedOnDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDeletedOnDataGridViewColumn.DataPropertyName = "DeletedOn";
			this.uxDeletedOnDataGridViewColumn.HeaderText = "DeletedOn";
			this.uxDeletedOnDataGridViewColumn.Name = "uxDeletedOnDataGridViewColumn";
			this.uxDeletedOnDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDeletedOnDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDeletedOnDataGridViewColumn.ReadOnly = false;		
			//
			// uxDeletedByDataGridViewColumn
			//
			this.uxDeletedByDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDeletedByDataGridViewColumn.DataPropertyName = "DeletedBy";
			this.uxDeletedByDataGridViewColumn.HeaderText = "DeletedBy";
			this.uxDeletedByDataGridViewColumn.Name = "uxDeletedByDataGridViewColumn";
			this.uxDeletedByDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDeletedByDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDeletedByDataGridViewColumn.ReadOnly = false;		
			//
			// uxUserType_IDDataGridViewColumn
			//				
			this.uxUserType_IDDataGridViewColumn.DisplayMember = "TypeName";	
			this.uxUserType_IDDataGridViewColumn.ValueMember = "ID";	
			this.uxUserType_IDDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxUserType_IDDataGridViewColumn.DataSource = uxUserType_IDBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxUsersDataGridView);
			this.Name = "UsersDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxUserType_IDBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUsersErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUsersDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUsersBindingSource)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion
				
		#region events
		
		/// <summary>
		/// Raised the CurrentEntityChanged event.
		/// </summary>
		protected void OnCurrentEntityChanged()
		{
			if (CurrentEntityChanged != null)
			{
				UsersDataGridViewEventArgs args = new UsersDataGridViewEventArgs();
				args.Users = _currentUsers;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class UsersDataGridViewEventArgs : System.EventArgs
		{
			private BLL.Users	_Users;
	
			/// <summary>
			/// the  BLL.Users instance.
			/// </summary>
			public BLL.Users Users
			{
				get { return _Users; }
				set { _Users = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxUsersDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnUsersDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxUsersDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnUsersDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxUsersDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].ID;
						break;
					case "uxUserNameDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].UserName;
						break;
					case "uxPasswordDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Password;
						break;
					case "uxLast_LoginDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Last_Login;
						break;
					case "uxLast_LogoutDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Last_Logout;
						break;
					case "uxIs_OnlineDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Is_Online;
						break;
					case "uxIs_ActiveDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Is_Active;
						break;
					case "uxIs_AdminDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Is_Admin;
						break;
					case "uxUserType_IDDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].UserType_ID;
						break;
					case "uxFirst_NameDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].First_Name;
						break;
					case "uxLast_NameDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Last_Name;
						break;
					case "uxEmailDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Email;
						break;
					case "uxCountryDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Country;
						break;
					case "uxCityDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].City;
						break;
					case "uxAddressDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Address;
						break;
					case "uxMobileDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Mobile;
						break;
					case "uxPhoneDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Phone;
						break;
					case "uxPostionDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Postion;
						break;
					case "uxIs_DeletedDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].Is_Deleted;
						break;
					case "uxCreatedOnDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].CreatedOn;
						break;
					case "uxCreatedByDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].CreatedBy;
						break;
					case "uxUpdatedOnDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].UpdatedOn;
						break;
					case "uxUpdatedByDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].UpdatedBy;
						break;
					case "uxDeletedOnDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].DeletedOn;
						break;
					case "uxDeletedByDataGridViewColumn":
						e.Value = UsersList[e.RowIndex].DeletedBy;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxUsersDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnUsersDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxUsersDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						UsersList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxUserNameDataGridViewColumn":
						UsersList[e.RowIndex].UserName = (System.String)e.Value;
						break;
					case "uxPasswordDataGridViewColumn":
						UsersList[e.RowIndex].Password = (System.String)e.Value;
						break;
					case "uxLast_LoginDataGridViewColumn":
						UsersList[e.RowIndex].Last_Login = (System.DateTime?)e.Value;
						break;
					case "uxLast_LogoutDataGridViewColumn":
						UsersList[e.RowIndex].Last_Logout = (System.DateTime?)e.Value;
						break;
					case "uxIs_OnlineDataGridViewColumn":
						UsersList[e.RowIndex].Is_Online = (System.Boolean)e.Value;
						break;
					case "uxIs_ActiveDataGridViewColumn":
						UsersList[e.RowIndex].Is_Active = (System.Boolean)e.Value;
						break;
					case "uxIs_AdminDataGridViewColumn":
						UsersList[e.RowIndex].Is_Admin = (System.Boolean)e.Value;
						break;
					case "uxUserType_IDDataGridViewColumn":
						UsersList[e.RowIndex].UserType_ID = (System.Int32)e.Value;
						break;
					case "uxFirst_NameDataGridViewColumn":
						UsersList[e.RowIndex].First_Name = (System.String)e.Value;
						break;
					case "uxLast_NameDataGridViewColumn":
						UsersList[e.RowIndex].Last_Name = (System.String)e.Value;
						break;
					case "uxEmailDataGridViewColumn":
						UsersList[e.RowIndex].Email = (System.String)e.Value;
						break;
					case "uxCountryDataGridViewColumn":
						UsersList[e.RowIndex].Country = (System.String)e.Value;
						break;
					case "uxCityDataGridViewColumn":
						UsersList[e.RowIndex].City = (System.String)e.Value;
						break;
					case "uxAddressDataGridViewColumn":
						UsersList[e.RowIndex].Address = (System.String)e.Value;
						break;
					case "uxMobileDataGridViewColumn":
						UsersList[e.RowIndex].Mobile = (System.String)e.Value;
						break;
					case "uxPhoneDataGridViewColumn":
						UsersList[e.RowIndex].Phone = (System.String)e.Value;
						break;
					case "uxPostionDataGridViewColumn":
						UsersList[e.RowIndex].Postion = (System.String)e.Value;
						break;
					case "uxIs_DeletedDataGridViewColumn":
						UsersList[e.RowIndex].Is_Deleted = (System.Boolean?)e.Value;
						break;
					case "uxCreatedOnDataGridViewColumn":
						UsersList[e.RowIndex].CreatedOn = (System.DateTime?)e.Value;
						break;
					case "uxCreatedByDataGridViewColumn":
						UsersList[e.RowIndex].CreatedBy = (System.Int32?)e.Value;
						break;
					case "uxUpdatedOnDataGridViewColumn":
						UsersList[e.RowIndex].UpdatedOn = (System.DateTime?)e.Value;
						break;
					case "uxUpdatedByDataGridViewColumn":
						UsersList[e.RowIndex].UpdatedBy = (System.Int32?)e.Value;
						break;
					case "uxDeletedOnDataGridViewColumn":
						UsersList[e.RowIndex].DeletedOn = (System.DateTime?)e.Value;
						break;
					case "uxDeletedByDataGridViewColumn":
						UsersList[e.RowIndex].DeletedBy = (System.Int32?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
