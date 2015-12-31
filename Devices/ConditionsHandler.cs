using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.XPath;
using Interfaces;

namespace Devices
{
    class ConditionsHandler
    {
        private bool EvaluateReturnBool(string expression)
        {
            string xsltExpression = string.Format("number({0})", new Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
                                                                                         .Replace("/", " div ")
                                                                                         .Replace("%", " mod "));
            var nav = new XPathDocument(new StringReader("<r/>")).CreateNavigator();
            object result = nav.Evaluate(xsltExpression);
            return ((double)result) != 0d;
        }

        private string EvaluateReturnString(string expression)
        {
            string xsltExpression = string.Format("number({0})", new Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
                                                                                         .Replace("/", " div ")
                                                                                         .Replace("%", " mod "));
            var nav = new XPathDocument(new StringReader("<r/>")).CreateNavigator();
            return nav.Evaluate(xsltExpression).ToString();
        }


        public bool CheckCondtion(string condition, int value) 
        {           
            condition = condition.ToLower().Replace("value", value.ToString());
            Regex reg = new Regex("or|and");
            if (reg.IsMatch(condition))
            {
                string[] splitedCondition = reg.Split(condition);
                string unitCondition = "";
                foreach (string splited in splitedCondition) 
                {
                    splited.Trim();
                    unitCondition = EqualizeBrackets(splited);
                    condition = condition.Replace(unitCondition,  EvaluateReturnString(unitCondition));
                }
                condition = condition.Replace("or", "+").Replace("and", "*");
            }
            return EvaluateReturnBool(condition);
        }

        private string EqualizeBrackets(string expression)
        {
            int leftBrackets= 0;
            int rightBrackets = 0;
            foreach(char exp in expression)
            {
                if(exp == '(')
                {
                    leftBrackets++;
                }
                if (exp == ')')
                {
                    rightBrackets++;
                }
            }
            if(leftBrackets > rightBrackets)
            {
                expression = expression.Remove(0, leftBrackets - rightBrackets);
            }
            if (rightBrackets > leftBrackets)
            {
                int delta = rightBrackets - leftBrackets + 1;
                expression = expression.Remove(expression.Length - delta , delta);
            }
            return expression;
        }
    }
}
