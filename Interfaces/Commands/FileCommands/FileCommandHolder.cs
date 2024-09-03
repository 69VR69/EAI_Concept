using EAI_Concept.Interfaces.Parameters;

namespace EAI_Concept.Interfaces.InstructionCommands.FileCommands
{
    public class BaseFileCommandResult(bool isSuccess) : BaseInstructionCommandResult(isSuccess)
    { }

    public abstract class FileCommandHolder<TResult>()
        : BaseInstructionCommand<FileInstructionParameters, TResult>()
        where TResult : BaseFileCommandResult
    { }

}
