
namespace Library.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="BLL.Book_Author"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class Book_AuthorEditControlBase : System.Windows.Forms.UserControl
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
		/// ComboBox for the Book_ID property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxBook_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Book_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxBook_IDLabel;
		
		/// <summary>
		/// ComboBox for the Author_ID property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxAuthor_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Author_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxAuthor_IDLabel;
		#endregion
		
		#region Main entity
		private BLL.Book_Author _Book_Author;
		/// <summary>
		/// Gets or sets the <see cref="BLL.Book_Author"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="BLL.Book_Author"/> instance.</value>
		public BLL.Book_Author Book_Author
		{
			get {return this._Book_Author;}
			set
			{
				this._Book_Author = value;
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
			this.uxBook_ID.DataBindings.Clear();
			this.uxBook_ID.DataBindings.Add("SelectedValue", this.uxBindingSource, "Book_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxAuthor_ID.DataBindings.Clear();
			this.uxAuthor_ID.DataBindings.Add("SelectedValue", this.uxBindingSource, "Author_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Book_AuthorEditControlBase"/> class.
		/// </summary>
		public Book_AuthorEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Book_Author != null) _Book_Author.Validate();
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
			this.uxBook_ID = new System.Windows.Forms.ComboBox();
			uxBook_IDLabel = new System.Windows.Forms.Label();
			this.uxAuthor_ID = new System.Windows.Forms.ComboBox();
			uxAuthor_IDLabel = new System.Windows.Forms.Label();
			
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
			// uxBook_IDLabel
			//
			this.uxBook_IDLabel.Name = "uxBook_IDLabel";
			this.uxBook_IDLabel.Text = "BookID:";
			this.uxBook_IDLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxBook_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBook_IDLabel);			
			//
			// uxBook_ID
			//
			this.uxBook_ID.Name = "uxBook_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBook_ID);
			this.uxBook_ID.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxBook_ID);
			//
			// uxAuthor_IDLabel
			//
			this.uxAuthor_IDLabel.Name = "uxAuthor_IDLabel";
			this.uxAuthor_IDLabel.Text = "AuthorID:";
			this.uxAuthor_IDLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxAuthor_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxAuthor_IDLabel);			
			//
			// uxAuthor_ID
			//
			this.uxAuthor_ID.Name = "uxAuthor_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxAuthor_ID);
			this.uxAuthor_ID.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxAuthor_ID);
			//
			// uxAuthor_ID
			//				
			this.uxAuthor_ID.DisplayMember = "Name";	
			this.uxAuthor_ID.ValueMember = "ID";	
			//
			// uxBook_ID
			//				
			this.uxBook_ID.DisplayMember = "Name";	
			this.uxBook_ID.ValueMember = "ID";	
			// 
			// Book_AuthorEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "Book_AuthorEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private BLL.TList<BLL.Author> _Author_IDList;
		
		/// <summary>
		/// The ComboBox associated with the Author_ID property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public BLL.TList<BLL.Author> Author_IDList
		{
			get {return _Author_IDList;}
			set 
			{
				this._Author_IDList = value;
				this.uxAuthor_ID.DataSource = null;
				this.uxAuthor_ID.DataSource = value;
			}
		}
		
		private bool _allowNewItemInAuthor_IDList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the Author_ID property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInAuthor_IDList
		{
			get { return _allowNewItemInAuthor_IDList;}
			set
			{
				this._allowNewItemInAuthor_IDList = value;
				this.uxAuthor_ID.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private BLL.TList<BLL.Book> _Book_IDList;
		
		/// <summary>
		/// The ComboBox associated with the Book_ID property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public BLL.TList<BLL.Book> Book_IDList
		{
			get {return _Book_IDList;}
			set 
			{
				this._Book_IDList = value;
				this.uxBook_ID.DataSource = null;
				this.uxBook_ID.DataSource = value;
			}
		}
		
		private bool _allowNewItemInBook_IDList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the Book_ID property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInBook_IDList
		{
			get { return _allowNewItemInBook_IDList;}
			set
			{
				this._allowNewItemInBook_IDList = value;
				this.uxBook_ID.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
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
        /// Indicates if the controls associated with the uxAuthor_ID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxAuthor_IDVisible
        {
            get { return this.uxAuthor_ID.Visible; }
            set
            {
                this.uxAuthor_IDLabel.Visible = value;
                this.uxAuthor_ID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxAuthor_ID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxAuthor_IDEnabled
        {
            get { return this.uxAuthor_ID.Enabled; }
            set
            {
                this.uxAuthor_ID.Enabled = value;
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
