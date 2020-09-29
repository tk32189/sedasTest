﻿/*
COPYRIGHT

Character transliteration tables:

Copyright 2001, Sean M. Burke <sburke@cpan.org>, all rights reserved.

Python code:

Copyright 2009, Tomaz Solc <tomaz@zemanta.com>

CSharp code:

Copyright 2010, Oleg Usanov <oleg@usanov.net>

The programs and documentation in this dist are distributed in the
hope that they will be useful, but without any warranty; without even
the implied warranty of merchantability or fitness for a particular
purpose.

This library is free software; you can redistribute it and/or modify
it under the same terms as Perl.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryAnalysis.UnidecodeSharp
{
    /// <summary>
    /// ASCII transliterations of Unicode text
    /// </summary>
    public static partial class Unidecoder
    {
        /// <summary>
        /// Transliterate an Unicode object into an ASCII string
        /// </summary>
        /// <remarks>
        /// unidecode(u"\u5317\u4EB0") == "Bei Jing "
        /// </remarks>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string Unidecode(this string input)
        {
            if (String.IsNullOrEmpty(input)) return input;
            var output = new StringBuilder();
            foreach(var c in input.ToCharArray()) 
            {
                if(c<0x80) {
                    output.Append(c);
                    continue;
                }
                var h = c >> 8;
                var l = c & 0xff;

                if (Characters.ContainsKey(h))
                {
                    output.Append(Characters[h][l]);
                }
                else
                {
                    output.Append("");
                }
            }

            return output.ToString();
        }
    }
}
