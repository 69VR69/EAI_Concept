using EAI_Concept.Interfaces.InstructionCommands.Factories;
using EAI_Concept.Interfaces.StateMachine;
using EAI_Concept.Interfaces.Strategies.Execution.Factories;
using EAI_Concept.Interfaces.Strategies.Transition.Factories;
using EAI_Concept.Services;

namespace EAI_Concept
{
    public class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
                ""instructions"": [
                    {
                        ""code"": ""instruction1"",
                        ""command"": ""UpdateValuesQueryCommand"",
                        ""transition"": {
                            ""executionStrategy"": ""BasicExecutionStrategy"",
                            ""transitionStrategies"": [
                                ""ContextMapTransitionStrategy""
                            ],
                            ""nextInstruction"": { ""ref"": ""instruction2"" }
                        }
                    },
                    {
                        ""code"": ""instruction2"",
                        ""command"": ""DeleteFileCommand""
                    }
                ]
            }";

            InterfaceBuilderService instructionSetService = InitInterfaceBuilder();

            Interface instructionSet = instructionSetService.DeserializeInstructionSet(json);

            InstructionDebugger.PrintInstructions(instructionSet);

            Console.WriteLine("\n-----------------------------------------------------------\n");

            InterfaceExecutionService interfaceExecutionService = new(new InstructionParameterService());
            interfaceExecutionService.Execute(instructionSet);
        }

        private static InterfaceBuilderService InitInterfaceBuilder()
        {
            var commandFactory = new InstructionCommandFactory();
            var executionStrategyFactory = new ExecutionStrategyFactory();
            var transitionStrategyFactory = new TransitionStrategyFactory();

            var instructionSetService = new InterfaceBuilderService(commandFactory, executionStrategyFactory, transitionStrategyFactory);
            return instructionSetService;
        }
    }
}
