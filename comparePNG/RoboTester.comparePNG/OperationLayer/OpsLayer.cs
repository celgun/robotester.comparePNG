using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Drawing.Imaging;
using Microsoft.Test.VisualVerification;
using System.Drawing.Drawing2D;
using System.Reflection;

using RoboTester.comparePNG.DataLayer;

namespace RoboTester.comparePNG.OperationLayer
{
    public class OpsLayer
    {
        public static int compareImages(string szImage1, string szImage2, string szResultImagePath)
        {
            //CCE | 07.01.2022: 1th image
            Snapshot test_image = Snapshot.FromFile(szImage1);

            //CCE | 07.01.2022: 2nd image
            Snapshot reference_image = Snapshot.FromFile(szImage2);

            if ((test_image.Width != reference_image.Width) || (test_image.Height != reference_image.Height))
            {
                Console.WriteLine("ERROR: Image sizes are different!!\n");
                return Constants.RESULT_ERROR_IMAGE_SIZES_DIFFERENT;
            }
            //CCE | 07.01.2022: compare 2 images
            Snapshot difference = test_image.CompareTo(reference_image);

            //CCE | 07.01.2022: configure the snapshot verifier
            SnapshotVerifier v = new SnapshotColorVerifier(Color.Black, new ColorDifference());

            //CCE | 07.01.2022: evaluate the difference image
            if (v.Verify(difference) == VerificationResult.Fail)
            {
                //CCE | 07.01.2022: If files are different, log the difference to the result image
                difference.ToFile(szResultImagePath, ImageFormat.Png);
                return Constants.RESULT_DIFFERENT;
            }
            else
            {
                return Constants.RESULT_SAME;
            }
        }


        public static void printResult(int iCompareResult)
        {
            switch (iCompareResult)
            {
                case Constants.RESULT_ERROR_FILE_NOT_FOUND:
                    Console.WriteLine("FILE NOT FOUND!");
                    break;

                case Constants.RESULT_ERROR_IMAGE_SIZES_DIFFERENT:
                    Console.WriteLine("DIFFERENT FILE SIZE!");
                    break;

                case Constants.RESULT_SAME:
                    Console.WriteLine("Compare Result: SAME!");
                    break;

                default:
                    Console.WriteLine("Compare Result: DIFFERENT!");
                    break;
            }
        }
    }
}
