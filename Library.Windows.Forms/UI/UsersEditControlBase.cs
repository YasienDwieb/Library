
namespace Library.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="BLL.Users"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class UsersEditControlBase : System.Windows.Forms.UserControl
	{
		#region Fields
		
		//private System.Windows.Forms.TableLayoutPanel uxTableLayoutPanel;
		/// <summary>
		/// The ErrorProvider for the Entity;
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxErrorProvider;
		
		/// <summary>
		/// The BindingSource for the entity.
		///</summary>
		protected System.Windows.Forms.BindingSource uxBindingSource;
						
		
		/// <summary>
		/// TextBox for the ID property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxIDLabel;
		
		/// <summary>
		/// TextBox for the UserName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUserName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UserName property.
		/// </summary>
		protected System.Windows.Forms.Label uxUserNameLabel;
		
		/// <summary>
		/// TextBox for the Password property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPassword;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Password property.
		/// </summary>
		protected System.Windows.Forms.Label uxPasswordLabel;
		
		/// <summary>
		/// DataTimePicker for the Last_Login property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxLast_Login;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Last_Login property.
		/// </summary>
		protected System.Windows.Forms.Label uxLast_LoginLabel;
		
		/// <summary>
		/// DataTimePicker for the Last_Logout property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxLast_Logout;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Last_Logout property.
		/// </summary>
		protected System.Windows.Forms.Label uxLast_LogoutLabel;
		
		/// <summary>
		/// CheckBox for the Is_Online property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxIs_Online;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Is_Online property.
		/// </summary>
		protected System.Windows.Forms.Label uxIs_OnlineLabel;
		
		/// <summary>
		/// CheckBox for the Is_Active property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxIs_Active;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Is_Active property.
		/// </summary>
		protected System.Windows.Forms.Label uxIs_ActiveLabel;
		
		/// <summary>
		/// CheckBox for the Is_Admin property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxIs_Admin;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Is_Admin property.
		/// </summary>
		protected System.Windows.Forms.Label uxIs_AdminLabel;
		
		/// <summary>
		/// ComboBox for the UserType_ID property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxUserType_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UserType_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxUserType_IDLabel;
		
		/// <summary>
		/// TextBox for the First_Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxFirst_Name;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the First_Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxFirst_NameLabel;
		
		/// <summary>
		/// TextBox for the Last_Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLast_Name;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Last_Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxLast_NameLabel;
		
		/// <summary>
		/// TextBox for the Email property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxEmail;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Email property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmailLabel;
		
		/// <summary>
		/// TextBox for the Country property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCountry;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Country property.
		/// </summary>
		protected System.Windows.Forms.Label uxCountryLabel;
		
		/// <summary>
		/// TextBox for the City property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCity;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the City property.
		/// </summary>
		protected System.Windows.Forms.Label uxCityLabel;
		
		/// <summary>
		/// TextBox for the Address property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxAddress;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Address property.
		/// </summary>
		protected System.Windows.Forms.Label uxAddressLabel;
		
		/// <summary>
		/// TextBox for the Mobile property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxMobile;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Mobile property.
		/// </summary>
		protected System.Windows.Forms.Label uxMobileLabel;
		
		/// <summary>
		/// TextBox for the Phone property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPhone;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Phone property.
		/// </summary>
		protected System.Windows.Forms.Label uxPhoneLabel;
		
		/// <summary>
		/// TextBox for the Postion property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPostion;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Postion property.
		/// </summary>
		protected System.Windows.Forms.Label uxPostionLabel;
		
		/// <summary>
		/// CheckBox for the Is_Deleted property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxIs_Deleted;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Is_Deleted property.
		/// </summary>
		protected System.Windows.Forms.Label uxIs_DeletedLabel;
		
		/// <summary>
		/// DataTimePicker for the CreatedOn property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxCreatedOn;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CreatedOn property.
		/// </summary>
		protected System.Windows.Forms.Label uxCreatedOnLabel;
		
		/// <summary>
		/// TextBox for the CreatedBy property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCreatedBy;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CreatedBy property.
		/// </summary>
		protected System.Windows.Forms.Label uxCreatedByLabel;
		
		/// <summary>
		/// DataTimePicker for the UpdatedOn property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxUpdatedOn;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UpdatedOn property.
		/// </summary>
		protected System.Windows.Forms.Label uxUpdatedOnLabel;
		
		/// <summary>
		/// TextBox for the UpdatedBy property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUpdatedBy;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UpdatedBy property.
		/// </summary>
		protected System.Windows.Forms.Label uxUpdatedByLabel;
		
		/// <summary>
		/// DataTimePicker for the DeletedOn property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxDeletedOn;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DeletedOn property.
		/// </summary>
		protected System.Windows.Forms.Label uxDeletedOnLabel;
		
		/// <summary>
		/// TextBox for the DeletedBy property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDeletedBy;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DeletedBy property.
		/// </summary>
		protected System.Windows.Forms.Label uxDeletedByLabel;
		#endregion
		
		#region Main entity
		private BLL.Users _Users;
		/// <summary>
		/// Gets or sets the <see cref="BLL.Users"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="BLL.Users"/> instance.</value>
		public BLL.Users Users
		{
			get {return this._Users;}
			set
			{
				this._Users = value;
				if (value != null) 
				{
					this.uxBindingSource.DataSource = value;
					BindControls();
				}			
				
			}
		}
		#endregion
		
		/// <summary>
		/// Binds the controls.
		/// </summary>
		private void BindControls()
		{
			this.uxID.DataBindings.Clear();
			this.uxID.DataBindings.Add("Text", this.uxBindingSource, "ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUserName.DataBindings.Clear();
			this.uxUserName.DataBindings.Add("Text", this.uxBindingSource, "UserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPassword.DataBindings.Clear();
			this.uxPassword.DataBindings.Add("Text", this.uxBindingSource, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLast_Login.DataBindings.Clear();
			this.uxLast_Login.DataBindings.Add("Value", this.uxBindingSource, "Last_Login", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLast_Logout.DataBindings.Clear();
			this.uxLast_Logout.DataBindings.Add("Value", this.uxBindingSource, "Last_Logout", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIs_Online.DataBindings.Clear();
			this.uxIs_Online.DataBindings.Add("Checked", this.uxBindingSource, "Is_Online", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIs_Active.DataBindings.Clear();
			this.uxIs_Active.DataBindings.Add("Checked", this.uxBindingSource, "Is_Active", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIs_Admin.DataBindings.Clear();
			this.uxIs_Admin.DataBindings.Add("Checked", this.uxBindingSource, "Is_Admin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUserType_ID.DataBindings.Clear();
			this.uxUserType_ID.DataBindings.Add("SelectedValue", this.uxBindingSource, "UserType_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFirst_Name.DataBindings.Clear();
			this.uxFirst_Name.DataBindings.Add("Text", this.uxBindingSource, "First_Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLast_Name.DataBindings.Clear();
			this.uxLast_Name.DataBindings.Add("Text", this.uxBindingSource, "Last_Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEmail.DataBindings.Clear();
			this.uxEmail.DataBindings.Add("Text", this.uxBindingSource, "Email", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCountry.DataBindings.Clear();
			this.uxCountry.DataBindings.Add("Text", this.uxBindingSource, "Country", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCity.DataBindings.Clear();
			this.uxCity.DataBindings.Add("Text", this.uxBindingSource, "City", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddress.DataBindings.Clear();
			this.uxAddress.DataBindings.Add("Text", this.uxBindingSource, "Address", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMobile.DataBindings.Clear();
			this.uxMobile.DataBindings.Add("Text", this.uxBindingSource, "Mobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPhone.DataBindings.Clear();
			this.uxPhone.DataBindings.Add("Text", this.uxBindingSource, "Phone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPostion.DataBindings.Clear();
			this.uxPostion.DataBindings.Add("Text", this.uxBindingSource, "Postion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIs_Deleted.DataBindings.Clear();
			this.uxIs_Deleted.DataBindings.Add("Checked", this.uxBindingSource, "Is_Deleted", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCreatedOn.DataBindings.Clear();
			this.uxCreatedOn.DataBindings.Add("Value", this.uxBindingSource, "CreatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCreatedBy.DataBindings.Clear();
			this.uxCreatedBy.DataBindings.Add("Text", this.uxBindingSource, "CreatedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUpdatedOn.DataBindings.Clear();
			this.uxUpdatedOn.DataBindings.Add("Value", this.uxBindingSource, "UpdatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUpdatedBy.DataBindings.Clear();
			this.uxUpdatedBy.DataBindings.Add("Text", this.uxBindingSource, "UpdatedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDeletedOn.DataBindings.Clear();
			this.uxDeletedOn.DataBindings.Add("Value", this.uxBindingSource, "DeletedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDeletedBy.DataBindings.Clear();
			this.uxDeletedBy.DataBindings.Add("Text", this.uxBindingSource, "DeletedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UsersEditControlBase"/> class.
		/// </summary>
		public UsersEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Users != null) _Users.Validate();
		}	
				
		/// <summary>
		/// Initializes the component.
		/// </summary>
		public void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.uxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxBindingSource = new System.Windows.Forms.BindingSource(this.components);
			
			//this.uxTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.uxID = new System.Windows.Forms.TextBox();
			uxIDLabel = new System.Windows.Forms.Label();
			this.uxUserName = new System.Windows.Forms.TextBox();
			uxUserNameLabel = new System.Windows.Forms.Label();
			this.uxPassword = new System.Windows.Forms.TextBox();
			uxPasswordLabel = new System.Windows.Forms.Label();
			this.uxLast_Login = new System.Windows.Forms.DateTimePicker();
			uxLast_LoginLabel = new System.Windows.Forms.Label();
			this.uxLast_Logout = new System.Windows.Forms.DateTimePicker();
			uxLast_LogoutLabel = new System.Windows.Forms.Label();
			this.uxIs_Online = new System.Windows.Forms.CheckBox();
			uxIs_OnlineLabel = new System.Windows.Forms.Label();
			this.uxIs_Active = new System.Windows.Forms.CheckBox();
			uxIs_ActiveLabel = new System.Windows.Forms.Label();
			this.uxIs_Admin = new System.Windows.Forms.CheckBox();
			uxIs_AdminLabel = new System.Windows.Forms.Label();
			this.uxUserType_ID = new System.Windows.Forms.ComboBox();
			uxUserType_IDLabel = new System.Windows.Forms.Label();
			this.uxFirst_Name = new System.Windows.Forms.TextBox();
			uxFirst_NameLabel = new System.Windows.Forms.Label();
			this.uxLast_Name = new System.Windows.Forms.TextBox();
			uxLast_NameLabel = new System.Windows.Forms.Label();
			this.uxEmail = new System.Windows.Forms.TextBox();
			uxEmailLabel = new System.Windows.Forms.Label();
			this.uxCountry = new System.Windows.Forms.TextBox();
			uxCountryLabel = new System.Windows.Forms.Label();
			this.uxCity = new System.Windows.Forms.TextBox();
			uxCityLabel = new System.Windows.Forms.Label();
			this.uxAddress = new System.Windows.Forms.TextBox();
			uxAddressLabel = new System.Windows.Forms.Label();
			this.uxMobile = new System.Windows.Forms.TextBox();
			uxMobileLabel = new System.Windows.Forms.Label();
			this.uxPhone = new System.Windows.Forms.TextBox();
			uxPhoneLabel = new System.Windows.Forms.Label();
			this.uxPostion = new System.Windows.Forms.TextBox();
			uxPostionLabel = new System.Windows.Forms.Label();
			this.uxIs_Deleted = new System.Windows.Forms.CheckBox();
			uxIs_DeletedLabel = new System.Windows.Forms.Label();
			this.uxCreatedOn = new System.Windows.Forms.DateTimePicker();
			uxCreatedOnLabel = new System.Windows.Forms.Label();
			this.uxCreatedBy = new System.Windows.Forms.TextBox();
			uxCreatedByLabel = new System.Windows.Forms.Label();
			this.uxUpdatedOn = new System.Windows.Forms.DateTimePicker();
			uxUpdatedOnLabel = new System.Windows.Forms.Label();
			this.uxUpdatedBy = new System.Windows.Forms.TextBox();
			uxUpdatedByLabel = new System.Windows.Forms.Label();
			this.uxDeletedOn = new System.Windows.Forms.DateTimePicker();
			uxDeletedOnLabel = new System.Windows.Forms.Label();
			this.uxDeletedBy = new System.Windows.Forms.TextBox();
			uxDeletedByLabel = new System.Windows.Forms.Label();
			
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).BeginInit();
			this.SuspendLayout();
			
			// 
			// uxTableLayoutPanel
			// 
			//this.uxTableLayoutPanel.AutoSize = true;
			//this.uxTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			//this.uxTableLayoutPanel.ColumnCount = 2;
			//this.uxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			//this.uxTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
			//this.uxTableLayoutPanel.Location = new System.Drawing.System.Drawing.Point(3, 3);
			//this.uxTableLayoutPanel.Name = "uxTableLayoutPanel";
			//this.uxTableLayoutPanel.RowCount = 2;
			//this.uxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			//this.uxTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			//this.uxTableLayoutPanel.Size = new System.Drawing.Size(450, 50);
			//this.uxTableLayoutPanel.TabIndex = 0;
			
			//
			// uxErrorProvider
			//
			this.uxErrorProvider.ContainerControl = this;
			this.uxErrorProvider.DataSource = this.uxBindingSource;
			
			//
			// uxIDLabel
			//
			this.uxIDLabel.Name = "uxIDLabel";
			this.uxIDLabel.Text = "ID:";
			this.uxIDLabel.Location = new System.Drawing.Point(3, 0);
			this.Controls.Add(this.uxIDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIDLabel);			
			//
			// uxID
			//
			this.uxID.Name = "uxID";
            this.uxID.ReadOnly = true;
			//this.uxTableLayoutPanel.Controls.Add(this.uxID);
			this.uxID.Location = new System.Drawing.Point(160, 0);
			this.Controls.Add(this.uxID);
			//
			// uxUserNameLabel
			//
			this.uxUserNameLabel.Name = "uxUserNameLabel";
			this.uxUserNameLabel.Text = "User Name:";
			this.uxUserNameLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxUserNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUserNameLabel);			
			//
			// uxUserName
			//
			this.uxUserName.Name = "uxUserName";
			this.uxUserName.Width = 250;
			this.uxUserName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxUserName);
			this.uxUserName.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxUserName);
			//
			// uxPasswordLabel
			//
			this.uxPasswordLabel.Name = "uxPasswordLabel";
			this.uxPasswordLabel.Text = "Password:";
			this.uxPasswordLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxPasswordLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPasswordLabel);			
			//
			// uxPassword
			//
			this.uxPassword.Name = "uxPassword";
			this.uxPassword.Width = 250;
			this.uxPassword.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPassword);
			this.uxPassword.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxPassword);
			//
			// uxLast_LoginLabel
			//
			this.uxLast_LoginLabel.Name = "uxLast_LoginLabel";
			this.uxLast_LoginLabel.Text = "Last Login:";
			this.uxLast_LoginLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxLast_LoginLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLast_LoginLabel);			
			//
			// uxLast_Login
			//
			this.uxLast_Login.Name = "uxLast_Login";
			//this.uxTableLayoutPanel.Controls.Add(this.uxLast_Login);
			this.uxLast_Login.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxLast_Login);
			//
			// uxLast_LogoutLabel
			//
			this.uxLast_LogoutLabel.Name = "uxLast_LogoutLabel";
			this.uxLast_LogoutLabel.Text = "Last Logout:";
			this.uxLast_LogoutLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxLast_LogoutLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLast_LogoutLabel);			
			//
			// uxLast_Logout
			//
			this.uxLast_Logout.Name = "uxLast_Logout";
			//this.uxTableLayoutPanel.Controls.Add(this.uxLast_Logout);
			this.uxLast_Logout.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxLast_Logout);
			//
			// uxIs_OnlineLabel
			//
			this.uxIs_OnlineLabel.Name = "uxIs_OnlineLabel";
			this.uxIs_OnlineLabel.Text = "Is Online:";
			this.uxIs_OnlineLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxIs_OnlineLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_OnlineLabel);			
			//
			// uxIs_Online
			//
			this.uxIs_Online.Name = "uxIs_Online";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_Online);
			this.uxIs_Online.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxIs_Online);
			//
			// uxIs_ActiveLabel
			//
			this.uxIs_ActiveLabel.Name = "uxIs_ActiveLabel";
			this.uxIs_ActiveLabel.Text = "Is Active:";
			this.uxIs_ActiveLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxIs_ActiveLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_ActiveLabel);			
			//
			// uxIs_Active
			//
			this.uxIs_Active.Name = "uxIs_Active";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_Active);
			this.uxIs_Active.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxIs_Active);
			//
			// uxIs_AdminLabel
			//
			this.uxIs_AdminLabel.Name = "uxIs_AdminLabel";
			this.uxIs_AdminLabel.Text = "Is Admin:";
			this.uxIs_AdminLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxIs_AdminLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_AdminLabel);			
			//
			// uxIs_Admin
			//
			this.uxIs_Admin.Name = "uxIs_Admin";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_Admin);
			this.uxIs_Admin.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxIs_Admin);
			//
			// uxUserType_IDLabel
			//
			this.uxUserType_IDLabel.Name = "uxUserType_IDLabel";
			this.uxUserType_IDLabel.Text = "User TypeID:";
			this.uxUserType_IDLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxUserType_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUserType_IDLabel);			
			//
			// uxUserType_ID
			//
			this.uxUserType_ID.Name = "uxUserType_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUserType_ID);
			this.uxUserType_ID.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxUserType_ID);
			//
			// uxFirst_NameLabel
			//
			this.uxFirst_NameLabel.Name = "uxFirst_NameLabel";
			this.uxFirst_NameLabel.Text = "First Name:";
			this.uxFirst_NameLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxFirst_NameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFirst_NameLabel);			
			//
			// uxFirst_Name
			//
			this.uxFirst_Name.Name = "uxFirst_Name";
			this.uxFirst_Name.Width = 250;
			this.uxFirst_Name.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxFirst_Name);
			this.uxFirst_Name.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxFirst_Name);
			//
			// uxLast_NameLabel
			//
			this.uxLast_NameLabel.Name = "uxLast_NameLabel";
			this.uxLast_NameLabel.Text = "Last Name:";
			this.uxLast_NameLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxLast_NameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLast_NameLabel);			
			//
			// uxLast_Name
			//
			this.uxLast_Name.Name = "uxLast_Name";
			this.uxLast_Name.Width = 250;
			this.uxLast_Name.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxLast_Name);
			this.uxLast_Name.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxLast_Name);
			//
			// uxEmailLabel
			//
			this.uxEmailLabel.Name = "uxEmailLabel";
			this.uxEmailLabel.Text = "Email:";
			this.uxEmailLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxEmailLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmailLabel);			
			//
			// uxEmail
			//
			this.uxEmail.Name = "uxEmail";
			this.uxEmail.Width = 250;
			this.uxEmail.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmail);
			this.uxEmail.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxEmail);
			//
			// uxCountryLabel
			//
			this.uxCountryLabel.Name = "uxCountryLabel";
			this.uxCountryLabel.Text = "Country:";
			this.uxCountryLabel.Location = new System.Drawing.Point(3, 312);
			this.Controls.Add(this.uxCountryLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountryLabel);			
			//
			// uxCountry
			//
			this.uxCountry.Name = "uxCountry";
			this.uxCountry.Width = 250;
			this.uxCountry.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountry);
			this.uxCountry.Location = new System.Drawing.Point(160, 312);
			this.Controls.Add(this.uxCountry);
			//
			// uxCityLabel
			//
			this.uxCityLabel.Name = "uxCityLabel";
			this.uxCityLabel.Text = "City:";
			this.uxCityLabel.Location = new System.Drawing.Point(3, 338);
			this.Controls.Add(this.uxCityLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCityLabel);			
			//
			// uxCity
			//
			this.uxCity.Name = "uxCity";
			this.uxCity.Width = 250;
			this.uxCity.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCity);
			this.uxCity.Location = new System.Drawing.Point(160, 338);
			this.Controls.Add(this.uxCity);
			//
			// uxAddressLabel
			//
			this.uxAddressLabel.Name = "uxAddressLabel";
			this.uxAddressLabel.Text = "Address:";
			this.uxAddressLabel.Location = new System.Drawing.Point(3, 364);
			this.Controls.Add(this.uxAddressLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLabel);			
			//
			// uxAddress
			//
			this.uxAddress.Name = "uxAddress";
			this.uxAddress.Width = 250;
			this.uxAddress.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddress);
			this.uxAddress.Location = new System.Drawing.Point(160, 364);
			this.Controls.Add(this.uxAddress);
			//
			// uxMobileLabel
			//
			this.uxMobileLabel.Name = "uxMobileLabel";
			this.uxMobileLabel.Text = "Mobile:";
			this.uxMobileLabel.Location = new System.Drawing.Point(3, 390);
			this.Controls.Add(this.uxMobileLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMobileLabel);			
			//
			// uxMobile
			//
			this.uxMobile.Name = "uxMobile";
			this.uxMobile.Width = 250;
			this.uxMobile.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxMobile);
			this.uxMobile.Location = new System.Drawing.Point(160, 390);
			this.Controls.Add(this.uxMobile);
			//
			// uxPhoneLabel
			//
			this.uxPhoneLabel.Name = "uxPhoneLabel";
			this.uxPhoneLabel.Text = "Phone:";
			this.uxPhoneLabel.Location = new System.Drawing.Point(3, 416);
			this.Controls.Add(this.uxPhoneLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhoneLabel);			
			//
			// uxPhone
			//
			this.uxPhone.Name = "uxPhone";
			this.uxPhone.Width = 250;
			this.uxPhone.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPhone);
			this.uxPhone.Location = new System.Drawing.Point(160, 416);
			this.Controls.Add(this.uxPhone);
			//
			// uxPostionLabel
			//
			this.uxPostionLabel.Name = "uxPostionLabel";
			this.uxPostionLabel.Text = "Postion:";
			this.uxPostionLabel.Location = new System.Drawing.Point(3, 442);
			this.Controls.Add(this.uxPostionLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPostionLabel);			
			//
			// uxPostion
			//
			this.uxPostion.Name = "uxPostion";
			this.uxPostion.Width = 250;
			this.uxPostion.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPostion);
			this.uxPostion.Location = new System.Drawing.Point(160, 442);
			this.Controls.Add(this.uxPostion);
			//
			// uxIs_DeletedLabel
			//
			this.uxIs_DeletedLabel.Name = "uxIs_DeletedLabel";
			this.uxIs_DeletedLabel.Text = "Is Deleted:";
			this.uxIs_DeletedLabel.Location = new System.Drawing.Point(3, 468);
			this.Controls.Add(this.uxIs_DeletedLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_DeletedLabel);			
			//
			// uxIs_Deleted
			//
			this.uxIs_Deleted.Name = "uxIs_Deleted";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_Deleted);
			this.uxIs_Deleted.Location = new System.Drawing.Point(160, 468);
			this.Controls.Add(this.uxIs_Deleted);
			//
			// uxCreatedOnLabel
			//
			this.uxCreatedOnLabel.Name = "uxCreatedOnLabel";
			this.uxCreatedOnLabel.Text = "Created On:";
			this.uxCreatedOnLabel.Location = new System.Drawing.Point(3, 494);
			this.Controls.Add(this.uxCreatedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedOnLabel);			
			//
			// uxCreatedOn
			//
			this.uxCreatedOn.Name = "uxCreatedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedOn);
			this.uxCreatedOn.Location = new System.Drawing.Point(160, 494);
			this.Controls.Add(this.uxCreatedOn);
			//
			// uxCreatedByLabel
			//
			this.uxCreatedByLabel.Name = "uxCreatedByLabel";
			this.uxCreatedByLabel.Text = "Created By:";
			this.uxCreatedByLabel.Location = new System.Drawing.Point(3, 520);
			this.Controls.Add(this.uxCreatedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedByLabel);			
			//
			// uxCreatedBy
			//
			this.uxCreatedBy.Name = "uxCreatedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedBy);
			this.uxCreatedBy.Location = new System.Drawing.Point(160, 520);
			this.Controls.Add(this.uxCreatedBy);
			//
			// uxUpdatedOnLabel
			//
			this.uxUpdatedOnLabel.Name = "uxUpdatedOnLabel";
			this.uxUpdatedOnLabel.Text = "Updated On:";
			this.uxUpdatedOnLabel.Location = new System.Drawing.Point(3, 546);
			this.Controls.Add(this.uxUpdatedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedOnLabel);			
			//
			// uxUpdatedOn
			//
			this.uxUpdatedOn.Name = "uxUpdatedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedOn);
			this.uxUpdatedOn.Location = new System.Drawing.Point(160, 546);
			this.Controls.Add(this.uxUpdatedOn);
			//
			// uxUpdatedByLabel
			//
			this.uxUpdatedByLabel.Name = "uxUpdatedByLabel";
			this.uxUpdatedByLabel.Text = "Updated By:";
			this.uxUpdatedByLabel.Location = new System.Drawing.Point(3, 572);
			this.Controls.Add(this.uxUpdatedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedByLabel);			
			//
			// uxUpdatedBy
			//
			this.uxUpdatedBy.Name = "uxUpdatedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedBy);
			this.uxUpdatedBy.Location = new System.Drawing.Point(160, 572);
			this.Controls.Add(this.uxUpdatedBy);
			//
			// uxDeletedOnLabel
			//
			this.uxDeletedOnLabel.Name = "uxDeletedOnLabel";
			this.uxDeletedOnLabel.Text = "Deleted On:";
			this.uxDeletedOnLabel.Location = new System.Drawing.Point(3, 598);
			this.Controls.Add(this.uxDeletedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedOnLabel);			
			//
			// uxDeletedOn
			//
			this.uxDeletedOn.Name = "uxDeletedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedOn);
			this.uxDeletedOn.Location = new System.Drawing.Point(160, 598);
			this.Controls.Add(this.uxDeletedOn);
			//
			// uxDeletedByLabel
			//
			this.uxDeletedByLabel.Name = "uxDeletedByLabel";
			this.uxDeletedByLabel.Text = "Deleted By:";
			this.uxDeletedByLabel.Location = new System.Drawing.Point(3, 624);
			this.Controls.Add(this.uxDeletedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedByLabel);			
			//
			// uxDeletedBy
			//
			this.uxDeletedBy.Name = "uxDeletedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedBy);
			this.uxDeletedBy.Location = new System.Drawing.Point(160, 624);
			this.Controls.Add(this.uxDeletedBy);
			//
			// uxUserType_ID
			//				
			this.uxUserType_ID.DisplayMember = "TypeName";	
			this.uxUserType_ID.ValueMember = "ID";	
			// 
			// UsersEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "UsersEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private BLL.TList<BLL.UserType> _UserType_IDList;
		
		/// <summary>
		/// The ComboBox associated with the UserType_ID property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public BLL.TList<BLL.UserType> UserType_IDList
		{
			get {return _UserType_IDList;}
			set 
			{
				this._UserType_IDList = value;
				this.uxUserType_ID.DataSource = null;
				this.uxUserType_ID.DataSource = value;
			}
		}
		
		private bool _allowNewItemInUserType_IDList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the UserType_ID property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInUserType_IDList
		{
			get { return _allowNewItemInUserType_IDList;}
			set
			{
				this._allowNewItemInUserType_IDList = value;
				this.uxUserType_ID.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
		
		#endregion
		
        #region Field visibility

        /// <summary>
        /// Indicates if the controls associated with the uxID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIDVisible
        {
            get { return this.uxID.Visible; }
            set
            {
                this.uxIDLabel.Visible = value;
                this.uxID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIDEnabled
        {
            get { return this.uxID.Enabled; }
            set
            {
                this.uxID.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUserName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUserNameVisible
        {
            get { return this.uxUserName.Visible; }
            set
            {
                this.uxUserNameLabel.Visible = value;
                this.uxUserName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUserName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUserNameEnabled
        {
            get { return this.uxUserName.Enabled; }
            set
            {
                this.uxUserName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPassword property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPasswordVisible
        {
            get { return this.uxPassword.Visible; }
            set
            {
                this.uxPasswordLabel.Visible = value;
                this.uxPassword.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPassword property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPasswordEnabled
        {
            get { return this.uxPassword.Enabled; }
            set
            {
                this.uxPassword.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLast_Login property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLast_LoginVisible
        {
            get { return this.uxLast_Login.Visible; }
            set
            {
                this.uxLast_LoginLabel.Visible = value;
                this.uxLast_Login.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLast_Login property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLast_LoginEnabled
        {
            get { return this.uxLast_Login.Enabled; }
            set
            {
                this.uxLast_Login.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLast_Logout property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLast_LogoutVisible
        {
            get { return this.uxLast_Logout.Visible; }
            set
            {
                this.uxLast_LogoutLabel.Visible = value;
                this.uxLast_Logout.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLast_Logout property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLast_LogoutEnabled
        {
            get { return this.uxLast_Logout.Enabled; }
            set
            {
                this.uxLast_Logout.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIs_Online property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIs_OnlineVisible
        {
            get { return this.uxIs_Online.Visible; }
            set
            {
                this.uxIs_OnlineLabel.Visible = value;
                this.uxIs_Online.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIs_Online property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIs_OnlineEnabled
        {
            get { return this.uxIs_Online.Enabled; }
            set
            {
                this.uxIs_Online.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIs_Active property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIs_ActiveVisible
        {
            get { return this.uxIs_Active.Visible; }
            set
            {
                this.uxIs_ActiveLabel.Visible = value;
                this.uxIs_Active.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIs_Active property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIs_ActiveEnabled
        {
            get { return this.uxIs_Active.Enabled; }
            set
            {
                this.uxIs_Active.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIs_Admin property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIs_AdminVisible
        {
            get { return this.uxIs_Admin.Visible; }
            set
            {
                this.uxIs_AdminLabel.Visible = value;
                this.uxIs_Admin.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIs_Admin property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIs_AdminEnabled
        {
            get { return this.uxIs_Admin.Enabled; }
            set
            {
                this.uxIs_Admin.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUserType_ID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUserType_IDVisible
        {
            get { return this.uxUserType_ID.Visible; }
            set
            {
                this.uxUserType_IDLabel.Visible = value;
                this.uxUserType_ID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUserType_ID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUserType_IDEnabled
        {
            get { return this.uxUserType_ID.Enabled; }
            set
            {
                this.uxUserType_ID.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxFirst_Name property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFirst_NameVisible
        {
            get { return this.uxFirst_Name.Visible; }
            set
            {
                this.uxFirst_NameLabel.Visible = value;
                this.uxFirst_Name.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFirst_Name property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFirst_NameEnabled
        {
            get { return this.uxFirst_Name.Enabled; }
            set
            {
                this.uxFirst_Name.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLast_Name property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLast_NameVisible
        {
            get { return this.uxLast_Name.Visible; }
            set
            {
                this.uxLast_NameLabel.Visible = value;
                this.uxLast_Name.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLast_Name property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLast_NameEnabled
        {
            get { return this.uxLast_Name.Enabled; }
            set
            {
                this.uxLast_Name.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEmail property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEmailVisible
        {
            get { return this.uxEmail.Visible; }
            set
            {
                this.uxEmailLabel.Visible = value;
                this.uxEmail.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEmail property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEmailEnabled
        {
            get { return this.uxEmail.Enabled; }
            set
            {
                this.uxEmail.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCountry property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCountryVisible
        {
            get { return this.uxCountry.Visible; }
            set
            {
                this.uxCountryLabel.Visible = value;
                this.uxCountry.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCountry property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCountryEnabled
        {
            get { return this.uxCountry.Enabled; }
            set
            {
                this.uxCountry.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCity property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCityVisible
        {
            get { return this.uxCity.Visible; }
            set
            {
                this.uxCityLabel.Visible = value;
                this.uxCity.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCity property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCityEnabled
        {
            get { return this.uxCity.Enabled; }
            set
            {
                this.uxCity.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxAddress property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAddressVisible
        {
            get { return this.uxAddress.Visible; }
            set
            {
                this.uxAddressLabel.Visible = value;
                this.uxAddress.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAddress property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAddressEnabled
        {
            get { return this.uxAddress.Enabled; }
            set
            {
                this.uxAddress.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxMobile property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxMobileVisible
        {
            get { return this.uxMobile.Visible; }
            set
            {
                this.uxMobileLabel.Visible = value;
                this.uxMobile.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxMobile property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxMobileEnabled
        {
            get { return this.uxMobile.Enabled; }
            set
            {
                this.uxMobile.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPhone property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPhoneVisible
        {
            get { return this.uxPhone.Visible; }
            set
            {
                this.uxPhoneLabel.Visible = value;
                this.uxPhone.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPhone property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPhoneEnabled
        {
            get { return this.uxPhone.Enabled; }
            set
            {
                this.uxPhone.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPostion property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPostionVisible
        {
            get { return this.uxPostion.Visible; }
            set
            {
                this.uxPostionLabel.Visible = value;
                this.uxPostion.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPostion property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPostionEnabled
        {
            get { return this.uxPostion.Enabled; }
            set
            {
                this.uxPostion.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIs_Deleted property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIs_DeletedVisible
        {
            get { return this.uxIs_Deleted.Visible; }
            set
            {
                this.uxIs_DeletedLabel.Visible = value;
                this.uxIs_Deleted.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIs_Deleted property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIs_DeletedEnabled
        {
            get { return this.uxIs_Deleted.Enabled; }
            set
            {
                this.uxIs_Deleted.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCreatedOn property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCreatedOnVisible
        {
            get { return this.uxCreatedOn.Visible; }
            set
            {
                this.uxCreatedOnLabel.Visible = value;
                this.uxCreatedOn.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCreatedOn property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCreatedOnEnabled
        {
            get { return this.uxCreatedOn.Enabled; }
            set
            {
                this.uxCreatedOn.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCreatedBy property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCreatedByVisible
        {
            get { return this.uxCreatedBy.Visible; }
            set
            {
                this.uxCreatedByLabel.Visible = value;
                this.uxCreatedBy.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCreatedBy property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCreatedByEnabled
        {
            get { return this.uxCreatedBy.Enabled; }
            set
            {
                this.uxCreatedBy.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedOn property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUpdatedOnVisible
        {
            get { return this.uxUpdatedOn.Visible; }
            set
            {
                this.uxUpdatedOnLabel.Visible = value;
                this.uxUpdatedOn.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedOn property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUpdatedOnEnabled
        {
            get { return this.uxUpdatedOn.Enabled; }
            set
            {
                this.uxUpdatedOn.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedBy property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUpdatedByVisible
        {
            get { return this.uxUpdatedBy.Visible; }
            set
            {
                this.uxUpdatedByLabel.Visible = value;
                this.uxUpdatedBy.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedBy property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUpdatedByEnabled
        {
            get { return this.uxUpdatedBy.Enabled; }
            set
            {
                this.uxUpdatedBy.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDeletedOn property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDeletedOnVisible
        {
            get { return this.uxDeletedOn.Visible; }
            set
            {
                this.uxDeletedOnLabel.Visible = value;
                this.uxDeletedOn.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDeletedOn property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDeletedOnEnabled
        {
            get { return this.uxDeletedOn.Enabled; }
            set
            {
                this.uxDeletedOn.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDeletedBy property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDeletedByVisible
        {
            get { return this.uxDeletedBy.Visible; }
            set
            {
                this.uxDeletedByLabel.Visible = value;
                this.uxDeletedBy.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDeletedBy property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDeletedByEnabled
        {
            get { return this.uxDeletedBy.Enabled; }
            set
            {
                this.uxDeletedBy.Enabled = value;
            }
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
	}
}
