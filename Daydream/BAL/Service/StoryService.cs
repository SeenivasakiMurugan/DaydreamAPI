using Daydream.BAL.Constants;
using Daydream.BAL.Model;
using Daydream.BAL.Service.Interface;
using Microsoft.Data.SqlClient;
using System.Data;
using static Daydream.BAL.Constants.Constants;

namespace Daydream.BAL.Service
{
    public class StoryService : IStoryService
    {
        public IConfiguration _configuration { get; set; }
        public CommonFunctions CommonFunctions { get; set; }
        public StoryService(IConfiguration configuration, CommonFunctions commonFunctions)
        {
            _configuration = configuration;
            CommonFunctions = commonFunctions;
        }

        public async Task<DataSet> StoryUpdate(Story story)
        {
            DataSet dataSet = new DataSet();
            SqlParameter[] storyParameters =
            {
                new SqlParameter("@StoryName" , story.StoryName),
                new SqlParameter("@StoryTypeId" , story.StoryTypeId),
                new SqlParameter("@StoryId" , story.StoryId),
                new SqlParameter("@Flag" , "S")
            };

            dataSet = CommonFunctions.ExcecuteProcedures(Procedures.STORE_STORY_DETAILS, storyParameters, _configuration);
            int storyId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["StoryID"]);

            foreach (var chapter in story?.Chapters)
            {

                SqlParameter[] chapterParameters =
                {
                    new SqlParameter("@ChapterName" , chapter.ChapterName),
                    new SqlParameter("@StoryId" , storyId),
                    new SqlParameter("@ChapterId" , chapter.ChapterId),
                    new SqlParameter("@Flag" , "C"),
                };

                dataSet = CommonFunctions.ExcecuteProcedures(Procedures.STORE_STORY_DETAILS, chapterParameters, _configuration);
                int chapterId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ChapterID"]);

                foreach (var part in chapter.Parts)
                {
                    SqlParameter[] partParameters =
                {
                    new SqlParameter("@Description" , part.Description),
                    new SqlParameter("@ImageFile" , part.Image),
                    new SqlParameter("@ChapterId" , chapterId),
                    new SqlParameter("@StoryId" , storyId),
                    new SqlParameter("@PartId" , part.PartId),
                    new SqlParameter("@Flag" , "P"),
                };

                    dataSet = CommonFunctions.ExcecuteProcedures(Procedures.STORE_STORY_DETAILS, partParameters, _configuration);
                }
            }
            return dataSet;
        }

        public async Task<DataSet> GetStoryList(int stroryId, int storyTypeId)
        {
            DataSet dataSet = new DataSet();
            dataSet = CommonFunctions.ExcecuteProcedures(Procedures.GET_STORY_LIST, null, _configuration);
            return dataSet;
        }

        public async Task<DataSet> GetStoryById(int storyId)
        {
            DataSet dataSet = new DataSet();
            SqlParameter[] parameters =
            {
                new SqlParameter("StoryId",storyId)
            };
            dataSet = CommonFunctions.ExcecuteProcedures(Procedures.GET_STORY_BYID, parameters, _configuration);
            dataSet.Tables[0].TableName = "StoryList";
            dataSet.Tables[1].TableName = "ChapterList";
            dataSet.Tables[2].TableName = "PartList";
            return dataSet;
        }

        public async Task<DataSet> GetStoryTypes()
        {
            DataSet dataSet = new DataSet();
            dataSet = CommonFunctions.ExcecuteProcedures(Procedures.GET_STORY_TYPE, null, _configuration);
            return dataSet;
        }
    }
}
