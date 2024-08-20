namespace EAI_Concept.Interfaces.Instructions.Factories
{
    public record QueryInstruction(string Code, string Label, string Query) : BaseInstruction(Code, Label, InstructionType.Query);

    public class QueryInstructionFactory : BaseInstructionFactory
    {
        public override BaseInstruction CreateInstruction()
        {
            return new QueryInstruction("my_instr", "My Test File Instruction", "SELECT * FROM toto");
        }
    }
}
