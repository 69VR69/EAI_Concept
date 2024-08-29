﻿namespace EAI_Concept.Interfaces.InstructionCommands.FileCommands
{
    public class DeleteFileCommandResult(bool isSucess, string deletedFilePath) : BaseFileCommandResult(isSucess)
    {
        public string DeletedFilePath { get; init; } = deletedFilePath;
    }

    public class DeleteFileCommand() : FileCommandHolder<DeleteFileCommandResult>()
    {
        public override async Task<DeleteFileCommandResult> Execute()
        {
            // Logic to delete a file
            await Task.Delay(500);
            Console.WriteLine($"Delete File at path : {Instruction.Path}");

            return new(isSucess: true, deletedFilePath: Instruction.Path);
        }
        public override string ToString()
            => nameof(DeleteFileCommand);
    }
}
