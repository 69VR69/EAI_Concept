using EAI_Concept.Utils.Exceptions;

namespace EAI_Concept.Interfaces.Parameters.Factories
{

    public class InstructionParametersFactory
    {
        #region Factories
        public Lazy<FileInstructionParametersFactory> FileInstructionParametersFactory = new(() => new FileInstructionParametersFactory());
        public Lazy<QueryInstructionParametersFactory> QueryInstructionParametersFactory = new(() => new QueryInstructionParametersFactory());
        #endregion

        public BaseInstructionParameters CreateInstruction(InstructionType type)
        {
            return type switch
            {
                InstructionType.File => FileInstructionParametersFactory.Value.CreateInstruction(),
                InstructionType.Query => QueryInstructionParametersFactory.Value.CreateInstruction(),
                _ => throw new NotExistingFactory(),
            };
        }
    }
}
