# Blazor State Sample

A small .NET 8 Blazor Web App focused on state management with a shared scoped service.

The app uses Blazor interactive server rendering. `StateContainer` is registered with dependency injection, then injected into components that need to read or update the shared counter value.

## Main Idea: State Management

The main purpose of this project is to show how multiple Blazor components can share and react to the same state.

`StateContainer` owns the counter value. Pages update that value, and the navigation menu listens for changes so it can refresh its badge without each component keeping a separate copy of the counter.

## Project Structure

```text
BlazorStateSample/
  Program.cs                    App startup, services, and render mode
  StateContainer.cs             Shared scoped counter state
  Components/
    App.razor                   HTML shell and Blazor script
    Routes.razor                Router configuration
    Layout/
      MainLayout.razor          Page layout
      NavMenu.razor             Navigation and counter badge
    Pages/
      Home.razor                Home page with counter increment button
      Counter.razor             Counter page with current count
      Weather.razor             Sample async data page
```

## Requirements

- .NET 8 SDK

## Run

```powershell
dotnet run --project .\BlazorStateSample\BlazorStateSample.csproj
```

Default launch URLs are:

- `https://localhost:7228`
- `http://localhost:5207`

## State Management Workflow

1. `Program.cs` creates the Blazor app, enables interactive server components, and registers `StateContainer` as a scoped service.
2. `App.razor` loads the app shell and renders `Routes` with `InteractiveServer` mode.
3. `Routes.razor` maps URL routes to Razor pages inside `MainLayout`.
4. `Home.razor` and `Counter.razor` inject `StateContainer` and increment `StateContainer.Counter` when their button is clicked.
5. `StateContainer.Counter` raises `OnChange` whenever the value changes.
6. `NavMenu.razor` listens to `StateContainer.OnChange`, calls `StateHasChanged`, and updates the counter badge in the sidebar.
7. `Weather.razor` is independent of the shared counter and demonstrates async component initialization with generated forecast data.

## Development Workflow

```powershell
dotnet restore .\BlazorStateSample.slnx
dotnet build .\BlazorStateSample.slnx
dotnet run --project .\BlazorStateSample\BlazorStateSample.csproj
```

Use the Home or Counter page to update the shared counter. The Counter page displays the current value, and the navigation badge updates after each state change.
