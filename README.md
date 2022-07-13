# Synethia
 A C# algorithm that can determine the way the user behaves with an app.

## Features
- [x] Detects how long the user is using which part of an app. (like a page)
- [x] Detects how many interactions the user has with an app. (like clicking on a button)
- [x] Calculates and associates a score to each page/part of the app depending on the two factors above.

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
## License
This project is under the [MIT License](https://github.com/Leo-Corporation/Synethia/blob/main/LICENSE).