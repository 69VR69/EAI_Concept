namespace EAI_Concept.Interfaces.Instructions.Factories
{
    public record FileInstructionParameters(string Path) : BaseInstructionParameters(InstructionType.File);

    public class FileInstructionParametersFactory : BaseInstructionParametersFactory
    {
        public override BaseInstructionParameters CreateInstruction()
        {
            return new FileInstructionParameters("./value");
        }
    }

    public class Parameter<Type>(Type value)
    {
        public Type Value { get; set; } = value;


    }

    public class FileInstructionParametersTEST
    {
        public Parameter<int> MyProperty
        {
            get
            {
                return (Parameter<int>)MyProperty;
            }
            set
            {
                MyProperty = value;
            }
        }
    }
}
