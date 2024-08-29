using EAI_Concept.Interfaces.InstructionCommands;
using EAI_Concept.Interfaces.Parameters;

using Newtonsoft.Json;

namespace EAI_Concept.interfaces.transitions
{
    using Command = IInstructionCommand;

    public class Instruction
    {
        [JsonProperty("id")]
        public required string Code { get; set; }

        public InstructionType Type => Command.Type;
        [JsonProperty("command")]
        public required Command Command { get; set; }

        [JsonProperty("transition")]
        public required Transition Transition { get; set; }

        public async void Execute()
        {
            var result = await Command.Execute();

            // manage result

            Transition.LaunchNextInstruction();
        }
    }
}
