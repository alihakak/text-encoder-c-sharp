using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextEncoder.Interface
{
    public interface ITextEncoder
    {
        void RunEncoder();
        public Task<string> HorizontalFlip(string inputStr);
        public Task<string> VerticalFlip(string inputStr);
        public Task<string> ShiftBy(string inputStr, int shiftBy);
        public Task<string> EncodeText(string inputStr, string commandLine);
    }
}
