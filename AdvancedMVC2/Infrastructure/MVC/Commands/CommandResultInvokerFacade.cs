using System.Web.Mvc;

namespace AdvancedMVC2.Infrastructure.MVC.Commands
{
    public class CommandResultInvokerFacade<T> : ICommandResultInvoker
        where T : ICommandResult
    {
        private readonly ICommandResultInvoker<T> invoker;

        public CommandResultInvokerFacade(ICommandResultInvoker<T> invoker)
        {
            this.invoker = invoker;
        }

        public ActionResult Invoke(object actionMethodResult, ControllerContext context)
        {
            return invoker.Invoke((T) actionMethodResult, context);
        }
    }
}