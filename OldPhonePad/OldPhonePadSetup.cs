using System;
using System.Collections.Generic;
using System.Text;

public static class OldPhonePadSetup
{
        public static string OldPhonePad(string input)
    {
        //Handles invalid or empty inputs from user
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;
        //sets the alphabets to appropriate keys
        var keypad = new Dictionary<char, string>
        {
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " }
        };

        var output = new StringBuilder();
        var buffer = new StringBuilder();

        foreach (char c in input)
        {
            if (c == '#') //checks if its end of message
            {
                PadBuffer(buffer, keypad, output);
                break;
            }
            else if (c == '*') //backspace 
            {
                if (buffer.Length > 0)
                {
                    buffer.Clear(); //cancel the current key
                }
                else if (output.Length > 0)
                {
                    output.Remove(output.Length - 1, 1); //deletes the last character
                }
            }
            else if (c == ' ') //pause between letters
            {
                PadBuffer(buffer, keypad, output); //process the letter
            }
            else if (char.IsDigit(c))
            {
                if (buffer.Length == 0 || buffer[0] == c)
                {
                    buffer.Append(c);
                }
                else
                {
                    PadBuffer(buffer, keypad, output);
                    buffer.Append(c);
                }
            }
        }

        return output.ToString();//return final output
    }

    private static void PadBuffer(StringBuilder buffer, Dictionary<char, string> keypad, StringBuilder output)
    {
        if (buffer.Length == 0) return;

        char key = buffer[0];
        if (keypad.ContainsKey(key))
        {
            string letters = keypad[key];
            int index = (buffer.Length - 1) % letters.Length; //cycle through letters
            output.Append(letters[index]); //add letter to output
        }

        buffer.Clear();//reset buffer for next sequence
    }
}