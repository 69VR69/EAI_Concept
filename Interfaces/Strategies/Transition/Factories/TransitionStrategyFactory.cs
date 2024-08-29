
using EAI_Concept.interfaces.transitions;
using EAI_Concept.services;

namespace EAI_Concept.Interfaces.Strategies.Transition.Factories
{
    public class TransitionStrategyFactory
    {
        protected Lazy<IContextService> ContextService = new(() => new ContextService());

        public ITransitionStrategy CreateTransitionStrategy(string transitionStrategy)
         => transitionStrategy switch
         {
             nameof(ContextMapTransitionStrategy) => new ContextMapTransitionStrategy(ContextService.Value),
             _ => throw new ArgumentException($"Execution strategy '{transitionStrategy}' is not recognized"),
         };
    }
}
