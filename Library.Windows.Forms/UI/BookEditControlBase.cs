
namespace Library.Windows.Forms
{
	/// <summary>
	/// This is the abstract edit form for the <see cref="BLL.Book"/> entity.
	/// </summary>
	/// <remarks>This class is overwritten by .netTiers at each generation.</remarks>
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public abstract class BookEditControlBase : System.Windows.Forms.UserControl
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
		/// TextBox for the Name property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxName;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Name property.
		/// </summary>
		protected System.Windows.Forms.Label uxNameLabel;
		
		/// <summary>
		/// TextBox for the Publisher property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPublisher;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Publisher property.
		/// </summary>
		protected System.Windows.Forms.Label uxPublisherLabel;
		
		/// <summary>
		/// DataTimePicker for the Publish_Date property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxPublish_Date;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Publish_Date property.
		/// </summary>
		protected System.Windows.Forms.Label uxPublish_DateLabel;
		
		/// <summary>
		/// CheckBox for the IsAvailablePdf property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxIsAvailablePdf;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the IsAvailablePdf property.
		/// </summary>
		protected System.Windows.Forms.Label uxIsAvailablePdfLabel;
		
		/// <summary>
		/// CheckBox for the IsAvailablePaper property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxIsAvailablePaper;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the IsAvailablePaper property.
		/// </summary>
		protected System.Windows.Forms.Label uxIsAvailablePaperLabel;
		
		/// <summary>
		/// CheckBox for the IsBorrowed property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxIsBorrowed;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the IsBorrowed property.
		/// </summary>
		protected System.Windows.Forms.Label uxIsBorrowedLabel;
		
		/// <summary>
		/// TextBox for the User_ID property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUser_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the User_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxUser_IDLabel;
		
		/// <summary>
		/// DataTimePicker for the BorrowDate property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxBorrowDate;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the BorrowDate property.
		/// </summary>
		protected System.Windows.Forms.Label uxBorrowDateLabel;
		
		/// <summary>
		/// TextBox for the Borrow_Times property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxBorrow_Times;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Borrow_Times property.
		/// </summary>
		protected System.Windows.Forms.Label uxBorrow_TimesLabel;
		
		/// <summary>
		/// CheckBox for the IsLost property.
		/// </summary>
		protected System.Windows.Forms.CheckBox uxIsLost;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the IsLost property.
		/// </summary>
		protected System.Windows.Forms.Label uxIsLostLabel;
		
		/// <summary>
		/// ComboBox for the Type_ID property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxType_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Type_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxType_IDLabel;
		
		/// <summary>
		/// ComboBox for the Publisher_ID property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxPublisher_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Publisher_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxPublisher_IDLabel;
		
		/// <summary>
		/// TextBox for the Papers_no property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPapers_no;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Papers_no property.
		/// </summary>
		protected System.Windows.Forms.Label uxPapers_noLabel;
		
		/// <summary>
		/// ComboBox for the Introducer_ID property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxIntroducer_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Introducer_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxIntroducer_IDLabel;
		
		/// <summary>
		/// ComboBox for the EmployeeI_D property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxEmployeeI_D;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the EmployeeI_D property.
		/// </summary>
		protected System.Windows.Forms.Label uxEmployeeI_DLabel;
		
		/// <summary>
		/// TextBox for the Size property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxSize;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Size property.
		/// </summary>
		protected System.Windows.Forms.Label uxSizeLabel;
		
		/// <summary>
		/// TextBox for the Price property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPrice;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Price property.
		/// </summary>
		protected System.Windows.Forms.Label uxPriceLabel;
		
		/// <summary>
		/// TextBox for the Pdf_Link property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxPdf_Link;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Pdf_Link property.
		/// </summary>
		protected System.Windows.Forms.Label uxPdf_LinkLabel;
		
		/// <summary>
		/// ComboBox for the Image_ID property.
		/// </summary>
		protected System.Windows.Forms.ComboBox uxImage_ID;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the Image_ID property.
		/// </summary>
		protected System.Windows.Forms.Label uxImage_IDLabel;
		
		/// <summary>
		/// TextBox for the ISBN property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxISBN;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the ISBN property.
		/// </summary>
		protected System.Windows.Forms.Label uxISBNLabel;
		
		/// <summary>
		/// DataTimePicker for the CreatedOn property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxCreatedOn;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CreatedOn property.
		/// </summary>
		protected System.Windows.Forms.Label uxCreatedOnLabel;
		
		/// <summary>
		/// TextBox for the CreatedBy property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxCreatedBy;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the CreatedBy property.
		/// </summary>
		protected System.Windows.Forms.Label uxCreatedByLabel;
		
		/// <summary>
		/// DataTimePicker for the UpdatedOn property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxUpdatedOn;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UpdatedOn property.
		/// </summary>
		protected System.Windows.Forms.Label uxUpdatedOnLabel;
		
		/// <summary>
		/// TextBox for the UpdatedBy property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxUpdatedBy;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the UpdatedBy property.
		/// </summary>
		protected System.Windows.Forms.Label uxUpdatedByLabel;
		
		/// <summary>
		/// DataTimePicker for the DeletedOn property.
		/// </summary>
		protected System.Windows.Forms.DateTimePicker uxDeletedOn;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DeletedOn property.
		/// </summary>
		protected System.Windows.Forms.Label uxDeletedOnLabel;
		
		/// <summary>
		/// TextBox for the DeletedBy property. 
		/// </summary>
		protected System.Windows.Forms.TextBox uxDeletedBy;
		
		/// <summary>
		/// The <see cref="System.Windows.Forms.Label"/> associated with the DeletedBy property.
		/// </summary>
		protected System.Windows.Forms.Label uxDeletedByLabel;
		#endregion
		
