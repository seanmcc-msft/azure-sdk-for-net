# File Storage
> see https://aka.ms/autorest

## Configuration
``` yaml
# Generate file storage
output-folder: ../src/Generated
clear-output-folder: false

# Use the Azure C# Track 2 generator
# use: C:\src\Storage\Swagger\Generator
# We can't use relative paths here, so use a relative path in generate.ps1
azure-track2-csharp: true
```

### Metrics
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.Metrics.type = "object";
```

### Remove ShareSnapshot as a method parameter.
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.ShareSnapshot["x-ms-parameter-location"];
```

### Times aren't required
``` yaml
directive:
- from: swagger-document
  where: $.parameters.FileCreationTime
  transform: >
    delete $.format;
- from: swagger-document
  where: $.parameters.FileLastWriteTime
  transform: >
    delete $.format;
```

### ErrorCode
``` yaml
directive:
- from: swagger-document
  where: $.definitions.ErrorCode["x-ms-enum"]
  transform: >
    $.name = "ShareErrorCode";
```

### Add ShareName, Directory, and FileName as a parameters
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
   Object.keys($).map(id => {
     if (id.includes('/{shareName}/{directory}?comp=listhandles'))
     {
       $[id.replace('/{shareName}/{directory}?comp=listhandles', '/{shareName}/{directory}?restype=directory&comp=listhandles')] = $[id];
       delete $[id];
     }
   });
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
   Object.keys($).map(id => {
     if (id.includes('/{shareName}/{directory}?comp=forceclosehandles'))
     {
       $[id.replace('/{shareName}/{directory}?comp=forceclosehandles', '/{shareName}/{directory}?restype=directory&comp=forceclosehandles')] = $[id];
       delete $[id];
     }
   });
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
   Object.keys($).map(id => {
     if (id.includes('{shareName}'))
     {
       $[id.replace('{shareName}', '')] = $[id];
       delete $[id];
     }
   });
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
   Object.keys($).map(id => {
     if (id.includes('/{directory}'))
     {
       $[id.replace('/{directory}', '')] = $[id];
       delete $[id];
     }
   });
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
   Object.keys($).map(id => {
     if (id.includes('/{fileName}'))
     {
       $[id.replace('/{fileName}', '')] = $[id];
       delete $[id];
     }
   });
```

