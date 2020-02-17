This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Introducion

This project has two parts, a WebServer written in C# and a Frontend in React.

## Explication

During the development phase was encountered some issues.
1. The method `CalculateOhmValue` receive a 4th parameter for the tolerance band.
    * Solution: The parameter was ignored, there is no need of that parameter for the calculation.
2. The method `CalculateOhmValue` return an int type.
    * There is are some multipliers colors with double values(Gold=>0.1 and Silver=>0.01) then in some cases the return value can be a floating-point value.
        *Solution: In those cases the result was rounded and converted to int.
    * There are some cases in which the return value is larger than the larger value that an int32 type value can store.
        *Solution: In those cases the result was set to the larger value that an int32 type value can store.

## Installation

### OhmcalculatorFrontend
    cd ohmcalculatorFrontend && npm install
### OhmCalculatorServer
    cd OhmCalculatorServer
    Use Visual Studo or another C# compiler to open the file `OhmCalculator.sln` and build the project

## Run the project
### First, start the server
    cd OhmCalculatorServer/OhmCalculator/bin/Debug
    start OhmCalculator.exe
### Second, start the React Server
    npm start
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

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can’t go back!**

If you aren’t satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you’re on your own.

You don’t have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn’t feel obligated to use this feature. However we understand that this tool wouldn’t be useful if you couldn’t customize it when you are ready for it.

