using EAI_Concept.Interfaces.InstructionCommands;
using EAI_Concept.Interfaces.InstructionCommands.Factories;

using Newtonsoft.Json;

namespace EAI_Concept.Interfaces.Converters
{
    public class InstructionCommandConverter(InstructionCommandFactory commandFactory) : JsonConverter<IInstructionCommand>
    {
        public override IInstructionCommand ReadJson(JsonReader reader, Type objectType, IInstructionCommand existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var commandType = reader.Value as string;
            return commandFactory.CreateCommand(commandType);
        }

        public override void WriteJson(JsonWriter writer, IInstructionCommand value, JsonSerializer serializer)
        {
            // This method is not required for deserialization, so we can leave it empty or implement as needed
            throw new NotImplementedException();
        }
    }

}
