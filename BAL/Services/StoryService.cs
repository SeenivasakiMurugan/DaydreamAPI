using BAL.Interfaces;
using BAL.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class StoryService : IStoryService
    {
        private readonly AppDbContext _context;
        public StoryService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<DataSet> AddUpdateStory(Story story)
        {
            var dataset = new DataSet();
            return dataset;
        }
    }
}
