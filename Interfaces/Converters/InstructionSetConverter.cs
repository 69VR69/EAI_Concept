using EAI_Concept.interfaces.transitions;
using EAI_Concept.Interfaces.StateMachine;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EAI_Concept.Interfaces.Converters
{
	public class InterfaceConverter : JsonConverter<Interface>
	{
		public override Interface ReadJson(JsonReader reader, Type objectType, Interface existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var Interface = new Interface() { Instructions = new() };
			var instructionDict = new Dictionary<string, Instruction>();

			// Read the JSON object first
			JObject jsonObject = JObject.Load(reader);

			// Now retrieve the array of instructions
			JArray jArray = (JArray)jsonObject["instructions"];

			foreach (var jInstruction in jArray)
			{
				var instruction = jInstruction.ToObject<Instruction>(serializer);
				if (instruction == null)
					continue;

				instructionDict[instruction.Code] = instruction;
				Interface.Instructions.Add(instruction);
			}

			// Now resolve NextInstruction references
			foreach (var instruction in Interface.Instructions)
			{
				if (instruction.Transition?.NextInstructionRef != null && instructionDict.TryGetValue(instruction.Transition.NextInstructionRef.Value<string>("ref") ?? string.Empty, out Instruction? value))
				{
					instruction.Transition.NextInstruction = value;
				}
			}

			return Interface;
		}

		public override void WriteJson(JsonWriter writer, Interface value, JsonSerializer serializer)
		{
			throw new NotImplementedException("Serialization is not supported in this custom converter.");
		}
	}

}
