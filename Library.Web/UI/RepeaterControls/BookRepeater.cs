using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace Library.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>BookRepeater</c>
    /// </summary>
	public class BookRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:BookRepeaterDesigner"/> class.
        /// </summary>
		public BookRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is BookRepeater))
			{ 
				throw new ArgumentException("Component is not a BookRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			BookRepeater z = (BookRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="BookRepeater"/> Type.
    /// </summary>
	[Designer(typeof(BookRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:BookRepeater runat=\"server\"></{0}:BookRepeater>")]
	public class BookRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:BookRepeater"/> class.
        /// </summary>
		public BookRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(BookItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(BookItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
        /// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(BookItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }
			
		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(BookItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(BookItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		
		
		/// <summary>
      	/// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      	/// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      	{
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						Library.BLL.Book entity = o as Library.BLL.Book;
						BookItem container = new BookItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
								
							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}
            //Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }

		}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class BookItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Library.BLL.Book _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BookItem"/> class.
        /// </summary>
		public BookItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BookItem"/> class.
        /// </summary>
		public BookItem(Library.BLL.Book entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the ID
        /// </summary>
        /// <value>The ID.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 ID
		{
			get { return _entity.ID; }
		}
        /// <summary>
        /// Gets the Name
        /// </summary>
        /// <value>The Name.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Name
		{
			get { return _entity.Name; }
		}
        /// <summary>
        /// Gets the Publisher
        /// </summary>
        /// <value>The Publisher.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Publisher
		{
			get { return _entity.Publisher; }
		}
        /// <summary>
        /// Gets the Publish_Date
        /// </summary>
        /// <value>The Publish_Date.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? Publish_Date
		{
			get { return _entity.Publish_Date; }
		}
        /// <summary>
        /// Gets the IsAvailablePdf
        /// </summary>
        /// <value>The IsAvailablePdf.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsAvailablePdf
		{
			get { return _entity.IsAvailablePdf; }
		}
        /// <summary>
        /// Gets the IsAvailablePaper
        /// </summary>
        /// <value>The IsAvailablePaper.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsAvailablePaper
		{
			get { return _entity.IsAvailablePaper; }
		}
        /// <summary>
        /// Gets the IsBorrowed
        /// </summary>
        /// <value>The IsBorrowed.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean IsBorrowed
		{
			get { return _entity.IsBorrowed; }
		}
        /// <summary>
        /// Gets the User_ID
        /// </summary>
        /// <value>The User_ID.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 User_ID
		{
			get { return _entity.User_ID; }
		}
        /// <summary>
        /// Gets the BorrowDate
        /// </summary>
        /// <value>The BorrowDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? BorrowDate
		{
			get { return _entity.BorrowDate; }
		}
        /// <summary>
        /// Gets the Borrow_Times
        /// </summary>
        /// <value>The Borrow_Times.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Borrow_Times
		{
			get { return _entity.Borrow_Times; }
		}
        /// <summary>
        /// Gets the IsLost
        /// </summary>
        /// <value>The IsLost.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsLost
		{
			get { return _entity.IsLost; }
		}
        /// <summary>
        /// Gets the Type_ID
        /// </summary>
        /// <value>The Type_ID.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Type_ID
		{
			get { return _entity.Type_ID; }
		}
        /// <summary>
        /// Gets the Publisher_ID
        /// </summary>
        /// <value>The Publisher_ID.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Publisher_ID
		{
			get { return _entity.Publisher_ID; }
		}
        /// <summary>
        /// Gets the Papers_no
        /// </summary>
        /// <value>The Papers_no.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Papers_no
		{
			get { return _entity.Papers_no; }
		}
        /// <summary>
        /// Gets the Introducer_ID
        /// </summary>
        /// <value>The Introducer_ID.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Introducer_ID
		{
			get { return _entity.Introducer_ID; }
		}
        /// <summary>
        /// Gets the EmployeeI_D
        /// </summary>
        /// <value>The EmployeeI_D.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EmployeeI_D
		{
			get { return _entity.EmployeeI_D; }
		}
        /// <summary>
        /// Gets the Size
        /// </summary>
        /// <value>The Size.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Double? Size
		{
			get { return _entity.Size; }
		}
        /// <summary>
        /// Gets the Price
        /// </summary>
        /// <value>The Price.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Price
		{
			get { return _entity.Price; }
		}
        /// <summary>
        /// Gets the Pdf_Link
        /// </summary>
        /// <value>The Pdf_Link.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Pdf_Link
		{
			get { return _entity.Pdf_Link; }
		}
        /// <summary>
        /// Gets the Image_ID
        /// </summary>
        /// <value>The Image_ID.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Image_ID
		{
			get { return _entity.Image_ID; }
		}
        /// <summary>
        /// Gets the ISBN
        /// </summary>
        /// <value>The ISBN.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ISBN
		{
			get { return _entity.ISBN; }
		}
        /// <summary>
        /// Gets the CreatedOn
        /// </summary>
        /// <value>The CreatedOn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CreatedOn
		{
			get { return _entity.CreatedOn; }
		}
        /// <summary>
        /// Gets the CreatedBy
        /// </summary>
        /// <value>The CreatedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? CreatedBy
		{
			get { return _entity.CreatedBy; }
		}
        /// <summary>
        /// Gets the UpdatedOn
        /// </summary>
        /// <value>The UpdatedOn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? UpdatedOn
		{
			get { return _entity.UpdatedOn; }
		}
        /// <summary>
        /// Gets the UpdatedBy
        /// </summary>
        /// <value>The UpdatedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? UpdatedBy
		{
			get { return _entity.UpdatedBy; }
		}
        /// <summary>
        /// Gets the DeletedOn
        /// </summary>
        /// <value>The DeletedOn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? DeletedOn
		{
			get { return _entity.DeletedOn; }
		}
        /// <summary>
        /// Gets the DeletedBy
        /// </summary>
        /// <value>The DeletedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DeletedBy
		{
			get { return _entity.DeletedBy; }
		}

        /// <summary>
        /// Gets a <see cref="T:Library.BLL.Book"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Library.BLL.Book Entity
        {
            get { return _entity; }
        }
	}
}
