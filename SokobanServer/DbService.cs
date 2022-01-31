﻿namespace SokobanServer
{
    public class DbService
    {
        public async void AddLevel(Level level)
        {
            await using var dbContext = new MyDbContext();
            await dbContext.Database.EnsureCreatedAsync(); 
            await dbContext.AddAsync(level);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Level>> GetLevels()
        {
            await using var dbContext = new MyDbContext();
            await dbContext.Database.EnsureCreatedAsync();
            List<Level> level = dbContext.Levels.ToList();
            return level;
        }

        public async Task<Level> GetLevel(int id)
        {
            await using var dbContext = new MyDbContext();
            await dbContext.Database.EnsureCreatedAsync();
            Level level = dbContext.Levels.Where(x => x.Id == id).First();
            return level;
        }

    }
}