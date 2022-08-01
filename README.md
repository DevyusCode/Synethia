![GitHub contributors](https://img.shields.io/github/contributors/Leo-Corporation/Synethia)
![GitHub issues](https://img.shields.io/github/issues/Leo-Corporation/Synethia)
![GitHub](https://img.shields.io/github/license/Leo-Corporation/Synethia)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/Leo-Corporation/Synethia/.NET%20Desktop)
![Using LeoCorpLibrary](https://img.shields.io/badge/using-LeoCorpLibrary-blue)
![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/Leo-Corporation/Synethia)

<br />

<h3 align="center"> 
⚠️ This is a work in progress. ⚠️
</h3>


<br />
<p align="center">
  <a href="https://github.com/Leo-Corporation/Synethia">
    <img src=".github/images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h1 align="center">Synethia</h3>

  <p align="center">
    A basic C# algorithm that can determine the behavior of a user with an application.
    <br />
    <a href="https://github.com/Leo-Corporation/Synethia/issues/new?assignees=&labels=bug&template=bug-report.yml&title=%5BBug%5D+">Report Bug</a>
    ·
    <a href="https://github.com/Leo-Corporation/Synethia/issues/new?assignees=&labels=enhancement&template=feature-request.yml&title=%5BEnhancement%5D+">Request Feature</a>
    ·
    <a href="https://github.com/Leo-Corporation/Synethia/issues?q=is%3Aopen+is%3Aissue+label%3Abug">Known Issues</a>

  </p>
</p>

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
$$
score = totalTime * ({interactions \over 2})
$$

> **Note** This formula can change/evolve in upcoming releases.

## Graph
~~~ mermaid
graph TD
    App-->MainWindow-->Page-->C
    Page-->A
    Page-->F
    A{When a page is viewed}-->B[Get the current Unix time]
    B 
    C{Page left}-->D[Calculate total time elapsed]
    D-->E[Add this value to the page interest score]
    C-->B

    F{When an interaction occurs}-->E

    E-->G[Compare this score with the score of other pages]
    H[The page with the highest score can be suggested to the user]
    I[The page with the lowest score can be suggested to a 'Discover' section]

    G-->H
    G-->I

    MainWindow-->p1(Page 1 interest score)
    MainWindow-->p2(Page 2 interest score)
    MainWindow-->p3(Page 3 interest score)
    p1-->G
    p2-->G
    p3-->G
~~~
## Contribute
To contribute to the project, you'll need:
- Visual Studio 2022 v17.0 or higher
  - .NET Desktop Development
  - Git
- .NET 6


[Click here](https://github.com/Leo-Corporation/ColorPicker/blob/main/CONTRIBUTING.md) to see the full guidelines.

## License
This project is under the [MIT License](https://github.com/Leo-Corporation/Synethia/blob/main/LICENSE).
