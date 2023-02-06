using System;

namespace Teste___Webapi.Models;

public class ProductQueryParameters : QueryParameters
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}
