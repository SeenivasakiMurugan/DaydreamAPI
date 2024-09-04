using Daydream.BAL.Model;
using Daydream.BAL.Service.Interface;
using Daydream.Filters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace Daydream.Controllers
{
    [ServiceFilter(typeof(AppException))]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class StoryController : Controller
    {
        public IStoryService _storyService { get; set; }
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpPost]
        [Route("StoryUpdate")]
        public async Task<IActionResult> StoryUpdate(Story story)
        {
            try
            {
                await _storyService.StoryUpdate(story);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("GetStoryList")]
        public async Task<IActionResult> GetStoryList(int storyId = 0, int storyTypeId = 0)
        {
            var data = await _storyService.GetStoryList(storyId, storyTypeId);
            string json = JsonConvert.SerializeObject(data.Tables[0]);
            return Ok(json);
        }

        [HttpGet]
        [Route("GetStoryById")]
        public async Task<IActionResult> GetStoryById(int storyId)
        {
            var dataSet = await _storyService.GetStoryById(storyId);
            var storyRow = dataSet.Tables[0].Rows[0];
            var chapterData = dataSet.Tables[1];
            var partData = dataSet.Tables[2];

            List<Chapter> chapterList = new List<Chapter>();
            List<Part> partList = new List<Part>();
            foreach (DataRow row in partData.Rows)
            {
                partList.Add(new Part()
                {
                    Description = Convert.ToString(row["Description"]),
                    Image = Convert.ToString(row["Image"]),
                    ChapterId = Convert.ToInt32(row["ChapterId"])
                });
            };

            foreach (DataRow row in chapterData.Rows)
            {
                chapterList.Add(new Chapter()
                {
                    ChapterName = Convert.ToString(row["ChapterName"]),
                    Parts = partList.Where(e => e.ChapterId == Convert.ToInt32(row["ChapterId"])).ToList()
                });
            };

            Story story = new Story
            {
                StoryName = Convert.ToString(storyRow["StoryName"]),
                StoryTypeId = Convert.ToInt32(storyRow["StoryTypeId"]),
                StoryId = Convert.ToInt32(storyRow["StoryId"]),
                Image = Convert.ToString(storyRow["StoryImage"]),
                Chapters = chapterList
            };
            //string json = JsonConvert.SerializeObject(data);
            return Ok(story);
        }

        [HttpGet]
        [Route("GetStoryByStoryId")]
        public async Task<IActionResult> GetStoryByStoryId(int storyId)
        {
            var dataSet = await _storyService.GetStoryById(storyId);
            string json = JsonConvert.SerializeObject(dataSet);
            return Ok(json);
        }

        [HttpGet]
        [Route("GetStoryTypes")]
        public async Task<IActionResult> GetStoryTypes()
        {
            var data = await _storyService.GetStoryTypes();
            string json = JsonConvert.SerializeObject(data.Tables[0]);
            return Ok(json);
        }
    }
}
