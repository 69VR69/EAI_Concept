using EAI_Concept.Interfaces.Strategies.Transition;
using EAI_Concept.Interfaces.Strategies.Transition.Factories;

using Newtonsoft.Json;

namespace EAI_Concept.Interfaces.Converters
{

    public class TransitionStrategyConverter(TransitionStrategyFactory transitionStrategyFactory) : JsonConverter<ITransitionStrategy>
    {
        public override ITransitionStrategy ReadJson(JsonReader reader, Type objectType, ITransitionStrategy existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var strategyType = reader.Value as string;
            return transitionStrategyFactory.CreateTransitionStrategy(strategyType);
        }

        public override void WriteJson(JsonWriter writer, ITransitionStrategy value, JsonSerializer serializer)
        {
            // This method is not required for deserialization, so we can leave it empty or implement as needed
            throw new NotImplementedException();
        }
    }

}
