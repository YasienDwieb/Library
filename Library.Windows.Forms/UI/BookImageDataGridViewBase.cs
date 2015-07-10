
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract BookImage typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class BookImageDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<BookImageDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.BookImage _currentBookImage = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxBookImageDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxBookImageErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxBookImageBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Format property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxFormatDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Size property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxSizeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Link property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxLinkDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the IsAvailable property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIsAvailableDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.BookImage> _BookImageList;
				
		/// <summary> 
		/// The list of BookImage to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.BookImage> BookImageList
		{
			get {return this._BookImageList;}
			set
			{
				this._BookImageList = value;
				this.uxBookImageBindingSource.DataSource = null;
				this.uxBookImageBindingSource.DataSource = value;
				this.uxBookImageDataGridView.DataSource = null;
				this.uxBookImageDataGridView.DataSource = this.uxBookImageBindingSource;				
				//this.uxBookImageBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxBookImageBindingSource_ListChanged);
				this.uxBookImageBindingSource.CurrentItemChanged += new System.EventHandler(OnBookImageBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnBookImageBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentBookImage = uxBookImageBindingSource.Current as BLL.BookImage;
			
			if (_currentBookImage != null)
			{
				_currentBookImage.Validate();
			}
			//_BookImage.Validate();
			OnCurrentEntityChanged();
		}

		//void uxBookImageBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.BookImage"/> instance.
		/// </summary>
		public BLL.BookImage SelectedBookImage
		{
			get {return this._currentBookImage;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxBookImageDataGridView.VirtualMode;}
			set
			{
				this.uxBookImageDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxBookImageDataGridView.AllowUserToAddRows;}
			set {this.uxBookImageDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxBookImageDataGridView.AllowUserToDeleteRows;}
			set {this.uxBookImageDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxBookImageDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxBookImageDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="BookImageDataGridViewBase"/> class.
		/// </summary>
		public BookImageDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxBookImageDataGridView = new System.Windows.Forms.DataGridView();
			this.uxBookImageBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxBookImageErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFormatDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxSizeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxLinkDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIsAvailableDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxBookImageDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookImageBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookImageErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxBookImageErrorProvider
			// 
			this.uxBookImageErrorProvider.ContainerControl = this;
			this.uxBookImageErrorProvider.DataSource = this.uxBookImageBindingSource;						
			// 
			// uxBookImageDataGridView
			// 
			this.uxBookImageDataGridView.AutoGenerateColumns = false;
			this.uxBookImageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxBookImageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxFormatDataGridViewColumn,
		this.uxSizeDataGridViewColumn,
		this.uxLinkDataGridViewColumn,
		this.uxIsAvailableDataGridViewColumn			});
			this.uxBookImageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxBookImageDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxBookImageDataGridView.Name = "uxBookImageDataGridView";
			this.uxBookImageDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxBookImageDataGridView.TabIndex = 0;	
			this.uxBookImageDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxBookImageDataGridView.EnableHeadersVisualStyles = false;
			this.uxBookImageDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnBookImageDataGridViewDataError);
			this.uxBookImageDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBookImageDataGridViewCellValueNeeded);
			this.uxBookImageDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBookImageDataGridViewCellValuePushed);
			
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
			// uxFormatDataGridViewColumn
			//
			this.uxFormatDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFormatDataGridViewColumn.DataPropertyName = "Format";
			this.uxFormatDataGridViewColumn.HeaderText = "Format";
			this.uxFormatDataGridViewColumn.Name = "uxFormatDataGridViewColumn";
			this.uxFormatDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFormatDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFormatDataGridViewColumn.ReadOnly = false;		
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
			// uxLinkDataGridViewColumn
			//
			this.uxLinkDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxLinkDataGridViewColumn.DataPropertyName = "Link";
			this.uxLinkDataGridViewColumn.HeaderText = "Link";
			this.uxLinkDataGridViewColumn.Name = "uxLinkDataGridViewColumn";
			this.uxLinkDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxLinkDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxLinkDataGridViewColumn.ReadOnly = false;		
			//
			// uxIsAvailableDataGridViewColumn
			//
			this.uxIsAvailableDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIsAvailableDataGridViewColumn.DataPropertyName = "IsAvailable";
			this.uxIsAvailableDataGridViewColumn.HeaderText = "IsAvailable";
			this.uxIsAvailableDataGridViewColumn.Name = "uxIsAvailableDataGridViewColumn";
			this.uxIsAvailableDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIsAvailableDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIsAvailableDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxBookImageDataGridView);
			this.Name = "BookImageDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxBookImageErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookImageDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookImageBindingSource)).EndInit();
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
				BookImageDataGridViewEventArgs args = new BookImageDataGridViewEventArgs();
				args.BookImage = _currentBookImage;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class BookImageDataGridViewEventArgs : System.EventArgs
		{
			private BLL.BookImage	_BookImage;
	
			/// <summary>
			/// the  BLL.BookImage instance.
			/// </summary>
			public BLL.BookImage BookImage
			{
				get { return _BookImage; }
				set { _BookImage = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxBookImageDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnBookImageDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxBookImageDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBookImageDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBookImageDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = BookImageList[e.RowIndex].ID;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = BookImageList[e.RowIndex].Name;
						break;
					case "uxFormatDataGridViewColumn":
						e.Value = BookImageList[e.RowIndex].Format;
						break;
					case "uxSizeDataGridViewColumn":
						e.Value = BookImageList[e.RowIndex].Size;
						break;
					case "uxLinkDataGridViewColumn":
						e.Value = BookImageList[e.RowIndex].Link;
						break;
					case "uxIsAvailableDataGridViewColumn":
						e.Value = BookImageList[e.RowIndex].IsAvailable;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxBookImageDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBookImageDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBookImageDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						BookImageList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						BookImageList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxFormatDataGridViewColumn":
						BookImageList[e.RowIndex].Format = (System.String)e.Value;
						break;
					case "uxSizeDataGridViewColumn":
						BookImageList[e.RowIndex].Size = (System.String)e.Value;
						break;
					case "uxLinkDataGridViewColumn":
						BookImageList[e.RowIndex].Link = (System.String)e.Value;
						break;
					case "uxIsAvailableDataGridViewColumn":
						BookImageList[e.RowIndex].IsAvailable = (System.String)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
