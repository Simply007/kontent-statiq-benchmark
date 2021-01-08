# Kontent and Statiq benchmark

Alternation of the [Gatsby's willit.build benchmark](https://github.com/gatsbyjs/gatsby/tree/master/benchmarks/source-kontent) for [Statiq](https://statiq.dev/) and [Kentico Kontent](https://kontent.ai) as a data source.

## 🧐 Results

### On Github action

See [Github action logs](https://github.com/Simply007/kontent-statiq-benchmark/actions) for test runs (Generation time in `Publish` step in the build Job).

> Every test was ran twice (to ensure items are properly cached on Fastly CDN.
>
> 1st run
> 
> * 512 pages - 8s (2m 17s for whole job incl. deploy to github pages)
> * 4096 pages - 17s (4m 35s for whole job incl. deploy to github pages)
> * 8192 pages - 29s (7m 17s for whole job incl. deploy to github pages)
> * 32768 pages - 1m 18s (23m 4s for whole job incl. deploy to github pages)

**2nd run**

* 512 pages - **9s** (2m 4s for whole job incl. deploy to github pages) - [JOB LINK](https://github.com/Simply007/kontent-statiq-benchmark/actions/runs/471564487)
* 4096 pages - **13s** (4m 45s for whole job incl. deploy to github pages) - [JOB LINK](https://github.com/Simply007/kontent-statiq-benchmark/actions/runs/471550272)
* 8192 pages - **16s*** (7m 40s for whole job incl. deploy to github pages) - [JOB LINK](https://github.com/Simply007/kontent-statiq-benchmark/actions/runs/471521860)
* 32768 pages - **46s** (21m 17s for whole job incl. deploy to github pages) - [JOB LINK](https://github.com/Simply007/kontent-statiq-benchmark/actions/runs/471459012)

## How to use

### Download manually

Download the example:

```sh
git clone https://github.com/Simply007/kontent-statiq-benchmark
cd kontent-statiq-benchmark
```

## Configuration

If you want to use prepared project skip following section. YOu could just run the test.

### Import content models and it's data (512 pages)

1. Enter [Kontent application](https://app.kontent.ai)
1. Go to "Project Settings", select API keys
1. Activate Management API
1. Copy `Project ID` and `Management API` key
1. Install [Kontent Backup Manager](https://github.com/Kentico/kontent-backup-manager-js) and import data to newly created project from [kontent-backup.zip](./kontent-backup.zip) file (place appropriate values for apiKey and projectId arguments):

   ```sh
   npm i -g @kentico/kontent-backup-manager
   kbm --action=restore --apiKey=<Management API key> --projectId=<Project ID> --zipFilename=kontent-backup
   ```

   > **:bulb: Alternatively, you can use the [Template Manager UI](https://kentico.github.io/kontent-template-manager/import-from-file) for importing the content.**

1. Go to your Kontent project and publish all the imported items.
   > You could deactivate Management API key, it is not necessary any more.

💡 If you want to generate bigger data sets, use [Kontent Data Generator](https://github.com/Simply007/kontent-data-generator).

## Run the benchmark

```sh
dotnet run  --configuration Release
```

The output wit the generation time should looks like that (**Last line**):

```plain
Run dotnet run --configuration Release
[INFO] Statiq Framework version 1.0.0-beta.29+a415eded36042aa7385b2f5b05cbf3d45ce2b7c7
[INFO] Statiq Web version 1.0.0-beta.14+cdb07e6364c16d1c6d5787f84bd8bc952e03ae3f
[INFO] Root path:
       /home/runner/work/kontent-statiq-benchmark/kontent-statiq-benchmark
[INFO] Input path(s):
       theme/input
       input
[INFO] Output path:
       output
[INFO] Temp path:
       temp
[INFO] ========== Execution ==========
[INFO] Executing 12 pipelines (AnalyzeContent, Archives, ArticlesPipeline, Assets, Content, Data, DirectoryMetadata, Feeds, HomePipeline, Inputs, Redirects, Sitemap)
[INFO] Cleaned temp directory: temp
[INFO] Cleaned output directory: output
[INFO] -> Inputs/Input » Starting Inputs Input phase execution... (0 input document(s), 1 module(s))
[INFO] -> ArticlesPipeline/Input » Starting ArticlesPipeline Input phase execution... (0 input document(s), 1 module(s))
[INFO] -> DirectoryMetadata/Input » Starting DirectoryMetadata Input phase execution... (0 input document(s), 1 module(s))
[INFO] <- Inputs/Input » Finished Inputs Input phase execution (1 output document(s), 1719 ms)
[INFO] <- DirectoryMetadata/Input » Finished DirectoryMetadata Input phase execution (0 output document(s), 870 ms)
[INFO] -> DirectoryMetadata/Process » Starting DirectoryMetadata Process phase execution... (0 input document(s), 1 module(s))
[INFO] <- DirectoryMetadata/Process » Finished DirectoryMetadata Process phase execution (0 output document(s), 2 ms)
[INFO] -> Inputs/Process » Starting Inputs Process phase execution... (1 input document(s), 9 module(s))
[INFO] <- Inputs/Process » Finished Inputs Process phase execution (1 output document(s), 150 ms)
[INFO] -> Assets/Process » Starting Assets Process phase execution... (0 input document(s), 3 module(s))
[INFO] -> Data/Process » Starting Data Process phase execution... (0 input document(s), 5 module(s))
[INFO] <- Data/Process » Finished Data Process phase execution (0 output document(s), 14 ms)
[INFO] -> Content/Process » Starting Content Process phase execution... (0 input document(s), 4 module(s))
[INFO] <- Assets/Process » Finished Assets Process phase execution (1 output document(s), 820 ms)
[INFO] <- Content/Process » Finished Content Process phase execution (0 output document(s), 825 ms)
[INFO] -> Redirects/Process » Starting Redirects Process phase execution... (0 input document(s), 2 module(s))
[INFO] -> Archives/Process » Starting Archives Process phase execution... (0 input document(s), 3 module(s))
[INFO] <- Archives/Process » Finished Archives Process phase execution (0 output document(s), 1 ms)
[INFO] -> Feeds/Process » Starting Feeds Process phase execution... (0 input document(s), 3 module(s))
[INFO] <- Feeds/Process » Finished Feeds Process phase execution (0 output document(s), 1 ms)
[INFO] <- Redirects/Process » Finished Redirects Process phase execution (0 output document(s), 5 ms)
[INFO] <- ArticlesPipeline/Input » Finished ArticlesPipeline Input phase execution (512 output document(s), 2574 ms)
[INFO] -> ArticlesPipeline/Process » Starting ArticlesPipeline Process phase execution... (512 input document(s), 3 module(s))
[INFO] [Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager] User profile is available. Using '/home/runner/.aspnet/DataProtection-Keys' as key repository; keys will not be encrypted at rest.
[INFO] <- ArticlesPipeline/Process » Finished ArticlesPipeline Process phase execution (512 output document(s), 4536 ms)
[INFO] -> HomePipeline/Process » Starting HomePipeline Process phase execution... (0 input document(s), 2 module(s))
[INFO] <- HomePipeline/Process » Finished HomePipeline Process phase execution (1 output document(s), 1 ms)
[INFO] -> Sitemap/PostProcess » Starting Sitemap PostProcess phase execution... (0 input document(s), 1 module(s))
[INFO] -> ArticlesPipeline/Output » Starting ArticlesPipeline Output phase execution... (512 input document(s), 1 module(s))
[INFO] <- Sitemap/PostProcess » Finished Sitemap PostProcess phase execution (1 output document(s), 1 ms)
[INFO] -> HomePipeline/Output » Starting HomePipeline Output phase execution... (1 input document(s), 3 module(s))
[INFO] -> Data/Output » Starting Data Output phase execution... (0 input document(s), 2 module(s))
[INFO] -> Content/PostProcess » Starting Content PostProcess phase execution... (0 input document(s), 1 module(s))
[INFO] -> Archives/PostProcess » Starting Archives PostProcess phase execution... (0 input document(s), 1 module(s))
[INFO] -> Feeds/Output » Starting Feeds Output phase execution... (0 input document(s), 2 module(s))
[INFO] -> Assets/Output » Starting Assets Output phase execution... (1 input document(s), 2 module(s))
[INFO] -> Redirects/Output » Starting Redirects Output phase execution... (0 input document(s), 1 module(s))
[INFO] -> Sitemap/Output » Starting Sitemap Output phase execution... (1 input document(s), 1 module(s))
[INFO] <- Content/PostProcess » Finished Content PostProcess phase execution (0 output document(s), 7 ms)
[INFO] -> Content/Output » Starting Content Output phase execution... (0 input document(s), 2 module(s))
[INFO] <- Data/Output » Finished Data Output phase execution (0 output document(s), 8 ms)
[INFO] <- Redirects/Output » Finished Redirects Output phase execution (0 output document(s), 5 ms)
[INFO] <- Feeds/Output » Finished Feeds Output phase execution (0 output document(s), 6 ms)
[INFO] <- Archives/PostProcess » Finished Archives PostProcess phase execution (0 output document(s), 8 ms)
[INFO] -> Archives/Output » Starting Archives Output phase execution... (0 input document(s), 2 module(s))
[INFO] <- Archives/Output » Finished Archives Output phase execution (0 output document(s), 0 ms)
[INFO] <- Content/Output » Finished Content Output phase execution (0 output document(s), 2 ms)
[INFO] <- Sitemap/Output » Finished Sitemap Output phase execution (1 output document(s), 10 ms)
[INFO] <- Assets/Output » Finished Assets Output phase execution (1 output document(s), 11 ms)
[INFO] <- ArticlesPipeline/Output » Finished ArticlesPipeline Output phase execution (512 output document(s), 107 ms)
[INFO] <- HomePipeline/Output » Finished HomePipeline Output phase execution (1 output document(s), 288 ms)
[INFO] -> AnalyzeContent/Input » Starting AnalyzeContent Input phase execution... (0 input document(s), 1 module(s))
[INFO] <- AnalyzeContent/Input » Finished AnalyzeContent Input phase execution (1 output document(s), 1 ms)
[INFO] AnalyzeContent/Process » Running 3 analyzers (FencedCodeBlocksShouldHaveLanguage, ValidateRelativeLinks, ValidateAbsoluteLinks)
[INFO] ========== Execution Summary ==========

Number of output documents per pipeline and phase:

 | Pipeline          | Input         | Process       | PostProcess | Output       | Total Time | 
 |---------------------------------------------------------------------------------------------| 
 | AnalyzeContent    | 1 (1 ms)      |               |             |              | 1 ms       | 
 | Archives          |               | 0 (1 ms)      | 0 (8 ms)    | 0 (0 ms)     | 9 ms       | 
 | ArticlesPipeline  | 512 (2574 ms) | 512 (4536 ms) |             | 512 (107 ms) | 7217 ms    | 
 | Assets            |               | 1 (820 ms)    |             | 1 (11 ms)    | 831 ms     | 
 | Content           |               | 0 (825 ms)    | 0 (7 ms)    | 0 (2 ms)     | 834 ms     | 
 | Data              |               | 0 (14 ms)     |             | 0 (8 ms)     | 22 ms      | 
 | DirectoryMetadata | 0 (870 ms)    | 0 (2 ms)      |             |              | 872 ms     | 
 | Feeds             |               | 0 (1 ms)      |             | 0 (6 ms)     | 7 ms       | 
 | HomePipeline      |               | 1 (1 ms)      |             | 1 (288 ms)   | 289 ms     | 
 | Inputs            | 1 (1719 ms)   | 1 (150 ms)    |             |              | 1869 ms    | 
 | Redirects         |               | 0 (5 ms)      |             | 0 (5 ms)     | 10 ms      | 
 | Sitemap           |               |               | 1 (1 ms)    | 1 (10 ms)    | 11 ms      | 

Pipeline phase timeline:

 | Pipeline          | Timeline (8086 total ms)                                                             | 
 |----------------------------------------------------------------------------------------------------------| 
 | AnalyzeContent    |                                                                                  I   | 
 | Archives          |                            P                                                  TO     | 
 | ArticlesPipeline  |        I-------------------------P--------------------------------------------O      | 
 | Assets            |                    P-------                                                   O      | 
 | Content           |                    P-------                                                   TO     | 
 | Data              |                    P                                                          O      | 
 | DirectoryMetadata |          I--------P                                                                  | 
 | Feeds             |                            P                                                  O      | 
 | HomePipeline      |                                                                               PO-    | 
 | Inputs            | I-----------------P                                                                  | 
 | Redirects         |                            P                                                  O      | 
 | Sitemap           |                                                                               TO     | 


[INFO] ========== Completed ==========
[INFO] Finished execution in 8259 ms
[INFO] Cleaned temp directory: temp
```

### Set up app setting

If you want to test out different data  Set `app.settings` ProjectId to:

512 pages: "a10066e5-3116-009d-b85f-92a648ba1b5e"
4096 pages: "cf018856-cb3d-00c8-6833-9b42bf5464dc"
8192 pages: "582c80c7-df57-00b5-d969-64b3cc3d4a36"
32 768 pages: "4b48bc3a-83aa-000e-55e0-4e1bcf9e829d"

