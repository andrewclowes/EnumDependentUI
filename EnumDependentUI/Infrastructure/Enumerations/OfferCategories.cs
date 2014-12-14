namespace EnumDependentUI.Infrastructure.Enumerations
{
    public enum OfferCategories
    {
        Online = OfferTypes.OnlineCode | OfferTypes.OnlineDeal | OfferTypes.OnlineSale,
        Instore = OfferTypes.Mobile | OfferTypes.Print
    }
}