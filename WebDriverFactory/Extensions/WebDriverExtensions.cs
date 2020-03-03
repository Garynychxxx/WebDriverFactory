using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Core.Controls;
using OpenQA.Selenium;


namespace Core.Extensions
{
    public static class WebDriverExtensions
    {
        public static T Find<T>(this ISearchContext context,  By by) where T : Control
        {
            var instance = (T)Activator.CreateInstance(typeof(T), context.FindElement(by));
            instance.Name = GetMethodsName();
            return instance;
        }

        public static List<T> FindAll<T>(this ISearchContext context, By by) where T : Control
        {
            var instances = context.FindElements(by).Select(item => (T)Activator.CreateInstance(typeof(T), item)).ToList();
            instances.Select((value, index) => value.Name = GetMethodsName() + index).ToList();
            return instances;
        }

        private static string GetMethodsName()
        {
            var method = new StackTrace().GetFrames().Select(frame => frame.GetMethod()).ToList()
                .FirstOrDefault(met => typeof(BasePage).IsAssignableFrom(met.DeclaringType));

            return method == null ? "" : method.Name.Replace("get_", "") + $" on <{method.DeclaringType?.Name}>";
        }
    }
}
