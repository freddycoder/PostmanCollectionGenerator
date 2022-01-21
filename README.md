# PostmanCollectionGenerator
A CLI tool to create postman collection from a folder full of request file and a collection template.

### Arguments:
 arg0: sourceFolder
 arg1: destinationFolder
 arg2: collectionSource
 arg3: collectionName

### Argument descritpions:
 sourceFolder: The folder with all the request file.
 destinationFolder: Where the collection generated will be located.
 collectionSource: The collection to start with. Use as a template to generate the new collection.
 collectionName: The name of the new collection.

## Exemple:
```
PostmanCollectionGenerator.exe E:\frederic\Bureau\xmls E:\frederic\Bureau\ "E:\frederic\Bureau\Default collection.postman_collection.json" Generated.postman_collection.json
```
