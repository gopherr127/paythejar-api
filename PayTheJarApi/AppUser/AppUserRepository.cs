using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayTheJarApi.AppUser
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppUserContext _context = null;
        private const int pageSize = 20;

        public AppUserRepository()
        {
            _context = new AppUserContext();
        }

        public async Task<IEnumerable<AppUser>> GetAll(int page)
        {
            try
            {
                return await _context.AppUsers
                    .Find(_ => true)
                    .Skip(page * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to get AppUser data: " + ex.Message);
            }
        }

        public async Task<AppUser> Get(string id)
        {
            try
            {
                var filter = Builders<AppUser>.Filter.Eq("Id", id);
                return await _context.AppUsers.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to get AppUser data: " + ex.Message);
            }
        }

        public async Task Add(AppUser item)
        {
            try
            {
                await _context.AppUsers.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to insert AppUser data: " + ex.Message);
            }
        }

        public async Task<bool> Update(string id, AppUser item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.AppUsers.ReplaceOneAsync(
                n => n.Id.Equals(id), item, new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to update AppUser data: " + ex.Message);
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                var filter = Builders<AppUser>.Filter.Eq("Id", id);
                DeleteResult actionResult = await _context.AppUsers.DeleteOneAsync(filter);
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while attempting to delete AppUser data: " + ex.Message);
            }
        }
    }
}