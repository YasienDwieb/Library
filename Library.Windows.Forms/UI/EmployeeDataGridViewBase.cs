
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract Employee typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class EmployeeDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<EmployeeDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.Employee _currentEmployee = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxEmployeeDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxEmployeeErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxEmployeeBindingSource;
		
		
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
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.Employee> _EmployeeList;
				
		/// <summary> 
		/// The list of Employee to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.Employee> EmployeeList
		{
			get {return this._EmployeeList;}
			set
			{
				this._EmployeeList = value;
				this.uxEmployeeBindingSource.DataSource = null;
				this.uxEmployeeBindingSource.DataSource = value;
				this.uxEmployeeDataGridView.DataSource = null;
				this.uxEmployeeDataGridView.DataSource = this.uxEmployeeBindingSource;				
				//this.uxEmployeeBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxEmployeeBindingSource_ListChanged);
				this.uxEmployeeBindingSource.CurrentItemChanged += new System.EventHandler(OnEmployeeBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnEmployeeBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentEmployee = uxEmployeeBindingSource.Current as BLL.Employee;
			
			if (_currentEmployee != null)
			{
				_currentEmployee.Validate();
			}
			//_Employee.Validate();
			OnCurrentEntityChanged();
		}

		//void uxEmployeeBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.Employee"/> instance.
		/// </summary>
		public BLL.Employee SelectedEmployee
		{
			get {return this._currentEmployee;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxEmployeeDataGridView.VirtualMode;}
			set
			{
				this.uxEmployeeDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxEmployeeDataGridView.AllowUserToAddRows;}
			set {this.uxEmployeeDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxEmployeeDataGridView.AllowUserToDeleteRows;}
			set {this.uxEmployeeDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxEmployeeDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxEmployeeDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="EmployeeDataGridViewBase"/> class.
		/// </summary>
		public EmployeeDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxEmployeeDataGridView = new System.Windows.Forms.DataGridView();
			this.uxEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxEmployeeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUserNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPasswordDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLast_LoginDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLast_LogoutDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIs_OnlineDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxIs_ActiveDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxIs_AdminDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxEmployeeErrorProvider
			// 
			this.uxEmployeeErrorProvider.ContainerControl = this;
			this.uxEmployeeErrorProvider.DataSource = this.uxEmployeeBindingSource;						
			// 
			// uxEmployeeDataGridView
			// 
			this.uxEmployeeDataGridView.AutoGenerateColumns = false;
			this.uxEmployeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxEmployeeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxUserNameDataGridViewColumn,
		this.uxPasswordDataGridViewColumn,
		this.uxLast_LoginDataGridViewColumn,
		this.uxLast_LogoutDataGridViewColumn,
		this.uxIs_OnlineDataGridViewColumn,
		this.uxIs_ActiveDataGridViewColumn,
		this.uxIs_AdminDataGridViewColumn,
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
			this.uxEmployeeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxEmployeeDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxEmployeeDataGridView.Name = "uxEmployeeDataGridView";
			this.uxEmployeeDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxEmployeeDataGridView.TabIndex = 0;	
			this.uxEmployeeDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxEmployeeDataGridView.EnableHeadersVisualStyles = false;
			this.uxEmployeeDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnEmployeeDataGridViewDataError);
			this.uxEmployeeDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeeDataGridViewCellValueNeeded);
			this.uxEmployeeDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnEmployeeDataGridViewCellValuePushed);
			
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
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxEmployeeDataGridView);
			this.Name = "EmployeeDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxEmployeeBindingSource)).EndInit();
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
				EmployeeDataGridViewEventArgs args = new EmployeeDataGridViewEventArgs();
				args.Employee = _currentEmployee;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class EmployeeDataGridViewEventArgs : System.EventArgs
		{
			private BLL.Employee	_Employee;
	
			/// <summary>
			/// the  BLL.Employee instance.
			/// </summary>
			public BLL.Employee Employee
			{
				get { return _Employee; }
				set { _Employee = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxEmployeeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxEmployeeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].ID;
						break;
					case "uxUserNameDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].UserName;
						break;
					case "uxPasswordDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Password;
						break;
					case "uxLast_LoginDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Last_Login;
						break;
					case "uxLast_LogoutDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Last_Logout;
						break;
					case "uxIs_OnlineDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Is_Online;
						break;
					case "uxIs_ActiveDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Is_Active;
						break;
					case "uxIs_AdminDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Is_Admin;
						break;
					case "uxFirst_NameDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].First_Name;
						break;
					case "uxLast_NameDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Last_Name;
						break;
					case "uxEmailDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Email;
						break;
					case "uxCountryDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Country;
						break;
					case "uxCityDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].City;
						break;
					case "uxAddressDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Address;
						break;
					case "uxMobileDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Mobile;
						break;
					case "uxPhoneDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Phone;
						break;
					case "uxPostionDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Postion;
						break;
					case "uxIs_DeletedDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].Is_Deleted;
						break;
					case "uxCreatedOnDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].CreatedOn;
						break;
					case "uxCreatedByDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].CreatedBy;
						break;
					case "uxUpdatedOnDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].UpdatedOn;
						break;
					case "uxUpdatedByDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].UpdatedBy;
						break;
					case "uxDeletedOnDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].DeletedOn;
						break;
					case "uxDeletedByDataGridViewColumn":
						e.Value = EmployeeList[e.RowIndex].DeletedBy;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxEmployeeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnEmployeeDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxEmployeeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						EmployeeList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxUserNameDataGridViewColumn":
						EmployeeList[e.RowIndex].UserName = (System.String)e.Value;
						break;
					case "uxPasswordDataGridViewColumn":
						EmployeeList[e.RowIndex].Password = (System.String)e.Value;
						break;
					case "uxLast_LoginDataGridViewColumn":
						EmployeeList[e.RowIndex].Last_Login = (System.DateTime?)e.Value;
						break;
					case "uxLast_LogoutDataGridViewColumn":
						EmployeeList[e.RowIndex].Last_Logout = (System.DateTime)e.Value;
						break;
					case "uxIs_OnlineDataGridViewColumn":
						EmployeeList[e.RowIndex].Is_Online = (System.Boolean?)e.Value;
						break;
					case "uxIs_ActiveDataGridViewColumn":
						EmployeeList[e.RowIndex].Is_Active = (System.Boolean?)e.Value;
						break;
					case "uxIs_AdminDataGridViewColumn":
						EmployeeList[e.RowIndex].Is_Admin = (System.Boolean?)e.Value;
						break;
					case "uxFirst_NameDataGridViewColumn":
						EmployeeList[e.RowIndex].First_Name = (System.String)e.Value;
						break;
					case "uxLast_NameDataGridViewColumn":
						EmployeeList[e.RowIndex].Last_Name = (System.String)e.Value;
						break;
					case "uxEmailDataGridViewColumn":
						EmployeeList[e.RowIndex].Email = (System.String)e.Value;
						break;
					case "uxCountryDataGridViewColumn":
						EmployeeList[e.RowIndex].Country = (System.String)e.Value;
						break;
					case "uxCityDataGridViewColumn":
						EmployeeList[e.RowIndex].City = (System.String)e.Value;
						break;
					case "uxAddressDataGridViewColumn":
						EmployeeList[e.RowIndex].Address = (System.String)e.Value;
						break;
					case "uxMobileDataGridViewColumn":
						EmployeeList[e.RowIndex].Mobile = (System.String)e.Value;
						break;
					case "uxPhoneDataGridViewColumn":
						EmployeeList[e.RowIndex].Phone = (System.String)e.Value;
						break;
					case "uxPostionDataGridViewColumn":
						EmployeeList[e.RowIndex].Postion = (System.String)e.Value;
						break;
					case "uxIs_DeletedDataGridViewColumn":
						EmployeeList[e.RowIndex].Is_Deleted = (System.Boolean?)e.Value;
						break;
					case "uxCreatedOnDataGridViewColumn":
						EmployeeList[e.RowIndex].CreatedOn = (System.DateTime?)e.Value;
						break;
					case "uxCreatedByDataGridViewColumn":
						EmployeeList[e.RowIndex].CreatedBy = (System.Int32?)e.Value;
						break;
					case "uxUpdatedOnDataGridViewColumn":
						EmployeeList[e.RowIndex].UpdatedOn = (System.DateTime?)e.Value;
						break;
					case "uxUpdatedByDataGridViewColumn":
						EmployeeList[e.RowIndex].UpdatedBy = (System.Int32?)e.Value;
						break;
					case "uxDeletedOnDataGridViewColumn":
						EmployeeList[e.RowIndex].DeletedOn = (System.DateTime?)e.Value;
						break;
					case "uxDeletedByDataGridViewColumn":
						EmployeeList[e.RowIndex].DeletedBy = (System.Int32?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
