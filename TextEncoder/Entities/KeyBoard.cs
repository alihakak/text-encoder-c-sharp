using System;
using System.Collections.Generic;
using System.Text;

namespace TextEncoder.Entities
{
    public class KeyBoard
    {
        public List<char> Row1 { get => new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }; }
        public List<char> Row2 { get => new List<char> { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' }; }
        public List<char> Row3 { get => new List<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', ';' }; }
        public List<char> Row4 { get => new List<char> { 'z', 'x', 'c', 'v', 'b', 'n', 'm', ',', '.', '/' }; }
    }
}
