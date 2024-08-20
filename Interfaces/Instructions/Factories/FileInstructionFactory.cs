namespace EAI_Concept.Interfaces.Instructions.Factories
{
    public record FileInstruction(string Code, string Label, string Path) : BaseInstruction(Code, Label, InstructionType.File);

    public class FileInstructionFactory : BaseInstructionFactory
    {
        public override BaseInstruction CreateInstruction()
        {
            return new FileInstruction("my_instr", "My Test File Instruction", "./value");
        }
    }
}
