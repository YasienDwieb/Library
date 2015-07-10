
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract BookType typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class BookTypeDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<BookTypeDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.BookType _currentBookType = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxBookTypeDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxBookTypeErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxBookTypeBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the TypeName property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxTypeNameDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.BookType> _BookTypeList;
				
		/// <summary> 
		/// The list of BookType to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.BookType> BookTypeList
		{
			get {return this._BookTypeList;}
			set
			{
				this._BookTypeList = value;
				this.uxBookTypeBindingSource.DataSource = null;
				this.uxBookTypeBindingSource.DataSource = value;
				this.uxBookTypeDataGridView.DataSource = null;
				this.uxBookTypeDataGridView.DataSource = this.uxBookTypeBindingSource;				
				//this.uxBookTypeBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxBookTypeBindingSource_ListChanged);
				this.uxBookTypeBindingSource.CurrentItemChanged += new System.EventHandler(OnBookTypeBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnBookTypeBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentBookType = uxBookTypeBindingSource.Current as BLL.BookType;
			
			if (_currentBookType != null)
			{
				_currentBookType.Validate();
			}
			//_BookType.Validate();
			OnCurrentEntityChanged();
		}

		//void uxBookTypeBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.BookType"/> instance.
		/// </summary>
		public BLL.BookType SelectedBookType
		{
			get {return this._currentBookType;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxBookTypeDataGridView.VirtualMode;}
			set
			{
				this.uxBookTypeDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxBookTypeDataGridView.AllowUserToAddRows;}
			set {this.uxBookTypeDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxBookTypeDataGridView.AllowUserToDeleteRows;}
			set {this.uxBookTypeDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxBookTypeDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxBookTypeDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="BookTypeDataGridViewBase"/> class.
		/// </summary>
		public BookTypeDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxBookTypeDataGridView = new System.Windows.Forms.DataGridView();
			this.uxBookTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxBookTypeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTypeNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxBookTypeDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookTypeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookTypeErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxBookTypeErrorProvider
			// 
			this.uxBookTypeErrorProvider.ContainerControl = this;
			this.uxBookTypeErrorProvider.DataSource = this.uxBookTypeBindingSource;						
			// 
			// uxBookTypeDataGridView
			// 
			this.uxBookTypeDataGridView.AutoGenerateColumns = false;
			this.uxBookTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxBookTypeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxTypeNameDataGridViewColumn			});
			this.uxBookTypeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxBookTypeDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxBookTypeDataGridView.Name = "uxBookTypeDataGridView";
			this.uxBookTypeDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxBookTypeDataGridView.TabIndex = 0;	
			this.uxBookTypeDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxBookTypeDataGridView.EnableHeadersVisualStyles = false;
			this.uxBookTypeDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnBookTypeDataGridViewDataError);
			this.uxBookTypeDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBookTypeDataGridViewCellValueNeeded);
			this.uxBookTypeDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnBookTypeDataGridViewCellValuePushed);
			
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
			// uxTypeNameDataGridViewColumn
			//
			this.uxTypeNameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxTypeNameDataGridViewColumn.DataPropertyName = "TypeName";
			this.uxTypeNameDataGridViewColumn.HeaderText = "TypeName";
			this.uxTypeNameDataGridViewColumn.Name = "uxTypeNameDataGridViewColumn";
			this.uxTypeNameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxTypeNameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxTypeNameDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxBookTypeDataGridView);
			this.Name = "BookTypeDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxBookTypeErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookTypeDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBookTypeBindingSource)).EndInit();
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
				BookTypeDataGridViewEventArgs args = new BookTypeDataGridViewEventArgs();
				args.BookType = _currentBookType;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class BookTypeDataGridViewEventArgs : System.EventArgs
		{
			private BLL.BookType	_BookType;
	
			/// <summary>
			/// the  BLL.BookType instance.
			/// </summary>
			public BLL.BookType BookType
			{
				get { return _BookType; }
				set { _BookType = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxBookTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnBookTypeDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxBookTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBookTypeDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBookTypeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = BookTypeList[e.RowIndex].ID;
						break;
					case "uxTypeNameDataGridViewColumn":
						e.Value = BookTypeList[e.RowIndex].TypeName;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxBookTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnBookTypeDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxBookTypeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						BookTypeList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxTypeNameDataGridViewColumn":
						BookTypeList[e.RowIndex].TypeName = (System.String)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
