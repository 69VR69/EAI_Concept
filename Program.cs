
using EAI_Concept.Interfaces.Instructions.Factories;

namespace EAI_Concept
{
    public class Program
    {
        static void Main(string[] _)
        {
            InstructionFactory factory = new();

            var myfileInstr = factory.CreateInstruction(InstructionType.File);
            Console.WriteLine($"My file instruction : \n{myfileInstr}");

            var myqueryInstr = factory.CreateInstruction(InstructionType.Query);
            Console.WriteLine($"My query instruciton : \n{myqueryInstr}");
        }
    }
}
