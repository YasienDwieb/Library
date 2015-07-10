
namespace Library.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="BLL.Introducer"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class IntroducerEditControlBase : System.Windows.Forms.UserControl
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
		/// DataTimePicker for the BirthDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxBirthDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the BirthDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxBirthDateLabel;
		
		/// <summary>
		/// TextBox for the Position property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPosition;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Position property.
		/// </summary>
		protected System.Windows.Forms.Label uxPositionLabel;
		
		/// <summary>
		/// TextBox for the IsAlive property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxIsAlive;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the IsAlive property.
		/// </summary>
		protected System.Windows.Forms.Label uxIsAliveLabel;
		
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
		/// TextBox for the Book_ID property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxBook_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Book_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxBook_IDLabel;
		
		/// <summary>
		/// CheckBox for the Gender property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxGender;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Gender property.
		/// </summary>
		protected System.Windows.Forms.Label uxGenderLabel;
		#endregion
		
		#region Main entity
		private BLL.Introducer _Introducer;
		/// <summary>
		/// Gets or sets the <see cref="BLL.Introducer"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="BLL.Introducer"/> instance.</value>
		public BLL.Introducer Introducer
		{
			get {return this._Introducer;}
			set
			{
				this._Introducer = value;
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
			this.uxCountry.DataBindings.Clear();
			this.uxCountry.DataBindings.Add("Text", this.uxBindingSource, "Country", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCity.DataBindings.Clear();
			this.uxCity.DataBindings.Add("Text", this.uxBindingSource, "City", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBirthDate.DataBindings.Clear();
			this.uxBirthDate.DataBindings.Add("Value", this.uxBindingSource, "BirthDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPosition.DataBindings.Clear();
			this.uxPosition.DataBindings.Add("Text", this.uxBindingSource, "Position", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIsAlive.DataBindings.Clear();
			this.uxIsAlive.DataBindings.Add("Text", this.uxBindingSource, "IsAlive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxMobile.DataBindings.Clear();
			this.uxMobile.DataBindings.Add("Text", this.uxBindingSource, "Mobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEmail.DataBindings.Clear();
			this.uxEmail.DataBindings.Add("Text", this.uxBindingSource, "Email", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxWebsite.DataBindings.Clear();
			this.uxWebsite.DataBindings.Add("Text", this.uxBindingSource, "Website", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBook_ID.DataBindings.Clear();
			this.uxBook_ID.DataBindings.Add("Text", this.uxBindingSource, "Book_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxGender.DataBindings.Clear();
			this.uxGender.DataBindings.Add("Checked", this.uxBindingSource, "Gender", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="IntroducerEditControlBase"/> class.
		/// </summary>
		public IntroducerEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Introducer != null) _Introducer.Validate();
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
			this.uxCountry = new System.Windows.Forms.TextBox();
			uxCountryLabel = new System.Windows.Forms.Label();
			this.uxCity = new System.Windows.Forms.TextBox();
			uxCityLabel = new System.Windows.Forms.Label();
			this.uxBirthDate = new System.Windows.Forms.DateTimePicker();
			uxBirthDateLabel = new System.Windows.Forms.Label();
			this.uxPosition = new System.Windows.Forms.TextBox();
			uxPositionLabel = new System.Windows.Forms.Label();
			this.uxIsAlive = new System.Windows.Forms.TextBox();
			uxIsAliveLabel = new System.Windows.Forms.Label();
			this.uxMobile = new System.Windows.Forms.TextBox();
			uxMobileLabel = new System.Windows.Forms.Label();
			this.uxEmail = new System.Windows.Forms.TextBox();
			uxEmailLabel = new System.Windows.Forms.Label();
			this.uxWebsite = new System.Windows.Forms.TextBox();
			uxWebsiteLabel = new System.Windows.Forms.Label();
			this.uxBook_ID = new System.Windows.Forms.TextBox();
			uxBook_IDLabel = new System.Windows.Forms.Label();
			this.uxGender = new System.Windows.Forms.CheckBox();
			uxGenderLabel = new System.Windows.Forms.Label();
			
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
			// uxCountryLabel
			//
			this.uxCountryLabel.Name = "uxCountryLabel";
			this.uxCountryLabel.Text = "Country:";
			this.uxCountryLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxCountryLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountryLabel);			
			//
			// uxCountry
			//
			this.uxCountry.Name = "uxCountry";
			this.uxCountry.Width = 250;
			this.uxCountry.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCountry);
			this.uxCountry.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxCountry);
			//
			// uxCityLabel
			//
			this.uxCityLabel.Name = "uxCityLabel";
			this.uxCityLabel.Text = "City:";
			this.uxCityLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxCityLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCityLabel);			
			//
			// uxCity
			//
			this.uxCity.Name = "uxCity";
			this.uxCity.Width = 250;
			this.uxCity.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCity);
			this.uxCity.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxCity);
			//
			// uxBirthDateLabel
			//
			this.uxBirthDateLabel.Name = "uxBirthDateLabel";
			this.uxBirthDateLabel.Text = "Birth Date:";
			this.uxBirthDateLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxBirthDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBirthDateLabel);			
			//
			// uxBirthDate
			//
			this.uxBirthDate.Name = "uxBirthDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBirthDate);
			this.uxBirthDate.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxBirthDate);
			//
			// uxPositionLabel
			//
			this.uxPositionLabel.Name = "uxPositionLabel";
			this.uxPositionLabel.Text = "Position:";
			this.uxPositionLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxPositionLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPositionLabel);			
			//
			// uxPosition
			//
			this.uxPosition.Name = "uxPosition";
			this.uxPosition.Width = 250;
			this.uxPosition.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPosition);
			this.uxPosition.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxPosition);
			//
			// uxIsAliveLabel
			//
			this.uxIsAliveLabel.Name = "uxIsAliveLabel";
			this.uxIsAliveLabel.Text = "Is Alive:";
			this.uxIsAliveLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxIsAliveLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsAliveLabel);			
			//
			// uxIsAlive
			//
			this.uxIsAlive.Name = "uxIsAlive";
			this.uxIsAlive.Width = 250;
			this.uxIsAlive.MaxLength = 10;
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsAlive);
			this.uxIsAlive.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxIsAlive);
			//
			// uxMobileLabel
			//
			this.uxMobileLabel.Name = "uxMobileLabel";
			this.uxMobileLabel.Text = "Mobile:";
			this.uxMobileLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxMobileLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxMobileLabel);			
			//
			// uxMobile
			//
			this.uxMobile.Name = "uxMobile";
			this.uxMobile.Width = 250;
			this.uxMobile.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxMobile);
			this.uxMobile.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxMobile);
			//
			// uxEmailLabel
			//
			this.uxEmailLabel.Name = "uxEmailLabel";
			this.uxEmailLabel.Text = "Email:";
			this.uxEmailLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxEmailLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmailLabel);			
			//
			// uxEmail
			//
			this.uxEmail.Name = "uxEmail";
			this.uxEmail.Width = 250;
			this.uxEmail.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmail);
			this.uxEmail.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxEmail);
			//
			// uxWebsiteLabel
			//
			this.uxWebsiteLabel.Name = "uxWebsiteLabel";
			this.uxWebsiteLabel.Text = "Website:";
			this.uxWebsiteLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxWebsiteLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxWebsiteLabel);			
			//
			// uxWebsite
			//
			this.uxWebsite.Name = "uxWebsite";
			this.uxWebsite.Width = 250;
			this.uxWebsite.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxWebsite);
			this.uxWebsite.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxWebsite);
			//
			// uxBook_IDLabel
			//
			this.uxBook_IDLabel.Name = "uxBook_IDLabel";
			this.uxBook_IDLabel.Text = "BookID:";
			this.uxBook_IDLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxBook_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBook_IDLabel);			
			//
			// uxBook_ID
			//
			this.uxBook_ID.Name = "uxBook_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBook_ID);
			this.uxBook_ID.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxBook_ID);
			//
			// uxGenderLabel
			//
			this.uxGenderLabel.Name = "uxGenderLabel";
			this.uxGenderLabel.Text = "Gender:";
			this.uxGenderLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxGenderLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxGenderLabel);			
			//
			// uxGender
			//
			this.uxGender.Name = "uxGender";
			//this.uxTableLayoutPanel.Controls.Add(this.uxGender);
			this.uxGender.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxGender);
			// 
			// IntroducerEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "IntroducerEditControlBase";
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
        /// Indicates if the controls associated with the uxBirthDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBirthDateVisible
        {
            get { return this.uxBirthDate.Visible; }
            set
            {
                this.uxBirthDateLabel.Visible = value;
                this.uxBirthDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBirthDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBirthDateEnabled
        {
            get { return this.uxBirthDate.Enabled; }
            set
            {
                this.uxBirthDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPosition property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPositionVisible
        {
            get { return this.uxPosition.Visible; }
            set
            {
                this.uxPositionLabel.Visible = value;
                this.uxPosition.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPosition property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPositionEnabled
        {
            get { return this.uxPosition.Enabled; }
            set
            {
                this.uxPosition.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIsAlive property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIsAliveVisible
        {
            get { return this.uxIsAlive.Visible; }
            set
            {
                this.uxIsAliveLabel.Visible = value;
                this.uxIsAlive.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIsAlive property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIsAliveEnabled
        {
            get { return this.uxIsAlive.Enabled; }
            set
            {
                this.uxIsAlive.Enabled = value;
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
        /// Indicates if the controls associated with the uxBook_ID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBook_IDVisible
        {
            get { return this.uxBook_ID.Visible; }
            set
            {
                this.uxBook_IDLabel.Visible = value;
                this.uxBook_ID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBook_ID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBook_IDEnabled
        {
            get { return this.uxBook_ID.Enabled; }
            set
            {
                this.uxBook_ID.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxGender property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxGenderVisible
        {
            get { return this.uxGender.Visible; }
            set
            {
                this.uxGenderLabel.Visible = value;
                this.uxGender.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxGender property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxGenderEnabled
        {
            get { return this.uxGender.Enabled; }
            set
            {
                this.uxGender.Enabled = value;
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
