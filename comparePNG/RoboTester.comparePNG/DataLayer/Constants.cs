using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboTester.comparePNG.DataLayer
{
    /// <summary>
    /// CCE | 06.01.2022: Constants.cs - Static definitions will be stored here
    /// </summary>
    public class Constants
    {
        //CCE | 06.01.2022: If SAVE_RESULT_IF_NOT_OK == TRUE, that means..
        public const bool SAVE_RESULT_IF_NOT_OK = true;

        /// <summary>
        /// CCE | 06.01.2022: Result types for comparePNG algorithm
        /// </summary>
        public const int RESULT_SAME = 1;
        public const int RESULT_DIFFERENT = 2;
        public const int RESULT_ERROR_USAGE = -3;
        public const int RESULT_ERROR_FILE_NOT_FOUND = -2;
        public const int RESULT_ERROR_IMAGE_SIZES_DIFFERENT = -1;

        /// <summary>
        /// CCE | 06.01.2022: Important parameters for compare algorithm
        /// THRESHOLD: Algorithm will decide according if image is same or not according to this threshold value. Lower value means there is no tolerance for change
        /// BLOCK_SIZE: Algorithm will divide image into blocks
        /// </summary>
        public const float THRESHOLD = (float)0.15;//2.0 //CCE | 21.10.2016: Threshold değeri 2.0 -> 1.5 olarak değiştirildi
        public const int BLOCK_SIZE = 12;
    }
}
