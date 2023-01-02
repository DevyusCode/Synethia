![GitHub contributors](https://img.shields.io/github/contributors/Leo-Corporation/Synethia)
![GitHub issues](https://img.shields.io/github/issues/Leo-Corporation/Synethia)
![GitHub](https://img.shields.io/github/license/Leo-Corporation/Synethia)
![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/Leo-Corporation/Synethia/dotnet-core-desktop.yml?branch=main)
![Using PeyrSharp](https://img.shields.io/badge/using-PeyrSharp-DD00FF?logo=nuget)
![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/Leo-Corporation/Synethia)

# Synethia
A basic C# algorithm that can determine the behavior of a user with an application.


[Report Bug](https://github.com/Leo-Corporation/Synethia/issues/new?assignees=&labels=bug&template=bug-report.yml&title=%5BBug%5D+) · [Request Feature](https://github.com/Leo-Corporation/Synethia/issues/new?assignees=&labels=enhancement&template=feature-request.yml&title=%5BEnhancement%5D+) · [Known Issues](https://github.com/Leo-Corporation/Synethia/issues?q=is%3Aopen+is%3Aissue+label%3Abug)

## Features
- [x] Detects how long the user is using which part of an app. (like a page)
- [x] Detects how many interactions the user has with an app. (like clicking on a button)
- [x] Calculates and associates a score to each page/part of the app depending on the two factors above.

More features are coming soon.

## Score
Synethia attributes a score to each page/part of the app depending on the following two factors:
- The time the user is using the page.
- The number of interactions the user has with the page.

The score is calculated using the following formula:

~~~
score = totalTime * (interactions / 2)
~~~

> **Note** This formula can change/evolve in upcoming releases.

## Graph
Mermaid is unsupported on NuGet.
[Click here to see the graph](https://github.com/Leo-Corporation/Synethia).


## Contribute
To contribute to the project, you'll need:
- Visual Studio 2022 v17.0 or higher
  - .NET Desktop Development
  - Git
- .NET 5, 6, 7


[Click here](https://github.com/Leo-Corporation/ColorPicker/blob/main/CONTRIBUTING.md) to see the full guidelines.

## License
This project is under the [MIT License](https://github.com/Leo-Corporation/Synethia/blob/main/LICENSE).
