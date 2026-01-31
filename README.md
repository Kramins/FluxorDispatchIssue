# FluxorDispatchIssue

A demo project for a bug submission showing an issue with Fluxor's dispatcher when dispatching actions from a background process using a scoped service provider.

## Overview

This project demonstrates a specific issue with Fluxor where actions dispatched from a background service via a scoped `IDispatcher` are not being properly handled or reflected in the application state.

## Project Structure

- **Store/**: Contains the Fluxor store setup with actions and reducers
  - `CounterState.cs` - Application state
  - `IncrementCounterAction.cs` - Action definition
  - `Reducers.cs` - State reducers
- **Pages/**: Blazor components displaying the counter
- **CounterBackgroundService.cs** - Background service that dispatches counter increment actions
- **Program.cs** - Application setup and configuration

## Running the Project

```bash
dotnet run
```

The application will start on `http://localhost:5000` and can be debugged in Chrome.

## Bug Description

When the `CounterBackgroundService` dispatches an `IncrementCounterAction` through a scoped `IDispatcher` instance, the action is dispatched but the state does not update as expected.