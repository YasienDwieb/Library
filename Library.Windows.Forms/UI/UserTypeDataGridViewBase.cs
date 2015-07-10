
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract UserType typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class UserTypeDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<UserTypeDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.UserType _currentUserType = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxUserTypeDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxUserTypeErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxUserTypeBindingSource;
		
		
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
		
		private BLL.TList<BLL.UserType> _UserTypeList;
				
		/// <summary> 
		/// The list of UserType to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.UserType> UserTypeList
		{
			get {return this._UserTypeList;}
			set
			{
				this._UserTypeList = value;
				this.uxUserTypeBindingSource.DataSource = null;
				this.uxUserTypeBindingSource.DataSource = value;
				this.uxUserTypeDataGridView.DataSource = null;
				this.uxUserTypeDataGridView.DataSource = this.uxUserTypeBindingSource;				
				//this.uxUserTypeBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxUserTypeBindingSource_ListChanged);
				this.uxUserTypeBindingSource.CurrentItemChanged += new System.EventHandler(OnUserTypeBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnUserTypeBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentUserType = uxUserTypeBindingSource.Current as BLL.UserType;
			
			if (_currentUserType != null)
			{
				_currentUserType.Validate();
			}
			//_UserType.Validate();
			OnCurrentEntityChanged();
		}

		//void uxUserTypeBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.UserType"/> instance.
		/// </summary>
		public BLL.UserType SelectedUserType
		{
			get {return this._currentUserType;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxUserTypeDataGridView.VirtualMode;}
			set
			{
				this.uxUserTypeDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxUserTypeDataGridView.AllowUserToAddRows;}
			set {this.uxUserTypeDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxUserTypeDataGridView.AllowUserToDeleteRows;}
			set {this.uxUserTypeDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxUserTypeDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxUserTypeDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="UserTypeDataGridViewBase"/> class.
		/// </summary>
		public UserTypeDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxUserTypeDataGridView = new System.Windows.Forms.DataGridView();
			this.uxUserTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxUserTypeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxTypeNameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxUserTypeDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUserTypeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUserTypeErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxUserTypeErrorProvider
			// 
			this.uxUserTypeErrorProvider.ContainerControl = this;
			this.uxUserTypeErrorProvider.DataSource = this.uxUserTypeBindingSource;						
			// 
			// uxUserTypeDataGridView
			// 
			this.uxUserTypeDataGridView.AutoGenerateColumns = false;
			this.uxUserTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxUserTypeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxTypeNameDataGridViewColumn			});
			this.uxUserTypeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxUserTypeDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxUserTypeDataGridView.Name = "uxUserTypeDataGridView";
			this.uxUserTypeDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxUserTypeDataGridView.TabIndex = 0;	
			this.uxUserTypeDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxUserTypeDataGridView.EnableHeadersVisualStyles = false;
			this.uxUserTypeDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnUserTypeDataGridViewDataError);
			this.uxUserTypeDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnUserTypeDataGridViewCellValueNeeded);
			this.uxUserTypeDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnUserTypeDataGridViewCellValuePushed);
			
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
			this.Controls.Add(this.uxUserTypeDataGridView);
			this.Name = "UserTypeDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxUserTypeErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUserTypeDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxUserTypeBindingSource)).EndInit();
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
				UserTypeDataGridViewEventArgs args = new UserTypeDataGridViewEventArgs();
				args.UserType = _currentUserType;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class UserTypeDataGridViewEventArgs : System.EventArgs
		{
			private BLL.UserType	_UserType;
	
			/// <summary>
			/// the  BLL.UserType instance.
			/// </summary>
			public BLL.UserType UserType
			{
				get { return _UserType; }
				set { _UserType = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxUserTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnUserTypeDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxUserTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnUserTypeDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxUserTypeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = UserTypeList[e.RowIndex].ID;
						break;
					case "uxTypeNameDataGridViewColumn":
						e.Value = UserTypeList[e.RowIndex].TypeName;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxUserTypeDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnUserTypeDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxUserTypeDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						UserTypeList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxTypeNameDataGridViewColumn":
						UserTypeList[e.RowIndex].TypeName = (System.String)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
