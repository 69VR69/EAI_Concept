using EAI_Concept.Interfaces.Strategies.Execution;
using EAI_Concept.Interfaces.Strategies.Execution.Factories;

using Newtonsoft.Json;

namespace EAI_Concept.Interfaces.Converters
{
	public class ExecutionStrategyConverter(ExecutionStrategyFactory executionStrategyFactory) : JsonConverter<IExecutionStrategy>
    {
        public override IExecutionStrategy ReadJson(JsonReader reader, Type objectType, IExecutionStrategy existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var strategyType = reader.Value as string;
            return executionStrategyFactory.CreateExecutionStrategy(strategyType);
        }

        public override void WriteJson(JsonWriter writer, IExecutionStrategy value, JsonSerializer serializer)
        {
            // This method is not required for deserialization, so we can leave it empty or implement as needed
            throw new NotImplementedException();
        }
    }

}
