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
    /// A designer class for a strongly typed repeater <c>UsersRepeater</c>
    /// </summary>
	public class UsersRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:UsersRepeaterDesigner"/> class.
        /// </summary>
		public UsersRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is UsersRepeater))
			{ 
				throw new ArgumentException("Component is not a UsersRepeater."); 
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
			UsersRepeater z = (UsersRepeater)Component;
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
    /// A strongly typed repeater control for the <see cref="UsersRepeater"/> Type.
    /// </summary>
	[Designer(typeof(UsersRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:UsersRepeater runat=\"server\"></{0}:UsersRepeater>")]
	public class UsersRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:UsersRepeater"/> class.
        /// </summary>
		public UsersRepeater()
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
		[TemplateContainer(typeof(UsersItem))]
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
		[TemplateContainer(typeof(UsersItem))]
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
        [TemplateContainer(typeof(UsersItem))]
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
		[TemplateContainer(typeof(UsersItem))]
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
		[TemplateContainer(typeof(UsersItem))]
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
						Library.BLL.Users entity = o as Library.BLL.Users;
						UsersItem container = new UsersItem(entity);
	
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
	public class UsersItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private Library.BLL.Users _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UsersItem"/> class.
        /// </summary>
		public UsersItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:UsersItem"/> class.
        /// </summary>
		public UsersItem(Library.BLL.Users entity)
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
        /// Gets the UserName
        /// </summary>
        /// <value>The UserName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UserName
		{
			get { return _entity.UserName; }
		}
        /// <summary>
        /// Gets the Password
        /// </summary>
        /// <value>The Password.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Password
		{
			get { return _entity.Password; }
		}
        /// <summary>
        /// Gets the Last_Login
        /// </summary>
        /// <value>The Last_Login.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? Last_Login
		{
			get { return _entity.Last_Login; }
		}
        /// <summary>
        /// Gets the Last_Logout
        /// </summary>
        /// <value>The Last_Logout.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? Last_Logout
		{
			get { return _entity.Last_Logout; }
		}
        /// <summary>
        /// Gets the Is_Online
        /// </summary>
        /// <value>The Is_Online.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean Is_Online
		{
			get { return _entity.Is_Online; }
		}
        /// <summary>
        /// Gets the Is_Active
        /// </summary>
        /// <value>The Is_Active.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean Is_Active
		{
			get { return _entity.Is_Active; }
		}
        /// <summary>
        /// Gets the Is_Admin
        /// </summary>
        /// <value>The Is_Admin.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean Is_Admin
		{
			get { return _entity.Is_Admin; }
		}
        /// <summary>
        /// Gets the UserType_ID
        /// </summary>
        /// <value>The UserType_ID.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 UserType_ID
		{
			get { return _entity.UserType_ID; }
		}
        /// <summary>
        /// Gets the First_Name
        /// </summary>
        /// <value>The First_Name.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String First_Name
		{
			get { return _entity.First_Name; }
		}
        /// <summary>
        /// Gets the Last_Name
        /// </summary>
        /// <value>The Last_Name.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Last_Name
		{
			get { return _entity.Last_Name; }
		}
        /// <summary>
        /// Gets the Email
        /// </summary>
        /// <value>The Email.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Email
		{
			get { return _entity.Email; }
		}
        /// <summary>
        /// Gets the Country
        /// </summary>
        /// <value>The Country.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Country
		{
			get { return _entity.Country; }
		}
        /// <summary>
        /// Gets the City
        /// </summary>
        /// <value>The City.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String City
		{
			get { return _entity.City; }
		}
        /// <summary>
        /// Gets the Address
        /// </summary>
        /// <value>The Address.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Address
		{
			get { return _entity.Address; }
		}
        /// <summary>
        /// Gets the Mobile
        /// </summary>
        /// <value>The Mobile.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Mobile
		{
			get { return _entity.Mobile; }
		}
        /// <summary>
        /// Gets the Phone
        /// </summary>
        /// <value>The Phone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Phone
		{
			get { return _entity.Phone; }
		}
        /// <summary>
        /// Gets the Postion
        /// </summary>
        /// <value>The Postion.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Postion
		{
			get { return _entity.Postion; }
		}
        /// <summary>
        /// Gets the Is_Deleted
        /// </summary>
        /// <value>The Is_Deleted.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Is_Deleted
		{
			get { return _entity.Is_Deleted; }
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
        /// Gets a <see cref="T:Library.BLL.Users"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public Library.BLL.Users Entity
        {
            get { return _entity; }
        }
	}
}
