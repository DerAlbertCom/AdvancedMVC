using System.Web.Mvc;

namespace AdvancedMVC2.Infrastructure.MVC.Commands
{
    public class CommandMethodResultInvoker<TModel>
        : ICommandResultInvoker<CommandResult<TModel>>
    {
        private readonly ICommandHandler<TModel> command;

        public CommandMethodResultInvoker(ICommandHandler<TModel> command)
        {
            this.command = command;
        }

        public ActionResult Invoke(
            CommandResult<TModel> actionResult,
            ControllerContext context)
        {
            if (!context.Controller.ViewData.ModelState.IsValid)
            {
                return actionResult.FailureContinuation();
            }

            command.Execute(actionResult.Model);

            return actionResult.SuccessContinuation();
        }
    }
}