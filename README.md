# Read Time Estimator

[![Build, Test & Coverage](https://github.com/bolorundurowb/read-time-estimator/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/bolorundurowb/read-time-estimator/actions/workflows/build-and-test.yml) [![Code Coverage](https://codecov.io/gh/bolorundurowb/read-time-estimator/branch/master/graph/badge.svg)](https://codecov.io/gh/bolorundurowb/read-time-estimator) [![NuGet Version](https://img.shields.io/nuget/v/ReadTimeEstimator)](https://www.nuget.org/packages/ReadTimeEstimator) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A .NET library that estimates the reading time of HTML and Markdown content, accounting for words, images, code blocks, and East Asian characters.


## Installation

```sh
dotnet add package ReadTimeEstimator
```

Or via the NuGet Package Manager Console:

```sh
Install-Package ReadTimeEstimator
```

Targets **netstandard2.0**, compatible with .NET Framework 4.6.1+, .NET Core 2.0+, and .NET 5+.


## Quick Start

```csharp
using ReadTimeEstimator.Implementations.Estimators;

var html = "<p>This is a short article about something interesting.</p>";
var markdown = "# Introduction\n\nThis is a short article about something interesting.";

var htmlEstimator = new HtmlEstimator();
var markdownEstimator = new MarkdownEstimator();

// Returns a double: estimated minutes to read
double minutes = htmlEstimator.ReadTimeInMinutes(html);

// Returns a human-friendly string: "less than a minute", "1 minute", "5 minutes"
string label = markdownEstimator.HumanFriendlyReadTime(markdown);
```


## API Reference

### `HtmlEstimator`

Estimates reading time for HTML content. Strips tags before counting words, accounts for `<img>` elements and `<pre>` code blocks.

```csharp
var estimator = new HtmlEstimator();

double minutes = estimator.ReadTimeInMinutes("<article>...</article>");
// Returns 0.0 for null or empty input

string label = estimator.HumanFriendlyReadTime("<article>...</article>");
// "less than a minute" | "1 minute" | "N minutes"
```

### `MarkdownEstimator`

Estimates reading time for Markdown content. Handles inline images (`![alt](url)`), fenced code blocks (` ``` ` and `~~~`), and East Asian characters.

```csharp
var estimator = new MarkdownEstimator();

double minutes = estimator.ReadTimeInMinutes("# Title\n\nContent...");
// Returns 0.0 for null or whitespace input

string label = estimator.HumanFriendlyReadTime("# Title\n\nContent...");
// "less than a minute" | "1 minute" | "N minutes"
```

### Using the `IMarkupEstimator` interface

Both estimators implement `IMarkupEstimator`, making them straightforward to use with dependency injection or to swap implementations in tests.

```csharp
using ReadTimeEstimator.Interfaces;

// Register in DI container
services.AddSingleton<IMarkupEstimator, HtmlEstimator>();

// Inject and use
public class ArticleService(IMarkupEstimator estimator)
{
    public string GetReadTime(string content) =>
        estimator.HumanFriendlyReadTime(content);
}
```


## How It Works

| Content type         | Rate                     |
|----------------------|--------------------------|
| Standard words       | 275 words per minute     |
| East Asian characters| 500 characters per minute|
| Images               | 12 seconds each          |
| Code blocks          | +10 second penalty each  |

The total estimated time is the sum of word read time, image time, and code block penalties. East Asian characters (CJK unified ideographs, Hiragana, Katakana, etc.) are counted separately at a lower WPM rate.

`HumanFriendlyReadTime` maps the raw double to a display string:

| Result          | Display              |
|-----------------|----------------------|
| < 0.5 minutes   | `less than a minute` |
| 0.5–1.5 minutes | `1 minute`           |
| > 1.5 minutes   | `N minutes`          |


## Contributing

Contributions are welcome. To get started:

```sh
git clone https://github.com/bolorundurowb/read-time-estimator.git
cd read-time-estimator/src
dotnet build
dotnet test
```

The solution layout:

```
src/
  ReadTimeEstimator/             # Library source
    Interfaces/                  # IMarkupEstimator, IMarkupPatterns
    Implementations/
      Estimators/                # HtmlEstimator, MarkdownEstimator
      Patterns/                  # HtmlPatterns, MarkdownPatterns
    Constants.cs                 # Reading speed constants
    Utilities.cs                 # HumanizeTime helper
  ReadTimeEstimator.Tests/       # xUnit test suite
```

Please open an issue before submitting a PR for anything beyond small fixes.


## License

[MIT](LICENSE)
