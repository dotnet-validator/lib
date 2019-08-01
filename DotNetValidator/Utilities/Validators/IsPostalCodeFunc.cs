﻿using System;
using System.Text.RegularExpressions;
using DotNetValidator.Models.Errors;

namespace DotNetValidator
{
    public static partial class ValidationUtility
    {
        /// <summary>
        /// Checks if the property's value is a valid postal code,
        /// note: this method uses both the 5-digits and 9-digits formates,
        /// some `12345` & `12345-6789` are both valid
        /// <para>Supported Data Types : Strings, Integers</para>
        /// </summary>
        /// <param name="model">The validator model to add more validations or sanitization</param>
        /// <param name="errorMessage">An optional validation error message</param>
        /// <returns>A Validator</returns>
        public static Validator IsPostalCode(this Validator model, string errorMessage = null)
        {
            try
            {
                var value = model.GetValue();
                if (!model.IsOptional || value != null)
                {
                    if (!Regex.IsMatch(value.ToString(), @"^[0-9]{5}(?:-[0-9]{4})?$"))
                        model.AddError(errorMessage ?? DefaultErrorMessages.IsPostalCode);
                }
            }
            catch (Exception)
            {
                model.AddError(errorMessage ?? DefaultErrorMessages.IsPostalCode);
            }
            return model;
        }
    }
}
