﻿using OurHeroWebAPI.Model;

namespace OurHeroWebAPI.Services
{
    public interface IOurHeroService
    {
        Task<List<OurHero>> GetAllHeros(bool? isActive);
        Task<OurHero?> GetHerosByID(int id);
        Task<OurHero?> AddOurHero(AddUpdateOurHero obj);
        Task<OurHero?> UpdateOurHero(int id, AddUpdateOurHero obj);
        Task<bool> DeleteHerosByID(int id);
    }

}
