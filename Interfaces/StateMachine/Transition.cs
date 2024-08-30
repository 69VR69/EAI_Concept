using EAI_Concept.Interfaces.Parameters;
using EAI_Concept.Interfaces.Parameters.Factories;
using EAI_Concept.Interfaces.Strategies.Execution;
using EAI_Concept.Interfaces.Strategies.Transition;
using EAI_Concept.Services;

using Newtonsoft.Json;

namespace EAI_Concept.interfaces.transitions
{
    public sealed class Transition
    {
        private readonly static Lazy<IInstructionParameterService> InstructionParameterService = new(() => new InstructionParameterService());

        [JsonProperty("executionStrategy")]
        public required IExecutionStrategy ExecutionStrategy { get; set; }
        [JsonProperty("transitionStrategies")]
        public required List<ITransitionStrategy> TransitionStrategies { get; set; }
        [JsonProperty("nextInstruction")]
        public required Instruction NextInstruction { get; set; }

        public void LaunchNextInstruction()
        {
            // Check if nextInstrction exist
            if (NextInstruction is null)
                return;

            // Get the instruction parameters from the type
            var instructionParameters = InstructionParameterService.Value.GetParametersForType(NextInstruction.Type);

            // Loop over the strategies to fill up the parameters and do some actions
            TransitionStrategies.ForEach(s => s.Apply(instructionParameters));

            // Assign the parameters to the instruction's command
            NextInstruction.Command.SetParameter(instructionParameters);

            // execute the next instruction
            ExecutionStrategy.Launch(NextInstruction);
        }

       
    }
}
