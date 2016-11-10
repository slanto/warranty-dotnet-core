using System;

class SoldArticle
{
    public IWarranty MoneyBackGuarantee { get; private set; }
    public IWarranty ExpressWarranty { get; private set; }

    public IWarranty NotOperationalWarranty { get; }

    public SoldArticle(IWarranty moneyBackGuarantee, IWarranty expressWarranty)
    {
        if (moneyBackGuarantee == null)
            throw new ArgumentNullException(nameof(moneyBackGuarantee));
        if (expressWarranty == null)
            throw new ArgumentNullException(nameof(expressWarranty));

        this.MoneyBackGuarantee = moneyBackGuarantee;
        this.ExpressWarranty = VoidWarranty.Instance;
        this.NotOperationalWarranty = expressWarranty;
    }

    public void VisibleDamage()
    {
        MoneyBackGuarantee = VoidWarranty.Instance;
    }

    public void NotOperational()
    {
        MoneyBackGuarantee = VoidWarranty.Instance;
        ExpressWarranty = NotOperationalWarranty;
    }
}