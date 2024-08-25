namespace EAI_Concept.Interfaces.Parameters
{
    public record QueryInstructionParameters(string Query) : BaseInstructionParameters(InstructionType.Query);
}
