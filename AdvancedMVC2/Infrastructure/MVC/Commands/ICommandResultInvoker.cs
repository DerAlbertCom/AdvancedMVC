using System.Web.Mvc;

namespace AdvancedMVC2.Infrastructure.MVC.Commands
{
    public interface ICommandResult
    {
    }

    public interface ICommandResultInvoker<T>
        where T : ICommandResult
    {
        ActionResult Invoke(T actionResult, ControllerContext context);
    }

    public interface ICommandResultInvoker
    {
        ActionResult Invoke(object actionMethodResult, ControllerContext context);
    }
}