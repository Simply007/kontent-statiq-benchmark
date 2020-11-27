using Kentico.Kontent.Benchmark.Statiq.Models;
using Kentico.Kontent.Delivery.Abstractions;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using System.Collections.Generic;
using System.Linq;

namespace Kentico.Kontent.Benchmark.Statiq.Pipelines
{
    public class HomePipeline : Pipeline
    {
        public HomePipeline(IDeliveryClient client)
        {
            Dependencies.Add(nameof(ArticlesPipeline));

            ProcessModules = new ModuleList
            {
                new ReplaceDocuments(nameof(ArticlesPipeline)),
                new ReplaceDocuments(
                    Config.FromContext(context =>
                    {
                        return (IEnumerable<IDocument>) new []
                        {
                            context.CreateDocument(
                                new NormalizedPath("index.html"),
                                new[]
                                {
                                    new KeyValuePair<string, object>(Keys.Children, context.Inputs)
                                }
                            )
                        };
                    })
                ),
                
            };

            OutputModules = new ModuleList
            {
                new MergeContent(
                    new ReadFiles(patterns: "_Listing.cshtml")
                ),
                new RenderRazor()
                    .WithModel(Config.FromDocument((doc, ctx) =>
                    {
                        return doc.GetChildren()
                            .Select(item => item.AsKontent<Article>());
                    })),
                new WriteFiles()
            };
        }
    }
}
