namespace EAI_Concept.Interfaces.Parameters
{
    public record FileInstructionParameters(string Path) : BaseInstructionParameters(InstructionType.File);
}
