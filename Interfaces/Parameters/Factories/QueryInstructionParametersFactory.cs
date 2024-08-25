namespace EAI_Concept.Interfaces.Parameters.Factories
{
    public class QueryInstructionParametersFactory : BaseInstructionParametersFactory
    {
        public override BaseInstructionParameters CreateInstruction()
        {
            return new QueryInstructionParameters("SELECT * FROM toto");
        }
    }
}
