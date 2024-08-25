using EAI_Concept.Interfaces.Parameters;
using EAI_Concept.Interfaces.Strategies.Transition;
using EAI_Concept.services;

namespace EAI_Concept.interfaces.transitions
{
    using Parameters = BaseInstructionParameters;

    public class ContextMapTransitionStrategy(IContextService contextService) : ITransitionStrategy
    {
        public void Apply(Parameters instructionParameters)
        {
            //
        }
    }
#endregion
}
