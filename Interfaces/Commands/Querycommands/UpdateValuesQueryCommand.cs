using EAI_Concept.Interfaces.Parameters;

namespace EAI_Concept.Interfaces.InstructionCommands.Querycommands
{
    public class UpdateValuesQueryCommandResult(bool isSucess, int nbImpactedLines) : BaseQueryCommandResult(isSucess)
    {
        public int NbImpactedLines { get; init; } = nbImpactedLines;
    }

    public class UpdateValuesQueryCommand() : QueryCommandHolder<UpdateValuesQueryCommandResult>()
    {
        public override InstructionType Type => InstructionType.Query;
        public override async Task<UpdateValuesQueryCommandResult> Execute()
        {
            // Update SQL logic
            Console.WriteLine($"Query executed : \n {Instruction.Query}");

            return new(isSucess: true, nbImpactedLines: 1);
        }
        public override string ToString()
            => nameof(UpdateValuesQueryCommand);
    }
}
