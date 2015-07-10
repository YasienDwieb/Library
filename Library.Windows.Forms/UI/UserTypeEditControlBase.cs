
namespace Library.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="BLL.UserType"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class UserTypeEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the TypeName property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxTypeName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the TypeName property.
		/// </summary>
		protected System.Windows.Forms.Label uxTypeNameLabel;
		#endregion
		
		#region Main entity
		private BLL.UserType _UserType;
		/// <summary>
		/// Gets or sets the <see cref="BLL.UserType"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="BLL.UserType"/> instance.</value>
		public BLL.UserType UserType
		{
			get {return this._UserType;}
			set
			{
				this._UserType = value;
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
			this.uxTypeName.DataBindings.Clear();
			this.uxTypeName.DataBindings.Add("Text", this.uxBindingSource, "TypeName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UserTypeEditControlBase"/> class.
		/// </summary>
		public UserTypeEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_UserType != null) _UserType.Validate();
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
			this.uxTypeName = new System.Windows.Forms.TextBox();
			uxTypeNameLabel = new System.Windows.Forms.Label();
			
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
			// uxTypeNameLabel
			//
			this.uxTypeNameLabel.Name = "uxTypeNameLabel";
			this.uxTypeNameLabel.Text = "Type Name:";
			this.uxTypeNameLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxTypeNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxTypeNameLabel);			
			//
			// uxTypeName
			//
			this.uxTypeName.Name = "uxTypeName";
			this.uxTypeName.Width = 250;
			this.uxTypeName.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxTypeName);
			this.uxTypeName.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxTypeName);
			// 
			// UserTypeEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "UserTypeEditControlBase";
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
        /// Indicates if the controls associated with the uxTypeName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxTypeNameVisible
        {
            get { return this.uxTypeName.Visible; }
            set
            {
                this.uxTypeNameLabel.Visible = value;
                this.uxTypeName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxTypeName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxTypeNameEnabled
        {
            get { return this.uxTypeName.Enabled; }
            set
            {
                this.uxTypeName.Enabled = value;
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
