using Kentico.Kontent.Benchmark.Statiq.Models;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kentico.Kontent.Benchmark.Statiq.Pipelines
{
    public class HomePipeline : Pipeline
    {
        public HomePipeline(IDeliveryClient client)
        {
            Dependencies.AddRange(nameof(ArticlesPipeline));

            ProcessModules = new ModuleList
            {                
                new ReplaceDocuments(nameof(ArticlesPipeline)), // I get 512 Artiles in Content.Inputs

                // I need to merge input documents into one to IEnumebrable<Article>
                // to be able to pass it to the Razor like:

                // new RenderRazor()
                //   .WithModel(/*THERE GET AN IENUMERABLE<ARTICLE>*/),
                

                // IGNORE THIS PART START
                //new ReplaceDocuments(
                //    new ExecuteConfig(Config.FromContext((context) =>
                //    {
                //        return context.Inputs;
                //    }))),
                //new ExecuteConfig(Config.FromDocument((doc, context) => {
                //    return doc;
                //})),
                //new ExecuteConfig(Config.FromContext((context) => {
                //    return context;
                //})),
                // IGNORE THIS PART END

                new MergeContent(
                    new ReadFiles(patterns: "_Hero.cshtml")
                ),
                new SetDestination(new NormalizedPath("index.html"))                
            };

            OutputModules = new ModuleList
            {
                new WriteFiles()
            };
        }
    }
}
