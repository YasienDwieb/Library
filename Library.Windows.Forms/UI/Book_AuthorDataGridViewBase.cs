
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract Book_Author typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class Book_AuthorDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<Book_AuthorDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.Book_Author _currentBook_Author = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxBook_AuthorDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxBook_AuthorErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxBook_AuthorBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIDDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the Book_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxBook_IDDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the Author_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxAuthor_IDDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
				
		private BLL.TList<BLL.Author> _Author_IDList;
		
		/// <summary> 
		/// The list of selectable Author
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public BLL.TList<BLL.Author> Author_IDList
		{
			get {return this._Author_IDList;}
			set 
			{
				this._Author_IDList = value;
				this.uxAuthor_IDDataGridViewColumn.DataSource = null;
				this.uxAuthor_IDDataGridViewColumn.DataSource = this._Author_IDList;
			}
		}
		
		private bool _allowNewItemInAuthor_IDList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Author
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInAuthor_IDList
		{
			get { return _allowNewItemInAuthor_IDList;}
			set
			{
				this._allowNewItemInAuthor_IDList = value;
				this.uxAuthor_IDDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private BLL.TList<BLL.Book> _Book_IDList;
		
		/// <summary> 
		/// The list of selectable Book
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public BLL.TList<BLL.Book> Book_IDList
		{
			get {return this._Book_IDList;}
			set 
			{
				this._Book_IDList = value;
				this.uxBook_IDDataGridViewColumn.DataSource = null;
				this.uxBook_IDDataGridViewColumn.DataSource = this._Book_IDList;
			}
		}
		
		private bool _allowNewItemInBook_IDList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Book
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInBook_IDList
		{
			get { return _allowNewItemInBook_IDList;}
			set
			{
				this._allowNewItemInBook_IDList = value;
				this.uxBook_IDDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.Book_Author> _Book_AuthorList;
				
		/// <summary> 
		/// The list of Book_Author to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.Book_Author> Book_AuthorList
		{
			get {return this._Book_AuthorList;}
			set
			{
				this._Book_AuthorList = value;
				this.uxBook_AuthorBindingSource.DataSource = null;
				this.uxBook_AuthorBindingSource.DataSource = value;
				this.uxBook_AuthorDataGridView.DataSource = null;
				this.uxBook_AuthorDataGridView.DataSource = this.uxBook_AuthorBindingSource;				
				//this.uxBook_AuthorBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxBook_AuthorBindingSource_ListChanged);
				this.uxBook_AuthorBindingSource.CurrentItemChanged += new System.EventHandler(OnBook_AuthorBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnBook_AuthorBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentBook_Author = uxBook_AuthorBindingSource.Current as BLL.Book_Author;
			
			if (_currentBook_Author != null)
			{
				_currentBook_Author.Validate();
			}
			//_Book_Author.Validate();
			OnCurrentEntityChanged();
		}

		//void uxBook_AuthorBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.Book_Author"/> instance.
		/// </summary>
		public BLL.Book_Author SelectedBook_Author
		{
			get {return this._currentBook_Author;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxBook_AuthorDataGridView.VirtualMode;}
			set
			{
				this.uxBook_AuthorDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxBook_AuthorDataGridView.AllowUserToAddRows;}
			set {this.uxBook_AuthorDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxBook_AuthorDataGridView.AllowUserToDeleteRows;}
			set {this.uxBook_AuthorDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxBook_AuthorDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxBook_AuthorDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="Book_AuthorDataGridViewBase"/> class.
		/// </summary>
		public Book_AuthorDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxBook_AuthorDataGridView = new System.Windows.Forms.DataGridView();
			this.uxBook_AuthorBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxBook_AuthorErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxBook_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxAuthor_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			//this.uxAuthor_IDBindingSource = new AuthorBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxAuthor_IDBindingSource)).BeginInit();
			//this.uxBook_IDBindingSource = new BookBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxBook_IDBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBook_AuthorDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBook_AuthorBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBook_AuthorErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxBook_AuthorErrorProvider
			// 
			this.uxBook_AuthorErrorProvider.ContainerControl = this;
			this.uxBook_AuthorErrorProvider.DataSource = this.uxBook_AuthorBindingSource;						
			// 
			// uxBook_AuthorDataGridView
			// 
			this.uxBook_AuthorDataGridView.AutoGenerateColumns = false;
			this.uxBook_AuthorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxBook_AuthorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxBook_IDDataGridViewColumn,
		this.uxAuthor_IDDataGridViewColumn			});
			this.uxBook_AuthorDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxBook_AuthorDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxBook_AuthorDataGridView.Name = "uxBook_AuthorDataGridView";
			this.uxBook_AuthorDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxBook_AuthorDataGridView.TabIndex = 0;	
			this.uxBook_AuthorDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxBook_AuthorDataGridView.EnableHeadersVisualStyles = false;
			this.uxBook_AuthorDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnBook_AuthorDataGridViewDataError);
			this.uxBook_AuthorDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBook_AuthorDataGridViewCellValueNeeded);
			this.uxBook_AuthorDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBook_AuthorDataGridViewCellValuePushed);
			
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
			// uxBook_IDDataGridViewColumn
			//
			this.uxBook_IDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBook_IDDataGridViewColumn.DataPropertyName = "Book_ID";
			this.uxBook_IDDataGridViewColumn.HeaderText = "Book_ID";
			this.uxBook_IDDataGridViewColumn.Name = "uxBook_IDDataGridViewColumn";
			this.uxBook_IDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBook_IDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBook_IDDataGridViewColumn.ReadOnly = false;		
			//
			// uxAuthor_IDDataGridViewColumn
			//
			this.uxAuthor_IDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAuthor_IDDataGridViewColumn.DataPropertyName = "Author_ID";
			this.uxAuthor_IDDataGridViewColumn.HeaderText = "Author_ID";
			this.uxAuthor_IDDataGridViewColumn.Name = "uxAuthor_IDDataGridViewColumn";
			this.uxAuthor_IDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAuthor_IDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAuthor_IDDataGridViewColumn.ReadOnly = false;		
			//
			// uxAuthor_IDDataGridViewColumn
			//				
			this.uxAuthor_IDDataGridViewColumn.DisplayMember = "Name";	
			this.uxAuthor_IDDataGridViewColumn.ValueMember = "ID";	
			this.uxAuthor_IDDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxAuthor_IDDataGridViewColumn.DataSource = uxAuthor_IDBindingSource;				
				
			//
			// uxBook_IDDataGridViewColumn
			//				
			this.uxBook_IDDataGridViewColumn.DisplayMember = "Name";	
			this.uxBook_IDDataGridViewColumn.ValueMember = "ID";	
			this.uxBook_IDDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxBook_IDDataGridViewColumn.DataSource = uxBook_IDBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxBook_AuthorDataGridView);
			this.Name = "Book_AuthorDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxAuthor_IDBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxBook_IDBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBook_AuthorErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBook_AuthorDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBook_AuthorBindingSource)).EndInit();
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
				Book_AuthorDataGridViewEventArgs args = new Book_AuthorDataGridViewEventArgs();
				args.Book_Author = _currentBook_Author;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class Book_AuthorDataGridViewEventArgs : System.EventArgs
		{
			private BLL.Book_Author	_Book_Author;
	
			/// <summary>
			/// the  BLL.Book_Author instance.
			/// </summary>
			public BLL.Book_Author Book_Author
			{
				get { return _Book_Author; }
				set { _Book_Author = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxBook_AuthorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnBook_AuthorDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxBook_AuthorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBook_AuthorDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBook_AuthorDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = Book_AuthorList[e.RowIndex].ID;
						break;
					case "uxBook_IDDataGridViewColumn":
						e.Value = Book_AuthorList[e.RowIndex].Book_ID;
						break;
					case "uxAuthor_IDDataGridViewColumn":
						e.Value = Book_AuthorList[e.RowIndex].Author_ID;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxBook_AuthorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBook_AuthorDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBook_AuthorDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						Book_AuthorList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxBook_IDDataGridViewColumn":
						Book_AuthorList[e.RowIndex].Book_ID = (System.Int32)e.Value;
						break;
					case "uxAuthor_IDDataGridViewColumn":
						Book_AuthorList[e.RowIndex].Author_ID = (System.Int32)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
