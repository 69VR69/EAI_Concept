using EAI_Concept.interfaces.transitions;

using Newtonsoft.Json;

namespace EAI_Concept.Interfaces.StateMachine
{
    public class Interface
    {
        [JsonProperty("instructions")]
        public required List<Instruction> Instructions { get; set; }

        public Instruction RootInstruction => Instructions?.FirstOrDefault(defaultValue: null) ;
    }
}
