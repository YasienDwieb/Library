
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract Book typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class BookDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<BookDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.Book _currentBook = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxBookDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxBookErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxBookBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Publisher property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPublisherDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Publish_Date property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPublish_DateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the IsAvailablePdf property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIsAvailablePdfDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the IsAvailablePaper property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIsAvailablePaperDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the IsBorrowed property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIsBorrowedDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the User_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxUser_IDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the BorrowDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBorrowDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Borrow_Times property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBorrow_TimesDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the IsLost property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIsLostDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the Type_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxType_IDDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the Publisher_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxPublisher_IDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Papers_no property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPapers_noDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the Introducer_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxIntroducer_IDDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the EmployeeI_D property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxEmployeeI_DDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Size property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSizeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Price property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPriceDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Pdf_Link property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPdf_LinkDataGridViewColumn;
		/// <summary> 
		/// the DGV column associated with the Image_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewComboBoxColumn uxImage_IDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the ISBN property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxISBNDataGridViewColumn;
		
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
		
				
		private BLL.TList<BLL.BookType> _Type_IDList;
		
		/// <summary> 
		/// The list of selectable BookType
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public BLL.TList<BLL.BookType> Type_IDList
		{
			get {return this._Type_IDList;}
			set 
			{
				this._Type_IDList = value;
				this.uxType_IDDataGridViewColumn.DataSource = null;
				this.uxType_IDDataGridViewColumn.DataSource = this._Type_IDList;
			}
		}
		
		private bool _allowNewItemInType_IDList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of BookType
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInType_IDList
		{
			get { return _allowNewItemInType_IDList;}
			set
			{
				this._allowNewItemInType_IDList = value;
				this.uxType_IDDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private BLL.TList<BLL.Employee> _EmployeeI_DList;
		
		/// <summary> 
		/// The list of selectable Employee
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public BLL.TList<BLL.Employee> EmployeeI_DList
		{
			get {return this._EmployeeI_DList;}
			set 
			{
				this._EmployeeI_DList = value;
				this.uxEmployeeI_DDataGridViewColumn.DataSource = null;
				this.uxEmployeeI_DDataGridViewColumn.DataSource = this._EmployeeI_DList;
			}
		}
		
		private bool _allowNewItemInEmployeeI_DList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Employee
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInEmployeeI_DList
		{
			get { return _allowNewItemInEmployeeI_DList;}
			set
			{
				this._allowNewItemInEmployeeI_DList = value;
				this.uxEmployeeI_DDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private BLL.TList<BLL.BookImage> _Image_IDList;
		
		/// <summary> 
		/// The list of selectable BookImage
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public BLL.TList<BLL.BookImage> Image_IDList
		{
			get {return this._Image_IDList;}
			set 
			{
				this._Image_IDList = value;
				this.uxImage_IDDataGridViewColumn.DataSource = null;
				this.uxImage_IDDataGridViewColumn.DataSource = this._Image_IDList;
			}
		}
		
		private bool _allowNewItemInImage_IDList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of BookImage
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInImage_IDList
		{
			get { return _allowNewItemInImage_IDList;}
			set
			{
				this._allowNewItemInImage_IDList = value;
				this.uxImage_IDDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private BLL.TList<BLL.Introducer> _Introducer_IDList;
		
		/// <summary> 
		/// The list of selectable Introducer
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public BLL.TList<BLL.Introducer> Introducer_IDList
		{
			get {return this._Introducer_IDList;}
			set 
			{
				this._Introducer_IDList = value;
				this.uxIntroducer_IDDataGridViewColumn.DataSource = null;
				this.uxIntroducer_IDDataGridViewColumn.DataSource = this._Introducer_IDList;
			}
		}
		
		private bool _allowNewItemInIntroducer_IDList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Introducer
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInIntroducer_IDList
		{
			get { return _allowNewItemInIntroducer_IDList;}
			set
			{
				this._allowNewItemInIntroducer_IDList = value;
				this.uxIntroducer_IDDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
				
		private BLL.TList<BLL.Publisher> _Publisher_IDList;
		
		/// <summary> 
		/// The list of selectable Publisher
		/// </summary>
		[System.ComponentModel.Category("DropDownList BindingSources")]
		public BLL.TList<BLL.Publisher> Publisher_IDList
		{
			get {return this._Publisher_IDList;}
			set 
			{
				this._Publisher_IDList = value;
				this.uxPublisher_IDDataGridViewColumn.DataSource = null;
				this.uxPublisher_IDDataGridViewColumn.DataSource = this._Publisher_IDList;
			}
		}
		
		private bool _allowNewItemInPublisher_IDList;
		
		/// <summary> 
		/// Indicates if user can add an item in the list of Publisher
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInPublisher_IDList
		{
			get { return _allowNewItemInPublisher_IDList;}
			set
			{
				this._allowNewItemInPublisher_IDList = value;
				this.uxPublisher_IDDataGridViewColumn.DisplayStyle = value ? System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox : System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton;
			}
		}
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.Book> _BookList;
				
		/// <summary> 
		/// The list of Book to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.Book> BookList
		{
			get {return this._BookList;}
			set
			{
				this._BookList = value;
				this.uxBookBindingSource.DataSource = null;
				this.uxBookBindingSource.DataSource = value;
				this.uxBookDataGridView.DataSource = null;
				this.uxBookDataGridView.DataSource = this.uxBookBindingSource;				
				//this.uxBookBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxBookBindingSource_ListChanged);
				this.uxBookBindingSource.CurrentItemChanged += new System.EventHandler(OnBookBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnBookBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentBook = uxBookBindingSource.Current as BLL.Book;
			
			if (_currentBook != null)
			{
				_currentBook.Validate();
			}
			//_Book.Validate();
			OnCurrentEntityChanged();
		}

		//void uxBookBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.Book"/> instance.
		/// </summary>
		public BLL.Book SelectedBook
		{
			get {return this._currentBook;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxBookDataGridView.VirtualMode;}
			set
			{
				this.uxBookDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxBookDataGridView.AllowUserToAddRows;}
			set {this.uxBookDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxBookDataGridView.AllowUserToDeleteRows;}
			set {this.uxBookDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxBookDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxBookDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="BookDataGridViewBase"/> class.
		/// </summary>
		public BookDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxBookDataGridView = new System.Windows.Forms.DataGridView();
			this.uxBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxBookErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPublisherDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPublish_DateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIsAvailablePdfDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxIsAvailablePaperDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxIsBorrowedDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxUser_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxBorrowDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxBorrow_TimesDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIsLostDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxType_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxPublisher_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxPapers_noDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIntroducer_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxEmployeeI_DDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxSizeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPriceDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPdf_LinkDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxImage_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.uxISBNDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCreatedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCreatedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUpdatedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUpdatedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDeletedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDeletedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			//this.uxType_IDBindingSource = new BookTypeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxType_IDBindingSource)).BeginInit();
			//this.uxEmployeeI_DBindingSource = new EmployeeBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeI_DBindingSource)).BeginInit();
			//this.uxImage_IDBindingSource = new BookImageBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxImage_IDBindingSource)).BeginInit();
			//this.uxIntroducer_IDBindingSource = new IntroducerBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxIntroducer_IDBindingSource)).BeginInit();
			//this.uxPublisher_IDBindingSource = new PublisherBindingSource(this.components);
			//((System.ComponentModel.ISupportInitialize)(this.uxPublisher_IDBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxBookErrorProvider
			// 
			this.uxBookErrorProvider.ContainerControl = this;
			this.uxBookErrorProvider.DataSource = this.uxBookBindingSource;						
			// 
			// uxBookDataGridView
			// 
			this.uxBookDataGridView.AutoGenerateColumns = false;
			this.uxBookDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxBookDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxPublisherDataGridViewColumn,
		this.uxPublish_DateDataGridViewColumn,
		this.uxIsAvailablePdfDataGridViewColumn,
		this.uxIsAvailablePaperDataGridViewColumn,
		this.uxIsBorrowedDataGridViewColumn,
		this.uxUser_IDDataGridViewColumn,
		this.uxBorrowDateDataGridViewColumn,
		this.uxBorrow_TimesDataGridViewColumn,
		this.uxIsLostDataGridViewColumn,
		this.uxType_IDDataGridViewColumn,
		this.uxPublisher_IDDataGridViewColumn,
		this.uxPapers_noDataGridViewColumn,
		this.uxIntroducer_IDDataGridViewColumn,
		this.uxEmployeeI_DDataGridViewColumn,
		this.uxSizeDataGridViewColumn,
		this.uxPriceDataGridViewColumn,
		this.uxPdf_LinkDataGridViewColumn,
		this.uxImage_IDDataGridViewColumn,
		this.uxISBNDataGridViewColumn,
		this.uxCreatedOnDataGridViewColumn,
		this.uxCreatedByDataGridViewColumn,
		this.uxUpdatedOnDataGridViewColumn,
		this.uxUpdatedByDataGridViewColumn,
		this.uxDeletedOnDataGridViewColumn,
		this.uxDeletedByDataGridViewColumn			});
			this.uxBookDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxBookDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxBookDataGridView.Name = "uxBookDataGridView";
			this.uxBookDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxBookDataGridView.TabIndex = 0;	
			this.uxBookDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxBookDataGridView.EnableHeadersVisualStyles = false;
			this.uxBookDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnBookDataGridViewDataError);
			this.uxBookDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBookDataGridViewCellValueNeeded);
			this.uxBookDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBookDataGridViewCellValuePushed);
			
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
			// uxNameDataGridViewColumn
			//
			this.uxNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxNameDataGridViewColumn.DataPropertyName = "Name";
			this.uxNameDataGridViewColumn.HeaderText = "Name";
			this.uxNameDataGridViewColumn.Name = "uxNameDataGridViewColumn";
			this.uxNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxNameDataGridViewColumn.ReadOnly = false;		
			//
			// uxPublisherDataGridViewColumn
			//
			this.uxPublisherDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPublisherDataGridViewColumn.DataPropertyName = "Publisher";
			this.uxPublisherDataGridViewColumn.HeaderText = "Publisher";
			this.uxPublisherDataGridViewColumn.Name = "uxPublisherDataGridViewColumn";
			this.uxPublisherDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPublisherDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPublisherDataGridViewColumn.ReadOnly = false;		
			//
			// uxPublish_DateDataGridViewColumn
			//
			this.uxPublish_DateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPublish_DateDataGridViewColumn.DataPropertyName = "Publish_Date";
			this.uxPublish_DateDataGridViewColumn.HeaderText = "Publish_Date";
			this.uxPublish_DateDataGridViewColumn.Name = "uxPublish_DateDataGridViewColumn";
			this.uxPublish_DateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPublish_DateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPublish_DateDataGridViewColumn.ReadOnly = false;		
			//
			// uxIsAvailablePdfDataGridViewColumn
			//
			this.uxIsAvailablePdfDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIsAvailablePdfDataGridViewColumn.DataPropertyName = "IsAvailablePdf";
			this.uxIsAvailablePdfDataGridViewColumn.HeaderText = "IsAvailablePdf";
			this.uxIsAvailablePdfDataGridViewColumn.Name = "uxIsAvailablePdfDataGridViewColumn";
			this.uxIsAvailablePdfDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIsAvailablePdfDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIsAvailablePdfDataGridViewColumn.ReadOnly = false;		
			//
			// uxIsAvailablePaperDataGridViewColumn
			//
			this.uxIsAvailablePaperDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIsAvailablePaperDataGridViewColumn.DataPropertyName = "IsAvailablePaper";
			this.uxIsAvailablePaperDataGridViewColumn.HeaderText = "IsAvailablePaper";
			this.uxIsAvailablePaperDataGridViewColumn.Name = "uxIsAvailablePaperDataGridViewColumn";
			this.uxIsAvailablePaperDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIsAvailablePaperDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIsAvailablePaperDataGridViewColumn.ReadOnly = false;		
			//
			// uxIsBorrowedDataGridViewColumn
			//
			this.uxIsBorrowedDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIsBorrowedDataGridViewColumn.DataPropertyName = "IsBorrowed";
			this.uxIsBorrowedDataGridViewColumn.HeaderText = "IsBorrowed";
			this.uxIsBorrowedDataGridViewColumn.Name = "uxIsBorrowedDataGridViewColumn";
			this.uxIsBorrowedDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIsBorrowedDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIsBorrowedDataGridViewColumn.ReadOnly = false;		
			//
			// uxUser_IDDataGridViewColumn
			//
			this.uxUser_IDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxUser_IDDataGridViewColumn.DataPropertyName = "User_ID";
			this.uxUser_IDDataGridViewColumn.HeaderText = "User_ID";
			this.uxUser_IDDataGridViewColumn.Name = "uxUser_IDDataGridViewColumn";
			this.uxUser_IDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxUser_IDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxUser_IDDataGridViewColumn.ReadOnly = false;		
			//
			// uxBorrowDateDataGridViewColumn
			//
			this.uxBorrowDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBorrowDateDataGridViewColumn.DataPropertyName = "BorrowDate";
			this.uxBorrowDateDataGridViewColumn.HeaderText = "BorrowDate";
			this.uxBorrowDateDataGridViewColumn.Name = "uxBorrowDateDataGridViewColumn";
			this.uxBorrowDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBorrowDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBorrowDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxBorrow_TimesDataGridViewColumn
			//
			this.uxBorrow_TimesDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBorrow_TimesDataGridViewColumn.DataPropertyName = "Borrow_Times";
			this.uxBorrow_TimesDataGridViewColumn.HeaderText = "Borrow_Times";
			this.uxBorrow_TimesDataGridViewColumn.Name = "uxBorrow_TimesDataGridViewColumn";
			this.uxBorrow_TimesDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBorrow_TimesDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBorrow_TimesDataGridViewColumn.ReadOnly = false;		
			//
			// uxIsLostDataGridViewColumn
			//
			this.uxIsLostDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIsLostDataGridViewColumn.DataPropertyName = "IsLost";
			this.uxIsLostDataGridViewColumn.HeaderText = "IsLost";
			this.uxIsLostDataGridViewColumn.Name = "uxIsLostDataGridViewColumn";
			this.uxIsLostDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIsLostDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIsLostDataGridViewColumn.ReadOnly = false;		
			//
			// uxType_IDDataGridViewColumn
			//
			this.uxType_IDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxType_IDDataGridViewColumn.DataPropertyName = "Type_ID";
			this.uxType_IDDataGridViewColumn.HeaderText = "Type_ID";
			this.uxType_IDDataGridViewColumn.Name = "uxType_IDDataGridViewColumn";
			this.uxType_IDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxType_IDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxType_IDDataGridViewColumn.ReadOnly = false;		
			//
			// uxPublisher_IDDataGridViewColumn
			//
			this.uxPublisher_IDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPublisher_IDDataGridViewColumn.DataPropertyName = "Publisher_ID";
			this.uxPublisher_IDDataGridViewColumn.HeaderText = "Publisher_ID";
			this.uxPublisher_IDDataGridViewColumn.Name = "uxPublisher_IDDataGridViewColumn";
			this.uxPublisher_IDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPublisher_IDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPublisher_IDDataGridViewColumn.ReadOnly = false;		
			//
			// uxPapers_noDataGridViewColumn
			//
			this.uxPapers_noDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPapers_noDataGridViewColumn.DataPropertyName = "Papers_no";
			this.uxPapers_noDataGridViewColumn.HeaderText = "Papers_no";
			this.uxPapers_noDataGridViewColumn.Name = "uxPapers_noDataGridViewColumn";
			this.uxPapers_noDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPapers_noDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPapers_noDataGridViewColumn.ReadOnly = false;		
			//
			// uxIntroducer_IDDataGridViewColumn
			//
			this.uxIntroducer_IDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIntroducer_IDDataGridViewColumn.DataPropertyName = "Introducer_ID";
			this.uxIntroducer_IDDataGridViewColumn.HeaderText = "Introducer_ID";
			this.uxIntroducer_IDDataGridViewColumn.Name = "uxIntroducer_IDDataGridViewColumn";
			this.uxIntroducer_IDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIntroducer_IDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIntroducer_IDDataGridViewColumn.ReadOnly = false;		
			//
			// uxEmployeeI_DDataGridViewColumn
			//
			this.uxEmployeeI_DDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEmployeeI_DDataGridViewColumn.DataPropertyName = "EmployeeI_D";
			this.uxEmployeeI_DDataGridViewColumn.HeaderText = "EmployeeI_D";
			this.uxEmployeeI_DDataGridViewColumn.Name = "uxEmployeeI_DDataGridViewColumn";
			this.uxEmployeeI_DDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEmployeeI_DDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEmployeeI_DDataGridViewColumn.ReadOnly = false;		
			//
			// uxSizeDataGridViewColumn
			//
			this.uxSizeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxSizeDataGridViewColumn.DataPropertyName = "Size";
			this.uxSizeDataGridViewColumn.HeaderText = "Size";
			this.uxSizeDataGridViewColumn.Name = "uxSizeDataGridViewColumn";
			this.uxSizeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxSizeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxSizeDataGridViewColumn.ReadOnly = false;		
			//
			// uxPriceDataGridViewColumn
			//
			this.uxPriceDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPriceDataGridViewColumn.DataPropertyName = "Price";
			this.uxPriceDataGridViewColumn.HeaderText = "Price";
			this.uxPriceDataGridViewColumn.Name = "uxPriceDataGridViewColumn";
			this.uxPriceDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPriceDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPriceDataGridViewColumn.ReadOnly = false;		
			//
			// uxPdf_LinkDataGridViewColumn
			//
			this.uxPdf_LinkDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPdf_LinkDataGridViewColumn.DataPropertyName = "Pdf_Link";
			this.uxPdf_LinkDataGridViewColumn.HeaderText = "Pdf_Link";
			this.uxPdf_LinkDataGridViewColumn.Name = "uxPdf_LinkDataGridViewColumn";
			this.uxPdf_LinkDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPdf_LinkDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPdf_LinkDataGridViewColumn.ReadOnly = false;		
			//
			// uxImage_IDDataGridViewColumn
			//
			this.uxImage_IDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxImage_IDDataGridViewColumn.DataPropertyName = "Image_ID";
			this.uxImage_IDDataGridViewColumn.HeaderText = "Image_ID";
			this.uxImage_IDDataGridViewColumn.Name = "uxImage_IDDataGridViewColumn";
			this.uxImage_IDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxImage_IDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxImage_IDDataGridViewColumn.ReadOnly = false;		
			//
			// uxISBNDataGridViewColumn
			//
			this.uxISBNDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxISBNDataGridViewColumn.DataPropertyName = "ISBN";
			this.uxISBNDataGridViewColumn.HeaderText = "ISBN";
			this.uxISBNDataGridViewColumn.Name = "uxISBNDataGridViewColumn";
			this.uxISBNDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxISBNDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxISBNDataGridViewColumn.ReadOnly = false;		
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
			// uxType_IDDataGridViewColumn
			//				
			this.uxType_IDDataGridViewColumn.DisplayMember = "TypeName";	
			this.uxType_IDDataGridViewColumn.ValueMember = "ID";	
			this.uxType_IDDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxType_IDDataGridViewColumn.DataSource = uxType_IDBindingSource;				
				
			//
			// uxEmployeeI_DDataGridViewColumn
			//				
			this.uxEmployeeI_DDataGridViewColumn.DisplayMember = "UserName";	
			this.uxEmployeeI_DDataGridViewColumn.ValueMember = "ID";	
			this.uxEmployeeI_DDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxEmployeeI_DDataGridViewColumn.DataSource = uxEmployeeI_DBindingSource;				
				
			//
			// uxImage_IDDataGridViewColumn
			//				
			this.uxImage_IDDataGridViewColumn.DisplayMember = "Name";	
			this.uxImage_IDDataGridViewColumn.ValueMember = "ID";	
			this.uxImage_IDDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxImage_IDDataGridViewColumn.DataSource = uxImage_IDBindingSource;				
				
			//
			// uxIntroducer_IDDataGridViewColumn
			//				
			this.uxIntroducer_IDDataGridViewColumn.DisplayMember = "Name";	
			this.uxIntroducer_IDDataGridViewColumn.ValueMember = "ID";	
			this.uxIntroducer_IDDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxIntroducer_IDDataGridViewColumn.DataSource = uxIntroducer_IDBindingSource;				
				
			//
			// uxPublisher_IDDataGridViewColumn
			//				
			this.uxPublisher_IDDataGridViewColumn.DisplayMember = "Name";	
			this.uxPublisher_IDDataGridViewColumn.ValueMember = "ID";	
			this.uxPublisher_IDDataGridViewColumn.DisplayStyleForCurrentCellOnly = true;
			//uxPublisher_IDDataGridViewColumn.DataSource = uxPublisher_IDBindingSource;				
				
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxBookDataGridView);
			this.Name = "BookDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			//((System.ComponentModel.ISupportInitialize)(this.uxType_IDBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxEmployeeI_DBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxImage_IDBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxIntroducer_IDBindingSource)).EndInit();
			//((System.ComponentModel.ISupportInitialize)(this.uxPublisher_IDBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookBindingSource)).EndInit();
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
				BookDataGridViewEventArgs args = new BookDataGridViewEventArgs();
				args.Book = _currentBook;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class BookDataGridViewEventArgs : System.EventArgs
		{
			private BLL.Book	_Book;
	
			/// <summary>
			/// the  BLL.Book instance.
			/// </summary>
			public BLL.Book Book
			{
				get { return _Book; }
				set { _Book = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxBookDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnBookDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxBookDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBookDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBookDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = BookList[e.RowIndex].ID;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Name;
						break;
					case "uxPublisherDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Publisher;
						break;
					case "uxPublish_DateDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Publish_Date;
						break;
					case "uxIsAvailablePdfDataGridViewColumn":
						e.Value = BookList[e.RowIndex].IsAvailablePdf;
						break;
					case "uxIsAvailablePaperDataGridViewColumn":
						e.Value = BookList[e.RowIndex].IsAvailablePaper;
						break;
					case "uxIsBorrowedDataGridViewColumn":
						e.Value = BookList[e.RowIndex].IsBorrowed;
						break;
					case "uxUser_IDDataGridViewColumn":
						e.Value = BookList[e.RowIndex].User_ID;
						break;
					case "uxBorrowDateDataGridViewColumn":
						e.Value = BookList[e.RowIndex].BorrowDate;
						break;
					case "uxBorrow_TimesDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Borrow_Times;
						break;
					case "uxIsLostDataGridViewColumn":
						e.Value = BookList[e.RowIndex].IsLost;
						break;
					case "uxType_IDDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Type_ID;
						break;
					case "uxPublisher_IDDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Publisher_ID;
						break;
					case "uxPapers_noDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Papers_no;
						break;
					case "uxIntroducer_IDDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Introducer_ID;
						break;
					case "uxEmployeeI_DDataGridViewColumn":
						e.Value = BookList[e.RowIndex].EmployeeI_D;
						break;
					case "uxSizeDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Size;
						break;
					case "uxPriceDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Price;
						break;
					case "uxPdf_LinkDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Pdf_Link;
						break;
					case "uxImage_IDDataGridViewColumn":
						e.Value = BookList[e.RowIndex].Image_ID;
						break;
					case "uxISBNDataGridViewColumn":
						e.Value = BookList[e.RowIndex].ISBN;
						break;
					case "uxCreatedOnDataGridViewColumn":
						e.Value = BookList[e.RowIndex].CreatedOn;
						break;
					case "uxCreatedByDataGridViewColumn":
						e.Value = BookList[e.RowIndex].CreatedBy;
						break;
					case "uxUpdatedOnDataGridViewColumn":
						e.Value = BookList[e.RowIndex].UpdatedOn;
						break;
					case "uxUpdatedByDataGridViewColumn":
						e.Value = BookList[e.RowIndex].UpdatedBy;
						break;
					case "uxDeletedOnDataGridViewColumn":
						e.Value = BookList[e.RowIndex].DeletedOn;
						break;
					case "uxDeletedByDataGridViewColumn":
						e.Value = BookList[e.RowIndex].DeletedBy;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxBookDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBookDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBookDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						BookList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						BookList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxPublisherDataGridViewColumn":
						BookList[e.RowIndex].Publisher = (System.String)e.Value;
						break;
					case "uxPublish_DateDataGridViewColumn":
						BookList[e.RowIndex].Publish_Date = (System.DateTime?)e.Value;
						break;
					case "uxIsAvailablePdfDataGridViewColumn":
						BookList[e.RowIndex].IsAvailablePdf = (System.Boolean?)e.Value;
						break;
					case "uxIsAvailablePaperDataGridViewColumn":
						BookList[e.RowIndex].IsAvailablePaper = (System.Boolean?)e.Value;
						break;
					case "uxIsBorrowedDataGridViewColumn":
						BookList[e.RowIndex].IsBorrowed = (System.Boolean)e.Value;
						break;
					case "uxUser_IDDataGridViewColumn":
						BookList[e.RowIndex].User_ID = (System.Int32)e.Value;
						break;
					case "uxBorrowDateDataGridViewColumn":
						BookList[e.RowIndex].BorrowDate = (System.DateTime?)e.Value;
						break;
					case "uxBorrow_TimesDataGridViewColumn":
						BookList[e.RowIndex].Borrow_Times = (System.Int32?)e.Value;
						break;
					case "uxIsLostDataGridViewColumn":
						BookList[e.RowIndex].IsLost = (System.Boolean?)e.Value;
						break;
					case "uxType_IDDataGridViewColumn":
						BookList[e.RowIndex].Type_ID = (System.Int32)e.Value;
						break;
					case "uxPublisher_IDDataGridViewColumn":
						BookList[e.RowIndex].Publisher_ID = (System.Int32)e.Value;
						break;
					case "uxPapers_noDataGridViewColumn":
						BookList[e.RowIndex].Papers_no = (System.Int32?)e.Value;
						break;
					case "uxIntroducer_IDDataGridViewColumn":
						BookList[e.RowIndex].Introducer_ID = (System.Int32?)e.Value;
						break;
					case "uxEmployeeI_DDataGridViewColumn":
						BookList[e.RowIndex].EmployeeI_D = (System.Int32)e.Value;
						break;
					case "uxSizeDataGridViewColumn":
						BookList[e.RowIndex].Size = (System.Double?)e.Value;
						break;
					case "uxPriceDataGridViewColumn":
						BookList[e.RowIndex].Price = (System.Int32?)e.Value;
						break;
					case "uxPdf_LinkDataGridViewColumn":
						BookList[e.RowIndex].Pdf_Link = (System.String)e.Value;
						break;
					case "uxImage_IDDataGridViewColumn":
						BookList[e.RowIndex].Image_ID = (System.Int32)e.Value;
						break;
					case "uxISBNDataGridViewColumn":
						BookList[e.RowIndex].ISBN = (System.String)e.Value;
						break;
					case "uxCreatedOnDataGridViewColumn":
						BookList[e.RowIndex].CreatedOn = (System.DateTime?)e.Value;
						break;
					case "uxCreatedByDataGridViewColumn":
						BookList[e.RowIndex].CreatedBy = (System.Int32?)e.Value;
						break;
					case "uxUpdatedOnDataGridViewColumn":
						BookList[e.RowIndex].UpdatedOn = (System.DateTime?)e.Value;
						break;
					case "uxUpdatedByDataGridViewColumn":
						BookList[e.RowIndex].UpdatedBy = (System.Int32?)e.Value;
						break;
					case "uxDeletedOnDataGridViewColumn":
						BookList[e.RowIndex].DeletedOn = (System.DateTime?)e.Value;
						break;
					case "uxDeletedByDataGridViewColumn":
						BookList[e.RowIndex].DeletedBy = (System.Int32?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
