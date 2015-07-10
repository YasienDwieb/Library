
namespace Library.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="BLL.Publisher"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class PublisherEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// TextBox for the Mobile property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxMobile;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Mobile property.
		/// </summary>
		protected System.Windows.Forms.Label uxMobileLabel;
		
		/// <summary>
		/// TextBox for the Email property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxEmail;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Email property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmailLabel;
		
		/// <summary>
		/// TextBox for the Website property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxWebsite;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Website property.
		/// </summary>
		protected System.Windows.Forms.Label uxWebsiteLabel;
		
		/// <summary>
		/// DataTimePicker for the FounedOn property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxFounedOn;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the FounedOn property.
		/// </summary>
		protected System.Windows.Forms.Label uxFounedOnLabel;
		
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
		#endregion
		
		#region Main entity
		private BLL.Publisher _Publisher;
		/// <summary>
		/// Gets or sets the <see cref="BLL.Publisher"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="BLL.Publisher"/> instance.</value>
		public BLL.Publisher Publisher
		{
			get {return this._Publisher;}
			set
			{
				this._Publisher = value;
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
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMobile.DataBindings.Clear();
			this.uxMobile.DataBindings.Add("Text", this.uxBindingSource, "Mobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEmail.DataBindings.Clear();
			this.uxEmail.DataBindings.Add("Text", this.uxBindingSource, "Email", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxWebsite.DataBindings.Clear();
			this.uxWebsite.DataBindings.Add("Text", this.uxBindingSource, "Website", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxFounedOn.DataBindings.Clear();
			this.uxFounedOn.DataBindings.Add("Value", this.uxBindingSource, "FounedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCountry.DataBindings.Clear();
			this.uxCountry.DataBindings.Add("Text", this.uxBindingSource, "Country", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCity.DataBindings.Clear();
			this.uxCity.DataBindings.Add("Text", this.uxBindingSource, "City", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAddress.DataBindings.Clear();
			this.uxAddress.DataBindings.Add("Text", this.uxBindingSource, "Address", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="PublisherEditControlBase"/> class.
		/// </summary>
		public PublisherEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Publisher != null) _Publisher.Validate();
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
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxMobile = new System.Windows.Forms.TextBox();
			uxMobileLabel = new System.Windows.Forms.Label();
			this.uxEmail = new System.Windows.Forms.TextBox();
			uxEmailLabel = new System.Windows.Forms.Label();
			this.uxWebsite = new System.Windows.Forms.TextBox();
			uxWebsiteLabel = new System.Windows.Forms.Label();
			this.uxFounedOn = new System.Windows.Forms.DateTimePicker();
			uxFounedOnLabel = new System.Windows.Forms.Label();
			this.uxCountry = new System.Windows.Forms.TextBox();
			uxCountryLabel = new System.Windows.Forms.Label();
			this.uxCity = new System.Windows.Forms.TextBox();
			uxCityLabel = new System.Windows.Forms.Label();
			this.uxAddress = new System.Windows.Forms.TextBox();
			uxAddressLabel = new System.Windows.Forms.Label();
			
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
			// uxNameLabel
			//
			this.uxNameLabel.Name = "uxNameLabel";
			this.uxNameLabel.Text = "Name:";
			this.uxNameLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameLabel);			
			//
			// uxName
			//
			this.uxName.Name = "uxName";
			this.uxName.Width = 250;
			this.uxName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxName);
			this.uxName.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxName);
			//
			// uxMobileLabel
			//
			this.uxMobileLabel.Name = "uxMobileLabel";
			this.uxMobileLabel.Text = "Mobile:";
			this.uxMobileLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxMobileLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMobileLabel);			
			//
			// uxMobile
			//
			this.uxMobile.Name = "uxMobile";
			this.uxMobile.Width = 250;
			this.uxMobile.MaxLength = 14;
			//this.uxTableLayoutPanel.Controls.Add(this.uxMobile);
			this.uxMobile.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxMobile);
			//
			// uxEmailLabel
			//
			this.uxEmailLabel.Name = "uxEmailLabel";
			this.uxEmailLabel.Text = "Email:";
			this.uxEmailLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxEmailLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmailLabel);			
			//
			// uxEmail
			//
			this.uxEmail.Name = "uxEmail";
			this.uxEmail.Width = 250;
			this.uxEmail.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmail);
			this.uxEmail.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxEmail);
			//
			// uxWebsiteLabel
			//
			this.uxWebsiteLabel.Name = "uxWebsiteLabel";
			this.uxWebsiteLabel.Text = "Website:";
			this.uxWebsiteLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxWebsiteLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxWebsiteLabel);			
			//
			// uxWebsite
			//
			this.uxWebsite.Name = "uxWebsite";
			this.uxWebsite.Width = 250;
			this.uxWebsite.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxWebsite);
			this.uxWebsite.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxWebsite);
			//
			// uxFounedOnLabel
			//
			this.uxFounedOnLabel.Name = "uxFounedOnLabel";
			this.uxFounedOnLabel.Text = "Founed On:";
			this.uxFounedOnLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxFounedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFounedOnLabel);			
			//
			// uxFounedOn
			//
			this.uxFounedOn.Name = "uxFounedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxFounedOn);
			this.uxFounedOn.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxFounedOn);
			//
			// uxCountryLabel
			//
			this.uxCountryLabel.Name = "uxCountryLabel";
			this.uxCountryLabel.Text = "Country:";
			this.uxCountryLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxCountryLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountryLabel);			
			//
			// uxCountry
			//
			this.uxCountry.Name = "uxCountry";
			this.uxCountry.Width = 250;
			this.uxCountry.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountry);
			this.uxCountry.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxCountry);
			//
			// uxCityLabel
			//
			this.uxCityLabel.Name = "uxCityLabel";
			this.uxCityLabel.Text = "City:";
			this.uxCityLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxCityLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCityLabel);			
			//
			// uxCity
			//
			this.uxCity.Name = "uxCity";
			this.uxCity.Width = 250;
			this.uxCity.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCity);
			this.uxCity.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxCity);
			//
			// uxAddressLabel
			//
			this.uxAddressLabel.Name = "uxAddressLabel";
			this.uxAddressLabel.Text = "Address:";
			this.uxAddressLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxAddressLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddressLabel);			
			//
			// uxAddress
			//
			this.uxAddress.Name = "uxAddress";
			this.uxAddress.Width = 250;
			this.uxAddress.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxAddress);
			this.uxAddress.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxAddress);
			// 
			// PublisherEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "PublisherEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
		
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
        /// Indicates if the controls associated with the uxName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxNameVisible
        {
            get { return this.uxName.Visible; }
            set
            {
                this.uxNameLabel.Visible = value;
                this.uxName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxNameEnabled
        {
            get { return this.uxName.Enabled; }
            set
            {
                this.uxName.Enabled = value;
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
        /// Indicates if the controls associated with the uxWebsite property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxWebsiteVisible
        {
            get { return this.uxWebsite.Visible; }
            set
            {
                this.uxWebsiteLabel.Visible = value;
                this.uxWebsite.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxWebsite property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxWebsiteEnabled
        {
            get { return this.uxWebsite.Enabled; }
            set
            {
                this.uxWebsite.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxFounedOn property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFounedOnVisible
        {
            get { return this.uxFounedOn.Visible; }
            set
            {
                this.uxFounedOnLabel.Visible = value;
                this.uxFounedOn.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFounedOn property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFounedOnEnabled
        {
            get { return this.uxFounedOn.Enabled; }
            set
            {
                this.uxFounedOn.Enabled = value;
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
