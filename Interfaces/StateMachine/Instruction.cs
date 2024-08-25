using EAI_Concept.Interfaces.InstructionCommands;
using EAI_Concept.Interfaces.Parameters;

namespace EAI_Concept.interfaces.transitions
{
    using Command = IInstructionCommand;

    public abstract class Instruction(Command command, Transition transition)
    {
        public InstructionType Type => command.Type;
        protected Command command = command;

        protected Transition transition = transition;

        public async void Execute()
        {
            var result = await command.Execute();

            // manage result

            transition.NextInstruction();
        }
    }
}
