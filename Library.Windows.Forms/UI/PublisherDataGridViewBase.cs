
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract Publisher typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class PublisherDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<PublisherDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.Publisher _currentPublisher = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxPublisherDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxPublisherErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxPublisherBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Mobile property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxMobileDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Email property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxEmailDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Website property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxWebsiteDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the FounedOn property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxFounedOnDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Country property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCountryDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the City property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCityDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Address property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxAddressDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.Publisher> _PublisherList;
				
		/// <summary> 
		/// The list of Publisher to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.Publisher> PublisherList
		{
			get {return this._PublisherList;}
			set
			{
				this._PublisherList = value;
				this.uxPublisherBindingSource.DataSource = null;
				this.uxPublisherBindingSource.DataSource = value;
				this.uxPublisherDataGridView.DataSource = null;
				this.uxPublisherDataGridView.DataSource = this.uxPublisherBindingSource;				
				//this.uxPublisherBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxPublisherBindingSource_ListChanged);
				this.uxPublisherBindingSource.CurrentItemChanged += new System.EventHandler(OnPublisherBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnPublisherBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentPublisher = uxPublisherBindingSource.Current as BLL.Publisher;
			
			if (_currentPublisher != null)
			{
				_currentPublisher.Validate();
			}
			//_Publisher.Validate();
			OnCurrentEntityChanged();
		}

		//void uxPublisherBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.Publisher"/> instance.
		/// </summary>
		public BLL.Publisher SelectedPublisher
		{
			get {return this._currentPublisher;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxPublisherDataGridView.VirtualMode;}
			set
			{
				this.uxPublisherDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxPublisherDataGridView.AllowUserToAddRows;}
			set {this.uxPublisherDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxPublisherDataGridView.AllowUserToDeleteRows;}
			set {this.uxPublisherDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxPublisherDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxPublisherDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="PublisherDataGridViewBase"/> class.
		/// </summary>
		public PublisherDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxPublisherDataGridView = new System.Windows.Forms.DataGridView();
			this.uxPublisherBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxPublisherErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMobileDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEmailDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxWebsiteDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxFounedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCountryDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxAddressDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxPublisherDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPublisherBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPublisherErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxPublisherErrorProvider
			// 
			this.uxPublisherErrorProvider.ContainerControl = this;
			this.uxPublisherErrorProvider.DataSource = this.uxPublisherBindingSource;						
			// 
			// uxPublisherDataGridView
			// 
			this.uxPublisherDataGridView.AutoGenerateColumns = false;
			this.uxPublisherDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxPublisherDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxMobileDataGridViewColumn,
		this.uxEmailDataGridViewColumn,
		this.uxWebsiteDataGridViewColumn,
		this.uxFounedOnDataGridViewColumn,
		this.uxCountryDataGridViewColumn,
		this.uxCityDataGridViewColumn,
		this.uxAddressDataGridViewColumn			});
			this.uxPublisherDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxPublisherDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxPublisherDataGridView.Name = "uxPublisherDataGridView";
			this.uxPublisherDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxPublisherDataGridView.TabIndex = 0;	
			this.uxPublisherDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxPublisherDataGridView.EnableHeadersVisualStyles = false;
			this.uxPublisherDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnPublisherDataGridViewDataError);
			this.uxPublisherDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnPublisherDataGridViewCellValueNeeded);
			this.uxPublisherDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnPublisherDataGridViewCellValuePushed);
			
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
			// uxMobileDataGridViewColumn
			//
			this.uxMobileDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxMobileDataGridViewColumn.DataPropertyName = "Mobile";
			this.uxMobileDataGridViewColumn.HeaderText = "Mobile";
			this.uxMobileDataGridViewColumn.Name = "uxMobileDataGridViewColumn";
			this.uxMobileDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxMobileDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxMobileDataGridViewColumn.ReadOnly = false;		
			//
			// uxEmailDataGridViewColumn
			//
			this.uxEmailDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxEmailDataGridViewColumn.DataPropertyName = "Email";
			this.uxEmailDataGridViewColumn.HeaderText = "Email";
			this.uxEmailDataGridViewColumn.Name = "uxEmailDataGridViewColumn";
			this.uxEmailDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxEmailDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxEmailDataGridViewColumn.ReadOnly = false;		
			//
			// uxWebsiteDataGridViewColumn
			//
			this.uxWebsiteDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxWebsiteDataGridViewColumn.DataPropertyName = "Website";
			this.uxWebsiteDataGridViewColumn.HeaderText = "Website";
			this.uxWebsiteDataGridViewColumn.Name = "uxWebsiteDataGridViewColumn";
			this.uxWebsiteDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxWebsiteDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxWebsiteDataGridViewColumn.ReadOnly = false;		
			//
			// uxFounedOnDataGridViewColumn
			//
			this.uxFounedOnDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxFounedOnDataGridViewColumn.DataPropertyName = "FounedOn";
			this.uxFounedOnDataGridViewColumn.HeaderText = "FounedOn";
			this.uxFounedOnDataGridViewColumn.Name = "uxFounedOnDataGridViewColumn";
			this.uxFounedOnDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxFounedOnDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxFounedOnDataGridViewColumn.ReadOnly = false;		
			//
			// uxCountryDataGridViewColumn
			//
			this.uxCountryDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCountryDataGridViewColumn.DataPropertyName = "Country";
			this.uxCountryDataGridViewColumn.HeaderText = "Country";
			this.uxCountryDataGridViewColumn.Name = "uxCountryDataGridViewColumn";
			this.uxCountryDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCountryDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCountryDataGridViewColumn.ReadOnly = false;		
			//
			// uxCityDataGridViewColumn
			//
			this.uxCityDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCityDataGridViewColumn.DataPropertyName = "City";
			this.uxCityDataGridViewColumn.HeaderText = "City";
			this.uxCityDataGridViewColumn.Name = "uxCityDataGridViewColumn";
			this.uxCityDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCityDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCityDataGridViewColumn.ReadOnly = false;		
			//
			// uxAddressDataGridViewColumn
			//
			this.uxAddressDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxAddressDataGridViewColumn.DataPropertyName = "Address";
			this.uxAddressDataGridViewColumn.HeaderText = "Address";
			this.uxAddressDataGridViewColumn.Name = "uxAddressDataGridViewColumn";
			this.uxAddressDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxAddressDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxAddressDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxPublisherDataGridView);
			this.Name = "PublisherDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxPublisherErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPublisherDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxPublisherBindingSource)).EndInit();
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
				PublisherDataGridViewEventArgs args = new PublisherDataGridViewEventArgs();
				args.Publisher = _currentPublisher;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class PublisherDataGridViewEventArgs : System.EventArgs
		{
			private BLL.Publisher	_Publisher;
	
			/// <summary>
			/// the  BLL.Publisher instance.
			/// </summary>
			public BLL.Publisher Publisher
			{
				get { return _Publisher; }
				set { _Publisher = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxPublisherDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnPublisherDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxPublisherDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnPublisherDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxPublisherDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = PublisherList[e.RowIndex].ID;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = PublisherList[e.RowIndex].Name;
						break;
					case "uxMobileDataGridViewColumn":
						e.Value = PublisherList[e.RowIndex].Mobile;
						break;
					case "uxEmailDataGridViewColumn":
						e.Value = PublisherList[e.RowIndex].Email;
						break;
					case "uxWebsiteDataGridViewColumn":
						e.Value = PublisherList[e.RowIndex].Website;
						break;
					case "uxFounedOnDataGridViewColumn":
						e.Value = PublisherList[e.RowIndex].FounedOn;
						break;
					case "uxCountryDataGridViewColumn":
						e.Value = PublisherList[e.RowIndex].Country;
						break;
					case "uxCityDataGridViewColumn":
						e.Value = PublisherList[e.RowIndex].City;
						break;
					case "uxAddressDataGridViewColumn":
						e.Value = PublisherList[e.RowIndex].Address;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxPublisherDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnPublisherDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxPublisherDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						PublisherList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						PublisherList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxMobileDataGridViewColumn":
						PublisherList[e.RowIndex].Mobile = (System.String)e.Value;
						break;
					case "uxEmailDataGridViewColumn":
						PublisherList[e.RowIndex].Email = (System.String)e.Value;
						break;
					case "uxWebsiteDataGridViewColumn":
						PublisherList[e.RowIndex].Website = (System.String)e.Value;
						break;
					case "uxFounedOnDataGridViewColumn":
						PublisherList[e.RowIndex].FounedOn = (System.DateTime?)e.Value;
						break;
					case "uxCountryDataGridViewColumn":
						PublisherList[e.RowIndex].Country = (System.String)e.Value;
						break;
					case "uxCityDataGridViewColumn":
						PublisherList[e.RowIndex].City = (System.String)e.Value;
						break;
					case "uxAddressDataGridViewColumn":
						PublisherList[e.RowIndex].Address = (System.String)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
