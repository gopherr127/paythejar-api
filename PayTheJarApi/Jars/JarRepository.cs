using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayTheJarApi.Jars
{
    public class JarRepository : IJarRepository
    {
        private readonly JarContext _context = null;
        private const int pageSize = 20;

        public JarRepository()
        {
            _context = new JarContext();
        }

        public async Task<IEnumerable<Jar>> GetAll(int page)
        {
            try
            {
                return await _context.Jars
                    .Find(_ => true)
                    .Skip(page * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to get Jar data: " + ex.Message);
            }
        }

        public async Task<Jar> Get(string id)
        {
            try
            {
                var filter = Builders<Jar>.Filter.Eq("Id", id);
                return await _context.Jars.Find(filter).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to get Jar data: " + ex.Message);
            }
        }

        public async Task Add(Jar item)
        {
            try
            {
                await _context.Jars.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to insert Jar data: " + ex.Message);
            }
        }

        public async Task<bool> Update(string id, Jar item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Jars.ReplaceOneAsync(
                n => n.Id.Equals(id), item, new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to update Jar data: " + ex.Message);
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                var filter = Builders<Jar>.Filter.Eq("Id", id);
                DeleteResult actionResult = await _context.Jars.DeleteOneAsync(filter);
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to delete Jar data: " + ex.Message);
            }
        }
    }
}