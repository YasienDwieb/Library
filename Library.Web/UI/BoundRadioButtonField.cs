﻿#region Using directives
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

namespace Library.Web.UI
{
    #region BoundRadioButtonField implementation
    /// <summary>
    /// Represents a Boolean field  in a data-bound control that is displayed as a single 
    /// radio button in the read mode, and two options radio button list in edit mode.
    /// </summary>
    public sealed class BoundRadioButtonField : CheckBoxField
    {
        #region ctor
        /// <summary>
        /// ctor
        /// </summary>
        public BoundRadioButtonField()
        {
        }
        #endregion

        #region overrides
        /// <summary>
        /// Gets a default value for a basic design-time experience. 
        /// Since it would look odd, even at design time, to have 
        /// more than one radio button selected, make sure that none
        /// are selected.
        /// </summary>
        /// <returns></returns>
        protected override object GetDesignTimeValue()
        {
            return false;
        }


        /// <summary>
        /// This method is called by the ExtractRowValues methods of 
        /// GridView and DetailsView. Retrieve the current value of the 
        /// cell from the Checked state of the Radio button.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="cell"></param>
        /// <param name="rowState"></param>
        /// <param name="includeReadOnly"></param>
        public override void ExtractValuesFromCell(IOrderedDictionary dictionary, DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly)
        {
            // Determine whether the cell contains a RadioButtonList
            // in its Controls collection.
            if (cell.Controls.Count > 0)
            {
                object radio = cell.Controls[0];

                object checkedValue = null;
                if (radio is RadioButton || radio is RadioButtonList)
                {
	                if (radio is RadioButton)
	                {
	                    checkedValue = ((RadioButton)radio).Checked;
	                }
	                else if (radio is RadioButtonList)
	                {
	                    checkedValue = ((RadioButtonList)radio).SelectedValue;
	                }
                }
                else
                {
                    // A RadioButton is expected, but a null is encountered.
                    throw new InvalidOperationException("BoundRadioButtonField could not extract control.");
                }


                // Add the value of the Checked attribute of the
                // RadioButton to the dictionary.
                if (dictionary.Contains(DataField))
                {
                    dictionary[DataField] = checkedValue;
                }
                else
                {
                    dictionary.Add(DataField, checkedValue);
                }
            }
        }

        /// <summary>
        /// This method adds a RadioButton or RadioButtonList controls and any other 
        /// content to the cell's Controls collection.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="rowState"></param>
        protected override void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
        {
            RadioButtonList radioList = new RadioButtonList();
            radioList.RepeatDirection = RepeatDirection.Horizontal;
            radioList.DataBound += new EventHandler(radioList_DataBound);
            RadioButton radio = new RadioButton();

            radioList.Items.Add("True");
            radioList.Items.Add("False");


            // If the RadioButton is bound to a DataField, add
            // the OnDataBindingField method event handler to the
            // DataBinding event.
            if (DataField.Length != 0)
            {
                radio.DataBinding += new EventHandler(this.OnDataBindField);
            }


            // Because the RadioButtonField is a BoundField, it only
            // displays data. Therefore, unless the row is in edit mode,
            // the RadioButton is displayed as disabled.

            // If the row is in edit mode, enable the button.
            if ((rowState & DataControlRowState.Edit) != 0 || (rowState & DataControlRowState.Insert) != 0)
            {
                radio.Visible = false;
                radioList.Visible = true;
                cell.Controls.Add(radioList);
            }
            else
            {
                radio.Text = this.Text;
                radio.Enabled = false;
                radioList.Visible = false;
                cell.Controls.Add(radio);
            }
        }
        #endregion

        #region events
        /// <summary>
        /// Occurs after the server control binds to a data source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void radioList_DataBound(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            object val = GetValue(ctrl.NamingContainer) ?? string.Empty;
            RadioButtonList radioList = ctrl as RadioButtonList;

            if (null != radioList)
            {
                //make sure the appropriate value is selected
                ListItem listItem = radioList.Items.FindByValue(val.ToString());
                if (null != listItem)
                {
                    listItem.Selected = true;
                }
            }
        }
        #endregion

    }
    #endregion
}