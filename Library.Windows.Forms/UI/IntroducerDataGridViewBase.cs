
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract Introducer typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class IntroducerDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<IntroducerDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.Introducer _currentIntroducer = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxIntroducerDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxIntroducerErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxIntroducerBindingSource;
		
		
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
		/// the DGV column associated with the Book_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxBook_IDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Gender property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxGenderDataGridViewColumn;
		
		#endregion
					
		#region Combo list
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.Introducer> _IntroducerList;
				
		/// <summary> 
		/// The list of Introducer to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.Introducer> IntroducerList
		{
			get {return this._IntroducerList;}
			set
			{
				this._IntroducerList = value;
				this.uxIntroducerBindingSource.DataSource = null;
				this.uxIntroducerBindingSource.DataSource = value;
				this.uxIntroducerDataGridView.DataSource = null;
				this.uxIntroducerDataGridView.DataSource = this.uxIntroducerBindingSource;				
				//this.uxIntroducerBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxIntroducerBindingSource_ListChanged);
				this.uxIntroducerBindingSource.CurrentItemChanged += new System.EventHandler(OnIntroducerBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnIntroducerBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentIntroducer = uxIntroducerBindingSource.Current as BLL.Introducer;
			
			if (_currentIntroducer != null)
			{
				_currentIntroducer.Validate();
			}
			//_Introducer.Validate();
			OnCurrentEntityChanged();
		}

		//void uxIntroducerBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.Introducer"/> instance.
		/// </summary>
		public BLL.Introducer SelectedIntroducer
		{
			get {return this._currentIntroducer;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxIntroducerDataGridView.VirtualMode;}
			set
			{
				this.uxIntroducerDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxIntroducerDataGridView.AllowUserToAddRows;}
			set {this.uxIntroducerDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxIntroducerDataGridView.AllowUserToDeleteRows;}
			set {this.uxIntroducerDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxIntroducerDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxIntroducerDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="IntroducerDataGridViewBase"/> class.
		/// </summary>
		public IntroducerDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxIntroducerDataGridView = new System.Windows.Forms.DataGridView();
			this.uxIntroducerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxIntroducerErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
			this.uxBook_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxGenderDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxIntroducerDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIntroducerBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIntroducerErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxIntroducerErrorProvider
			// 
			this.uxIntroducerErrorProvider.ContainerControl = this;
			this.uxIntroducerErrorProvider.DataSource = this.uxIntroducerBindingSource;						
			// 
			// uxIntroducerDataGridView
			// 
			this.uxIntroducerDataGridView.AutoGenerateColumns = false;
			this.uxIntroducerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxIntroducerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
		this.uxBook_IDDataGridViewColumn,
		this.uxGenderDataGridViewColumn			});
			this.uxIntroducerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxIntroducerDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxIntroducerDataGridView.Name = "uxIntroducerDataGridView";
			this.uxIntroducerDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxIntroducerDataGridView.TabIndex = 0;	
			this.uxIntroducerDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxIntroducerDataGridView.EnableHeadersVisualStyles = false;
			this.uxIntroducerDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnIntroducerDataGridViewDataError);
			this.uxIntroducerDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnIntroducerDataGridViewCellValueNeeded);
			this.uxIntroducerDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnIntroducerDataGridViewCellValuePushed);
			
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
			this.Controls.Add(this.uxIntroducerDataGridView);
			this.Name = "IntroducerDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxIntroducerErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIntroducerDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxIntroducerBindingSource)).EndInit();
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
				IntroducerDataGridViewEventArgs args = new IntroducerDataGridViewEventArgs();
				args.Introducer = _currentIntroducer;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class IntroducerDataGridViewEventArgs : System.EventArgs
		{
			private BLL.Introducer	_Introducer;
	
			/// <summary>
			/// the  BLL.Introducer instance.
			/// </summary>
			public BLL.Introducer Introducer
			{
				get { return _Introducer; }
				set { _Introducer = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxIntroducerDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnIntroducerDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxIntroducerDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnIntroducerDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxIntroducerDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].ID;
						break;
					case "uxNameDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].Name;
						break;
					case "uxCountryDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].Country;
						break;
					case "uxCityDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].City;
						break;
					case "uxBirthDateDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].BirthDate;
						break;
					case "uxPositionDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].Position;
						break;
					case "uxIsAliveDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].IsAlive;
						break;
					case "uxMobileDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].Mobile;
						break;
					case "uxEmailDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].Email;
						break;
					case "uxWebsiteDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].Website;
						break;
					case "uxBook_IDDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].Book_ID;
						break;
					case "uxGenderDataGridViewColumn":
						e.Value = IntroducerList[e.RowIndex].Gender;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxIntroducerDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnIntroducerDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxIntroducerDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						IntroducerList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxNameDataGridViewColumn":
						IntroducerList[e.RowIndex].Name = (System.String)e.Value;
						break;
					case "uxCountryDataGridViewColumn":
						IntroducerList[e.RowIndex].Country = (System.String)e.Value;
						break;
					case "uxCityDataGridViewColumn":
						IntroducerList[e.RowIndex].City = (System.String)e.Value;
						break;
					case "uxBirthDateDataGridViewColumn":
						IntroducerList[e.RowIndex].BirthDate = (System.DateTime?)e.Value;
						break;
					case "uxPositionDataGridViewColumn":
						IntroducerList[e.RowIndex].Position = (System.String)e.Value;
						break;
					case "uxIsAliveDataGridViewColumn":
						IntroducerList[e.RowIndex].IsAlive = (System.String)e.Value;
						break;
					case "uxMobileDataGridViewColumn":
						IntroducerList[e.RowIndex].Mobile = (System.String)e.Value;
						break;
					case "uxEmailDataGridViewColumn":
						IntroducerList[e.RowIndex].Email = (System.String)e.Value;
						break;
					case "uxWebsiteDataGridViewColumn":
						IntroducerList[e.RowIndex].Website = (System.String)e.Value;
						break;
					case "uxBook_IDDataGridViewColumn":
						IntroducerList[e.RowIndex].Book_ID = (System.Int32)e.Value;
						break;
					case "uxGenderDataGridViewColumn":
						IntroducerList[e.RowIndex].Gender = (System.Boolean?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
