using TextEncoder.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TextEncoder.Entities;
using System.Linq;

namespace TextEncoder.Services
{
    public class TextEncoder : ITextEncoder
    {
        public void CreateEncoder()
        {
            Console.WriteLine("Creating a Encoder with concrete class injected using constructor injection");
        }

        /// <summary>
        /// Flip Text Horizontally.
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public string HorizontalFlip(string inputStr)
        {
            KeyBoard keyBoard = new KeyBoard();
            inputStr = inputStr.ToLower();

            var horizontalFlipValue = new List<char>();
            for (var i = 0; i < inputStr.Length; i++)
            {

                int charPosition;

                if (keyBoard.Row1.Contains(inputStr[i]))
                {
                    charPosition = keyBoard.Row1.IndexOf(inputStr[i]);
                    horizontalFlipValue.Add(keyBoard.Row1[(keyBoard.Row1.Count - 1) - charPosition]);
                }
                else if (keyBoard.Row2.Contains(inputStr[i]))
                {
                    charPosition = keyBoard.Row2.IndexOf(inputStr[i]);
                    horizontalFlipValue.Add(keyBoard.Row2[(keyBoard.Row2.Count - 1) - charPosition]);

                }
                else if (keyBoard.Row3.Contains(inputStr[i]))
                {
                    charPosition = keyBoard.Row3.IndexOf(inputStr[i]);
                    horizontalFlipValue.Add(keyBoard.Row3[(keyBoard.Row3.Count - 1) - charPosition]);
                }
                else if (keyBoard.Row4.Contains(inputStr[i]))
                {
                    charPosition = keyBoard.Row4.IndexOf(inputStr[i]);
                    horizontalFlipValue.Add(keyBoard.Row4[(keyBoard.Row4.Count - 1) - charPosition]);
                }
                else
                {
                    horizontalFlipValue.Add(inputStr[i]);
                }
            }

            return new string(horizontalFlipValue.ToArray());
        }

        public string VerticalFlip(string inputStr)
        {
            KeyBoard keyBoard = new KeyBoard();
            inputStr = inputStr.ToLower();

            var verticalFlipValue = new List<char>();
            for (var i = 0; i < inputStr.Length; i++)
            {
                int charPosition;

                if (keyBoard.Row1.Contains(inputStr[i]))
                {
                    charPosition = keyBoard.Row1.IndexOf(inputStr[i]);
                    verticalFlipValue.Add(keyBoard.Row4[charPosition]);
                }
                else if (keyBoard.Row2.Contains(inputStr[i]))
                {
                    charPosition = keyBoard.Row2.IndexOf(inputStr[i]);
                    verticalFlipValue.Add(keyBoard.Row3[charPosition]);
                }
                else if (keyBoard.Row3.Contains(inputStr[i]))
                {
                    charPosition = keyBoard.Row3.IndexOf(inputStr[i]);
                    verticalFlipValue.Add(keyBoard.Row2[charPosition]);
                }
                else if (keyBoard.Row4.Contains(inputStr[i]))
                {
                    charPosition = keyBoard.Row4.IndexOf(inputStr[i]);
                    verticalFlipValue.Add(keyBoard.Row1[charPosition]);
                }
                else
                {
                    verticalFlipValue.Add(inputStr[i]);
                }
            }

            return new string(verticalFlipValue.ToArray());
        }

        /// <summary>
        /// Shift characters by value of ShiftBy.
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="shiftBy"></param>
        /// <returns></returns>
        public string ShiftBy(string inputStr, int shiftBy)
        {
            KeyBoard keyBoard = new KeyBoard();
            inputStr = inputStr.ToLower();

            var shiftedValue = new List<char>();
            var allRows = keyBoard.Row1.Concat(keyBoard.Row2.Concat(keyBoard.Row3.Concat(keyBoard.Row4))).ToList();
            for (var i = 0; i < inputStr.Length; i++)
            {
                int charPosition;
                if (allRows.Contains(inputStr[i]))
                {
                    charPosition = allRows.IndexOf(inputStr[i]);
                    if (shiftBy < 0 || shiftBy == 0)
                    {
                        if ((shiftBy % 40) == 0)
                        {
                            shiftedValue.Add(allRows[charPosition]);
                        }
                        else
                        {
                            if ((charPosition + (shiftBy % 40)) < 0)
                            {
                                shiftedValue.Add(allRows[allRows.Count + (charPosition + (shiftBy % 40))]);
                            }
                            else
                            {
                                shiftedValue.Add(allRows[charPosition + (shiftBy % 40)]);
                            }
                        }
                    }
                    else if (shiftBy > 0)
                    {
                        shiftedValue.Add(allRows[(charPosition + (shiftBy % 40)) % 40]);
                    }
                }
                else
                {
                    shiftedValue.Add(inputStr[i]);
                }
            }
            return new string(shiftedValue.ToArray());
        }
    }
}
