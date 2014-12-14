using EnumDependentUI.Infrastructure.Enumerations;

namespace EnumDependentUI.Models
{
    public class EnumDependentViewModel
    {
        public OfferCategories[] OfferCategories { get; set; }
        public object[] OfferTypeGroup { get; set; }
        public OfferCategories OfferCategory { get; set; }
        public OfferTypes OfferType { get; set; }
    }
}