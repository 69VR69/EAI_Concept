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
        public abstract void SetParameter(BaseInstructionParameters parameter);
        public abstract InstructionType Type { get; }

        public Task<BaseInstructionCommandResult> Execute();
    }

#pragma warning disable CS8618 // Non-nullable field must contain a value => will be check through method Execute()
    public abstract class BaseInstructionCommand<TParameters, TResult>() : IInstructionCommand
#pragma warning restore CS8618
        where TParameters : BaseInstructionParameters
        where TResult : BaseInstructionCommandResult
    {

        public TParameters Instruction;

        public abstract InstructionType Type { get; }

        async Task<BaseInstructionCommandResult> IInstructionCommand.Execute()
        {
            if (Instruction is null)
                throw new ArgumentNullException(nameof(Instruction));

            return await Execute();
        }

        public abstract Task<TResult> Execute();

        public static TCommand Create<TCommand>(TParameters instruction) where TCommand : TParameters
            => Activator.CreateInstance(typeof(TCommand), instruction) as TCommand
               ?? throw new CannotCreateCommand();

        public void SetParameter(BaseInstructionParameters parameter)
        {
            Instruction = (TParameters)parameter;
        }
    }
}
