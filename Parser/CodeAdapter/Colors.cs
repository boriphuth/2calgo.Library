﻿using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Linq;

namespace _2calgo.Parser.CodeAdapter
{
    public static class Mq4RgbColors
    {
        private static readonly Regex RgbRegex = new Regex(@"C'(?<red>\d+)\,(?<green>\d+),(?<blue>\d+)\'",
                                                           RegexOptions.Compiled);

        public static string ReplaceMq4RgbColorsToKnownColors(this string code)
        {
            foreach (var match in RgbRegex.Matches(code).OfType<Match>().ToArray())
            {
                var red = GetValue(match, "red");
                var green = GetValue(match, "green");
                var blue = GetValue(match, "blue");

                if (red == null || green == null || blue == null)
                    continue;

                var similarColor = FindSimilarColor(red.Value, green.Value, blue.Value);

                code = code.Replace(match.Value, similarColor);
            }
            return code;
        }

        private static string FindSimilarColor(int red, int green, int blue)
        {
            var result = "Green";
            var minDistance = double.MaxValue;
            foreach (var supportedColor in SupportedColors)
            {
                var distance = Math.Sqrt(Math.Pow(red - supportedColor.R, 2) + Math.Pow(green - supportedColor.G, 2)
                                         + Math.Pow(blue - supportedColor.B, 2));
                if (distance < minDistance)
                {
                    minDistance = distance;
                    result = supportedColor.Name;
                }
            }
            return result;
        }

        private static int? GetValue(Match match, string groupName)
        {
            int result;
            if (!int.TryParse(match.Groups[groupName].Value, out result))
                return null;
            return result;
        }

        private static readonly Color[] SupportedColors = new[]
            {
                Color.White,
                Color.Snow,
                Color.MintCream,
                Color.LavenderBlush,
                Color.AliceBlue,
                Color.Honeydew,
                Color.Ivory,
                Color.WhiteSmoke,
                Color.OldLace,
                Color.MistyRose,
                Color.Lavender,
                Color.Linen,
                Color.LightCyan,
                Color.LightYellow,
                Color.Cornsilk,
                Color.PapayaWhip,
                Color.AntiqueWhite,
                Color.Beige,
                Color.LemonChiffon,
                Color.BlanchedAlmond,
                Color.Bisque,
                Color.Pink,
                Color.PeachPuff,
                Color.Gainsboro,
                Color.LightPink,
                Color.Moccasin,
                Color.NavajoWhite,
                Color.Wheat,
                Color.LightGray,
                Color.PaleTurquoise,
                Color.PaleGoldenrod,
                Color.PowderBlue,
                Color.Thistle,
                Color.PaleGreen,
                Color.LightBlue,
                Color.LightSteelBlue,
                Color.LightSkyBlue,
                Color.Silver,
                Color.Aquamarine,
                Color.LightGreen,
                Color.Khaki,
                Color.Plum,
                Color.LightSalmon,
                Color.SkyBlue,
                Color.LightCoral,
                Color.Violet,
                Color.Salmon,
                Color.HotPink,
                Color.BurlyWood,
                Color.DarkSalmon,
                Color.Tan,
                Color.MediumSlateBlue,
                Color.SandyBrown,
                Color.DarkGray,
                Color.CornflowerBlue,
                Color.Coral,
                Color.PaleVioletRed,
                Color.MediumPurple,
                Color.Orchid,
                Color.RosyBrown,
                Color.Tomato,
                Color.DarkSeaGreen,
                Color.MediumAquamarine,
                Color.GreenYellow,
                Color.MediumOrchid,
                Color.IndianRed,
                Color.DarkKhaki,
                Color.SlateBlue,
                Color.RoyalBlue,
                Color.Turquoise,
                Color.DodgerBlue,
                Color.MediumTurquoise,
                Color.DeepPink,
                Color.LightSlateGray,
                Color.BlueViolet,
                Color.Peru,
                Color.SlateGray,
                Color.Gray,
                Color.Red,
                Color.Magenta,
                Color.Blue,
                Color.DeepSkyBlue,
                Color.Aqua,
                Color.SpringGreen,
                Color.Lime,
                Color.Chartreuse,
                Color.Yellow,
                Color.Gold,
                Color.Orange,
                Color.DarkOrange,
                Color.OrangeRed,
                Color.LimeGreen,
                Color.YellowGreen,
                Color.DarkOrchid,
                Color.CadetBlue,
                Color.LawnGreen,
                Color.MediumSpringGreen,
                Color.Goldenrod,
                Color.SteelBlue,
                Color.Crimson,
                Color.Chocolate,
                Color.MediumSeaGreen,
                Color.MediumVioletRed,
                Color.DarkViolet,
                Color.LightSeaGreen,
                Color.DimGray,
                Color.DarkTurquoise,
                Color.Brown,
                Color.MediumBlue,
                Color.Sienna,
                Color.DarkSlateBlue,
                Color.DarkGoldenrod,
                Color.SeaGreen,
                Color.OliveDrab,
                Color.ForestGreen,
                Color.SaddleBrown,
                Color.DarkOliveGreen,
                Color.DarkBlue,
                Color.MidnightBlue,
                Color.Indigo,
                Color.Maroon,
                Color.Purple,
                Color.Navy,
                Color.Teal,
                Color.Green,
                Color.Olive,
                Color.DarkSlateGray,
                Color.DarkGreen,
                Color.Black
            };
    }
}