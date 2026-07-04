# WinForms Mini Projects

Two small C# WinForms projects built while practicing event-driven UI, control state, and custom rendering.

## 1. Pizza Order

A pizza order form with dynamic price calculation.

**Features**
- Radio buttons for size and crust selection
- Checkboxes for toppings
- Live price calculation using the `Tag` property to store per-option prices
- Order summary displayed in a `MessageBox` on submit

**Concepts practiced**
- Grouping controls (`GroupBox`/`Panel`) for mutually exclusive radio button sets
- Reading control state (`Checked`) across multiple controls
- Using `Tag` to attach data (price) directly to UI elements instead of separate lookup logic

## 2. Tic-Tac-Toe

A dark-themed Tic-Tac-Toe game for two players.

**Features**
- Dark UI theme
- X / O / empty-cell images
- Single shared click event handler for all 9 cells
- Win detection (rows, columns, diagonals)
- Draw detection
- Grid painted manually using `Graphics`

**Concepts practiced**
- Sharing one event handler across multiple controls and identifying the sender
- Win/draw logic using a game-state array
- Custom drawing with `System.Drawing.Graphics` instead of static images for the grid

## Tech

- C# / .NET WinForms
- Visual Studio

## How to Run

1. Clone the repo
2. Open the desired project's `.sln` file in Visual Studio
3. Build and run (F5)
