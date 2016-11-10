using System;

interface IWarranty
{
    void Claim(DateTime onDate, Action onValidClaim);
}