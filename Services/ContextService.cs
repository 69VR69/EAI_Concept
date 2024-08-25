using EAI_Concept.Interfaces.InstructionCommands;

namespace EAI_Concept.services
{
    using Result = BaseInstructionCommandResult;

    public class ContextService : IContextService
    {
        protected Dictionary<IInstructionCommand, Result> Context = new();

        public void Add(IInstructionCommand command, Result result)
            => Context.TryAdd(command, result);

        public (IInstructionCommand command, Result result) GetContextLine(int line)
        {
            var kv = Context.ElementAt(line);
            return (kv.Key, kv.Value);
        }

        public Result GetResult(IInstructionCommand command)
        {
            return Context[command];
        }
    }
}
