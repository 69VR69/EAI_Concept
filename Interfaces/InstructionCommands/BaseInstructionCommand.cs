using EAI_Concept.Interfaces.Parameters;
using EAI_Concept.Utils.Exceptions;

namespace EAI_Concept.Interfaces.InstructionCommands
{
    public abstract class BaseInstructionCommandResult(bool isSuccess)
    {
        public bool IsSuccess { get; protected set; } = isSuccess;
    }

    public interface IInstructionCommand
    {
        public abstract InstructionType Type { get; }

        public Task<BaseInstructionCommandResult> Execute();
    }

    public abstract class BaseInstructionCommand<TParameters, TResult>(TParameters instruction) : IInstructionCommand
        where TParameters : BaseInstructionParameters
        where TResult : BaseInstructionCommandResult
    {
        public InstructionType Type => Instruction.Type;
        protected readonly TParameters Instruction = instruction;

        async Task<BaseInstructionCommandResult> IInstructionCommand.Execute() => await Execute();
        public abstract Task<TResult> Execute();

        public static TCommand Create<TCommand>(TParameters instruction) where TCommand : TParameters
            => Activator.CreateInstance(typeof(TCommand), instruction) as TCommand
               ?? throw new CannotCreateCommand();
    }
}
