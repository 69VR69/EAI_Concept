using EAI_Concept.Interfaces.Instructions.Factories;

namespace EAI_Concept.Interfaces.Instructions.Commands.FileCommands
{
    public class BaseFileCommandResult(bool isSuccess) : BaseInstructionCommandResult(isSuccess)
    { }

    public abstract class FileCommandHolder<TResult>(FileInstruction instruction)
        : BaseInstructionCommand<FileInstruction, TResult>(instruction)
        where TResult : BaseFileCommandResult
    { }

}
