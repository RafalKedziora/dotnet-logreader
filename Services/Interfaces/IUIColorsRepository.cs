using Data;

namespace Services.Interfaces
{
    public interface IUIColorsRepository
    {
        Task<UIColors> GetByIdAsync(int id);
        Task UpdateAsync(UIColors updateUIColors);
    }
}
