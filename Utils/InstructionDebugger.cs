using EAI_Concept.interfaces.transitions;
using EAI_Concept.Interfaces.StateMachine;

namespace EAI_Concept
{
    public static class InstructionDebugger
    {

        public static void PrintInstruction(Instruction instruction, string indent)
        {
            Console.WriteLine($"{indent}Instruction: {instruction.Command.GetType().Name}");
            if (instruction.Transition != null)
            {
                Console.WriteLine($"{indent}  Transition: {instruction.Transition.ExecutionStrategy.GetType().Name}");
                foreach (var strategy in instruction.Transition.TransitionStrategies)
                {
                    Console.WriteLine($"{indent}    Strategy: {strategy.GetType().Name}");
                }
                if (instruction.Transition.NextInstruction != null)
                {
                    PrintInstruction(instruction.Transition.NextInstruction, indent + "  ");
                }
            }
        }

        public static void PrintInstructions(Interface instructionSet)
        {
            foreach (var instruction in instructionSet.Instructions)
            {
                PrintInstruction(instruction, "");
            }
        }
    }
}