﻿#region Using Directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Library;
#endregion

namespace Library.Web.UI
{
    /// <summary>
    /// Used to store important GridView and GridViewSearchPanel properties
    /// so that their state can be maintained
    /// </summary>
    public class GridViewSearchPanelState
    {
        #region Properties
        #region GridView
        private int m_PageIndex;
        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        public int PageIndex
        {
            get { return m_PageIndex; }
            set { m_PageIndex = value; }
        }

        private int m_PageSize;
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize
        {
            get { return m_PageSize; }
            set { m_PageSize = value; }
        }

        private string m_SortExpression;
        /// <summary>
        /// Gets or sets the sort expression.
        /// </summary>
        /// <value>The sort expression.</value>
        public string SortExpression
        {
            get { return m_SortExpression; }
            set { m_SortExpression = value; }
        }

        private SortDirection m_SortDirection;
        /// <summary>
        /// Gets or sets the sort direction.
        /// </summary>
        /// <value>The sort direction.</value>
        public SortDirection SortDirection
        {
            get { return m_SortDirection; }
            set { m_SortDirection = value; }
        } 
        #endregion

        #region GridViewSearchPanel
        private string m_SearchKeyword;
        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        /// <value>The search keyword.</value>
        public string SearchKeyword
        {
            get { return m_SearchKeyword; }
            set { m_SearchKeyword = value; }
        }

        private string m_SearchFieldName;
        /// <summary>
        /// Gets or sets the name of the search field.
        /// </summary>
        /// <value>The name of the search field.</value>
        public string SearchFieldName
        {
            get { return m_SearchFieldName; }
            set { m_SearchFieldName = value; }
        }

        private SearchOperator m_SearchOperator;
        /// <summary>
        /// Gets or sets the search operator.
        /// </summary>
        /// <value>The search operator.</value>
        public SearchOperator SearchOperator
        {
            get { return m_SearchOperator; }
            set { m_SearchOperator = value; }
        }

        private string m_Filter;
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>The filter condition.</value>
        public string Filter
        {
            get { return m_Filter; }
            set { m_Filter = value; }
        } 
        #endregion
	
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:GridViewSearchPanelState"/> class.
        /// </summary>
        public GridViewSearchPanelState()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GridViewSearchPanelState"/> class.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="searchPanel">The search panel.</param>
        public GridViewSearchPanelState( GridView gridView, GridViewSearchPanel searchPanel )
        {
            SaveState( gridView, searchPanel );
        }
        #endregion

        #region Public methods
        /// <summary>
		/// Saves the state of the grid view and grid view search panel.
		/// </summary>
		/// <param name="gridView">The grid view.</param>
		/// <param name="searchPanel">The search panel.</param>
		public void SaveState( GridView gridView, GridViewSearchPanel searchPanel )
		{
			// Grid view values
			this.PageIndex = gridView.PageIndex;
			this.PageSize = gridView.PageSize;
			this.SortExpression = gridView.SortExpression;
			this.SortDirection = gridView.SortDirection;
	
		    this.SearchFieldName = searchPanel.SearchFieldName;
			this.SearchOperator = searchPanel.SearchOperator;
			this.SearchKeyword = searchPanel.SearchKeyword;
            this.Filter = searchPanel.Filter;
            searchPanel.DataBind();
		}
        
        /// <summary>
        /// Restores the state of the grid view and grid view search panel.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="searchPanel">The search panel.</param>
        public void RestoreState( ref GridView gridView, ref GridViewSearchPanel searchPanel )
        {
            gridView.PageIndex = this.PageIndex;
            gridView.PageSize = this.PageSize;  

            searchPanel.SearchFieldName = this.SearchFieldName;
            searchPanel.SearchKeyword = this.SearchKeyword;
            searchPanel.SearchOperator = this.SearchOperator;
            searchPanel.Filter = this.Filter;

            if (!string.IsNullOrEmpty(this.SortExpression))
            {
                gridView.Sort(this.SortExpression, this.SortDirection);
            }
        }
        #endregion

    }
}
