how to run? nothing special just build and use docker (windows) or iis Express options in visual studio, it will build and deploy evrithing is needed

assumption: I tried to make it more as working app, but for 3 hours it very hard to choose the more important thing to implement

done as monolit but in general I would prefer some cloud app using AWS Steps + lambda or Azure function or "on premise" with queues and transaction coordinator. but I did it as set of separate projects so it's easy to adjust to mentioned technologies. as we discussed in prvious interview it's better to do as microservices because of scaling, and controling all states of a transaction lifecycle. but for small and medium app monolit could be an optimal and good solution

there is alot to improve
- model validations
- more fields for requests and response models
- unit tests
- using AWS lambda or Azure funtions
