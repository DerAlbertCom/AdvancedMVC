using System;
using System.Web.Mvc;

namespace AdvancedMVC2.Infrastructure.MVC.Commands
{
    public class CommandResult<TModel> : ICommandResult
    {
        public CommandResult(TModel model,
                                   Func<ActionResult> successContinuation,
                                   Func<ActionResult> failureContinuation)
        {
            Model = model;
            SuccessContinuation = successContinuation;
            FailureContinuation = failureContinuation;
        }

        public TModel Model { get; private set; }
        public Func<ActionResult> SuccessContinuation { get; private set; }
        public Func<ActionResult> FailureContinuation { get; private set; }
    }
}