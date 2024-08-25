namespace EAI_Concept.Interfaces.Parameters.Factories
{
    public class FileInstructionParametersFactory : BaseInstructionParametersFactory
    {
        public override BaseInstructionParameters CreateInstruction()
        {
            return new FileInstructionParameters("./value");
        }
    }
}
