using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using New_Application.Infrastructure;
using New_Application.Models;

namespace New_Application.Repository {
    public class CampRepository : ICampRepository {
        private readonly NewApplicationDbContext _ctx;

        public CampRepository (NewApplicationDbContext ctx) {
            _ctx = ctx;
        }
        public async Task<Camp> CampAsync (Guid campId) {
            return await _ctx.Camps.FirstOrDefaultAsync (c => c.CampId == campId);
        }
        public async Task<bool> CampExistAsync (Guid campId) {
            return await _ctx.Camps.AnyAsync (c => c.CampId == campId);
        }
        public async Task<IEnumerable<Camp>> CampsAsync () {
            return await _ctx.Camps.OrderByDescending (c => c.CampId).ToListAsync ();
        }
        public async Task<bool> DeleteCampAsync (Guid campId) {
            var deleteCamp = await _ctx.Camps.FirstOrDefaultAsync (c => c.CampId == campId);
            _ctx.Remove (deleteCamp);
            try {
                return await _ctx.SaveChangesAsync () > 0 ? true : false;
            } catch (System.Exception ex) {

                throw new Exception ($"{ex.Message}");
            }
        }
        public async Task<Camp> InsertCampAsync (Camp camp) {

            await _ctx.Camps.AddAsync (camp);
            try {
                await _ctx.SaveChangesAsync ();
            } catch (System.Exception ex) {

                throw new Exception ($"{ex.Message}");
            }
            return camp;
        }
        public async Task<bool> SaveCampAsync () {
            return (await _ctx.SaveChangesAsync () >= 0);
        }

        public Task<bool> UpdateCampAsync (Guid campId) {
            throw new NotImplementedException ();
        }
    }
}