
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MainPrj.Util
{
    /// <summary>
    /// Data class
    /// </summary>
    public class DataPure
    {
        #region Data members
        #endregion

        #region Singleton Instance
        /// <summary>
        /// Instance
        /// </summary>
        private static DataPure instance;
        /// <summary>
        /// Constructor.
        /// </summary>
        private DataPure()
        {
        }
        /// <summary>
        /// Get instance
        /// </summary>
        public static DataPure Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataPure();
                }
                return instance;
            }
        }
        #endregion
    }
}
