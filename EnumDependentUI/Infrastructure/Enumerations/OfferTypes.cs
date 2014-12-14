using System;

namespace EnumDependentUI.Infrastructure.Enumerations
{
    [Flags]
    public enum OfferTypes
    {
        Mobile = 1 << 0,
        Print = 1 << 1,
        MobileAndPrint = Mobile | Print,
        OnlineCode = 1 << 2,
        OnlineDeal = 1 << 3,
        OnlineSale = 1 << 4
    }
}