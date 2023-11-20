using GraphQL.Types;
using VideoGamesApi.Models;

namespace VideoGamesApi.Types
{
    public class GameInputType : InputObjectGraphType<Game>
    {
        public GameInputType()
        {
            Name = "gameInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DateGraphType>>("publicationDate");
            Field<ListGraphType<EditorInputType>>(
                "editors"
            );
            Field<ListGraphType<StudioInputType>>(
                "studios"
            );
        }
    }
}
