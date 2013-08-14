﻿using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using _2calgo.Parser.InnerStructures;
using _2calgo.Parser.Extensions;

namespace _2calgo.Presenter
{
    public static class TemplateOptimizer
    {
        private static readonly Regex ConditionalRegex = new Regex(@"\[Conditional\((?<words>[^\)]+)\)\]", RegexOptions.Compiled);

        public static string RemoveUnusedCode(string template, Words words)
        {
            var result = new StringBuilder();

            var lastIndex = 0;
            foreach (var match in ConditionalRegex.Matches(template).OfType<Match>().ToArray())
            {
                var innerStructures = new InnerStructures();
                var currentIndex = template.IndexOf('{', match.Index);
                innerStructures.Handle(template[currentIndex]);
                while (innerStructures.IsInsideSomeStructure)
                {
                    currentIndex++;
                    innerStructures.Handle(template[currentIndex]);
                }
                result.Append(template.SubstringFromTo(lastIndex, match.Index - 1));
                var wordsGroup = match.Groups["words"].Value;
                var conditionalWords = wordsGroup
                    .SplitByComma()
                    .Select(s => s.Replace("\"", string.Empty))
                    .ToArray();
                if (conditionalWords.Length > 1)
                {
                    
                }

                if (conditionalWords.Any(words.Contains))
                {
                    var partToCopy = template.SubstringFromTo(match.Index + match.Length, currentIndex);
                    result.Append(partToCopy);
                }
                lastIndex = currentIndex + 1;
            }
            result.Append(template.SubstringFromTo(lastIndex, template.Length - 1));
            return result.ToString();
        }
    }
}