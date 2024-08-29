using EAI_Concept.Interfaces.Parameters;
using EAI_Concept.Interfaces.Parameters.Factories;
using EAI_Concept.Interfaces.Strategies.Execution;
using EAI_Concept.Interfaces.Strategies.Transition;

using Newtonsoft.Json;

namespace EAI_Concept.interfaces.transitions
{
    public sealed class Transition
    {
        private readonly static Lazy<InstructionParametersFactory> factory = new(() => new InstructionParametersFactory());

        [JsonProperty("executionStrategy")]
        public IExecutionStrategy ExecutionStrategy { get; set; }
        [JsonProperty("transitionStrategies")]
        public List<ITransitionStrategy> TransitionStrategies { get; set; }
        [JsonProperty("nextInstruction")]
        public Instruction NextInstruction { get; set; }

        public void LaunchNextInstruction()
        {
            // Check if nextInstrction exist
            if (NextInstruction is null)
                return;

            // Get the instruction type
            InstructionType instructionType = NextInstruction.Type;

            // Create the instruction parameter object using the factory
            var instructionParameters = factory.Value.CreateInstruction(instructionType);

            // Loop over the strategies to fill up the parameters and do some actions
            TransitionStrategies.ForEach(s => s.Apply(instructionParameters));

            // Assign the parameters to the instruction's command
            NextInstruction.Command.SetParameter(instructionParameters);

            // execute the next instruction
            ExecutionStrategy.Launch(NextInstruction);
        }
    }
}
