# CafeConsole ☕️

**CafeConsole** is a .NET console application that simulates a self-service café ordering system.  
The project focuses on **SOLID principles**, **loose coupling**, and the practical use of **GoF design patterns**, together with several optional architectural extensions.

Users can select a base beverage, add optional extras, choose a pricing policy, and receive an itemized receipt. When an order is placed, domain events are published and handled by observers for logging and analytics.

---

## Features

- **Console ordering flow**
  - Choose a base beverage (Espresso, Tea, Hot Chocolate)
  - Add multiple add-ons (Milk, Syrup, Extra Shot)
  - Select a pricing policy
  - Print an itemized receipt
- **Pricing strategies**
  - Regular pricing (no discount)
  - Happy Hour pricing (20% discount)
  - Member pricing (10% discount)
  - Coupon pricing (custom percentage discount)
- **Event-driven side effects**
  - `OrderPlaced` event is published when an order is finalized
  - Observers handle logging and analytics without coupling to core logic
- **Preparation simulation**
  - Beverage preparation steps are simulated using a standardized workflow
- **Unit tests**
  - Core business logic is covered using xUnit and Moq

---

## Architecture

The solution is split into multiple projects to ensure a clean separation of concerns and a pure domain layer.

CafeConsole.sln
├── Cafe.Domain
│ ├── Beverages (IBeverage, Espresso, Tea, HotChocolate, decorators)
│ ├── Pricing (IPricingStrategy, Regular, HappyHour, Member, Coupon)
│ ├── Events (OrderPlaced, IOrderEventObserver, IOrderEventPublisher)
│ └── Factories (IBeverageFactory)
├── Cafe.Application
│ ├── Orders (IOrderService, OrderService, OrderReceiptDto)
│ └── Events (OrderEventPublisher)
├── Cafe.Infrastructure
│ ├── Factories (BeverageFactory)
│ ├── Observers (ConsoleOrderLogger, InMemoryOrderAnalytics, RemoteAnalyticsObserver)
│ └── Analytics (Proxy, Remote stub, fallback)
├── CafeConsole
│ ├── States (State pattern kiosk flow)
│ ├── MenuHelper, PreparationHelper
│ └── Program.cs (composition root)
└── Cafe.Tests (xUnit, Moq)

yaml
Copy code

The **Domain** layer contains no console I/O and no infrastructure concerns.  
All dependencies are wired manually in the console project.

---

## Design Patterns Used

### Factory
Centralizes creation of base beverages and keeps the system open for extension.

### Decorator
Adds optional extras (milk, syrup, extra shot) to beverages without modifying base classes.

### Strategy
Encapsulates pricing rules so they can be swapped at runtime (Regular, Happy Hour, Member, Coupon).

### Observer
Decouples side effects (logging, analytics) from order placement using domain events.

---

## Extensions (Stretch Goals)

### State Pattern (Kiosk Flow)
The console UI is modeled as a simple kiosk state machine:
Idle → BuildingOrder → Printing → Idle

yaml
Copy code
Each state encapsulates its own behavior and transitions.

### Template Method (Beverage Preparation)
A standardized preparation sequence (heat water, brew, pour, garnish) is defined using the Template Method pattern, with hooks for beverage-specific behavior and add-on customization.

### Proxy Pattern (Remote Analytics)
A proxy wraps a simulated remote analytics client, adding retry and fallback behavior so analytics failures never impact the core ordering flow.

---

## How to Run

### Requirements
- .NET 8 or .NET 9 SDK

### Run the application
```bash
dotnet run --project CafeConsole
Run unit tests
bash
Copy code
dotnet test
Testing
Unit tests cover:

Beverage decorators (cost and description composition)

Pricing strategies (Regular, Happy Hour, Member, Coupon)

Factory behavior and invalid inputs

Observer notification using Moq

In-memory analytics aggregation

Notes
Business logic is isolated from UI and infrastructure concerns.

The project is designed to be easily extensible with new beverages, add-ons, pricing rules, or observers.

The focus is on clarity, maintainability, and correct application of design patterns.
