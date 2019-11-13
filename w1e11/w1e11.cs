using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace w1e11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string formula = String.Join(" ", args);
            float result = CalculateString(formula);
            Console.WriteLine($"{formula} = {result}");
        }

        public static float CalculateString(string formula)
        {
            return (new Program(formula)).calc();
        }

        private string formula;
        private Dictionary<string, string> parts;
        private Dictionary<string, float> partValues;

        public Program(string formula)
        {
            parts = new Dictionary<string, string>();
            partValues = new Dictionary<string, float>();
            this.formula = formula;
        }

        public float calc()
        {
            return parse(decode(encode(this.formula)));

        }

        public string encode(string formula)
        {
            string pattern = "\\(([^\\(\\)]+)\\)";
            MatchCollection paranteses = Regex.Matches(formula, pattern);
            while (paranteses.Count > 0)
            {
                foreach (Match parantes in paranteses)
                {
                    string token = $"#P{parts.Count}#";
                    string after = formula.Replace(parantes.Value, token);
                    if (after != formula)
                    {
                        formula = after;
                        parts.Add(token, parantes.Value);
                    }
                }

                paranteses = Regex.Matches(formula, pattern);
            }

            return formula;
        }

        public string decode(string formula)
        {
            string pattern = "#P([0-9]+)#";
            MatchCollection tokens = Regex.Matches(formula, pattern);
            foreach (Match matchedToken in tokens)
            {
                string token = matchedToken.Value;
                if (!partValues.ContainsKey(token))
                {
                    string part = parts[token];
                    part = part.Substring(1, part.Length - 2);
                    partValues.Add(token, parse(decode(part)));
                }

                formula = formula.Replace(token, $"{partValues[token]}");
            }

            return formula;
        }

        public float parse(string formula)
        {
            int pos;

            pos = formula.IndexOf('+');
            if (pos >= 0)
            {
                return add(formula.Substring(0, pos), formula.Substring(pos + 1));
            }

            pos = formula.IndexOf('-');
            if (pos >= 0)
            {
                return sub(formula.Substring(0, pos), formula.Substring(pos + 1));
            }

            pos = formula.IndexOf('*');
            if (pos >= 0)
            {
                return mul(formula.Substring(0, pos), formula.Substring(pos + 1));
            }

            pos = formula.LastIndexOf('/');
            if (pos >= 0)
            {
                return div(formula.Substring(0, pos), formula.Substring(pos + 1));
            }

            pos = formula.LastIndexOf('^');
            if (pos >= 0)
            {
                return pow(formula.Substring(0, pos), formula.Substring(pos + 1));
            }

            return Int32.Parse(formula);
        }

        public float add(string a, string b)
        {
            return parse(a) + parse(b);
        }
        
        public float sub(string a, string b)
        {
            return parse(a) - parse(b);
        }
        
        public float mul(string a, string b)
        {
            return parse(a) * parse(b);
        }

        public float div(string a, string b)
        {
            return parse(a) / parse(b);
        }

        public float pow(string a, string b)
        {
            return (float) Math.Pow(parse(a), parse(b));
        }
    }
}
