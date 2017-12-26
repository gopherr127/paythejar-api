using MongoDB.Bson;
using MongoDB.Driver;
using PayTheJarApi.Jars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayTheJarApi.JarTransactions
{
    public class JarTransactionRepository : IJarTransactionRepository
    {
        private readonly JarTransactionContext _context = null;
        private const int pageSize = 20;

        public JarTransactionRepository()
        {
            _context = new JarTransactionContext();
        }

        public async Task<IEnumerable<JarTransaction>> Get(string jarId, int page)
        {
            try
            {
                return await _context.JarTransactions
                    .Find(i => i.Id.StartsWith(jarId + "::"))
                    .Skip(page * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error: " + ex.Message);
            }
        }

        public async Task<JarTransaction> Get(string id)
        {
            try
            {
                var filter = Builders<JarTransaction>.Filter.Eq("_id",id);
                return await _context.JarTransactions.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error: " + ex.Message);
            }
        }

        public async Task Add(Jar jar, JarTransaction item)
        {
            try
            {
                item.Id = jar.Id.ToString() + "::" + ObjectId.GenerateNewId();
                await _context.JarTransactions.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error: " + ex.Message);
            }
        }

        public Task<bool> Update(string id, JarTransaction item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}