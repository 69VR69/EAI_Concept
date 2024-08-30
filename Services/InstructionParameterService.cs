using EAI_Concept.Interfaces.Parameters;
using EAI_Concept.Interfaces.Parameters.Factories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAI_Concept.Services
{
    public class InstructionParameterService : IInstructionParameterService
    {
        private readonly static Lazy<InstructionParametersFactory> factory = new(() => new InstructionParametersFactory());

        public BaseInstructionParameters GetParametersForType(InstructionType instructionType)
        {
            // Create the instruction parameter object using the factory
            var instructionParameters = factory.Value.CreateInstruction(instructionType);
            return instructionParameters;
        }
    }
}
