using Data;

namespace Services.Interfaces
{
    public interface IUIColorsRepository
    {
        UIColors GetById(int id);
        void Update(UIColors updateUIColors);
    }
}
