
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract Author typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class AuthorDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<AuthorDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.Author _currentAuthor = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxAuthorDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxAuthorErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxAuthorBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxNameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Country property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCountryDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the City property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCityDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the BirthDate property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBirthDateDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Position property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxPositionDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the IsAlive property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIsAliveDataGridViewColumn;
		
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
		/// the DGV column associated with the Gender property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxGenderDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.Author> _AuthorList;
				
		/// <summary> 
		/// The list of Author to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.Author> AuthorList
		{
			get {return this._AuthorList;}
			set
			{
				this._AuthorList = value;
				this.uxAuthorBindingSource.DataSource = null;
				this.uxAuthorBindingSource.DataSource = value;
				this.uxAuthorDataGridView.DataSource = null;
				this.uxAuthorDataGridView.DataSource = this.uxAuthorBindingSource;				
				//this.uxAuthorBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxAuthorBindingSource_ListChanged);
				this.uxAuthorBindingSource.CurrentItemChanged += new System.EventHandler(OnAuthorBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnAuthorBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentAuthor = uxAuthorBindingSource.Current as BLL.Author;
			
			if (_currentAuthor != null)
			{
				_currentAuthor.Validate();
			}
			//_Author.Validate();
			OnCurrentEntityChanged();
		}

		//void uxAuthorBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.Author"/> instance.
		/// </summary>
		public BLL.Author SelectedAuthor
		{
			get {return this._currentAuthor;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxAuthorDataGridView.VirtualMode;}
			set
			{
				this.uxAuthorDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxAuthorDataGridView.AllowUserToAddRows;}
			set {this.uxAuthorDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxAuthorDataGridView.AllowUserToDeleteRows;}
			set {this.uxAuthorDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxAuthorDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxAuthorDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="AuthorDataGridViewBase"/> class.
		/// </summary>
		public AuthorDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxAuthorDataGridView = new System.Windows.Forms.DataGridView();
			this.uxAuthorBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxAuthorErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCountryDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCityDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxBirthDateDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxPositionDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIsAliveDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxMobileDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxEmailDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxWebsiteDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxGenderDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxAuthorDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAuthorBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAuthorErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxAuthorErrorProvider
			// 
			this.uxAuthorErrorProvider.ContainerControl = this;
			this.uxAuthorErrorProvider.DataSource = this.uxAuthorBindingSource;						
			// 
			// uxAuthorDataGridView
			// 
			this.uxAuthorDataGridView.AutoGenerateColumns = false;
			this.uxAuthorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxAuthorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxNameDataGridViewColumn,
		this.uxCountryDataGridViewColumn,
		this.uxCityDataGridViewColumn,
		this.uxBirthDateDataGridViewColumn,
		this.uxPositionDataGridViewColumn,
		this.uxIsAliveDataGridViewColumn,
		this.uxMobileDataGridViewColumn,
		this.uxEmailDataGridViewColumn,
		this.uxWebsiteDataGridViewColumn,
		this.uxGenderDataGridViewColumn			});
			this.uxAuthorDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxAuthorDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxAuthorDataGridView.Name = "uxAuthorDataGridView";
			this.uxAuthorDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxAuthorDataGridView.TabIndex = 0;	
			this.uxAuthorDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxAuthorDataGridView.EnableHeadersVisualStyles = false;
			this.uxAuthorDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnAuthorDataGridViewDataError);
			this.uxAuthorDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnAuthorDataGridViewCellValueNeeded);
			this.uxAuthorDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnAuthorDataGridViewCellValuePushed);
			
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
			// uxBirthDateDataGridViewColumn
			//
			this.uxBirthDateDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxBirthDateDataGridViewColumn.DataPropertyName = "BirthDate";
			this.uxBirthDateDataGridViewColumn.HeaderText = "BirthDate";
			this.uxBirthDateDataGridViewColumn.Name = "uxBirthDateDataGridViewColumn";
			this.uxBirthDateDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxBirthDateDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxBirthDateDataGridViewColumn.ReadOnly = false;		
			//
			// uxPositionDataGridViewColumn
			//
			this.uxPositionDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxPositionDataGridViewColumn.DataPropertyName = "Position";
			this.uxPositionDataGridViewColumn.HeaderText = "Position";
			this.uxPositionDataGridViewColumn.Name = "uxPositionDataGridViewColumn";
			this.uxPositionDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxPositionDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxPositionDataGridViewColumn.ReadOnly = false;		
			//
			// uxIsAliveDataGridViewColumn
			//
			this.uxIsAliveDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIsAliveDataGridViewColumn.DataPropertyName = "IsAlive";
			this.uxIsAliveDataGridViewColumn.HeaderText = "IsAlive";
			this.uxIsAliveDataGridViewColumn.Name = "uxIsAliveDataGridViewColumn";
			this.uxIsAliveDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIsAliveDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIsAliveDataGridViewColumn.ReadOnly = false;		
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
			// uxGenderDataGridViewColumn
			//
			this.uxGenderDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxGenderDataGridViewColumn.DataPropertyName = "Gender";
			this.uxGenderDataGridViewColumn.HeaderText = "Gender";
			this.uxGenderDataGridViewColumn.Name = "uxGenderDataGridViewColumn";
			this.uxGenderDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxGenderDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxGenderDataGridViewColumn.ReadOnly = false;		
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxAuthorDataGridView);
			this.Name = "AuthorDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxAuthorErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAuthorDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxAuthorBindingSource)).EndInit();
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
				AuthorDataGridViewEventArgs args = new AuthorDataGridViewEventArgs();
				args.Author = _currentAuthor;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class AuthorDataGridViewEventArgs : System.EventArgs
		{
			private BLL.Author	_Author;
	
			/// <summary>
			/// the  BLL.Author instance.
			/// </summary>
			public BLL.Author Author
			{
				get { return _Author; }
				set { _Author = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxAuthorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnAuthorDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxAuthorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnAuthorDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxAuthorDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].ID;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].Name;
						break;
					case "uxCountryDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].Country;
						break;
					case "uxCityDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].City;
						break;
					case "uxBirthDateDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].BirthDate;
						break;
					case "uxPositionDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].Position;
						break;
					case "uxIsAliveDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].IsAlive;
						break;
					case "uxMobileDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].Mobile;
						break;
					case "uxEmailDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].Email;
						break;
					case "uxWebsiteDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].Website;
						break;
					case "uxGenderDataGridViewColumn":
						e.Value = AuthorList[e.RowIndex].Gender;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxAuthorDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnAuthorDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxAuthorDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						AuthorList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						AuthorList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxCountryDataGridViewColumn":
						AuthorList[e.RowIndex].Country = (System.String)e.Value;
						break;
					case "uxCityDataGridViewColumn":
						AuthorList[e.RowIndex].City = (System.String)e.Value;
						break;
					case "uxBirthDateDataGridViewColumn":
						AuthorList[e.RowIndex].BirthDate = (System.DateTime?)e.Value;
						break;
					case "uxPositionDataGridViewColumn":
						AuthorList[e.RowIndex].Position = (System.String)e.Value;
						break;
					case "uxIsAliveDataGridViewColumn":
						AuthorList[e.RowIndex].IsAlive = (System.String)e.Value;
						break;
					case "uxMobileDataGridViewColumn":
						AuthorList[e.RowIndex].Mobile = (System.String)e.Value;
						break;
					case "uxEmailDataGridViewColumn":
						AuthorList[e.RowIndex].Email = (System.String)e.Value;
						break;
					case "uxWebsiteDataGridViewColumn":
						AuthorList[e.RowIndex].Website = (System.String)e.Value;
						break;
					case "uxGenderDataGridViewColumn":
						AuthorList[e.RowIndex].Gender = (System.Boolean?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
