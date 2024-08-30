using EAI_Concept.Interfaces.Parameters;

namespace EAI_Concept.Services
{
    public interface IInstructionParameterService
    {
        BaseInstructionParameters GetParametersForType(InstructionType instructionType);
    }
}
