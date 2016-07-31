using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace IdeaManagement.DAL
{
    /// <summary>
    ///   <para> Author      : Suresh Prajapati </para>
    /// <para> Created On  : 24-Jul-2016 </para>
    /// <para> Description : This class contains </para>
    /// </summary>
    public class CustomParser
    {
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Parse string object </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// string
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static string ParseStringObject<T>(T value)
        {
            return Convert.ToString(value);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Parse int object </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static int ParseIntObject<T>(T value)
        {
            int outValue;
            int.TryParse(Convert.ToString(value), out outValue);
            return outValue;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Parse u int object </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// u int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static uint ParseUIntObject<T>(T value)
        {
            uint outValue;
            uint.TryParse(Convert.ToString(value), out outValue);
            return outValue;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Parse short object </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// int16
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static short ParseShortObject<T>(T value)
        {
            short outValue;
            short.TryParse(Convert.ToString(value), out outValue);
            return outValue;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Parse bool object </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static bool ParseBoolObject<T>(T value)
        {
            bool outValue;
            bool.TryParse(Convert.ToString(value), out outValue);
            return outValue;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Parse double object </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// double
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static double ParseDoubleObject<T>(T value)
        {
            double outValue;
            double.TryParse(Convert.ToString(value), out outValue);
            return outValue;
        }

        /// <summary>
        /// Parse to date object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">input in dd/mm/yyyy format</param>
        /// <returns>
        /// date time
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static DateTime ParseDateObject<T>(T value)
        {
            DateTime outValue;

            string strDateValue = value != null ? value.ToString() : string.Empty;

            if (DateTime.TryParse(strDateValue, new CultureInfo("en-IN"), DateTimeStyles.AssumeLocal, out outValue))
                return outValue;
            else
            {
                DateTime.TryParse(Convert.ToString(strDateValue), out outValue);
                return outValue;
            }
        }

        /// <summary>
        /// Parse to date object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">input in MM/dd/yyyy format</param>
        /// <returns>
        /// date time
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static DateTime ParseCustomDate<T>(T value)
        {
            DateTime outValue;

            string strDateValue = value != null ? value.ToString() : string.Empty;

            DateTime.TryParse(Convert.ToString(strDateValue), out outValue);
            return outValue;
        }


        //Added By Nilima More On 14th March.(Common class for try parse in case of BigInt)
        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Parse big int </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>
        /// int64
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static Int64 ParseBigInt<T>(T value)
        {
            Int64 outValue;
            Int64.TryParse(Convert.ToString(value), out outValue);
            return outValue;
        }
    }
}
