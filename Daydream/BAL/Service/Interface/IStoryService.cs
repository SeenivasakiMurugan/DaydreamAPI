using Daydream.BAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Daydream.BAL.Service.Interface
{
    public interface IStoryService
    {
        public Task<DataSet> StoryUpdate(Story storys); 

        public Task<DataSet> GetStoryList(int stroryId, int storyTypeId);

        public Task<DataSet> GetStoryById(int storyId);

        public Task<DataSet> GetStoryTypes();
    }
}
