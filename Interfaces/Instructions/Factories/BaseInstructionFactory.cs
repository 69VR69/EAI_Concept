namespace EAI_Concept.Interfaces.Instructions.Factories
{
    public abstract record BaseInstruction(string Code, string Label, InstructionType Type);

    public abstract class BaseInstructionFactory
    {
        public abstract BaseInstruction CreateInstruction();
    }
}
