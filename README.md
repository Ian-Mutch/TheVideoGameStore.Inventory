# The Video Game Store - Inventory
An inventory microservice for TheVideoGameStore managing products

![example workflow](https://github.com/Ian-Mutch/TheVideoGameStore.Inventory/actions/workflows/build-inventory.yml/badge.svg)

## What's new

### New in 0.0.2
- Clean Architecture
  - Change project structure to use 'Clean Architecture' and CQRS pattern
  - Added MediatR
  - Changed EF Core from InMemory to SqlServer
  - Changed ApiClient to Api.Sdk

### New in 0.0.1
- Initial basic 'InventoryService' implementation
  - NSwag for API client generation
  - AutoMapper for domain > application model mappings
  - EFC InMemory database for initial data implementation with seed data
  - Serilog for logging
