using System;
using System.Collections.Generic;
using System.Text;

namespace TextEncoder.Interface
{
    public interface ITextEncoder
    {
        void CreateEncoder();
        public string HorizontalFlip(string inputStr);
        public string VerticalFlip(string inputStr);
        public string ShiftBy(string inputStr, int shiftBy);
    }
}
