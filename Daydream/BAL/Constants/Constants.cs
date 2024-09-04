namespace Daydream.BAL.Constants
{
    public class Constants
    {
        public class Procedures
        {
            public const string STORE_STORY_DETAILS = "SP_StoreStoryDetail";
            public const string GET_STORY_LIST = "SP_GetStoryList";
            public const string GET_STORY_BYID = "SP_GetStoryById";
            public const string GET_STORY_TYPE = "SP_GetStoryTypes";

            public const string ADD_UPDATE_USER = "SP_AddUpdateUsers";
            public const string LOGIN = "SP_Login";
        }

        public class ResponseStatus
        {
            public const string SUCCESS = "S";
            public const string FAILURE = "F";
        }

        public class ResponseMessage
        {
            public const string SUCCESS = "Success";
            public const string FAILURE = "Something went wrong. Please try again later";
        }
    }
}
