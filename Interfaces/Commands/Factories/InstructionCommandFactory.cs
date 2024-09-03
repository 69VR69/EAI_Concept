
using EAI_Concept.Interfaces.InstructionCommands.FileCommands;
using EAI_Concept.Interfaces.InstructionCommands.Querycommands;

namespace EAI_Concept.Interfaces.InstructionCommands.Factories
{
    public class InstructionCommandFactory
    {
        public IInstructionCommand CreateCommand(string commandType)
            => commandType switch
            {
                nameof(UpdateValuesQueryCommand) => new UpdateValuesQueryCommand(),
                nameof(DeleteFileCommand) => new DeleteFileCommand(),
                _ => throw new ArgumentException($"Command type '{commandType}' is not recognized"),
            };
    }
}
