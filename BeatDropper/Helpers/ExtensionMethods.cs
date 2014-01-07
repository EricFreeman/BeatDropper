using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq.Expressions;

namespace BeatDropper.Helpers
{
    public static class ExtensionMethods
    {
        public static string GetPropertyName(this LambdaExpression property)
        {
            var memberExpression = (MemberExpression)property.Body;
            return memberExpression.Member.Name;
        }
    }
}
