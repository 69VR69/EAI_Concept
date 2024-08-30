using EAI_Concept.interfaces.transitions;
using EAI_Concept.Interfaces.StateMachine;
using EAI_Concept.Services;

namespace EAI_Concept
{
    public class InterfaceExecutionService(IInstructionParameterService instructionParameterService)
    {
        public void Execute(Interface instructionSet)
        {
            Instruction instruction = instructionSet.RootInstruction;

            if (instruction == null)
                return;

            var parameter = instructionParameterService.GetParametersForType(instruction.Type);
            if (parameter == null) return;

            instruction.Command.SetParameter(parameter);

            instruction.Execute();
        }
    }
}