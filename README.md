## The Goal: Name Sorter 
Build a name sorter. Given a set of names, order that set first by last name, then by any given names the person my have. A name must have at least 1 given name and may have up to 3 given names.

## Motivation
The GlobalX coding assessment for the role of a Junior Engineer.

## Build status [![Build Status](https://travis-ci.com/graciasrochelle/GlobalXCodingAssessment.svg?branch=master)](https://travis-ci.com/graciasrochelle/GlobalXCodingAssessment)
Build status of continus integration i.e. travis. Travis CI is configured by adding a file named .travis.yml.

## Code style
Implemented using Dependency Injection to achieve safe, reliable and secure source code. The idea of the pattern itself is to create decoupled systems that the implementation of lower level domain is not a concern of the implementor, and can be replaced without having concern of breaking implementor function.

## Tech/framework used
### Built with
- [Visual Studio for MAC](https://tutorials.visualstudio.com/vs4mac-install/install)

### Logger
- [NLog](https://nlog-project.org/)

### Testing Framework
- [xUnit.net](https://xunit.github.io/docs/getting-started-dotnet-core)

## Features
- Takes two command line arguments:
> dotnet run name-sorter ./unsorted-names-list.txt

Or set Visual Studion environment variables
> Project -> Options -> Run -> Configuration -> Default -> Arguments -> OK

_Note: Argument 1 is the feature name and Argument 2 is the filename that contains the Names to be sorted._
- The program reads the file and sorts the set of names by last name. A name must have at least 1 given name and may have up to 3 given names
- The program then writes the sorted set of names to a file `sorted-names-list.txt`
- The program also prints the unsorted and sorted set of names on the screen once the program executes

## Installation
- Step 1: Install Visual Studio or VSCode
- Step 2: Clone the project
- Step 3: Open Cloned project
- Step 4: Clean and Build project
- Step 5: Run project

**Dependencies**
- .Net version : 2.1.302 
- NLog
- xUnit

## Tests
**Run tests via terminal**
```
cd GlobalXCodingAssessment
dotnet test UnitTest/NameSorterTester.csproj
```
**Run tests via IDE**
- Step 1: Open cloned project
- Step 2: Select `NameSorterTester-UnitTests`
- Step 3: Run project

## How to use?
_Please ensure correct filename is passed_
**Run project via terminal**
```
git clone git@github.com:graciasrochelle/GlobalXCodingAssessment.git
cd GlobalXCodingAssessment
cd NameSorter
dotnet build
dotnet run name-sorter ./unsorted-names-list.txt
```
**Run test via terminal**
```
cd GlobalXCodingAssessment
dotnet build
dotnet test UnitTest/NameSorterTester.csproj
```
