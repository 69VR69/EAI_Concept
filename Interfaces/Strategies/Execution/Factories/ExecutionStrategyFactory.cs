namespace EAI_Concept.Interfaces.Strategies.Execution.Factories
{
    public class ExecutionStrategyFactory
    {
        public IExecutionStrategy CreateExecutionStrategy(string executionStrategy)
         => executionStrategy switch
         {
             nameof(BasicExecutionStrategy) => new BasicExecutionStrategy(),
             _ => throw new ArgumentException($"Execution strategy '{executionStrategy}' is not recognized"),
         };
    }
}
