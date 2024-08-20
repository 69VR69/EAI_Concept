using EAI_Concept.Interfaces.Instructions.Factories;
using EAI_Concept.Utils.Exceptions;

namespace EAI_Concept.Interfaces.Instructions.Commands
{
    public abstract class BaseInstructionCommandResult(bool isSuccess)
    {
        public bool IsSuccess { get; protected set; } = isSuccess;
    }

    public abstract class BaseInstructionCommand<TInstruction, TResult>(TInstruction instruction) where TInstruction : BaseInstruction where TResult : BaseInstructionCommandResult
    {
        protected readonly TInstruction Instruction = instruction;

        public abstract Task<TResult> Execute();

        public static TCommand Create<TCommand>(TInstruction instruction) where TCommand : TInstruction
            => Activator.CreateInstance(typeof(TCommand), instruction) as TCommand ?? throw new CannotCreateCommand();
    }
}
