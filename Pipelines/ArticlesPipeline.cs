using Kentico.Kontent.Benchmark.Statiq.Models;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace Kentico.Kontent.Benchmark.Statiq.Pipelines
{
    public class ArticlesPipeline : Pipeline
    {
        public ArticlesPipeline(IDeliveryClient client)
        {
            InputModules = new ModuleList
            {
                new Kontent<Article>(client)
            };

            ProcessModules = new ModuleList
            {
                new MergeContent(
                    new ReadFiles(patterns: "_Detail.cshtml")
                ),
                new RenderRazor()
                    .WithModel(KontentConfig.As<Article>()),
                new SetDestination(
                    Config.FromDocument((doc, ctx)
                        => new NormalizedPath( $"{doc.AsKontent<Article>().Slug}.html")
                    )
                )
            };

            OutputModules = new ModuleList {
                new WriteFiles()
            };
        }
    }
}
