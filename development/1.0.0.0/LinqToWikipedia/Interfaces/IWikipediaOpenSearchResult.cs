using System;
namespace LinqToWikipedia
{
    interface IWikipediaOpenSearchResult
    {
        string Description { get; set; }
        Uri ImageUrl { get; set; }
        string Keyword { get; set; }
        string Text { get; set; }
        Uri Url { get; set; }
    }
}
