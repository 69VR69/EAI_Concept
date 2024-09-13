using EAI_Concept.Interfaces.Parameters;

namespace EAI_Concept.Interfaces.Strategies.Transition
{
    using Parameters = BaseInstructionParameters;

    public interface ITransitionStrategy
    {
        void Apply(Parameters instructionParameters);

    }
}