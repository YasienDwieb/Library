﻿#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library.BLL;
using Library.DAL;
using Library.Web.UI;
#endregion

namespace Library.Web.Data
{
    /// <summary>
    /// Binds SQL filter expressions to a parameter object.
    /// </summary>
    [CLSCompliant(true)]
    [ParseChildren(true), PersistChildren(false)]
    public class SqlParameter : Parameter
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SqlParameter class.
        /// </summary>
        public SqlParameter()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The Filters member variable.
        /// </summary>
        private IList filters;

        /// <summary>
        /// Gets or Sets the Filters property.
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public IList Filters
        {
            get
            {
                if (filters == null)
                {
                    filters = new ArrayList();
                }

                return filters;
            }
        }

        /// <summary>
        /// The CallbackControlID member variable.
        /// </summary>
        private String callbackControlID;

        /// <summary>
        /// Gets or Sets the CallbackControlID property.
        /// </summary>
        public String CallbackControlID
        {
            get { return callbackControlID; }
            set { callbackControlID = value; }
        }

        /// <summary>
        /// The UseParameterizedFilters member variable.
        /// </summary>
        private bool useParameterizedFilters = true;

        /// <summary>
        /// Gets or Sets the UseParameterizedFilters property.
        /// </summary>
        public bool UseParameterizedFilters
        {
            get { return useParameterizedFilters; }
            set { useParameterizedFilters = value; }
        }

        #endregion Properties

        #region Evaluate

        /// <summary>
        /// Updates and returns the value of the SqlParameter object.
        /// </summary>
        /// <param name="context">The current System.Web.HttpContext of the request.</param>
        /// <param name="control">The System.Web.UI.Control that the parameter is bound to.</param>
        /// <returns>A System.Object that represents the updated and current value of the parameter.</returns>
        protected override object Evaluate(HttpContext context, Control control)
        {
            Object returnValue = null;
            bool isCallback = false;

            if (!UseParameterizedFilters)
            {
                returnValue = String.Empty;
            }
            if (!String.IsNullOrEmpty(CallbackControlID))
            {
                IList<Control> controls = FormUtil.GetControls(control.Page, CallbackControlID);
                if (controls != null && controls.Count > 0)
                {
                    try
                    {
                        isCallback = (bool)EntityUtil.GetPropertyValue(controls[0], "IsCallback");
                    }
                    catch (Exception) { /* ignore */ }
                }
            }
            if (filters != null && filters.Count > 0)
            {
                if (UseParameterizedFilters)
                {
                    returnValue = (filters[0] as ISqlFilter).GetSqlFilterParameters(control, filters, isCallback);
                }
                else
                {
                    returnValue = (filters[0] as ISqlFilter).GetSqlFilterString(control, filters, isCallback);
                }
            }

            return returnValue;
        }

