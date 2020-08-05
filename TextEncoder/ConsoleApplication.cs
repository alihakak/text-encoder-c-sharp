using TextEncoder.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextEncoder
{
    class ConsoleApplication
    {
        private readonly ITextEncoder _encoder;
        public ConsoleApplication(ITextEncoder encoder)
        {
            _encoder = encoder;
        }

        public void Run()
        {
            _encoder.CreateEncoder(); 
        }
    }
}
