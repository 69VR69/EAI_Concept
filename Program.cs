using EAI_Concept.Interfaces.Parameters;
using EAI_Concept.Interfaces.Parameters.Factories;

namespace EAI_Concept
{
    public partial class Program
    {
        static void Main(string[] _)
        {
            InstructionParametersFactory factory = new();

            var myfileInstr = factory.CreateInstruction(InstructionType.File);
            Console.WriteLine($"My file instruction : \n{myfileInstr}");

            var myqueryInstr = factory.CreateInstruction(InstructionType.Query);
            Console.WriteLine($"My query instruciton : \n{myqueryInstr}");
        }
    }
}
