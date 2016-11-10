using System;

class TimeLimitedWarranty : IWarranty
{
    private DateTime dateIssued;
    private TimeSpan duration;
    public TimeLimitedWarranty (DateTime dateIssued, TimeSpan duration)
    {
        this.dateIssued = dateIssued;
        this.duration = duration;
    }

    public void Claim(DateTime onDate, Action onValidClaim)
    {
        if (IsValidOn(onDate))
            onValidClaim();
                    
        return;
    }

    private bool IsValidOn(DateTime date) =>
        date.Date >= dateIssued && date.Date < dateIssued + duration;
}