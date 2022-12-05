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
        public UIColors GetById(int id = 1)
        {
            return _context.UIColors.FirstOrDefault(elem => elem.Id == id);
        }
        public void Update(UIColors updateUIColors)
        {
            _context.UIColors.Update(updateUIColors);
            _context.SaveChanges();
        }
    }
}
