using EAI_Concept.interfaces.transitions;
using EAI_Concept.Interfaces.Converters;
using EAI_Concept.Interfaces.InstructionCommands.Factories;
using EAI_Concept.Interfaces.StateMachine;
using EAI_Concept.Interfaces.Strategies.Execution.Factories;
using EAI_Concept.Interfaces.Strategies.Transition.Factories;

using Newtonsoft.Json;

namespace EAI_Concept.Services
{
	public class InterfaceBuilderService(
		InstructionCommandFactory commandFactory,
		ExecutionStrategyFactory executionStrategyFactory,
		TransitionStrategyFactory transitionStrategyFactory)
	{
		protected Lazy<JsonSerializerSettings> serializerSettings = new(() =>
		{
			JsonSerializerSettings settings = new()
			{
				Converters =
				[
				new InterfaceConverter(),
				new InstructionCommandConverter(commandFactory),
				new ExecutionStrategyConverter(executionStrategyFactory),
				new TransitionStrategyConverter(transitionStrategyFactory),
				]
			};

			return settings;
		});

		public Interface DeserializeInstructionSet(string json)
		{
			var interfaceObj = JsonConvert.DeserializeObject<Interface>(json, serializerSettings.Value);
			var instructionDict = BuildInstructionDictionary(interfaceObj);

			InitializeCommands(interfaceObj);
			InitializeTransitions(interfaceObj, instructionDict);

			return interfaceObj;
		}

		private Dictionary<string, Instruction> BuildInstructionDictionary(Interface instructionSet)
		{
			var instructionDict = new Dictionary<string, Instruction>();

			foreach (var instruction in instructionSet.Instructions)
			{
				if (!string.IsNullOrEmpty(instruction.Code))
				{
					instructionDict[instruction.Code] = instruction;
				}
			}

			return instructionDict;
		}

		private void InitializeCommands(Interface instructionSet)
		{
			foreach (var instruction in instructionSet.Instructions)
			{
				instruction.Command = commandFactory.CreateCommand(instruction.Command.ToString());
			}
		}

		private void InitializeTransitions(Interface instructionSet, Dictionary<string, Instruction> instructionDict)
		{
			foreach (var instruction in instructionSet.Instructions)
			{
				if (instruction.Transition != null)
				{
					ResolveNextInstruction(instruction.Transition, instructionDict);
				}
			}
		}

		private void ResolveNextInstruction(Transition transition, Dictionary<string, Instruction> instructionDict)
		{
			//if (!string.IsNullOrEmpty(transition.NextInstructionRef?.ToString()))
			//{
			//	var refPath = transition.NextInstructionRef.ToString();
			//	var id = ExtractIdFromRef(refPath);

			//	if (instructionDict.TryGetValue(id, out var nextInstruction))
			//	{
			//		transition.NextInstruction = nextInstruction;
			//	}
			//	else
			//	{
			//		throw new InvalidOperationException($"Unable to resolve reference: {refPath}");
			//	}
			//}
		}

		private string ExtractIdFromRef(string refPath)
			=> refPath.Split('/').Last();
	}

}
