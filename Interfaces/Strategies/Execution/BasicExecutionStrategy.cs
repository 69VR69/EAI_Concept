using EAI_Concept.interfaces.transitions;

namespace EAI_Concept.Interfaces.Strategies.Execution
{
    public class BasicExecutionStrategy : IExecutionStrategy
    {
        public void Launch(Instruction instruction)
        {
            instruction.Execute();
        }
        public override string ToString()
            => nameof(BasicExecutionStrategy);
    }
}
