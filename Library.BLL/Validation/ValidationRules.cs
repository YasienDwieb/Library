﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Validation
{

   /// <summary>
   /// Maintains the list of validation rules associated with an object
   /// </summary>
   [Serializable()]
   public class ValidationRules
   {
      /// <summary>
      /// List of rules that have not passed validation
      /// </summary>
      private BrokenRulesList _brokenRules;

      /// <summary>
      /// Object associated with this list of rules.
      /// </summary>
      [NonSerialized()]
      private object _target;

      [NonSerialized()]
      private Dictionary<string, List<ValidationRuleInfo>> _rulesList;

      /// <summary>
      /// Creates an instance of the class and associates the target.
      /// </summary>
      /// <param name="businessEntity">Target</param>
      internal ValidationRules(object businessEntity)
      {
         this.Target = businessEntity;
      }

      /// <summary>
      /// Object associated with this list of rules.
      /// </summary>
      internal object Target
      {
         get
         {
            return _target;
         }
         set
         {
            _target = value;
         }
      }

      /// <summary>
      /// List of <see cref="BrokenRule"/> objects
      /// </summary>
      private BrokenRulesList BrokenRulesList
      {
         get
         {
            if (_brokenRules == null)
               _brokenRules = new BrokenRulesList();
            return _brokenRules;
         }
      }

      /// <summary>
      /// Read-only list of validation rules
      /// </summary>
      private Dictionary<string, List<ValidationRuleInfo>> RulesList
      {
         get
         {
            if (_rulesList == null)
               _rulesList = new Dictionary<string, List<ValidationRuleInfo>>();
            return _rulesList;
         }
      }

      #region Adding Rules

      /// <summary>
      /// Returns a list of <see cref="ValidationRuleInfo"/> objects for a specified property.
      /// </summary>
      /// <param name="propertyName">The name of the property to get the rules for.</param>
      /// <returns>A <see cref="List{ValidationRuleInfo}"/> containing all of the rules for the specified property.</returns>
      private List<ValidationRuleInfo> GetPropertyRules(string propertyName)
      {
         List<ValidationRuleInfo> list = null;

         //See if the list of rules exists
         if (RulesList.ContainsKey(propertyName))
            list = RulesList[propertyName];
         if (list == null)
         {
            //No list found - create a new one.
            list = new List<ValidationRuleInfo>();
            RulesList.Add(propertyName, list);
         }
         return list;
      }

      /// <summary>
      /// Adds a rule to the list of validated rules.
      /// </summary>
      /// <remarks>
      /// <para>
      /// A rule is implemented by a method which conforms to the 
      /// method signature defined by the <see cref="ValidationRuleHandler" /> delegate.
      /// </para>
      /// </remarks>
      /// <param name="handler">The method that implements the rule.</param>
      /// <param name="propertyName">
      /// The name of the property on the target object where the rule implementation can retrieve
      /// the value to be validated.
      /// </param>
      public void AddRule(ValidationRuleHandler handler, string propertyName)
      {
         AddRule(handler, new ValidationRuleArgs(propertyName));
      }

      /// <summary>
      /// Adds a rule to the list of validated rules.
      /// </summary>
      /// <remarks>
      /// <para>
      /// A rule is implemented by a method which conforms to the 
      /// method signature defined by the <see cref="ValidationRuleHandler" /> delegate.
      /// </para>
      /// </remarks>
      /// <param name="handler">The method that implements the rule.</param>
      /// <param name="args">
      /// A <see cref="ValidationRuleArgs"/> object specifying the property name and other arguments
      /// passed to the rule method
      /// </param>
      public void AddRule(ValidationRuleHandler handler, ValidationRuleArgs args)
      {
         // get the list of rules for the property
         List<ValidationRuleInfo> list = GetPropertyRules(args.PropertyName);

         // we have the list, add our new rule
         list.Add(new ValidationRuleInfo(_target, handler, args));
      }

      #endregion

      #region Validating Rules

      /// <summary>
      /// Validates a list of rules.
      /// </summary>
      /// <remarks>
      /// This method calls the Invoke method on each rule in the list.  If the rule fails, it 
      /// is added to the <see cref="BrokenRulesList"/>
      /// </remarks>
      /// <param name="ruleList">List of rules to validate.</param>
      private void ValidateRuleList(List<ValidationRuleInfo> ruleList)
      {
         foreach (ValidationRuleInfo rule in ruleList)
         {
            if (rule.Invoke())
               BrokenRulesList.Remove(rule);
            else
               BrokenRulesList.Add(rule);
         }
      }

      /// <summary>
      /// Validates all rules for a property
      /// </summary>
      /// <param name="propertyName">Name of the property to validate.</param>
      public void ValidateRules(string propertyName)
      {
         List<ValidationRuleInfo> list;
         //Get the rules for the property
         if (RulesList.ContainsKey(propertyName))
         {
            list = RulesList[propertyName];
            if (list == null)
               return;

            ValidateRuleList(list);
         }
      }

      /// <summary>
      /// Validate all the rules for all properties.
      /// </summary>
      public void ValidateRules()
      {
         // get the rules for each rule name
         foreach (KeyValuePair<string, List<ValidationRuleInfo>> rulePair in RulesList)
         {
            ValidateRuleList(rulePair.Value);
         }
      }

      #endregion

      #region Validation Status

      /// <summary>
      /// Returns a value indicateing whether the <see cref="Target"/> object is valid.
      /// </summary>
      /// <remarks>If one or more rules are broken, the object is assumed to be invalid and 
      /// false is return.  Otherwise, True is returned.
      /// </remarks>
      /// <returns>A value indicating whether any rules are broken.</returns>
      internal bool IsValid
      {
         get { return BrokenRulesList.Count == 0; }
      }

      /// <summary>
      /// Return a <see cref="BrokenRulesList"/> that contains all of the invalid rules.
      /// </summary>
      public BrokenRulesList GetBrokenRules()
      {
         return BrokenRulesList;
      }

      #endregion
      
      /// <summary>
      /// 	Clear the rules list.
      /// </summary>
			public void Clear()
	   	{
		  	_rulesList.Clear();
	   	}
   }
}