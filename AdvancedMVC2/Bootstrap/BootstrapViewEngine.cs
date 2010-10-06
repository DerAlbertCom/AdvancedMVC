using System;
using System.Web.Mvc;
using AdvancedMVC2.Infrastructure.Bootstrap;
using AdvancedMVC2.ViewEngine;

namespace AdvancedMVC2.Bootstrap
{
    public class BootstrapViewEngine : IBootstrapItem
    {
        public void Execute()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CustomerWebFormsViewEngine());
        }
    }
}