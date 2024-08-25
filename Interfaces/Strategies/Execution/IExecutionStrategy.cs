using EAI_Concept.interfaces.transitions;

namespace EAI_Concept.Interfaces.Strategies.Execution
{
    public interface IExecutionStrategy
    {
        void Launch(Instruction node);
    }
#endregion
}
