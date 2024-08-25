using EAI_Concept.Interfaces.Parameters;

namespace EAI_Concept.Interfaces.InstructionCommands.Querycommands
{
    public class UpdateValuesQueryCommandResult(bool isSucess, int nbImpactedLines) : BaseQueryCommandResult(isSucess)
    {
        public int NbImpactedLines { get; init; } = nbImpactedLines;
    }

    public class UpdateValuesQueryCommand(QueryInstructionParameters instruction) : QueryCommandHolder<UpdateValuesQueryCommandResult>(instruction)
    {
        public override async Task<UpdateValuesQueryCommandResult> Execute()
        {
            // Update SQL logic
            await Task.Delay(500);
            Console.WriteLine($"Query executed : \n {Instruction.Query}");

            return new(isSucess: true, nbImpactedLines: 1);
        }
    }
}
