
namespace Library.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="BLL.BookImage"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class BookImageEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the Format property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxFormat;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Format property.
		/// </summary>
		protected System.Windows.Forms.Label uxFormatLabel;
		
		/// <summary>
		/// TextBox for the Size property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSize;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Size property.
		/// </summary>
		protected System.Windows.Forms.Label uxSizeLabel;
		
		/// <summary>
		/// TextBox for the Link property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxLink;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Link property.
		/// </summary>
		protected System.Windows.Forms.Label uxLinkLabel;
		
		/// <summary>
		/// TextBox for the IsAvailable property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxIsAvailable;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the IsAvailable property.
		/// </summary>
		protected System.Windows.Forms.Label uxIsAvailableLabel;
		#endregion
		
		#region Main entity
		private BLL.BookImage _BookImage;
		/// <summary>
		/// Gets or sets the <see cref="BLL.BookImage"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="BLL.BookImage"/> instance.</value>
		public BLL.BookImage BookImage
		{
			get {return this._BookImage;}
			set
			{
				this._BookImage = value;
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
			this.uxFormat.DataBindings.Clear();
			this.uxFormat.DataBindings.Add("Text", this.uxBindingSource, "Format", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSize.DataBindings.Clear();
			this.uxSize.DataBindings.Add("Text", this.uxBindingSource, "Size", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxLink.DataBindings.Clear();
			this.uxLink.DataBindings.Add("Text", this.uxBindingSource, "Link", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIsAvailable.DataBindings.Clear();
			this.uxIsAvailable.DataBindings.Add("Text", this.uxBindingSource, "IsAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="BookImageEditControlBase"/> class.
		/// </summary>
		public BookImageEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_BookImage != null) _BookImage.Validate();
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
			this.uxFormat = new System.Windows.Forms.TextBox();
			uxFormatLabel = new System.Windows.Forms.Label();
			this.uxSize = new System.Windows.Forms.TextBox();
			uxSizeLabel = new System.Windows.Forms.Label();
			this.uxLink = new System.Windows.Forms.TextBox();
			uxLinkLabel = new System.Windows.Forms.Label();
			this.uxIsAvailable = new System.Windows.Forms.TextBox();
			uxIsAvailableLabel = new System.Windows.Forms.Label();
			
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
			// uxFormatLabel
			//
			this.uxFormatLabel.Name = "uxFormatLabel";
			this.uxFormatLabel.Text = "Format:";
			this.uxFormatLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxFormatLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxFormatLabel);			
			//
			// uxFormat
			//
			this.uxFormat.Name = "uxFormat";
			this.uxFormat.Width = 250;
			this.uxFormat.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxFormat);
			this.uxFormat.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxFormat);
			//
			// uxSizeLabel
			//
			this.uxSizeLabel.Name = "uxSizeLabel";
			this.uxSizeLabel.Text = "Size:";
			this.uxSizeLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxSizeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSizeLabel);			
			//
			// uxSize
			//
			this.uxSize.Name = "uxSize";
			this.uxSize.Width = 250;
			this.uxSize.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxSize);
			this.uxSize.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxSize);
			//
			// uxLinkLabel
			//
			this.uxLinkLabel.Name = "uxLinkLabel";
			this.uxLinkLabel.Text = "Link:";
			this.uxLinkLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxLinkLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxLinkLabel);			
			//
			// uxLink
			//
			this.uxLink.Name = "uxLink";
			this.uxLink.Width = 250;
			this.uxLink.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxLink);
			this.uxLink.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxLink);
			//
			// uxIsAvailableLabel
			//
			this.uxIsAvailableLabel.Name = "uxIsAvailableLabel";
			this.uxIsAvailableLabel.Text = "Is Available:";
			this.uxIsAvailableLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxIsAvailableLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsAvailableLabel);			
			//
			// uxIsAvailable
			//
			this.uxIsAvailable.Name = "uxIsAvailable";
			this.uxIsAvailable.Width = 250;
			this.uxIsAvailable.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsAvailable);
			this.uxIsAvailable.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxIsAvailable);
			// 
			// BookImageEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "BookImageEditControlBase";
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
        /// Indicates if the controls associated with the uxFormat property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxFormatVisible
        {
            get { return this.uxFormat.Visible; }
            set
            {
                this.uxFormatLabel.Visible = value;
                this.uxFormat.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxFormat property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxFormatEnabled
        {
            get { return this.uxFormat.Enabled; }
            set
            {
                this.uxFormat.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSize property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSizeVisible
        {
            get { return this.uxSize.Visible; }
            set
            {
                this.uxSizeLabel.Visible = value;
                this.uxSize.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSize property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSizeEnabled
        {
            get { return this.uxSize.Enabled; }
            set
            {
                this.uxSize.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxLink property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxLinkVisible
        {
            get { return this.uxLink.Visible; }
            set
            {
                this.uxLinkLabel.Visible = value;
                this.uxLink.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxLink property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxLinkEnabled
        {
            get { return this.uxLink.Enabled; }
            set
            {
                this.uxLink.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIsAvailable property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIsAvailableVisible
        {
            get { return this.uxIsAvailable.Visible; }
            set
            {
                this.uxIsAvailableLabel.Visible = value;
                this.uxIsAvailable.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIsAvailable property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIsAvailableEnabled
        {
            get { return this.uxIsAvailable.Enabled; }
            set
            {
                this.uxIsAvailable.Enabled = value;
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
