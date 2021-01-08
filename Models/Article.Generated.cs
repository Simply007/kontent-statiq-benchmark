// This code was generated by a kontent-generators-net tool 
// (see https://github.com/Kentico/kontent-generators-net).
// 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
// For further modifications of the class, create a separate file with the partial class.

using System;
using System.Collections.Generic;
using Kentico.Kontent.Delivery.Abstractions;

namespace Kentico.Kontent.Benchmark.Statiq.Models
{
    public partial class Article
    {
        public const string Codename = "article";
        public const string ArticleNumberCodename = "article_number";
        public const string ContentCodename = "content";
        public const string ImageCodename = "image";
        public const string SlugCodename = "slug";
        public const string TitleCodename = "title";

        public decimal? ArticleNumber { get; set; }
        public string Content { get; set; }
        public IEnumerable<IAsset> Image { get; set; }
        public string Slug { get; set; }
        public IContentItemSystemAttributes System { get; set; }
        public string Title { get; set; }
    }
}