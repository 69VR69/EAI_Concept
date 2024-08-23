using EAI_Concept.Interfaces.Instructions.Commands;
using EAI_Concept.Interfaces.Instructions.Factories;

namespace EAI_Concept.interfaces.transitions
{
    using Parameters = BaseInstructionParameters;
    using Result = BaseInstructionCommandResult;
    public sealed class Transition(Instruction nextInstruction, List<ITransitionStrategy> transitionsStrategies, IExecutionStrategy executionStrategy)
    {
        private readonly static Lazy<InstructionParametersFactory> factory = new(() => new InstructionParametersFactory());

        public void NextInstruction()
        {
            // Check if nextInstrction exist
            if (nextInstruction is null)
                return;

            // Get the instruction type
            InstructionType instructionType = nextInstruction.Type;

            // Create the instruction parameter object using the factory
            Parameters instructionParameters = factory.Value.CreateInstruction(instructionType);

            // Loop over the strategies to fill up the parameters and do some actions
            transitionsStrategies.ForEach(s => s.Apply(instructionParameters));

            // execute the next instruction
            executionStrategy.Launch(nextInstruction);
        }
    }

    public interface ITransitionStrategy
    {
        void Apply(Parameters instructionParameters);
    }

    public interface IExecutionStrategy
    {
        void Launch(Instruction node);
    }

    public class ContextMapTransitionStrategy(IContextService contextService) : ITransitionStrategy
    {
        public void Apply(Parameters instructionParameters)
        {
            //
        }
    }

    #region Context
    public interface IContextService
    {
        void Add(IInstructionCommand command, Result result);
        Result GetResult(IInstructionCommand command);
        (IInstructionCommand command, Result result) GetContextLine(int line);
    }

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
    #endregion
}
