using System;
using OpenCvSharp;

namespace Persian_OCR.Utilites
{

    public static class DocumentPreprocessor
    {
        public static Mat PreprocessDocument(string inputImagePath)
        {
            Mat original = Cv2.ImRead(inputImagePath);

            //  Mat noStamp = RemoveStamp(original);

            //  Mat deskewed = Deskew(noStamp);

            Mat gray = new Mat();
            Cv2.CvtColor(original, gray, ColorConversionCodes.BGR2GRAY);

            // Mat noLines = RemoveLines(gray);

            Mat final = new Mat();
            Cv2.Threshold(gray, final, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);

            return final;
        }

        private static Mat RemoveStamp(Mat input)
        {
            Mat hsv = new Mat();
            Cv2.CvtColor(input, hsv, ColorConversionCodes.BGR2HSV);

            Scalar lowerBlue = new Scalar(90, 50, 50);
            Scalar upperBlue = new Scalar(140, 255, 255);

            Mat mask = new Mat();
            Cv2.InRange(hsv, lowerBlue, upperBlue, mask);

            Mat result = input.Clone();
            result.SetTo(new Scalar(255, 255, 255), mask);

            return result;
        }

        private static Mat Deskew(Mat src)
        {
            Mat gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            Mat binary = new Mat();
            Cv2.Threshold(gray, binary, 0, 255, ThresholdTypes.BinaryInv | ThresholdTypes.Otsu);

            Mat nonZeroCoordinates = new Mat();
            Cv2.FindNonZero(binary, nonZeroCoordinates);

            if (nonZeroCoordinates.Rows == 0)
                return src;

            RotatedRect rect = Cv2.MinAreaRect(nonZeroCoordinates);
            double angle = rect.Angle;
            if (angle < -45)
                angle += 90;

            Point2f center = new Point2f(src.Cols / 2f, src.Rows / 2f);
            Mat rot = Cv2.GetRotationMatrix2D(center, angle, 1.0);

            Mat rotated = new Mat();
            Cv2.WarpAffine(src, rotated, rot, new Size(src.Cols, src.Rows),
     flags: InterpolationFlags.Lanczos4,
     borderMode: BorderTypes.Replicate);


            return rotated;
        }

        private static Mat RemoveLines(Mat gray)
        {
            Mat binary = new Mat();
            Cv2.Threshold(gray, binary, 0, 255, ThresholdTypes.BinaryInv | ThresholdTypes.Otsu);

            Mat horizontal = binary.Clone();
            int horizontalSize = horizontal.Cols / 30;
            Mat horizontalStructure = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(horizontalSize, 1));
            Cv2.Erode(horizontal, horizontal, horizontalStructure);
            Cv2.Dilate(horizontal, horizontal, horizontalStructure);

            Mat vertical = binary.Clone();
            int verticalSize = vertical.Rows / 30;
            Mat verticalStructure = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(1, verticalSize));
            Cv2.Erode(vertical, vertical, verticalStructure);
            Cv2.Dilate(vertical, vertical, verticalStructure);

            Mat mask = new Mat();
            Cv2.Add(horizontal, vertical, mask);

            Cv2.BitwiseNot(mask, mask);

            Mat final = new Mat();
            Cv2.BitwiseAnd(binary, mask, final);

            Cv2.BitwiseNot(final, final);

            return final;
        }
    }

}
