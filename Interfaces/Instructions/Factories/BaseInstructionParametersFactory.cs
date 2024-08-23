namespace EAI_Concept.Interfaces.Instructions.Factories
{
    public abstract record BaseInstructionParameters(InstructionType Type);

    public abstract class BaseInstructionParametersFactory
    {
        public abstract BaseInstructionParameters CreateInstruction();
    }
}
