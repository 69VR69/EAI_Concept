using EAI_Concept.Interfaces.InstructionCommands;

namespace EAI_Concept.services
{
    using Result = BaseInstructionCommandResult;
    public interface IContextService
    {
        void Add(IInstructionCommand command, Result result);
        Result GetResult(IInstructionCommand command);
        (IInstructionCommand command, Result result) GetContextLine(int line);
    }
}
