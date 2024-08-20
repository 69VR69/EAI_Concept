using EAI_Concept.Utils.Exceptions;

namespace EAI_Concept.Interfaces.Instructions.Factories
{
    public enum InstructionType
    {
        File,
        Query
    }

    public class InstructionFactory
    {
        #region Factories
        public Lazy<FileInstructionFactory> FileInstructionFactory = new(() => new FileInstructionFactory());
        public Lazy<QueryInstructionFactory> QueryInstructionFactory = new(() => new QueryInstructionFactory());
        #endregion

        public BaseInstruction CreateInstruction(InstructionType type)
        {
            return type switch
            {
                InstructionType.File => FileInstructionFactory.Value.CreateInstruction(),
                InstructionType.Query => QueryInstructionFactory.Value.CreateInstruction(),
                _ => throw new NotExistingFactory(),
            };
        }
    }
}
