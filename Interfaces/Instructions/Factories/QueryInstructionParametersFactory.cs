namespace EAI_Concept.Interfaces.Instructions.Factories
{
    public record QueryInstructionParameters(string Query) : BaseInstructionParameters(InstructionType.Query);

    public class QueryInstructionParametersFactory : BaseInstructionParametersFactory
    {
        public override BaseInstructionParameters CreateInstruction()
        {
            return new QueryInstructionParameters("SELECT * FROM toto");
        }
    }
}
