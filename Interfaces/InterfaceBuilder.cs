using EAI_Concept.interfaces.transitions;
using EAI_Concept.Interfaces.InstructionCommands;
using EAI_Concept.Interfaces.Strategies.Execution;
using EAI_Concept.Interfaces.Strategies.Transition;

namespace EAI_Concept.Interfaces
{
    public class InterfaceBuilder
    {
        protected TransitionBuilder TransitionBuilder;

        void Init()
        {
            InstructionBuilder InstructionBuilder = new InstructionBuilder();
            TransitionBuilder = new TransitionBuilder { Builder = InstructionBuilder };
            InstructionBuilder.Builder = TransitionBuilder;
        }

        void Build()
        {
            //TransitionBuilder
            //    .AddInstruction()
            //    .AddTransition();
        }
    }

    public class InstructionBuilder
    {
        public TransitionBuilder Builder { get; set; }

        public TransitionBuilder AddTransition(Transition transition)
        {

            return Builder;
        }

        public TransitionBuilder AddTransition(Instruction nextInstruction, IExecutionStrategy executionStrategy, params ITransitionStrategy[] transitionsStrategies)
        {

            return Builder;
        }
    }

    public class TransitionBuilder
    {
        public InstructionBuilder Builder { get; set; }

        public InstructionBuilder AddInstruction(Instruction instruction)
        {

            return Builder;
        }

        public InstructionBuilder AddInstruction(IInstructionCommand command, Transition transition)
        {

            return Builder;
        }

    }
}
