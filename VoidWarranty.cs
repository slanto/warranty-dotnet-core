using System;

class VoidWarranty : IWarranty
{
    [ThreadStatic]
    private static VoidWarranty warranty;

    private VoidWarranty() {}
    
    public static VoidWarranty Instance
    {
        get
        {
            if (warranty == null)
            {
                warranty = new VoidWarranty();
            }

            return warranty;
        }
        

    }
    public void Claim(DateTime onDate, Action onValidClaim) {}    
}