        #endregion Evaluate
    }

    #region SqlExpressionBuilder<EntityColumn>
    /// <summary>
    /// Provides SQL filter expressions for the <see cref="SqlParameter"/> class.
    /// </summary>
    /// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
    [CLSCompliant(true)]
    public abstract class SqlExpressionBuilder<EntityColumn> : SqlFilter<EntityColumn>
    {

        #region Public Properties

        /// <summary>
        /// The ExpressionGroupState member variable.
        /// </summary>
        public enum ExpressionGroupState
        {
            /// <summary>
            /// Group State is not used
            /// </summary>
            None = 0,
            /// <summary>
            /// Group State starts with "("
            /// </summary>
            Begin,
            /// <summary>
            /// Group State starts with "AND ("
            /// </summary>
            AndBegin,
            /// <summary>
            /// Group State starts with "OR ("
            /// </summary>
            OrBegin,
            /// <summary>
            /// Group State ends with ")"
            /// </summary>
            End
        }

        /// <summary>
        /// The ComparisionType member variable.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override SqlComparisonType ComparisionType
        {
            get
            {
                return base.ComparisionType;
            }
            set
            {
                base.ComparisionType = value;
            }
        }
		
        /// <summary>
        /// Gets or Sets the FilterType member variable.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override SqlFilterType FilterType
        {
            get
            {
                return base.FilterType;
            }
            set
            {
                base.FilterType = value;
            }
        }
		
        /// <summary>
        /// Occurs when the filter expression is to be created.
        /// </summary>
        public override event SqlFilterEventHandler<EntityColumn> ApplyFilter;

        /// <summary>
        /// The BuilderExpression member variable.
        /// </summary>
        private StringBuilderExpression builderExpression;

        /// <summary>
        /// The Junction member variable.
        /// </summary>
        private String junction;

        /// <summary>
        /// The IgnoreCase member variable.
        /// </summary>
        private bool ignoreCase;

        /// <summary>
        /// The Format member variable.
        /// </summary>
        private String format = "{0}";

        /// <summary>
        /// The GroupName member variable.
        /// </summary>
        private String groupName;

        /// <summary>
        /// The GroupState member variable.
        /// </summary>
        private ExpressionGroupState groupState = ExpressionGroupState.None;

        //private 
        /// <summary>
        /// Gets or Sets the BuilderExpression property.
        /// </summary>
        public StringBuilderExpression BuilderExpression
        {
            get { return builderExpression; }
            set { builderExpression = value; }
        }

        /// <summary>
        /// The Junction member variable.
        /// </summary>
        public String Junction
        {
            get { return junction; }
            set { junction = value; }
        }

        /// <summary>
        /// The IgnoreCase member variable.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IgnoreCase
        {
            get { return ignoreCase; }
            set { ignoreCase = value; }
        }

        /// <summary>
        /// The Format member variable.
        /// </summary>
        public String Format
        {
            get { return format; }
            set { format = value; }
        }

        /// <summary>
        /// The Group Name member variable.
        /// </summary>
        public String GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }


        /// <summary>
        /// The Group State member variable.
        /// </summary>
        public ExpressionGroupState GroupState
        {
            get 
            {
                return groupState; 
            }
            set
            {
                groupState = value;
            }
        }

        /// <summary>
        /// The Parameters member variable.
        /// </summary>
        private ParameterCollection parameters;

        /// <summary>
        /// Collections of parameter objects where each object specifies the value of 
        /// a specified parameter 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ParameterCollection Parameters
        {
            get
            {
                if (parameters == null)
                {
                    parameters = new ParameterCollection();
                }

                return parameters;
            }
        }
        #endregion

        /// <summary>
        /// Applies the filters to the specified <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> object.
        /// </summary>
        /// <param name="sql">The <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> object.</param>
        /// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
        /// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
        /// <param name="isCallback">Indicates whether this is a callback request.</param>
        protected override void ApplyFilters(SqlFilterBuilder<EntityColumn> sql, Control control, IList filters, bool isCallback)
        {
            String value;
            object[] e;
                        
            foreach (SqlExpressionBuilder<EntityColumn> filter in filters)
            {
                if (filter.ApplyFilter != null)
                {
                    value = filter.GetFilterValue(control, isCallback);
                    SqlFilterEventArgs<EntityColumn> args = new SqlFilterEventArgs<EntityColumn>(sql, filter.Column, value);
                    filter.ApplyFilter(this, args);
                }
                else
                {
                    switch (filter.BuilderExpression)
                    {
                        case StringBuilderExpression.AppendRange:
                            IOrderedDictionary prms = filter.Parameters.GetValues(HttpContext.Current, control);

                            if (filter.Junction == null)
                                e = new object[] { filter.Column, prms["From"], prms["To"] };
                            else
                                e = new object[] { filter.Junction, filter.Column, prms["From"], prms["To"] };

                            if (prms["From"] == null && prms["To"] == null)
                            {
                                throw new ArgumentException("The AppendRange expression requires \"From\" and \"To\" parameters. ");
                            }
                            break;
                        case StringBuilderExpression.Append:
                            value = filter.GetFilterValue(control, isCallback);
                            if (filter.Junction == null)
                                e = new object[] { filter.Column, string.Format(filter.Format, value) };
                            else
                                e = new object[] { filter.Junction, filter.Column, string.Format(filter.Format, value), true };
                            break;
                        case StringBuilderExpression.AppendIsNotNull:
                        case StringBuilderExpression.AppendIsNull:
							if (filter.Junction == null)
                                e = new object[] { filter.Column };
                            else
                                e = new object[] { filter.Junction, filter.Column };
                            break;
                        case StringBuilderExpression.AppendGreaterThan:
                        case StringBuilderExpression.AppendGreaterThanOrEqual:
                        case StringBuilderExpression.AppendLessThan:
                        case StringBuilderExpression.AppendLessThanOrEqual:
                        case StringBuilderExpression.AppendEquals:
                        case StringBuilderExpression.AppendNotEquals:
                        case StringBuilderExpression.AppendIn:
                        case StringBuilderExpression.AppendInQuery:
                        case StringBuilderExpression.AppendNotInQuery:
                            value = filter.GetFilterValue(control, isCallback);
                            if (filter.Junction == null)
                                e = new object[] { filter.Column, string.Format(filter.Format, value) };
                            else
                                e = new object[] { filter.Junction, filter.Column, string.Format(filter.Format, value) };
                            break;
                        default:
                            value = filter.GetFilterValue(control, isCallback);
                            if (filter.Junction == null)
                                e = new object[] { filter.Column, string.Format(filter.Format, value) };
                            else
                                e = new object[] { filter.Junction, filter.Column, string.Format(filter.Format, value) };
                            break;
                    }
                    
                    if (filter.GroupState == ExpressionGroupState.Begin)
                    {
                        EntityUtil.InvokeMethod(sql, "BeginGroup", new object[] { "" });
                        EntityUtil.InvokeMethod(sql, filter.BuilderExpression.ToString(), e);
                    }
                    else if (filter.GroupState == ExpressionGroupState.AndBegin)
                    {
                        EntityUtil.InvokeMethod(sql, "BeginGroup", new object[] { "AND" });
                        EntityUtil.InvokeMethod(sql, filter.BuilderExpression.ToString(), e);
                    }
                    else if (filter.GroupState == ExpressionGroupState.OrBegin)
                    {
                        EntityUtil.InvokeMethod(sql, "BeginGroup", new object[] { "OR" });
                        EntityUtil.InvokeMethod(sql, filter.BuilderExpression.ToString(), e);
                    }
                    else if (filter.GroupState == ExpressionGroupState.End)
                    {
                        EntityUtil.InvokeMethod(sql, filter.BuilderExpression.ToString(), e);
                        EntityUtil.InvokeMethod(sql, "EndGroup");
                    }
                    else
                    {
                        EntityUtil.InvokeMethod(sql, filter.BuilderExpression.ToString(), e);
                    }                                        
                }
            }
        }
    }
    #endregion SqlExpressionBuilder<EntityColumn>

    #region SqlFilter<EntityColumn>
    /// <summary>
    /// Provides SQL filter expressions for the <see cref="SqlParameter"/> class.
    /// </summary>
    /// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
    [CLSCompliant(true)]
    public abstract class SqlFilter<EntityColumn> : ISqlFilter
    {
        #region Properties

        /// <summary>
        /// The Column member variable.
        /// </summary>
        private EntityColumn column;

        /// <summary>
        /// Gets or Sets the Column property.
        /// </summary>
        public EntityColumn Column
        {
            get { return column; }
            set { column = value; }
        }

        /// <summary>
        /// The ControlID member variable.
        /// </summary>
        private String controlID;

        /// <summary>
        /// Gets or Sets the ControlID property.
        /// </summary>
		[System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
        public String ControlID
        {
            get { return controlID; }
            set { controlID = value; }
        }

        /// <summary>
        /// The QueryStringField member variable.
        /// </summary>
        private String queryStringField;

        /// <summary>
        /// The SessionField member variable.
        /// </summary>
        private String sessionField;

        /// <summary>
        /// The ComparisionType member variable.
        /// </summary>
        private SqlComparisonType comparisonType;

        /// <summary>
        /// The PropertyName member variable.
        /// </summary>
        private String propertyName;

        /// <summary>
        /// The DefaultValue member variable.
        /// </summary>
        private String defaultValue;
		
        /// <summary>
        /// The FilterType member variable.
        /// </summary>
        private SqlFilterType filterType;		

        /// <summary>
        /// Gets or Sets the QueryStringField member variable.
        /// </summary>
        public virtual String QueryStringField
        {
            get { return queryStringField; }
            set { queryStringField = value; }
        }

        /// <summary>
        /// Gets or Sets the SessionField member variable.
        /// </summary>
        public virtual String SessionField
        {
            get { return sessionField; }
            set { sessionField = value; }
        }

        /// <summary>
        /// Gets or Sets the PropertyName property.
        /// </summary>
        public virtual String PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }

        /// <summary>
        /// Gets or Sets the DefaultValue property.
        /// </summary>
        public virtual String DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        /// <summary>
        /// Gets or Sets the ComparisionType property.
        /// </summary>
        public virtual SqlComparisonType ComparisionType
        {
            get { return comparisonType; }
            set { comparisonType = value; }
        }
		
        /// <summary>
        /// Gets or Sets the FilterType property.
        /// </summary>
        public virtual SqlFilterType FilterType
        {
            get { return filterType; }
            set { filterType = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the filter value.
        /// </summary>
        /// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
        /// <param name="isCallback">Indicates whether this is a callback request.</param>
        protected virtual String GetFilterValue(Control control, bool isCallback)
        {
            Object value = null;

            if (!string.IsNullOrEmpty(QueryStringField))
            {
                value = HttpContext.Current.Request.QueryString[QueryStringField];
            }
            else if (!string.IsNullOrEmpty(SessionField))
            {
                value = HttpContext.Current.Session[SessionField];
            }
            else if (!String.IsNullOrEmpty(ControlID))
            {
                Control input = FormUtil.FindControl(control, ControlID);

                if (input == null)
                {
                    // if the ControlID was not found using the supplied control, we will
                    // search the entire conrol tree for the current page
                    IList<Control> controls = FormUtil.GetControls(control.Page, ControlID);

                    if (controls != null && controls.Count > 0)
                    {
                        input = controls[0];
                    }
                }
                if (input != null)
                {
                    if (isCallback)
                    {
                        value = HttpContext.Current.Request[input.UniqueID];
                    }
                    else
                    {
                        value = FormUtil.GetValue(input, PropertyName);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(DefaultValue))
            {
                value = DefaultValue;
            }
            String format = "{0}";

            return String.Format(format, value);
        }

        /// <summary>
        /// Applies the filters to the specified <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> object.
        /// </summary>
        /// <param name="sql">The <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> object.</param>
        /// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
        /// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
        /// <param name="isCallback">Indicates whether this is a callback request.</param>
        protected virtual void ApplyFilters(SqlFilterBuilder<EntityColumn> sql, Control control, IList filters, bool isCallback)
        {
            foreach (SqlFilter<EntityColumn> filter in filters)
            {
                String value = filter.GetFilterValue(control, isCallback);

                if (filter.ApplyFilter != null)
                {
                    SqlFilterEventArgs<EntityColumn> args = new SqlFilterEventArgs<EntityColumn>(sql, filter.Column, value);
                    filter.ApplyFilter(this, args);
                }
                else
                {
                    String format = "{0}";
                    if (filter.ComparisionType == SqlComparisonType.Contains)
                        format = "%{0}%"; 
                    else if (filter.ComparisionType == SqlComparisonType.StartsWith)
                        format = "{0}%";
                    else if (filter.ComparisionType == SqlComparisonType.EndsWith)
                        format = "%{0}";
                    if (filter.FilterType == SqlFilterType.Phrase)
                        format = string.Format("\"{0}\"", format);
                    sql.Append(filter.Column, string.Format(format, value));
				}
            }
        }

        /// <summary>
        /// Creates a new instance of a <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
        /// that can be used to generate a SQL filter expression for this filter.
        /// </summary>
        /// <returns></returns>
        protected virtual SqlFilterBuilder<EntityColumn> GetFilterBuilder(bool useParameterizedFilters)
        {
            return useParameterizedFilters
                ? new ParameterizedSqlFilterBuilder<EntityColumn>()
                : new SqlFilterBuilder<EntityColumn>();
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Occurs when the filter expression is to be created.
        /// </summary>
        public virtual event SqlFilterEventHandler<EntityColumn> ApplyFilter;

        #endregion Events

        #region ISqlFilter Members

        /// <summary>
        /// Gets the SQL filter expression that is represented by the specified filters.
        /// </summary>
        /// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
        /// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
        /// <param name="isCallback">Indicates whether this is a callback request.</param>
        /// <returns>A SQL filter expression.</returns>
        public String GetSqlFilterString(Control control, IList filters, bool isCallback)
        {
            SqlFilterBuilder<EntityColumn> sql = GetFilterBuilder(false);

            ApplyFilters(sql, control, filters, isCallback);

            return sql.ToString();
        }

        /// <summary>
        /// Gets the collection of SQL filter parameters that is represented by the specified filters.
        /// </summary>
        /// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
        /// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
        /// <param name="isCallback">Indicates whether this is a callback request.</param>
        /// <returns>A collection SQL filter parameters.</returns>
        public SqlFilterParameterCollection GetSqlFilterParameters(Control control, IList filters, bool isCallback)
        {
            SqlFilterBuilder<EntityColumn> sql = GetFilterBuilder(true);

            ApplyFilters(sql, control, filters, isCallback);

            return (sql as ParameterizedSqlFilterBuilder<EntityColumn>).GetParameters();
        }

        #endregion ISqlFilter Members
    }

    #endregion SqlFilter<EntityColumn>

    #region SqlFilterEventHandler

    /// <summary>
    /// Represents the method that will handle the <see cref="SqlFilter&lt;EntityColumn&gt;.ApplyFilter"/> event.
    /// </summary>
    /// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
    /// <param name="sender">The data source control that the filter is bound to.</param>
    /// <param name="e">The event data.</param>
    public delegate void SqlFilterEventHandler<EntityColumn>(object sender, SqlFilterEventArgs<EntityColumn> e);

    /// <summary>
    /// Provides data for the <see cref="SqlFilter&lt;EntityColumn&gt;.ApplyFilter"/> event.
    /// </summary>
    /// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
    public class SqlFilterEventArgs<EntityColumn> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the SqlFilterEventArgs class.
        /// </summary>
        /// <param name="builder">An <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> object.</param>
        /// <param name="column">The current column.</param>
        /// <param name="filter">The column filter value.</param>
        public SqlFilterEventArgs(SqlFilterBuilder<EntityColumn> builder, EntityColumn column, String filter)
        {
            this.filterBuilder = builder;
            this.column = column;
            this.filter = filter;
        }

        #region Properties

        /// <summary>
        /// The FilterBuilder member variable.
        /// </summary>
        private SqlFilterBuilder<EntityColumn> filterBuilder;

        /// <summary>
        /// Gets the FilterBuilder property.
        /// </summary>
        public SqlFilterBuilder<EntityColumn> FilterBuilder
        {
            get { return filterBuilder; }
        }

        /// <summary>
        /// The Column member variable.
        /// </summary>
        private EntityColumn column;

        /// <summary>
        /// Gets the Column property.
        /// </summary>
        public EntityColumn Column
        {
            get { return column; }
        }

        /// <summary>
        /// The Filter member variable.
        /// </summary>
        private String filter;

        /// <summary>
        /// Gets the Filter property.
        /// </summary>
        public String Filter
        {
            get { return filter; }
        }

        #endregion Properties
    }

    #endregion SqlFilterEventHandler

    #region ISqlFilter

    /// <summary>
    /// Provides the ability to construct a valid SQL filter expression.
    /// </summary>
    [CLSCompliant(true)]
    public interface ISqlFilter
    {
        /// <summary>
        /// Gets the SQL filter expression that is represented by the specified filters.
        /// </summary>
        /// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
        /// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
        /// <param name="isCallback">Indicates whether this is a callback request.</param>
        /// <returns>A SQL filter expression.</returns>
        String GetSqlFilterString(Control control, IList filters, bool isCallback);

        /// <summary>
        /// Gets the collection of SQL filter parameters that is represented by the specified filters.
        /// </summary>
        /// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
        /// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
        /// <param name="isCallback">Indicates whether this is a callback request.</param>
        /// <returns>A collection SQL filter parameters.</returns>
        SqlFilterParameterCollection GetSqlFilterParameters(Control control, IList filters, bool isCallback);
    }

    #endregion ISqlFilter
}
