using Petrobar_OCR.Enums;

namespace Petrobar_OCR
{
    public class CheckRequest
    {
        public string[] Strings { get; set; }
        public string FilePath { get; set; }
        public CheckMethod CheckMethod { get; set; }
    }

}
