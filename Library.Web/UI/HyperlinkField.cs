﻿#region Using directives
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.ComponentModel;
using System.Security.Permissions;
using System.Reflection;
using System.Web.UI.WebControls;
#endregion

namespace Library.Web.UI
{
/// <summary>
    /// Represents a field that is displayed as a hyperlink in a data-bound control. 
    /// Supports complex objects via DataContainer property.
    /// </summary>
    public class HyperLinkField : DataControlField
    {
        #region class members
        PropertyDescriptor[] urlProperties;
        PropertyDescriptor[] dataTextFieldProperties;
        static string[] emptyFields;
        #endregion /* class members */

        #region props
        /// <summary>
        /// Gets or sets the names of the fields from the data source used to construct the URLs for the hyperlinks in the HyperLinkField object.
        /// </summary>
        [EditorAttribute("System.Web.UI.Design.WebControls.DataFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverterAttribute(typeof(StringArrayConverter))]
        [DefaultValueAttribute("")]
        public virtual string[] DataNavigateUrlFields
        {
            get
            {
                object o = ViewState["DataNavigateUrlFields"];
                if (o != null) return (string[])o;
                if (emptyFields == null) emptyFields = new string[0];
                return emptyFields;
            }
            set
            {
                ViewState["DataNavigateUrlFields"] = value;
                OnFieldChanged();
            }
        }

        /// <summary>
        /// Gets or sets the string that specifies the format in which the URLs for the hyperlinks in a HyperLinkField object are rendered.
        /// </summary>
        [DefaultValueAttribute("")]
        public virtual string DataNavigateUrlFormatString
        {
            get
            {
                object o = ViewState["DataNavigateUrlFormatString"];
                if (o != null) return (string)o;
                return string.Empty;
            }
            set
            {
                ViewState["DataNavigateUrlFormatString"] = value;
                OnFieldChanged();
            }
        }

        /// <summary>
        /// Gets or sets the string that specifies Data Container if complex object used.
        /// </summary>
        [DefaultValueAttribute("")]
        [TypeConverterAttribute("System.Web.UI.Design.DataSourceViewSchemaConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public virtual string DataContainer
        {
            get
            {
                object o = ViewState["DataContainer"];
                if (o != null) return (string)o;
                return string.Empty;
            }
            set
            {
                ViewState["DataContainer"] = value;
                OnFieldChanged();
            }
        }
        
        /// <summary>
        /// Gets or sets the name of the field from the data source containing the text to display for the hyperlink captions in the HyperLinkField object.
        /// </summary>
        [DefaultValueAttribute("")]
        [TypeConverterAttribute("System.Web.UI.Design.DataSourceViewSchemaConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public virtual string DataTextField
        {
            get
            {
                object o = ViewState["DataTextField"];
                if (o != null) return (string)o;
                return string.Empty;
            }
            set
            {
                ViewState["DataTextField"] = value;
                OnFieldChanged();
            }
        }

        /// <summary>
        /// Get or sets the string that specifies the format in which the hyperlink captions in a HyperLinkField object are displayed.
        /// </summary>
        [DefaultValueAttribute("")]        
        public virtual string DataTextFormatString
        {
            get
            {
                object o = ViewState["DataTextFormatString"];
                if (o != null) return (string)o;
                return string.Empty;
            }
            set
            {
                ViewState["DataTextFormatString"] = value;
                OnFieldChanged();
            }
        }

        /// <summary>
        /// Gets or sets the URL to navigate to when a hyperlink in a HyperLinkField object is clicked.
        /// </summary>
        [DefaultValueAttribute("")]
        [EditorAttribute("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [UrlPropertyAttribute]
        public virtual string NavigateUrl
        {
            get
            {
                object o = ViewState["NavigateUrl"];
                if (o != null) return (string)o;
                return string.Empty;
            }
            set
            {
                ViewState["NavigateUrl"] = value;
                OnFieldChanged();
            }
        }

        /// <summary>
        /// Gets or sets the target window or frame in which to display the Web page linked to when a hyperlink in a HyperLinkField object is clicked.
        /// </summary>
        [DefaultValueAttribute("")]
        [TypeConverterAttribute(typeof(TargetConverter))]
        public virtual string Target
        {
            get
            {
                object o = ViewState["Target"];
                if (o != null) return (string)o;
                return string.Empty;
            }
            set
            {
                ViewState["Target"] = value;
                OnFieldChanged();
            }
        }

        /// <summary>
        /// Gets or sets the text to display for each hyperlink in the HyperLinkField object.
        /// </summary>
        [LocalizableAttribute(true)]
        [DefaultValueAttribute("")]
        public virtual string Text
        {
            get
            {
                object o = ViewState["Text"];
                if (o != null) return (string)o;
                return string.Empty;
            }
            set
            {
                ViewState["Text"] = value;
                OnFieldChanged();
            }
        }
        #endregion /* props */

        #region control implementation
        /// <summary>
        /// Virtual. Initializes a cell in a HyperLinkField object.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="rowState"></param>
        public virtual void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
        {
            HyperLink link = new HyperLink();
            cell.Controls.Add(link);
        }
        
        /// <summary>
        /// Virtual. Formats Url based using DataNavigateUrlFormatString
        /// </summary>
        /// <param name="dataUrlValues"></param>
        /// <returns></returns>
        protected virtual string FormatDataNavigateUrlValue(object[] dataUrlValues)
        {
			bool isNullOrEmpty = dataUrlValues == null || dataUrlValues.Length == 0;
            if (isNullOrEmpty || dataUrlValues[0] == null)
                return string.Empty;
            else if (DataNavigateUrlFormatString.Length > 0)
                return string.Format(DataNavigateUrlFormatString, dataUrlValues);
            else
                return dataUrlValues[0].ToString();
        }

        /// <summary>
        /// Virtual. Formats Text using FormatDataTextValue
        /// </summary>
        /// <param name="dataTextValues"></param>
        /// <returns></returns>
        protected virtual string FormatDataTextValue(object[] dataTextValues)
        {
			bool isNullOrEmpty = dataTextValues == null || dataTextValues.Length == 0;
        	if (isNullOrEmpty || dataTextValues[0] == null)
			    return string.Empty;
            else if (DataTextFormatString.Length > 0)
                return string.Format(DataTextFormatString, dataTextValues);
            else
                return dataTextValues[0].ToString();
        }

        /// <summary>
        /// Occurs when cell binds to the field value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDataBindField(object sender, EventArgs e)
        {
            DataControlFieldCell cell = (DataControlFieldCell)sender;
            HyperLink link = (HyperLink)cell.Controls[0];
            object controlContainer = cell.BindingContainer;
            object item = DataBinder.GetDataItem(controlContainer);
            
            // check if the complex type is used            
            if (DataTextField.Length > 0 && DataContainer.Length > 0)
            {
                //string[] values = DataTextField.Split(new char[] { '.' });
                item = DataBinder.Eval(item, this.DataContainer);
		        if (item == null) return;
            }

            if (DataTextField.Length > 0)
            {
                if (dataTextFieldProperties == null)
                {
                    SetupProperties(item);
                }
                object[] dataTextValues = new object[DataTextField.Split(',').Length];

                for (int n = 0; n < dataTextValues.Length; n++)
                    dataTextValues[n] = dataTextFieldProperties[n].GetValue(item);
                link.Text = FormatDataTextValue(dataTextValues);
            }

            string[] urlFields = DataNavigateUrlFields;
            if (urlFields.Length > 0)
            {
                if (urlProperties == null)
                {
                    SetupProperties(item);
                }
                object[] dataUrlValues = new object[urlFields.Length];

                for (int n = 0; n < dataUrlValues.Length; n++)
                    dataUrlValues[n] = urlProperties[n].GetValue(item);
                link.NavigateUrl = FormatDataNavigateUrlValue(dataUrlValues);
            }
        }

        /// <summary>
        /// Is used to set properties of the HyperLinkField
        /// </summary>
        /// <param name="controlContainer"></param>
        void SetupProperties(object controlContainer)
        {                      
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(controlContainer);

            if (DataTextField.Length > 0)
            {
                string[] dataFields = DataTextField.Split(',');
                if (dataFields.Length > 0)
                {
                    dataTextFieldProperties = new PropertyDescriptor[dataFields.Length];
                    for (int n = 0; n < dataFields.Length; n++)
                    {
                        PropertyDescriptor prop = props[dataFields[n]];
                        if (prop == null)
                            throw new InvalidOperationException(string.Format("Property '{0}' not found in object of type {1}", dataFields[n], controlContainer.GetType()));
                        dataTextFieldProperties[n] = prop;
                    }
                }
            }

            string[] urlFields = DataNavigateUrlFields;
            if (urlFields.Length > 0)
            {
                urlProperties = new PropertyDescriptor[urlFields.Length];
                for (int n = 0; n < urlFields.Length; n++)
                {
                    PropertyDescriptor prop = props[urlFields[n]];
                    if (prop == null)
                        throw new InvalidOperationException(string.Format("Property '{0}' not found in object of type {1}", urlFields[n], controlContainer.GetType()));
                    urlProperties[n] = prop;
                }
            }
        }
        #endregion /* control implementation */

        #region overrides
        /// <summary>
        /// Performs instance initialization
        /// </summary>
        /// <param name="sortingEnabled"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public override bool Initialize(bool sortingEnabled, Control control)
        {
            return base.Initialize(sortingEnabled, control);
        }

        /// <summary>
        /// Overridden. Initializes a cell in a HyperLinkField object.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="cellType"></param>
        /// <param name="rowState"></param>
        /// <param name="rowIndex"></param>
        public override void InitializeCell(DataControlFieldCell cell,
            DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            base.InitializeCell(cell, cellType, rowState, rowIndex);
            if (cellType == DataControlCellType.DataCell)
            {
                InitializeDataCell(cell, rowState);
                if ((rowState & DataControlRowState.Insert) == 0)
                    cell.DataBinding += new EventHandler(OnDataBindField);
            }
        }

        /// <summary>
        /// Overridden. Returns a new instance of the HyperLinkField class.
        /// </summary>
        /// <returns></returns>
        protected override DataControlField CreateField()
        {
            return new HyperLinkField();
        }

        /// <summary>
        /// Overridden. Copies the properties of the current HyperLinkField object to the specified object.
        /// </summary>
        /// <param name="newField"></param>
        protected override void CopyProperties(DataControlField newField)
        {
            base.CopyProperties(newField);
            HyperLinkField field = (HyperLinkField)newField;
            field.DataNavigateUrlFields = DataNavigateUrlFields;
            field.DataNavigateUrlFormatString = DataNavigateUrlFormatString;
            field.DataTextField = DataTextField;
            field.DataTextFormatString = DataTextFormatString;
            field.NavigateUrl = NavigateUrl;
            field.Target = Target;
            field.Text = Text;
        }
        /// <summary>
        /// Overridden. Indicates that the controls contained by the HyperLinkField object support callbacks.
        /// </summary>
        public override void ValidateSupportsCallback()
        {
        }
        #endregion /* overrides */
    }    
}

