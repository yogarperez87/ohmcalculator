
## Introduction

This project has two parts, a WebServer written in C# and a Frontend in React.

## Explanation
The project has two parts
1. An API server written in C# (OhmCalculatorServer)
    * Contains the all the classes, interfaces and operations
2. A frontend written whith React (ohmcalculatorFrontend)

During the development phase was encountered some issues.
1. The method `CalculateOhmValue` receive a 4th parameter for the tolerance band.
    * Solution: The parameter was ignored, there is no need of that parameter for the calculation.
2. The method `CalculateOhmValue` return an int type.
    * There is are some multipliers colors with double values(Gold=>0.1 and Silver=>0.01) then in some cases the return value can be a floating-point value.
        * Solution: In those cases the result was rounded and converted to int.
    * There are some cases in which the return value is larger than the larger value that an int32 type value can store.
        * Solution: In those cases the result was set to the larger value that an int32 type value can store.

## Requirements
* Node 8.16.0 or later version
* Visual Studio or another C# compiler

## Installation

### OhmcalculatorFrontend
#### From the project root
    cd ohmcalculatorFrontend && npm install
### OhmCalculatorServer
#### From the project root
    cd OhmCalculatorServer
    Use Visual Studo or another C# compiler to open the file `OhmCalculator.sln` and build the project

## Run the project
### First, start the server
#### From the project root
    cd OhmCalculatorServer/OhmCalculator/bin/Debug
    start OhmCalculator.exe
### Second, start the React Server
#### From the project root
    cd ohmcalculatorFrontend && npm start
You cant start to use the calculator

## Available Scripts

In the project OhmcalculatorFrontend directory, you can run:

### `npm start`

Runs the app in the development mode.<br />
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.<br />
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.<br />
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.<br />
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.<br />
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.


