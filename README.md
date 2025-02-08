# ⏳ Read Time Estimator  

[![Build Status](https://ci.appveyor.com/api/projects/status/qavt251akt6rfpm3?svg=true)](https://ci.appveyor.com/project/BolorunduroWinnerTimothy/read-time-estimator)  [![Code Coverage](https://codecov.io/gh/bolorundurowb/read-time-estimator/branch/master/graph/badge.svg)](https://codecov.io/gh/bolorundurowb/read-time-estimator)  [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)  ![NuGet Version](https://img.shields.io/nuget/v/ReadTimeEstimator)
 

📖 **Read Time Estimator** is a library that provides an accurate estimate of the read time for an article in **HTML** or **Markdown**.

---

## 📦 Installation  

You can install the package via **NuGet**:  

```sh
Install-Package ReadTimeEstimator
```

Or using **.NET CLI**:

```sh
dotnet add package ReadTimeEstimator
```

Or with **Paket**:

```sh
paket add ReadTimeEstimator
```

---

## 🚀 Usage

This package provides two estimators:

- 🖥️ `HtmlEstimator` for HTML content
- ✍️ `MarkdownEstimator` for Markdown content

Each estimator offers two methods for retrieving time estimates:

- ⏱️ `ReadTimeInMinutes()` → Returns a `double` (estimated read time in minutes).
- 🗣️ `HumanFriendlyReadTime()` → Returns a `string` (human-friendly read time).

### ✅ Example Usage:

```csharp
using ReadTimeEstimator.Implementations.Estimators;

var htmlEstimator = new HtmlEstimator();
var markdownEstimator = new MarkdownEstimator();

var htmlReadTime = htmlEstimator.ReadTimeInMinutes("<div>Hello World</div>"); // 0.00727
var markdownReadTime = markdownEstimator.HumanFriendlyReadTime("# Hello World"); // "less than a minute"
```

🔹 Now you can easily estimate reading time for your content! 🚀