using BAL.Model;
using System.Data;

namespace BAL.Interfaces
{
    public interface IStoryService
    {
        public Task<DataSet> AddUpdateStory(Story story);
    }
}
