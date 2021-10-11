//Date: October 11, 2021
//Projetc: PROJ - 009 - 003 – Project Workshop 3, Desktop Application

//Group 1, Team 1:
//Osama Malik		SAIT Student ID 880863
//Tracy Crape		SAIT Student ID 420488
//Adesola Oyatunji	SAIT Student ID 838997

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace TravelExpertsData
{
    /// <summary>
    /// A repository of validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// checks if textbox has anything in it
        /// </summary>
        /// <param name="tb">text box to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsPresent(TextBox tb)
        {
            bool isValid = true;
            if(String.IsNullOrWhiteSpace(tb.Text))// empty
            {
                MessageBox.Show(tb.Tag + " is required");
                tb.Focus(); 
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if user selected from combo box
        /// </summary>
        /// <param name="cb">combo box to validate</param>
        /// <returns>true is selected, and false if not</returns>
        public static bool IsSelected(ComboBox cb)
        {
            bool isValid = true;
            if (cb.SelectedIndex == -1)// no selection
            {
                MessageBox.Show(cb.Tag + " has to be selected");
                cb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains whole number that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonNegativeInt(TextBox tb)
        {
            bool isValid = true;
            int value;
            if(!Int32.TryParse(tb.Text, out value)) // if the content cannot be  parsed as int
            {
                MessageBox.Show(tb.Tag + " has to be a whole number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if(value < 0 ) // int, but negative
            {
                MessageBox.Show(tb.Tag + " cannot be negative");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains whole number within range
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <param name="minValue">minimum value allowed</param>
        /// <param name="maxValue">maximum value allowed</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsIntInRange(TextBox tb, int minValue, int maxValue)
        {
            bool isValid = true;
            int value;
            if (!Int32.TryParse(tb.Text, out value)) // if the content cannot be  parsed as int
            {
                MessageBox.Show(tb.Tag + " has to be a whole number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < minValue || value > maxValue) // int, but outside the range
            {
                MessageBox.Show(tb.Tag + $" has to be between {minValue} and {maxValue}");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains a number (possibly with decimal part)
        /// that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonNegativeDouble(TextBox tb)
        {
            bool isValid = true;
            double value;
            if (!Double.TryParse(tb.Text, out value)) // if the content cannot be  parsed as double
            {
                MessageBox.Show(tb.Tag + " has to be a number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < 0) // double, but negative
            {
                MessageBox.Show(tb.Tag + " cannot be negative");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }


        /// <summary>
        /// checks if a textbox contains a number (possibly with decimal part)
        /// that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox tb)
        {
            bool isValid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value)) // if the content cannot be  parsed as double
            {
                MessageBox.Show(tb.Tag + " has to be a number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < 0) // double, but negative
            {
                MessageBox.Show(tb.Tag + " cannot be negative");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains decimal number within range
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <param name="minValue">minimum value allowed</param>
        /// <param name="maxValue">maximum value allowed</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsDecimalInRange(TextBox tb, decimal minValue, decimal maxValue)
        {
            bool isValid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value)) // if the content cannot be  parsed as decimal
            {
                MessageBox.Show(tb.Tag + " has to be a decimal number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < minValue || value > maxValue) // int, but outside the range
            {
                MessageBox.Show(tb.Tag + $" has to be between {minValue} and {maxValue}");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }
        /// <summary>
        /// Check wether the input string is with the allowed length
        /// </summary>
        /// <param name="tb">Text box whose input length is to be checked</param>
        /// <param name="length"> Max Length of string that user can enter</param>
        /// <returns> true if within given length, False if not</returns>
        public static bool IsTextWithInLength(TextBox tb,int length)
        {
            bool isValid = true;
            if (tb.TextLength > length)
            {
                MessageBox.Show(tb.Tag + $" length can not be greater than {length}.");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            
                return isValid;
        }

        /// <summary>
        /// Check wether the date entered is in the correct format
        /// </summary>
        /// <param name="tb">Text box to validate</param>
        /// <returns>True if entered in teh correct format, False if not.</returns>
        public static bool IsDateFormat(TextBox tb)
        {
            DateTime dateValue;
            bool isValid = true;
            if (!DateTime.TryParse(tb.Text,out dateValue))
            {
                MessageBox.Show(tb.Tag + $" should be in the MM/DD/YYYY format.");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }


            return isValid;
        }

    }
}
