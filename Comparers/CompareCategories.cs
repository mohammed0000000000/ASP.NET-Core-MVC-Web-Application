using System.Diagnostics.CodeAnalysis;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Comparers
{
    public class CompareCategories : IEqualityComparer<CategoryViewModel>
    {
        public bool Equals(CategoryViewModel? x, CategoryViewModel? y) {
            if (y is null) return false;
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] CategoryViewModel obj) {
            throw new NotImplementedException();
        }
    }
}
