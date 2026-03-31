
# FeaturesPlatform — Full Implementation Plan (Phases 0 → 8)

## 🔒 Architecture Contract (Source of Truth)

- Concept: **Feature** (not Task)
- Application:
  - Commands + Handlers in same folder
  - Queries + Handlers in same folder
  - EventHandlers separate
  - No MediatR
- Database:
  - DbContext
  - Configurations
  - Repositories
  - Outbox
- Infrastructure:
  - DomainEventDispatcher
  - OutboxProcessor
- No controllers yet
- Prefer constants over magic strings

---

# 🧱 Phase 0 — Solution Setup

## Goal
Create clean architecture structure.

## Steps
1. Create projects:
   - Domain
   - Application
   - Database
   - Infrastructure
   - API
2. Add references:
   - Application → Domain
   - Database → Domain
   - Infrastructure → Application
   - API → all

---

# 🧱 Phase 1 — Domain Model

## Goal
Define core business logic.

## Key Elements
- Project (Aggregate Root)
- FeatureItem (Entity)
- FeatureStatus (Enum)
- FeatureCreatedDomainEvent

## Important
- `_features` as private field
- Raise domain events inside aggregate

---

# 🧱 Phase 2 — Application Layer

## Goal
Introduce use cases.

## Structure
Application/Features/Features/

### Commands
- CreateFeatureCommand
- CreateFeatureCommandHandler

### Queries
- GetProjectByIdQuery
- GetProjectByIdQueryHandler

### EventHandlers
- FeatureCreatedEventHandler

## Concepts
- No MediatR
- Manual orchestration

---

# 🧱 Phase 3 — Persistence (EF Core)

## Goal
Persist aggregates.

## Key Elements
- DbContext
- Configurations
- Repository (ProjectRepository)
- UnitOfWork

## Concepts
- Aggregate persistence
- Transaction boundary per command

---

# 🧱 Phase 4 — Domain Events Dispatching

## Goal
React to domain events.

## Key Elements
- IDomainEventDispatcher (Application)
- DomainEventDispatcher (Infrastructure)
- IDomainEventHandler

## Flow
SaveChanges → Dispatch events → Execute handlers

---

# 🧱 Phase 5 — Outbox Pattern

## Goal
Ensure reliable event processing.

## Key Elements
- OutboxMessage (Database)
- UnitOfWork stores events instead of dispatching

## Flow
Command → DB + Outbox → Processor → Dispatcher → Handler

---

# 🧱 Phase 6 — Background Processing

## Goal
Automate outbox processing.

## Options
- Manual trigger (teaching phase)
- BackgroundService (production)

## Key Element
- OutboxProcessor loop

---

# 🧱 Phase 7 — Message Broker Integration

## Goal
Make system distributed.

## Add
- RabbitMQ / Azure Service Bus

## Flow
Outbox → Broker → External Consumers

## Concepts
- Event-driven architecture
- Decoupling services

---

# 🧱 Phase 8 — Read Models & Projections

## Goal
Optimize queries.

## Add
- Read models
- Projection handlers

## Concepts
- CQRS (full)
- Eventually consistent reads

---

# 🎯 Final Outcome

A production-ready system with:
- Clean Architecture
- DDD
- CQRS
- Domain Events
- Outbox Pattern
- Messaging