		#region Main entity
		private BLL.Book _Book;
		/// <summary>
		/// Gets or sets the <see cref="BLL.Book"/> entity to edit with this form.
		/// </summary>
		/// <value>The <see cref="BLL.Book"/> instance.</value>
		public BLL.Book Book
		{
			get {return this._Book;}
			set
			{
				this._Book = value;
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
			this.uxName.DataBindings.Clear();
			this.uxName.DataBindings.Add("Text", this.uxBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPublisher.DataBindings.Clear();
			this.uxPublisher.DataBindings.Add("Text", this.uxBindingSource, "Publisher", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPublish_Date.DataBindings.Clear();
			this.uxPublish_Date.DataBindings.Add("Value", this.uxBindingSource, "Publish_Date", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIsAvailablePdf.DataBindings.Clear();
			this.uxIsAvailablePdf.DataBindings.Add("Checked", this.uxBindingSource, "IsAvailablePdf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIsAvailablePaper.DataBindings.Clear();
			this.uxIsAvailablePaper.DataBindings.Add("Checked", this.uxBindingSource, "IsAvailablePaper", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIsBorrowed.DataBindings.Clear();
			this.uxIsBorrowed.DataBindings.Add("Checked", this.uxBindingSource, "IsBorrowed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUser_ID.DataBindings.Clear();
			this.uxUser_ID.DataBindings.Add("Text", this.uxBindingSource, "User_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBorrowDate.DataBindings.Clear();
			this.uxBorrowDate.DataBindings.Add("Value", this.uxBindingSource, "BorrowDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxBorrow_Times.DataBindings.Clear();
			this.uxBorrow_Times.DataBindings.Add("Text", this.uxBindingSource, "Borrow_Times", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIsLost.DataBindings.Clear();
			this.uxIsLost.DataBindings.Add("Checked", this.uxBindingSource, "IsLost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxType_ID.DataBindings.Clear();
			this.uxType_ID.DataBindings.Add("SelectedValue", this.uxBindingSource, "Type_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPublisher_ID.DataBindings.Clear();
			this.uxPublisher_ID.DataBindings.Add("SelectedValue", this.uxBindingSource, "Publisher_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPapers_no.DataBindings.Clear();
			this.uxPapers_no.DataBindings.Add("Text", this.uxBindingSource, "Papers_no", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxIntroducer_ID.DataBindings.Clear();
			this.uxIntroducer_ID.DataBindings.Add("SelectedValue", this.uxBindingSource, "Introducer_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxEmployeeI_D.DataBindings.Clear();
			this.uxEmployeeI_D.DataBindings.Add("SelectedValue", this.uxBindingSource, "EmployeeI_D", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxSize.DataBindings.Clear();
			this.uxSize.DataBindings.Add("Text", this.uxBindingSource, "Size", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPrice.DataBindings.Clear();
			this.uxPrice.DataBindings.Add("Text", this.uxBindingSource, "Price", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxPdf_Link.DataBindings.Clear();
			this.uxPdf_Link.DataBindings.Add("Text", this.uxBindingSource, "Pdf_Link", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxImage_ID.DataBindings.Clear();
			this.uxImage_ID.DataBindings.Add("SelectedValue", this.uxBindingSource, "Image_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxISBN.DataBindings.Clear();
			this.uxISBN.DataBindings.Add("Text", this.uxBindingSource, "ISBN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCreatedOn.DataBindings.Clear();
			this.uxCreatedOn.DataBindings.Add("Value", this.uxBindingSource, "CreatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxCreatedBy.DataBindings.Clear();
			this.uxCreatedBy.DataBindings.Add("Text", this.uxBindingSource, "CreatedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUpdatedOn.DataBindings.Clear();
			this.uxUpdatedOn.DataBindings.Add("Value", this.uxBindingSource, "UpdatedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxUpdatedBy.DataBindings.Clear();
			this.uxUpdatedBy.DataBindings.Add("Text", this.uxBindingSource, "UpdatedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDeletedOn.DataBindings.Clear();
			this.uxDeletedOn.DataBindings.Add("Value", this.uxBindingSource, "DeletedOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
			this.uxDeletedBy.DataBindings.Clear();
			this.uxDeletedBy.DataBindings.Add("Text", this.uxBindingSource, "DeletedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
		}					
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the <see cref="BookEditControlBase"/> class.
		/// </summary>
		public BookEditControlBase()
		{
			InitializeComponent();			
			
			this.uxBindingSource.CurrentItemChanged += new System.EventHandler(uxBindingSource_currentItemChanged);
		}		
		
		/// <summary>
		/// 
		/// </summary>
		private void uxBindingSource_currentItemChanged(object sender, System.EventArgs e)
		{
			if (_Book != null) _Book.Validate();
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
			this.uxName = new System.Windows.Forms.TextBox();
			uxNameLabel = new System.Windows.Forms.Label();
			this.uxPublisher = new System.Windows.Forms.TextBox();
			uxPublisherLabel = new System.Windows.Forms.Label();
			this.uxPublish_Date = new System.Windows.Forms.DateTimePicker();
			uxPublish_DateLabel = new System.Windows.Forms.Label();
			this.uxIsAvailablePdf = new System.Windows.Forms.CheckBox();
			uxIsAvailablePdfLabel = new System.Windows.Forms.Label();
			this.uxIsAvailablePaper = new System.Windows.Forms.CheckBox();
			uxIsAvailablePaperLabel = new System.Windows.Forms.Label();
			this.uxIsBorrowed = new System.Windows.Forms.CheckBox();
			uxIsBorrowedLabel = new System.Windows.Forms.Label();
			this.uxUser_ID = new System.Windows.Forms.TextBox();
			uxUser_IDLabel = new System.Windows.Forms.Label();
			this.uxBorrowDate = new System.Windows.Forms.DateTimePicker();
			uxBorrowDateLabel = new System.Windows.Forms.Label();
			this.uxBorrow_Times = new System.Windows.Forms.TextBox();
			uxBorrow_TimesLabel = new System.Windows.Forms.Label();
			this.uxIsLost = new System.Windows.Forms.CheckBox();
			uxIsLostLabel = new System.Windows.Forms.Label();
			this.uxType_ID = new System.Windows.Forms.ComboBox();
			uxType_IDLabel = new System.Windows.Forms.Label();
			this.uxPublisher_ID = new System.Windows.Forms.ComboBox();
			uxPublisher_IDLabel = new System.Windows.Forms.Label();
			this.uxPapers_no = new System.Windows.Forms.TextBox();
			uxPapers_noLabel = new System.Windows.Forms.Label();
			this.uxIntroducer_ID = new System.Windows.Forms.ComboBox();
			uxIntroducer_IDLabel = new System.Windows.Forms.Label();
			this.uxEmployeeI_D = new System.Windows.Forms.ComboBox();
			uxEmployeeI_DLabel = new System.Windows.Forms.Label();
			this.uxSize = new System.Windows.Forms.TextBox();
			uxSizeLabel = new System.Windows.Forms.Label();
			this.uxPrice = new System.Windows.Forms.TextBox();
			uxPriceLabel = new System.Windows.Forms.Label();
			this.uxPdf_Link = new System.Windows.Forms.TextBox();
			uxPdf_LinkLabel = new System.Windows.Forms.Label();
			this.uxImage_ID = new System.Windows.Forms.ComboBox();
			uxImage_IDLabel = new System.Windows.Forms.Label();
			this.uxISBN = new System.Windows.Forms.TextBox();
			uxISBNLabel = new System.Windows.Forms.Label();
			this.uxCreatedOn = new System.Windows.Forms.DateTimePicker();
			uxCreatedOnLabel = new System.Windows.Forms.Label();
			this.uxCreatedBy = new System.Windows.Forms.TextBox();
			uxCreatedByLabel = new System.Windows.Forms.Label();
			this.uxUpdatedOn = new System.Windows.Forms.DateTimePicker();
			uxUpdatedOnLabel = new System.Windows.Forms.Label();
			this.uxUpdatedBy = new System.Windows.Forms.TextBox();
			uxUpdatedByLabel = new System.Windows.Forms.Label();
			this.uxDeletedOn = new System.Windows.Forms.DateTimePicker();
			uxDeletedOnLabel = new System.Windows.Forms.Label();
			this.uxDeletedBy = new System.Windows.Forms.TextBox();
			uxDeletedByLabel = new System.Windows.Forms.Label();
			
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
			// uxNameLabel
			//
			this.uxNameLabel.Name = "uxNameLabel";
			this.uxNameLabel.Text = "Name:";
			this.uxNameLabel.Location = new System.Drawing.Point(3, 26);
			this.Controls.Add(this.uxNameLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxNameLabel);			
			//
			// uxName
			//
			this.uxName.Name = "uxName";
			this.uxName.Width = 250;
			this.uxName.MaxLength = 100;
			//this.uxTableLayoutPanel.Controls.Add(this.uxName);
			this.uxName.Location = new System.Drawing.Point(160, 26);
			this.Controls.Add(this.uxName);
			//
			// uxPublisherLabel
			//
			this.uxPublisherLabel.Name = "uxPublisherLabel";
			this.uxPublisherLabel.Text = "Publisher:";
			this.uxPublisherLabel.Location = new System.Drawing.Point(3, 52);
			this.Controls.Add(this.uxPublisherLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPublisherLabel);			
			//
			// uxPublisher
			//
			this.uxPublisher.Name = "uxPublisher";
			this.uxPublisher.Width = 250;
			this.uxPublisher.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPublisher);
			this.uxPublisher.Location = new System.Drawing.Point(160, 52);
			this.Controls.Add(this.uxPublisher);
			//
			// uxPublish_DateLabel
			//
			this.uxPublish_DateLabel.Name = "uxPublish_DateLabel";
			this.uxPublish_DateLabel.Text = "Publish Date:";
			this.uxPublish_DateLabel.Location = new System.Drawing.Point(3, 78);
			this.Controls.Add(this.uxPublish_DateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPublish_DateLabel);			
			//
			// uxPublish_Date
			//
			this.uxPublish_Date.Name = "uxPublish_Date";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPublish_Date);
			this.uxPublish_Date.Location = new System.Drawing.Point(160, 78);
			this.Controls.Add(this.uxPublish_Date);
			//
			// uxIsAvailablePdfLabel
			//
			this.uxIsAvailablePdfLabel.Name = "uxIsAvailablePdfLabel";
			this.uxIsAvailablePdfLabel.Text = "Is Available Pdf:";
			this.uxIsAvailablePdfLabel.Location = new System.Drawing.Point(3, 104);
			this.Controls.Add(this.uxIsAvailablePdfLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsAvailablePdfLabel);			
			//
			// uxIsAvailablePdf
			//
			this.uxIsAvailablePdf.Name = "uxIsAvailablePdf";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsAvailablePdf);
			this.uxIsAvailablePdf.Location = new System.Drawing.Point(160, 104);
			this.Controls.Add(this.uxIsAvailablePdf);
			//
			// uxIsAvailablePaperLabel
			//
			this.uxIsAvailablePaperLabel.Name = "uxIsAvailablePaperLabel";
			this.uxIsAvailablePaperLabel.Text = "Is Available Paper:";
			this.uxIsAvailablePaperLabel.Location = new System.Drawing.Point(3, 130);
			this.Controls.Add(this.uxIsAvailablePaperLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsAvailablePaperLabel);			
			//
			// uxIsAvailablePaper
			//
			this.uxIsAvailablePaper.Name = "uxIsAvailablePaper";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsAvailablePaper);
			this.uxIsAvailablePaper.Location = new System.Drawing.Point(160, 130);
			this.Controls.Add(this.uxIsAvailablePaper);
			//
			// uxIsBorrowedLabel
			//
			this.uxIsBorrowedLabel.Name = "uxIsBorrowedLabel";
			this.uxIsBorrowedLabel.Text = "Is Borrowed:";
			this.uxIsBorrowedLabel.Location = new System.Drawing.Point(3, 156);
			this.Controls.Add(this.uxIsBorrowedLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsBorrowedLabel);			
			//
			// uxIsBorrowed
			//
			this.uxIsBorrowed.Name = "uxIsBorrowed";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsBorrowed);
			this.uxIsBorrowed.Location = new System.Drawing.Point(160, 156);
			this.Controls.Add(this.uxIsBorrowed);
			//
			// uxUser_IDLabel
			//
			this.uxUser_IDLabel.Name = "uxUser_IDLabel";
			this.uxUser_IDLabel.Text = "UserID:";
			this.uxUser_IDLabel.Location = new System.Drawing.Point(3, 182);
			this.Controls.Add(this.uxUser_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUser_IDLabel);			
			//
			// uxUser_ID
			//
			this.uxUser_ID.Name = "uxUser_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUser_ID);
			this.uxUser_ID.Location = new System.Drawing.Point(160, 182);
			this.Controls.Add(this.uxUser_ID);
			//
			// uxBorrowDateLabel
			//
			this.uxBorrowDateLabel.Name = "uxBorrowDateLabel";
			this.uxBorrowDateLabel.Text = "Borrow Date:";
			this.uxBorrowDateLabel.Location = new System.Drawing.Point(3, 208);
			this.Controls.Add(this.uxBorrowDateLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBorrowDateLabel);			
			//
			// uxBorrowDate
			//
			this.uxBorrowDate.Name = "uxBorrowDate";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBorrowDate);
			this.uxBorrowDate.Location = new System.Drawing.Point(160, 208);
			this.Controls.Add(this.uxBorrowDate);
			//
			// uxBorrow_TimesLabel
			//
			this.uxBorrow_TimesLabel.Name = "uxBorrow_TimesLabel";
			this.uxBorrow_TimesLabel.Text = "Borrow Times:";
			this.uxBorrow_TimesLabel.Location = new System.Drawing.Point(3, 234);
			this.Controls.Add(this.uxBorrow_TimesLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxBorrow_TimesLabel);			
			//
			// uxBorrow_Times
			//
			this.uxBorrow_Times.Name = "uxBorrow_Times";
			//this.uxTableLayoutPanel.Controls.Add(this.uxBorrow_Times);
			this.uxBorrow_Times.Location = new System.Drawing.Point(160, 234);
			this.Controls.Add(this.uxBorrow_Times);
			//
			// uxIsLostLabel
			//
			this.uxIsLostLabel.Name = "uxIsLostLabel";
			this.uxIsLostLabel.Text = "Is Lost:";
			this.uxIsLostLabel.Location = new System.Drawing.Point(3, 260);
			this.Controls.Add(this.uxIsLostLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsLostLabel);			
			//
			// uxIsLost
			//
			this.uxIsLost.Name = "uxIsLost";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIsLost);
			this.uxIsLost.Location = new System.Drawing.Point(160, 260);
			this.Controls.Add(this.uxIsLost);
			//
			// uxType_IDLabel
			//
			this.uxType_IDLabel.Name = "uxType_IDLabel";
			this.uxType_IDLabel.Text = "TypeID:";
			this.uxType_IDLabel.Location = new System.Drawing.Point(3, 286);
			this.Controls.Add(this.uxType_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxType_IDLabel);			
			//
			// uxType_ID
			//
			this.uxType_ID.Name = "uxType_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxType_ID);
			this.uxType_ID.Location = new System.Drawing.Point(160, 286);
			this.Controls.Add(this.uxType_ID);
			//
			// uxPublisher_IDLabel
			//
			this.uxPublisher_IDLabel.Name = "uxPublisher_IDLabel";
			this.uxPublisher_IDLabel.Text = "PublisherID:";
			this.uxPublisher_IDLabel.Location = new System.Drawing.Point(3, 312);
			this.Controls.Add(this.uxPublisher_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPublisher_IDLabel);			
			//
			// uxPublisher_ID
			//
			this.uxPublisher_ID.Name = "uxPublisher_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPublisher_ID);
			this.uxPublisher_ID.Location = new System.Drawing.Point(160, 312);
			this.Controls.Add(this.uxPublisher_ID);
			//
			// uxPapers_noLabel
			//
			this.uxPapers_noLabel.Name = "uxPapers_noLabel";
			this.uxPapers_noLabel.Text = "Papersno:";
			this.uxPapers_noLabel.Location = new System.Drawing.Point(3, 338);
			this.Controls.Add(this.uxPapers_noLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPapers_noLabel);			
			//
			// uxPapers_no
			//
			this.uxPapers_no.Name = "uxPapers_no";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPapers_no);
			this.uxPapers_no.Location = new System.Drawing.Point(160, 338);
			this.Controls.Add(this.uxPapers_no);
			//
			// uxIntroducer_IDLabel
			//
			this.uxIntroducer_IDLabel.Name = "uxIntroducer_IDLabel";
			this.uxIntroducer_IDLabel.Text = "IntroducerID:";
			this.uxIntroducer_IDLabel.Location = new System.Drawing.Point(3, 364);
			this.Controls.Add(this.uxIntroducer_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxIntroducer_IDLabel);			
			//
			// uxIntroducer_ID
			//
			this.uxIntroducer_ID.Name = "uxIntroducer_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxIntroducer_ID);
			this.uxIntroducer_ID.Location = new System.Drawing.Point(160, 364);
			this.Controls.Add(this.uxIntroducer_ID);
			//
			// uxEmployeeI_DLabel
			//
			this.uxEmployeeI_DLabel.Name = "uxEmployeeI_DLabel";
			this.uxEmployeeI_DLabel.Text = "Employee ID:";
			this.uxEmployeeI_DLabel.Location = new System.Drawing.Point(3, 390);
			this.Controls.Add(this.uxEmployeeI_DLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeI_DLabel);			
			//
			// uxEmployeeI_D
			//
			this.uxEmployeeI_D.Name = "uxEmployeeI_D";
			//this.uxTableLayoutPanel.Controls.Add(this.uxEmployeeI_D);
			this.uxEmployeeI_D.Location = new System.Drawing.Point(160, 390);
			this.Controls.Add(this.uxEmployeeI_D);
			//
			// uxSizeLabel
			//
			this.uxSizeLabel.Name = "uxSizeLabel";
			this.uxSizeLabel.Text = "Size:";
			this.uxSizeLabel.Location = new System.Drawing.Point(3, 416);
			this.Controls.Add(this.uxSizeLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxSizeLabel);			
			//
			// uxSize
			//
			this.uxSize.Name = "uxSize";
			//this.uxTableLayoutPanel.Controls.Add(this.uxSize);
			this.uxSize.Location = new System.Drawing.Point(160, 416);
			this.Controls.Add(this.uxSize);
			//
			// uxPriceLabel
			//
			this.uxPriceLabel.Name = "uxPriceLabel";
			this.uxPriceLabel.Text = "Price:";
			this.uxPriceLabel.Location = new System.Drawing.Point(3, 442);
			this.Controls.Add(this.uxPriceLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPriceLabel);			
			//
			// uxPrice
			//
			this.uxPrice.Name = "uxPrice";
			//this.uxTableLayoutPanel.Controls.Add(this.uxPrice);
			this.uxPrice.Location = new System.Drawing.Point(160, 442);
			this.Controls.Add(this.uxPrice);
			//
			// uxPdf_LinkLabel
			//
			this.uxPdf_LinkLabel.Name = "uxPdf_LinkLabel";
			this.uxPdf_LinkLabel.Text = "Pdf Link:";
			this.uxPdf_LinkLabel.Location = new System.Drawing.Point(3, 468);
			this.Controls.Add(this.uxPdf_LinkLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxPdf_LinkLabel);			
			//
			// uxPdf_Link
			//
			this.uxPdf_Link.Name = "uxPdf_Link";
			this.uxPdf_Link.Width = 250;
			this.uxPdf_Link.MaxLength = 250;
			//this.uxTableLayoutPanel.Controls.Add(this.uxPdf_Link);
			this.uxPdf_Link.Location = new System.Drawing.Point(160, 468);
			this.Controls.Add(this.uxPdf_Link);
			//
			// uxImage_IDLabel
			//
			this.uxImage_IDLabel.Name = "uxImage_IDLabel";
			this.uxImage_IDLabel.Text = "ImageID:";
			this.uxImage_IDLabel.Location = new System.Drawing.Point(3, 494);
			this.Controls.Add(this.uxImage_IDLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxImage_IDLabel);			
			//
			// uxImage_ID
			//
			this.uxImage_ID.Name = "uxImage_ID";
			//this.uxTableLayoutPanel.Controls.Add(this.uxImage_ID);
			this.uxImage_ID.Location = new System.Drawing.Point(160, 494);
			this.Controls.Add(this.uxImage_ID);
			//
			// uxISBNLabel
			//
			this.uxISBNLabel.Name = "uxISBNLabel";
			this.uxISBNLabel.Text = "ISBN:";
			this.uxISBNLabel.Location = new System.Drawing.Point(3, 520);
			this.Controls.Add(this.uxISBNLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxISBNLabel);			
			//
			// uxISBN
			//
			this.uxISBN.Name = "uxISBN";
			this.uxISBN.Width = 250;
			this.uxISBN.MaxLength = 50;
			//this.uxTableLayoutPanel.Controls.Add(this.uxISBN);
			this.uxISBN.Location = new System.Drawing.Point(160, 520);
			this.Controls.Add(this.uxISBN);
			//
			// uxCreatedOnLabel
			//
			this.uxCreatedOnLabel.Name = "uxCreatedOnLabel";
			this.uxCreatedOnLabel.Text = "Created On:";
			this.uxCreatedOnLabel.Location = new System.Drawing.Point(3, 546);
			this.Controls.Add(this.uxCreatedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedOnLabel);			
			//
			// uxCreatedOn
			//
			this.uxCreatedOn.Name = "uxCreatedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedOn);
			this.uxCreatedOn.Location = new System.Drawing.Point(160, 546);
			this.Controls.Add(this.uxCreatedOn);
			//
			// uxCreatedByLabel
			//
			this.uxCreatedByLabel.Name = "uxCreatedByLabel";
			this.uxCreatedByLabel.Text = "Created By:";
			this.uxCreatedByLabel.Location = new System.Drawing.Point(3, 572);
			this.Controls.Add(this.uxCreatedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedByLabel);			
			//
			// uxCreatedBy
			//
			this.uxCreatedBy.Name = "uxCreatedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxCreatedBy);
			this.uxCreatedBy.Location = new System.Drawing.Point(160, 572);
			this.Controls.Add(this.uxCreatedBy);
			//
			// uxUpdatedOnLabel
			//
			this.uxUpdatedOnLabel.Name = "uxUpdatedOnLabel";
			this.uxUpdatedOnLabel.Text = "Updated On:";
			this.uxUpdatedOnLabel.Location = new System.Drawing.Point(3, 598);
			this.Controls.Add(this.uxUpdatedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedOnLabel);			
			//
			// uxUpdatedOn
			//
			this.uxUpdatedOn.Name = "uxUpdatedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedOn);
			this.uxUpdatedOn.Location = new System.Drawing.Point(160, 598);
			this.Controls.Add(this.uxUpdatedOn);
			//
			// uxUpdatedByLabel
			//
			this.uxUpdatedByLabel.Name = "uxUpdatedByLabel";
			this.uxUpdatedByLabel.Text = "Updated By:";
			this.uxUpdatedByLabel.Location = new System.Drawing.Point(3, 624);
			this.Controls.Add(this.uxUpdatedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedByLabel);			
			//
			// uxUpdatedBy
			//
			this.uxUpdatedBy.Name = "uxUpdatedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxUpdatedBy);
			this.uxUpdatedBy.Location = new System.Drawing.Point(160, 624);
			this.Controls.Add(this.uxUpdatedBy);
			//
			// uxDeletedOnLabel
			//
			this.uxDeletedOnLabel.Name = "uxDeletedOnLabel";
			this.uxDeletedOnLabel.Text = "Deleted On:";
			this.uxDeletedOnLabel.Location = new System.Drawing.Point(3, 650);
			this.Controls.Add(this.uxDeletedOnLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedOnLabel);			
			//
			// uxDeletedOn
			//
			this.uxDeletedOn.Name = "uxDeletedOn";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedOn);
			this.uxDeletedOn.Location = new System.Drawing.Point(160, 650);
			this.Controls.Add(this.uxDeletedOn);
			//
			// uxDeletedByLabel
			//
			this.uxDeletedByLabel.Name = "uxDeletedByLabel";
			this.uxDeletedByLabel.Text = "Deleted By:";
			this.uxDeletedByLabel.Location = new System.Drawing.Point(3, 676);
			this.Controls.Add(this.uxDeletedByLabel);
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedByLabel);			
			//
			// uxDeletedBy
			//
			this.uxDeletedBy.Name = "uxDeletedBy";
			//this.uxTableLayoutPanel.Controls.Add(this.uxDeletedBy);
			this.uxDeletedBy.Location = new System.Drawing.Point(160, 676);
			this.Controls.Add(this.uxDeletedBy);
			//
			// uxType_ID
			//				
			this.uxType_ID.DisplayMember = "TypeName";	
			this.uxType_ID.ValueMember = "ID";	
			//
			// uxEmployeeI_D
			//				
			this.uxEmployeeI_D.DisplayMember = "UserName";	
			this.uxEmployeeI_D.ValueMember = "ID";	
			//
			// uxImage_ID
			//				
			this.uxImage_ID.DisplayMember = "Name";	
			this.uxImage_ID.ValueMember = "ID";	
			//
			// uxIntroducer_ID
			//				
			this.uxIntroducer_ID.DisplayMember = "Name";	
			this.uxIntroducer_ID.ValueMember = "ID";	
			//
			// uxPublisher_ID
			//				
			this.uxPublisher_ID.DisplayMember = "Name";	
			this.uxPublisher_ID.ValueMember = "ID";	
			// 
			// BookEditControlBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.uxTableLayoutPanel);
			this.AutoScroll = true;
			this.Name = "BookEditControlBase";
			this.Size = new System.Drawing.Size(478, 311);
			//this.Localizable = true;
			((System.ComponentModel.ISupportInitialize)(this.uxErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uxBindingSource)).EndInit();			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
				
		#region ComboBox List
		
				
		private BLL.TList<BLL.BookType> _Type_IDList;
		
		/// <summary>
		/// The ComboBox associated with the Type_ID property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public BLL.TList<BLL.BookType> Type_IDList
		{
			get {return _Type_IDList;}
			set 
			{
				this._Type_IDList = value;
				this.uxType_ID.DataSource = null;
				this.uxType_ID.DataSource = value;
			}
		}
		
		private bool _allowNewItemInType_IDList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the Type_ID property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInType_IDList
		{
			get { return _allowNewItemInType_IDList;}
			set
			{
				this._allowNewItemInType_IDList = value;
				this.uxType_ID.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private BLL.TList<BLL.Employee> _EmployeeI_DList;
		
		/// <summary>
		/// The ComboBox associated with the EmployeeI_D property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public BLL.TList<BLL.Employee> EmployeeI_DList
		{
			get {return _EmployeeI_DList;}
			set 
			{
				this._EmployeeI_DList = value;
				this.uxEmployeeI_D.DataSource = null;
				this.uxEmployeeI_D.DataSource = value;
			}
		}
		
		private bool _allowNewItemInEmployeeI_DList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the EmployeeI_D property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInEmployeeI_DList
		{
			get { return _allowNewItemInEmployeeI_DList;}
			set
			{
				this._allowNewItemInEmployeeI_DList = value;
				this.uxEmployeeI_D.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private BLL.TList<BLL.BookImage> _Image_IDList;
		
		/// <summary>
		/// The ComboBox associated with the Image_ID property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public BLL.TList<BLL.BookImage> Image_IDList
		{
			get {return _Image_IDList;}
			set 
			{
				this._Image_IDList = value;
				this.uxImage_ID.DataSource = null;
				this.uxImage_ID.DataSource = value;
			}
		}
		
		private bool _allowNewItemInImage_IDList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the Image_ID property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInImage_IDList
		{
			get { return _allowNewItemInImage_IDList;}
			set
			{
				this._allowNewItemInImage_IDList = value;
				this.uxImage_ID.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private BLL.TList<BLL.Introducer> _Introducer_IDList;
		
		/// <summary>
		/// The ComboBox associated with the Introducer_ID property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public BLL.TList<BLL.Introducer> Introducer_IDList
		{
			get {return _Introducer_IDList;}
			set 
			{
				this._Introducer_IDList = value;
				this.uxIntroducer_ID.DataSource = null;
				this.uxIntroducer_ID.DataSource = value;
			}
		}
		
		private bool _allowNewItemInIntroducer_IDList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the Introducer_ID property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInIntroducer_IDList
		{
			get { return _allowNewItemInIntroducer_IDList;}
			set
			{
				this._allowNewItemInIntroducer_IDList = value;
				this.uxIntroducer_ID.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
			}
		}
		
				
		private BLL.TList<BLL.Publisher> _Publisher_IDList;
		
		/// <summary>
		/// The ComboBox associated with the Publisher_ID property.
		/// </summary>
		[System.ComponentModel.Category("ComboBox BindingSources")]
		public BLL.TList<BLL.Publisher> Publisher_IDList
		{
			get {return _Publisher_IDList;}
			set 
			{
				this._Publisher_IDList = value;
				this.uxPublisher_ID.DataSource = null;
				this.uxPublisher_ID.DataSource = value;
			}
		}
		
		private bool _allowNewItemInPublisher_IDList;
		
		/// <summary>
		/// Indicates if the ComboBox associated with the Publisher_ID property allow user to add item.
		/// </summary>
		[System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Indicates if end user can add a new item in the combobox. an event will be thrown then.")]
		public bool AllowNewItemInPublisher_IDList
		{
			get { return _allowNewItemInPublisher_IDList;}
			set
			{
				this._allowNewItemInPublisher_IDList = value;
				this.uxPublisher_ID.DropDownStyle = value ? System.Windows.Forms.ComboBoxStyle.DropDown : System.Windows.Forms.ComboBoxStyle.DropDownList;
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
        /// Indicates if the controls associated with the uxName property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxNameVisible
        {
            get { return this.uxName.Visible; }
            set
            {
                this.uxNameLabel.Visible = value;
                this.uxName.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxName property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxNameEnabled
        {
            get { return this.uxName.Enabled; }
            set
            {
                this.uxName.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPublisher property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPublisherVisible
        {
            get { return this.uxPublisher.Visible; }
            set
            {
                this.uxPublisherLabel.Visible = value;
                this.uxPublisher.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPublisher property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPublisherEnabled
        {
            get { return this.uxPublisher.Enabled; }
            set
            {
                this.uxPublisher.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPublish_Date property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPublish_DateVisible
        {
            get { return this.uxPublish_Date.Visible; }
            set
            {
                this.uxPublish_DateLabel.Visible = value;
                this.uxPublish_Date.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPublish_Date property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPublish_DateEnabled
        {
            get { return this.uxPublish_Date.Enabled; }
            set
            {
                this.uxPublish_Date.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIsAvailablePdf property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIsAvailablePdfVisible
        {
            get { return this.uxIsAvailablePdf.Visible; }
            set
            {
                this.uxIsAvailablePdfLabel.Visible = value;
                this.uxIsAvailablePdf.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIsAvailablePdf property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIsAvailablePdfEnabled
        {
            get { return this.uxIsAvailablePdf.Enabled; }
            set
            {
                this.uxIsAvailablePdf.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIsAvailablePaper property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIsAvailablePaperVisible
        {
            get { return this.uxIsAvailablePaper.Visible; }
            set
            {
                this.uxIsAvailablePaperLabel.Visible = value;
                this.uxIsAvailablePaper.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIsAvailablePaper property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIsAvailablePaperEnabled
        {
            get { return this.uxIsAvailablePaper.Enabled; }
            set
            {
                this.uxIsAvailablePaper.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIsBorrowed property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIsBorrowedVisible
        {
            get { return this.uxIsBorrowed.Visible; }
            set
            {
                this.uxIsBorrowedLabel.Visible = value;
                this.uxIsBorrowed.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIsBorrowed property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIsBorrowedEnabled
        {
            get { return this.uxIsBorrowed.Enabled; }
            set
            {
                this.uxIsBorrowed.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUser_ID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUser_IDVisible
        {
            get { return this.uxUser_ID.Visible; }
            set
            {
                this.uxUser_IDLabel.Visible = value;
                this.uxUser_ID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUser_ID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUser_IDEnabled
        {
            get { return this.uxUser_ID.Enabled; }
            set
            {
                this.uxUser_ID.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxBorrowDate property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBorrowDateVisible
        {
            get { return this.uxBorrowDate.Visible; }
            set
            {
                this.uxBorrowDateLabel.Visible = value;
                this.uxBorrowDate.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBorrowDate property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBorrowDateEnabled
        {
            get { return this.uxBorrowDate.Enabled; }
            set
            {
                this.uxBorrowDate.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxBorrow_Times property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxBorrow_TimesVisible
        {
            get { return this.uxBorrow_Times.Visible; }
            set
            {
                this.uxBorrow_TimesLabel.Visible = value;
                this.uxBorrow_Times.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxBorrow_Times property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxBorrow_TimesEnabled
        {
            get { return this.uxBorrow_Times.Enabled; }
            set
            {
                this.uxBorrow_Times.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIsLost property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIsLostVisible
        {
            get { return this.uxIsLost.Visible; }
            set
            {
                this.uxIsLostLabel.Visible = value;
                this.uxIsLost.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIsLost property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIsLostEnabled
        {
            get { return this.uxIsLost.Enabled; }
            set
            {
                this.uxIsLost.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxType_ID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxType_IDVisible
        {
            get { return this.uxType_ID.Visible; }
            set
            {
                this.uxType_IDLabel.Visible = value;
                this.uxType_ID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxType_ID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxType_IDEnabled
        {
            get { return this.uxType_ID.Enabled; }
            set
            {
                this.uxType_ID.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPublisher_ID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPublisher_IDVisible
        {
            get { return this.uxPublisher_ID.Visible; }
            set
            {
                this.uxPublisher_IDLabel.Visible = value;
                this.uxPublisher_ID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPublisher_ID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPublisher_IDEnabled
        {
            get { return this.uxPublisher_ID.Enabled; }
            set
            {
                this.uxPublisher_ID.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPapers_no property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPapers_noVisible
        {
            get { return this.uxPapers_no.Visible; }
            set
            {
                this.uxPapers_noLabel.Visible = value;
                this.uxPapers_no.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPapers_no property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPapers_noEnabled
        {
            get { return this.uxPapers_no.Enabled; }
            set
            {
                this.uxPapers_no.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxIntroducer_ID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxIntroducer_IDVisible
        {
            get { return this.uxIntroducer_ID.Visible; }
            set
            {
                this.uxIntroducer_IDLabel.Visible = value;
                this.uxIntroducer_ID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxIntroducer_ID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxIntroducer_IDEnabled
        {
            get { return this.uxIntroducer_ID.Enabled; }
            set
            {
                this.uxIntroducer_ID.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeI_D property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxEmployeeI_DVisible
        {
            get { return this.uxEmployeeI_D.Visible; }
            set
            {
                this.uxEmployeeI_DLabel.Visible = value;
                this.uxEmployeeI_D.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxEmployeeI_D property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxEmployeeI_DEnabled
        {
            get { return this.uxEmployeeI_D.Enabled; }
            set
            {
                this.uxEmployeeI_D.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxSize property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxSizeVisible
        {
            get { return this.uxSize.Visible; }
            set
            {
                this.uxSizeLabel.Visible = value;
                this.uxSize.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxSize property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxSizeEnabled
        {
            get { return this.uxSize.Enabled; }
            set
            {
                this.uxSize.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPrice property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPriceVisible
        {
            get { return this.uxPrice.Visible; }
            set
            {
                this.uxPriceLabel.Visible = value;
                this.uxPrice.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPrice property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPriceEnabled
        {
            get { return this.uxPrice.Enabled; }
            set
            {
                this.uxPrice.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxPdf_Link property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxPdf_LinkVisible
        {
            get { return this.uxPdf_Link.Visible; }
            set
            {
                this.uxPdf_LinkLabel.Visible = value;
                this.uxPdf_Link.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxPdf_Link property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxPdf_LinkEnabled
        {
            get { return this.uxPdf_Link.Enabled; }
            set
            {
                this.uxPdf_Link.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxImage_ID property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxImage_IDVisible
        {
            get { return this.uxImage_ID.Visible; }
            set
            {
                this.uxImage_IDLabel.Visible = value;
                this.uxImage_ID.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxImage_ID property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxImage_IDEnabled
        {
            get { return this.uxImage_ID.Enabled; }
            set
            {
                this.uxImage_ID.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxISBN property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxISBNVisible
        {
            get { return this.uxISBN.Visible; }
            set
            {
                this.uxISBNLabel.Visible = value;
                this.uxISBN.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxISBN property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxISBNEnabled
        {
            get { return this.uxISBN.Enabled; }
            set
            {
                this.uxISBN.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCreatedOn property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCreatedOnVisible
        {
            get { return this.uxCreatedOn.Visible; }
            set
            {
                this.uxCreatedOnLabel.Visible = value;
                this.uxCreatedOn.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCreatedOn property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCreatedOnEnabled
        {
            get { return this.uxCreatedOn.Enabled; }
            set
            {
                this.uxCreatedOn.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxCreatedBy property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxCreatedByVisible
        {
            get { return this.uxCreatedBy.Visible; }
            set
            {
                this.uxCreatedByLabel.Visible = value;
                this.uxCreatedBy.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxCreatedBy property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxCreatedByEnabled
        {
            get { return this.uxCreatedBy.Enabled; }
            set
            {
                this.uxCreatedBy.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedOn property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUpdatedOnVisible
        {
            get { return this.uxUpdatedOn.Visible; }
            set
            {
                this.uxUpdatedOnLabel.Visible = value;
                this.uxUpdatedOn.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedOn property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUpdatedOnEnabled
        {
            get { return this.uxUpdatedOn.Enabled; }
            set
            {
                this.uxUpdatedOn.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedBy property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxUpdatedByVisible
        {
            get { return this.uxUpdatedBy.Visible; }
            set
            {
                this.uxUpdatedByLabel.Visible = value;
                this.uxUpdatedBy.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxUpdatedBy property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxUpdatedByEnabled
        {
            get { return this.uxUpdatedBy.Enabled; }
            set
            {
                this.uxUpdatedBy.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDeletedOn property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDeletedOnVisible
        {
            get { return this.uxDeletedOn.Visible; }
            set
            {
                this.uxDeletedOnLabel.Visible = value;
                this.uxDeletedOn.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDeletedOn property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDeletedOnEnabled
        {
            get { return this.uxDeletedOn.Enabled; }
            set
            {
                this.uxDeletedOn.Enabled = value;
            }
        }
        /// <summary>
        /// Indicates if the controls associated with the uxDeletedBy property should be visible.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Visible property for related controls.")]
        public bool uxDeletedByVisible
        {
            get { return this.uxDeletedBy.Visible; }
            set
            {
                this.uxDeletedByLabel.Visible = value;
                this.uxDeletedBy.Visible = value;
            }
        }

        /// <summary>
        /// Indicates if the controls associated with the uxDeletedBy property should be enabled.
        /// </summary>
        [System.ComponentModel.Category(".netTiers"), System.ComponentModel.Description("Set Enabled property for related controls.")]
        public bool uxDeletedByEnabled
        {
            get { return this.uxDeletedBy.Enabled; }
            set
            {
                this.uxDeletedBy.Enabled = value;
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
