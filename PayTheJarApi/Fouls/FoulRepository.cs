using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayTheJarApi.Fouls
{
    public class FoulRepository : IFoulRepository
    {
        private readonly FoulContext _context = null;
        private const int pageSize = 20;

        public FoulRepository()
        {
            _context = new FoulContext();
        }

        public async Task<IEnumerable<Foul>> GetAll(int page)
        {
            try
            {
                return await _context.Fouls
                    .Find(_ => true)
                    .Skip(page * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to get Foul data: " + ex.Message);
            }
        }

        public async Task<Foul> Get(string id)
        {
            try
            {
                var filter = Builders<Foul>.Filter.Eq("Id", id);
                return await _context.Fouls.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to get Foul data: " + ex.Message);
            }
        }

        public async Task Add(Foul item)
        {
            try
            {
                await _context.Fouls.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to insert Foul data: " + ex.Message);
            }
        }

        public async Task<bool> Update(string id, Foul item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Fouls.ReplaceOneAsync(
                n => n.Id.Equals(id), item, new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to update Foul data: " + ex.Message);
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                var filter = Builders<Foul>.Filter.Eq("Id", id);
                DeleteResult actionResult = await _context.Fouls.DeleteOneAsync(filter);
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to delete Foul data: " + ex.Message);
            }
        }
    }
}