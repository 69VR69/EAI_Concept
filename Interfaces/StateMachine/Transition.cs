using EAI_Concept.Interfaces.Parameters;
using EAI_Concept.Interfaces.Parameters.Factories;
using EAI_Concept.Interfaces.Strategies.Execution;
using EAI_Concept.Interfaces.Strategies.Transition;

namespace EAI_Concept.interfaces.transitions
{
    using Parameters = BaseInstructionParameters;
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
}
