using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextBalancing
{
    public class TextBalancing
    {
        private const string signsPattern = @"([\[\]\(\)\{\}]+)";
        private readonly char[] parenthesis = { '(', ')' };
        private readonly char[] braquets = { '[', ']' };
        private readonly char[] braces = { '{', '}' };

        public bool IsBalanced(string input)
        {
            if (String.IsNullOrEmpty(input))
                return true;

            MatchCollection matches = Regex.Matches(input, signsPattern, RegexOptions.Compiled);

            if (matches.Count == 0)
                return true;

            return
                IsBalancedSign(input, parenthesis[0], parenthesis[1])
                &&
                IsBalancedSign(input, braquets[0], braquets[1])
                &&
                IsBalancedSign(input, braces[0], braces[1]);
        }

        private bool IsBalancedSign(string input, char apertureSign, char closeSign)
        {
            Stack<int> chars = new Stack<int>(input.Length);

            if (!input.Contains(apertureSign) && !input.Contains(closeSign))
                return true;

            for (int i = 0; i < input.Length; i++)
            {
                char character = input[i];

                if (character == apertureSign)
                    chars.Push(i);
                else if (character == closeSign)
                {
                    if (chars.Count == 0)
                        return false;

                    chars.Pop();
                }
            }

            return chars.Count == 0;
        }
    }
}
