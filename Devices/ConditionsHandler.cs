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
        public bool Evaluate(string expression)
        {
            string xsltExpression = string.Format("number({0})", new Regex(@"([\+\-\*])").Replace(expression, " ${1} ")
                                                                                         .Replace("/", " div ")
                                                                                         .Replace("%", " mod "));
            var nav = new XPathDocument(new StringReader("<r/>")).CreateNavigator();
            object result = nav.Evaluate(xsltExpression);
            return ((double)result) != 0d;
        }

        public bool CheckCondtion(string condition, int value) 
        {
            condition = condition.ToLower().Replace("value", value.ToString());
            Regex reg = new Regex("(or)|(and)");
            string[] splitedCondition =  reg.Split(condition);
            splitedCondition[0].Trim();
            bool result = Evaluate(splitedCondition[0]);
            for (int i = 1;i<splitedCondition.Length - 1 ; i = i+2 )
            {
                splitedCondition[i].Trim();
                switch (splitedCondition[i]) {
                    case "or":
                        result = result || Evaluate(splitedCondition[i + 1]);
                        break;
                    case "and":
                        result = result && Evaluate(splitedCondition[i + 1]);
                        break;
                    default: break;
                }
            }          
            return result;
        }
    }
}
