
namespace Library.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="BLL.Course"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CourseEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the Course_Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCourse_Name;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Course_Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxCourse_NameLabel;
		
		/// <summary>
		/// TextBox for the Course_Scope property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCourse_Scope;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Course_Scope property.
		/// </summary>
		protected System.Windows.Forms.Label uxCourse_ScopeLabel;
		
		/// <summary>
		/// TextBox for the Duration property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDuration;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Duration property.
		/// </summary>
		protected System.Windows.Forms.Label uxDurationLabel;
		
		/// <summary>
		/// TextBox for the DurationType_ID property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDurationType_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DurationType_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxDurationType_IDLabel;
		
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
		private BLL.Course _Course;
		/// <summary>
		/// Gets or sets the <see cref="BLL.Course"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="BLL.Course"/> instance.</value>
		public BLL.Course Course
		{
			get {return this._Course;}
			set
			{
				this._Course = value;
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
			this.uxCourse_Name.DataBindings.Clear();
			this.uxCourse_Name.DataBindings.Add("Text", this.uxBindingSource, "Course_Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCourse_Scope.DataBindings.Clear();
			this.uxCourse_Scope.DataBindings.Add("Text", this.uxBindingSource, "Course_Scope", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDuration.DataBindings.Clear();
			this.uxDuration.DataBindings.Add("Text", this.uxBindingSource, "Duration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDurationType_ID.DataBindings.Clear();
			this.uxDurationType_ID.DataBindings.Add("Text", this.uxBindingSource, "DurationType_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
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
		/// Initializes a new instance of the <see cref="CourseEditControlBase"/> class.
		/// </summary>
		public CourseEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Course != null) _Course.Validate();
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
			this.uxCourse_Name = new System.Windows.Forms.TextBox();
			uxCourse_NameLabel = new System.Windows.Forms.Label();
			this.uxCourse_Scope = new System.Windows.Forms.TextBox();
			uxCourse_ScopeLabel = new System.Windows.Forms.Label();
			this.uxDuration = new System.Windows.Forms.TextBox();
			uxDurationLabel = new System.Windows.Forms.Label();
			this.uxDurationType_ID = new System.Windows.Forms.TextBox();
			uxDurationType_IDLabel = new System.Windows.Forms.Label();
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
			// uxCourse_NameLabel
			//
			this.uxCourse_NameLabel.Name = "uxCourse_NameLabel";
			this.uxCourse_NameLabel.Text = "Course Name:";
			this.uxCourse_NameLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxCourse_NameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCourse_NameLabel);			
			//
			// uxCourse_Name
			//
			this.uxCourse_Name.Name = "uxCourse_Name";
			this.uxCourse_Name.Width = 250;
			this.uxCourse_Name.MaxLength = 200;
			//this.uxTableLayoutPanel.Controls.Add(this.uxCourse_Name);
			this.uxCourse_Name.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxCourse_Name);
			//
			// uxCourse_ScopeLabel
			//
			this.uxCourse_ScopeLabel.Name = "uxCourse_ScopeLabel";
			this.uxCourse_ScopeLabel.Text = "Course Scope:";
			this.uxCourse_ScopeLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxCourse_ScopeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCourse_ScopeLabel);			
			//
			// uxCourse_Scope
			//
			this.uxCourse_Scope.Name = "uxCourse_Scope";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCourse_Scope);
			this.uxCourse_Scope.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxCourse_Scope);
			//
			// uxDurationLabel
			//
			this.uxDurationLabel.Name = "uxDurationLabel";
			this.uxDurationLabel.Text = "Duration:";
			this.uxDurationLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxDurationLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDurationLabel);			
			//
			// uxDuration
			//
			this.uxDuration.Name = "uxDuration";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDuration);
			this.uxDuration.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxDuration);
			//
			// uxDurationType_IDLabel
			//
			this.uxDurationType_IDLabel.Name = "uxDurationType_IDLabel";
			this.uxDurationType_IDLabel.Text = "Duration TypeID:";
			this.uxDurationType_IDLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxDurationType_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDurationType_IDLabel);			
			//
			// uxDurationType_ID
			//
			this.uxDurationType_ID.Name = "uxDurationType_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDurationType_ID);
			this.uxDurationType_ID.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxDurationType_ID);
			//
			// uxIs_DeletedLabel
			//
			this.uxIs_DeletedLabel.Name = "uxIs_DeletedLabel";
			this.uxIs_DeletedLabel.Text = "Is Deleted:";
			this.uxIs_DeletedLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxIs_DeletedLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_DeletedLabel);			
			//
			// uxIs_Deleted
			//
			this.uxIs_Deleted.Name = "uxIs_Deleted";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIs_Deleted);
			this.uxIs_Deleted.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxIs_Deleted);
			//
			// uxCreatedOnLabel
			//
			this.uxCreatedOnLabel.Name = "uxCreatedOnLabel";
			this.uxCreatedOnLabel.Text = "Created On:";
			this.uxCreatedOnLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxCreatedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedOnLabel);			
			//
			// uxCreatedOn
			//
			this.uxCreatedOn.Name = "uxCreatedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedOn);
			this.uxCreatedOn.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxCreatedOn);
			//
			// uxCreatedByLabel
			//
			this.uxCreatedByLabel.Name = "uxCreatedByLabel";
			this.uxCreatedByLabel.Text = "Created By:";
			this.uxCreatedByLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxCreatedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedByLabel);			
			//
			// uxCreatedBy
			//
			this.uxCreatedBy.Name = "uxCreatedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedBy);
			this.uxCreatedBy.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxCreatedBy);
			//
			// uxUpdatedOnLabel
			//
			this.uxUpdatedOnLabel.Name = "uxUpdatedOnLabel";
			this.uxUpdatedOnLabel.Text = "Updated On:";
			this.uxUpdatedOnLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxUpdatedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedOnLabel);			
			//
			// uxUpdatedOn
			//
			this.uxUpdatedOn.Name = "uxUpdatedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedOn);
			this.uxUpdatedOn.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxUpdatedOn);
			//
			// uxUpdatedByLabel
			//
			this.uxUpdatedByLabel.Name = "uxUpdatedByLabel";
			this.uxUpdatedByLabel.Text = "Updated By:";
			this.uxUpdatedByLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxUpdatedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedByLabel);			
			//
			// uxUpdatedBy
			//
			this.uxUpdatedBy.Name = "uxUpdatedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedBy);
			this.uxUpdatedBy.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxUpdatedBy);
			//
			// uxDeletedOnLabel
			//
			this.uxDeletedOnLabel.Name = "uxDeletedOnLabel";
			this.uxDeletedOnLabel.Text = "Deleted On:";
			this.uxDeletedOnLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxDeletedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedOnLabel);			
			//
			// uxDeletedOn
			//
			this.uxDeletedOn.Name = "uxDeletedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedOn);
			this.uxDeletedOn.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxDeletedOn);
			//
			// uxDeletedByLabel
			//
			this.uxDeletedByLabel.Name = "uxDeletedByLabel";
			this.uxDeletedByLabel.Text = "Deleted By:";
			this.uxDeletedByLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxDeletedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedByLabel);			
			//
			// uxDeletedBy
			//
			this.uxDeletedBy.Name = "uxDeletedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedBy);
			this.uxDeletedBy.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxDeletedBy);
			// 
			// CourseEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "CourseEditControlBase";
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
        /// Indicates if the controls associated with the uxCourse_Name property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCourse_NameVisible
        {
            get { return this.uxCourse_Name.Visible; }
            set
            {
                this.uxCourse_NameLabel.Visible = value;
                this.uxCourse_Name.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCourse_Name property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCourse_NameEnabled
        {
            get { return this.uxCourse_Name.Enabled; }
            set
            {
                this.uxCourse_Name.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCourse_Scope property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCourse_ScopeVisible
        {
            get { return this.uxCourse_Scope.Visible; }
            set
            {
                this.uxCourse_ScopeLabel.Visible = value;
                this.uxCourse_Scope.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCourse_Scope property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCourse_ScopeEnabled
        {
            get { return this.uxCourse_Scope.Enabled; }
            set
            {
                this.uxCourse_Scope.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDuration property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDurationVisible
        {
            get { return this.uxDuration.Visible; }
            set
            {
                this.uxDurationLabel.Visible = value;
                this.uxDuration.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDuration property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDurationEnabled
        {
            get { return this.uxDuration.Enabled; }
            set
            {
                this.uxDuration.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDurationType_ID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDurationType_IDVisible
        {
            get { return this.uxDurationType_ID.Visible; }
            set
            {
                this.uxDurationType_IDLabel.Visible = value;
                this.uxDurationType_ID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDurationType_ID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDurationType_IDEnabled
        {
            get { return this.uxDurationType_ID.Enabled; }
            set
            {
                this.uxDurationType_ID.Enabled = value;
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
