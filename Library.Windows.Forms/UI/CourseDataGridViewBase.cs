
namespace Library.Windows.Forms
{
	/// <summary>
	/// abstract Course typed datagridview
	/// </summary>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class CourseDataGridViewBase : System.Windows.Forms.UserControl
	{	
		/// <summary> 
		/// Thrown when the current Entity changed.
		/// </summary>
		public event System.EventHandler<CourseDataGridViewEventArgs> CurrentEntityChanged;
		
		#region Fields
				
		/// <summary> 
		/// the current entity.
		/// </summary>
		private BLL.Course _currentCourse = null;
		//private Dictionary<string, string> _columnsHeaders = new Dictionary<string, string>();
		
		/// <summary> 
		/// the datagridview instance
		/// </summary>
		protected System.Windows.Forms.DataGridView uxCourseDataGridView;
		
		/// <summary> 
		/// the errorprovider
		/// </summary>
		protected System.Windows.Forms.ErrorProvider uxCourseErrorProvider;
		
		/// <summary> 
		/// the bindingsource
		/// </summary>
		protected System.Windows.Forms.BindingSource uxCourseBindingSource;
		
		
		/// <summary> 
		/// the DGV column associated with the ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxIDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Course_Name property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCourse_NameDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Course_Scope property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxCourse_ScopeDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Duration property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDurationDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the DurationType_ID property
		/// </summary>
		protected System.Windows.Forms.DataGridViewTextBoxColumn uxDurationType_IDDataGridViewColumn;
		
		/// <summary> 
		/// the DGV column associated with the Is_Deleted property
		/// </summary>
		protected System.Windows.Forms.DataGridViewCheckBoxColumn uxIs_DeletedDataGridViewColumn;
		
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
		
		#endregion
		
		#region Main Datasource
		
		private BLL.TList<BLL.Course> _CourseList;
				
		/// <summary> 
		/// The list of Course to be displayed in the DGV.
		/// </summary>
		[System.ComponentModel.Category("Data")]
		public BLL.TList<BLL.Course> CourseList
		{
			get {return this._CourseList;}
			set
			{
				this._CourseList = value;
				this.uxCourseBindingSource.DataSource = null;
				this.uxCourseBindingSource.DataSource = value;
				this.uxCourseDataGridView.DataSource = null;
				this.uxCourseDataGridView.DataSource = this.uxCourseBindingSource;				
				//this.uxCourseBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(uxCourseBindingSource_ListChanged);
				this.uxCourseBindingSource.CurrentItemChanged += new System.EventHandler(OnCourseBindingSourceCurrentItemChanged);
			}
		}
		
		private void OnCourseBindingSourceCurrentItemChanged(object sender, System.EventArgs e)
		{
			_currentCourse = uxCourseBindingSource.Current as BLL.Course;
			
			if (_currentCourse != null)
			{
				_currentCourse.Validate();
			}
			//_Course.Validate();
			OnCurrentEntityChanged();
		}

		//void uxCourseBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		//{
			//throw new Exception("The method or operation is not implemented.");
		//}		
		
		#endregion
		
		/// <summary>
		/// Gets the currently selected <see cref="BLL.Course"/> instance.
		/// </summary>
		public BLL.Course SelectedCourse
		{
			get {return this._currentCourse;}
		}
		
		#region other properties
		
		/// <summary>
		/// Gets or sets a value indicating whether you have provided your own data-management operations for the DataGridView control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool VirtualMode
		{
			get {return this.uxCourseDataGridView.VirtualMode;}
			set
			{
				this.uxCourseDataGridView.VirtualMode = value;
			}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToAddRows
		{
			get {return this.uxCourseDataGridView.AllowUserToAddRows;}
			set {this.uxCourseDataGridView.AllowUserToAddRows = value;}
		}
		
		/// <summary>
		/// Gets or sets a value indicating whether the user is allowed to delete rows from the DataGridView.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public bool AllowUserToDeleteRows
		{
			get {return this.uxCourseDataGridView.AllowUserToDeleteRows;}
			set {this.uxCourseDataGridView.AllowUserToDeleteRows = value;}
		}
		
		/// <summary>
		/// Gets the <see cref="DataGridView"/> instance.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]
		public System.Windows.Forms.DataGridView DataGridView
		{
			get {return this.uxCourseDataGridView;}
		}
		
		/// <summary>
		/// Gets a collection that contains all the columns in the control.
		/// </summary>
		[System.ComponentModel.Category(".netTiers")]		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		//[System.ComponentModel.EditorAttribute("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design", typeof(System.Drawing.Design.UITypeEditor))] 
		public System.Windows.Forms.DataGridViewColumnCollection Columns
		{
			get { return this.uxCourseDataGridView.Columns; }
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
		/// Initializes a new instance of the <see cref="CourseDataGridViewBase"/> class.
		/// </summary>
		public CourseDataGridViewBase()
		{			
			this.components = new System.ComponentModel.Container();			
			
			this.uxCourseDataGridView = new System.Windows.Forms.DataGridView();
			this.uxCourseBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.uxCourseErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.uxIDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCourse_NameDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCourse_ScopeDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDurationDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDurationType_IDDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxIs_DeletedDataGridViewColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.uxCreatedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxCreatedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUpdatedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxUpdatedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDeletedOnDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uxDeletedByDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.uxCourseDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCourseBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCourseErrorProvider)).BeginInit();
			this.SuspendLayout();
						
			// 
			// uxCourseErrorProvider
			// 
			this.uxCourseErrorProvider.ContainerControl = this;
			this.uxCourseErrorProvider.DataSource = this.uxCourseBindingSource;						
			// 
			// uxCourseDataGridView
			// 
			this.uxCourseDataGridView.AutoGenerateColumns = false;
			this.uxCourseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxCourseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
		this.uxIDDataGridViewColumn,
		this.uxCourse_NameDataGridViewColumn,
		this.uxCourse_ScopeDataGridViewColumn,
		this.uxDurationDataGridViewColumn,
		this.uxDurationType_IDDataGridViewColumn,
		this.uxIs_DeletedDataGridViewColumn,
		this.uxCreatedOnDataGridViewColumn,
		this.uxCreatedByDataGridViewColumn,
		this.uxUpdatedOnDataGridViewColumn,
		this.uxUpdatedByDataGridViewColumn,
		this.uxDeletedOnDataGridViewColumn,
		this.uxDeletedByDataGridViewColumn			});
			this.uxCourseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uxCourseDataGridView.Location = new System.Drawing.Point(0, 0);
			this.uxCourseDataGridView.Name = "uxCourseDataGridView";
			this.uxCourseDataGridView.Size = new System.Drawing.Size(470, 300);
			this.uxCourseDataGridView.TabIndex = 0;	
			this.uxCourseDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.uxCourseDataGridView.EnableHeadersVisualStyles = false;
			this.uxCourseDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnCourseDataGridViewDataError);
			this.uxCourseDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCourseDataGridViewCellValueNeeded);
			this.uxCourseDataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.OnCourseDataGridViewCellValuePushed);
			
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
			// uxCourse_NameDataGridViewColumn
			//
			this.uxCourse_NameDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCourse_NameDataGridViewColumn.DataPropertyName = "Course_Name";
			this.uxCourse_NameDataGridViewColumn.HeaderText = "Course_Name";
			this.uxCourse_NameDataGridViewColumn.Name = "uxCourse_NameDataGridViewColumn";
			this.uxCourse_NameDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCourse_NameDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCourse_NameDataGridViewColumn.ReadOnly = false;		
			//
			// uxCourse_ScopeDataGridViewColumn
			//
			this.uxCourse_ScopeDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxCourse_ScopeDataGridViewColumn.DataPropertyName = "Course_Scope";
			this.uxCourse_ScopeDataGridViewColumn.HeaderText = "Course_Scope";
			this.uxCourse_ScopeDataGridViewColumn.Name = "uxCourse_ScopeDataGridViewColumn";
			this.uxCourse_ScopeDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxCourse_ScopeDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxCourse_ScopeDataGridViewColumn.ReadOnly = false;		
			//
			// uxDurationDataGridViewColumn
			//
			this.uxDurationDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDurationDataGridViewColumn.DataPropertyName = "Duration";
			this.uxDurationDataGridViewColumn.HeaderText = "Duration";
			this.uxDurationDataGridViewColumn.Name = "uxDurationDataGridViewColumn";
			this.uxDurationDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDurationDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDurationDataGridViewColumn.ReadOnly = false;		
			//
			// uxDurationType_IDDataGridViewColumn
			//
			this.uxDurationType_IDDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxDurationType_IDDataGridViewColumn.DataPropertyName = "DurationType_ID";
			this.uxDurationType_IDDataGridViewColumn.HeaderText = "DurationType_ID";
			this.uxDurationType_IDDataGridViewColumn.Name = "uxDurationType_IDDataGridViewColumn";
			this.uxDurationType_IDDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxDurationType_IDDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxDurationType_IDDataGridViewColumn.ReadOnly = false;		
			//
			// uxIs_DeletedDataGridViewColumn
			//
			this.uxIs_DeletedDataGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.uxIs_DeletedDataGridViewColumn.DataPropertyName = "Is_Deleted";
			this.uxIs_DeletedDataGridViewColumn.HeaderText = "Is_Deleted";
			this.uxIs_DeletedDataGridViewColumn.Name = "uxIs_DeletedDataGridViewColumn";
			this.uxIs_DeletedDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.uxIs_DeletedDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.uxIs_DeletedDataGridViewColumn.ReadOnly = false;		
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
			
			// this
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.uxCourseDataGridView);
			this.Name = "CourseDataGridView";
			this.Size = new System.Drawing.Size(470, 300);
			((System.ComponentModel.ISupportInitialize)(this.uxCourseErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCourseDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxCourseBindingSource)).EndInit();
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
				CourseDataGridViewEventArgs args = new CourseDataGridViewEventArgs();
				args.Course = _currentCourse;
				CurrentEntityChanged(this, args); 
			}
		}
		
		#endregion
		
		/// <summary>
		/// Strongly typed event 
		/// </summary>
		public class CourseDataGridViewEventArgs : System.EventArgs
		{
			private BLL.Course	_Course;
	
			/// <summary>
			/// the  BLL.Course instance.
			/// </summary>
			public BLL.Course Course
			{
				get { return _Course; }
				set { _Course = value; }
			}	
		}
		
		/// <summary>
		/// Handles the DataError event of the uxCourseDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
		protected void OnCourseDataGridViewDataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format( "{0}, {1}", e.ColumnIndex, e.RowIndex));
		}
		
		/// <summary>
		/// Handles the CellValueNeeded event of the uxCourseDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCourseDataGridViewCellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCourseDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].ID;
						break;
					case "uxCourse_NameDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].Course_Name;
						break;
					case "uxCourse_ScopeDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].Course_Scope;
						break;
					case "uxDurationDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].Duration;
						break;
					case "uxDurationType_IDDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].DurationType_ID;
						break;
					case "uxIs_DeletedDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].Is_Deleted;
						break;
					case "uxCreatedOnDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].CreatedOn;
						break;
					case "uxCreatedByDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].CreatedBy;
						break;
					case "uxUpdatedOnDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].UpdatedOn;
						break;
					case "uxUpdatedByDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].UpdatedBy;
						break;
					case "uxDeletedOnDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].DeletedOn;
						break;
					case "uxDeletedByDataGridViewColumn":
						e.Value = CourseList[e.RowIndex].DeletedBy;
						break;
				default:
				break;
			}
		}
		
		/// <summary>
		/// Handles the CellValuePushed event of the uxCourseDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Windows.Forms.DataGridViewCellValueEventArgs"/> instance containing the event data.</param>
		protected void OnCourseDataGridViewCellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
		{
			switch(uxCourseDataGridView.Columns[e.ColumnIndex].Name)
			{
					case "uxIDDataGridViewColumn":
						CourseList[e.RowIndex].ID = (System.Int32)e.Value;
						break;
					case "uxCourse_NameDataGridViewColumn":
						CourseList[e.RowIndex].Course_Name = (System.String)e.Value;
						break;
					case "uxCourse_ScopeDataGridViewColumn":
						CourseList[e.RowIndex].Course_Scope = (System.Int32)e.Value;
						break;
					case "uxDurationDataGridViewColumn":
						CourseList[e.RowIndex].Duration = (System.Int32)e.Value;
						break;
					case "uxDurationType_IDDataGridViewColumn":
						CourseList[e.RowIndex].DurationType_ID = (System.Int32)e.Value;
						break;
					case "uxIs_DeletedDataGridViewColumn":
						CourseList[e.RowIndex].Is_Deleted = (System.Boolean?)e.Value;
						break;
					case "uxCreatedOnDataGridViewColumn":
						CourseList[e.RowIndex].CreatedOn = (System.DateTime?)e.Value;
						break;
					case "uxCreatedByDataGridViewColumn":
						CourseList[e.RowIndex].CreatedBy = (System.Int32?)e.Value;
						break;
					case "uxUpdatedOnDataGridViewColumn":
						CourseList[e.RowIndex].UpdatedOn = (System.DateTime?)e.Value;
						break;
					case "uxUpdatedByDataGridViewColumn":
						CourseList[e.RowIndex].UpdatedBy = (System.Int32?)e.Value;
						break;
					case "uxDeletedOnDataGridViewColumn":
						CourseList[e.RowIndex].DeletedOn = (System.DateTime?)e.Value;
						break;
					case "uxDeletedByDataGridViewColumn":
						CourseList[e.RowIndex].DeletedBy = (System.Int32?)e.Value;
						break;
				default:
				break;
			}
		}
	}
}
