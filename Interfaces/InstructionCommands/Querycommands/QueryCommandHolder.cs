using EAI_Concept.Interfaces.Parameters;

namespace EAI_Concept.Interfaces.InstructionCommands.Querycommands
{
    public abstract class BaseQueryCommandResult(bool isSuccess) : BaseInstructionCommandResult(isSuccess) { }

    public abstract class QueryCommandHolder<TResult>()
        : BaseInstructionCommand<QueryInstructionParameters, TResult>()
        where TResult : BaseQueryCommandResult
    { }

}
