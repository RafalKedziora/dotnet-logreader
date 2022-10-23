using Data;
using Services.Data;
using Services.Interfaces;

namespace Services.Repositories
{
    public class UIColorsRepository : IUIColorsRepository
    {
        private readonly LFContext _context;
        public UIColorsRepository(LFContext context)
        {
            _context = context;
        }
        public async Task<UIColors> GetByIdAsync(int id = 1)
        {
            return await _context.UIColors
                .FindAsync(id);
        }
        public async Task UpdateAsync(UIColors updateUIColors)
        {
            _context.UIColors.Update(updateUIColors);
            await _context.SaveChangesAsync();
        }
    }
}
