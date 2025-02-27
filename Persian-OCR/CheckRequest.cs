using Persian_OCR.Enums;

namespace Persian_OCR
{
    public class CheckRequest
    {
        public string[] Strings { get; set; }
        public string FilePath { get; set; }
        public CheckMethod CheckMethod { get; set; }
    }

}
