# Distributed Algorithms and Advanced Programming Techniques

## Laboratory Plan (Angular Standalone + ASP.NET Core)

------------------------------------------------------------------------

# 🎯 Course Strategy

We will build, step by step, a distributed-ready application composed
of:

-   Frontend: Angular (standalone architecture)
-   Backend: ASP.NET Core Web API
-   Database: SQL Server or PostgreSQL
-   Messaging: RabbitMQ / Azure Service Bus
-   DevOps: Azure DevOps Pipelines
-   Containerization: Docker
-   Cloud Concepts: Azure
-   Architecture Patterns: Clean Architecture, CQRS, Event-Driven
    Architecture

------------------------------------------------------------------------

# 📦 Project Theme (Example)

Distributed Task Management Platform

Features: - Users - Projects - Tasks - Notifications - Activity logs -
Real-time updates - Background processing - Analytics service (later
microservice)

------------------------------------------------------------------------

# 🧪 Laboratory 1 --- System Architecture & Clean Project Setup

## Goals

-   Understand distributed systems fundamentals
-   Setup FE + BE skeleton
-   Introduce Clean Architecture

## Topics

-   CAP theorem (conceptual)
-   Monolith vs Microservices
-   Clean Architecture in ASP.NET
-   Angular standalone structure

## Practical Work

Backend: - Create solution with API, Application, Domain, Infrastructure
layers - Setup DI - Configure EF Core

Frontend: - Create Angular standalone project - Setup routing and base
layout

------------------------------------------------------------------------

# 🧪 Laboratory 2 --- REST API & Angular Integration

## Goals

-   Implement proper CRUD
-   Introduce DTO mapping and validation

## Topics

-   REST constraints
-   FluentValidation
-   Angular interceptors
-   Error handling strategies

## Practical Work

Backend: - CRUD for Tasks - Global exception middleware

Frontend: - HTTP interceptor - Task list + create/edit forms

------------------------------------------------------------------------

# 🧪 Laboratory 3 --- Asynchronous Programming & Pipelines

## Goals

-   Understand async programming in distributed systems

## Topics

-   async/await deep dive
-   ASP.NET request pipeline
-   Middleware pipeline
-   Cancellation tokens

## Practical Work

-   Convert operations to async
-   Add logging middleware
-   Add correlation ID middleware

------------------------------------------------------------------------

# 🧪 Laboratory 4 --- Authentication & Authorization

## Goals

-   Secure distributed systems

## Topics

-   JWT
-   OAuth concepts
-   Role-based authorization

## Practical Work

-   Implement JWT auth
-   Angular auth guard

------------------------------------------------------------------------

# 🧪 Laboratory 5 --- Introduction to Message Queues

## Goals

-   Move from synchronous to asynchronous communication

## Topics

-   Pub/Sub
-   Competing consumers
-   RabbitMQ or Azure Service Bus basics

## Practical Work

-   Publish TaskCreated event
-   Create background consumer service

------------------------------------------------------------------------

# 🧪 Laboratory 6 --- Background Processing & Reliability

## Goals

-   Handle long-running tasks

## Topics

-   Hosted services
-   Retry policies
-   Dead Letter Queues
-   Idempotent consumers

## Practical Work

-   Implement retries
-   Simulate consumer failures

------------------------------------------------------------------------

# 🧪 Laboratory 7 --- CQRS & Read Models

## Goals

-   Separate reads from writes

## Topics

-   CQRS pattern
-   Projections
-   Event-driven updates

## Practical Work

-   Separate commands and queries
-   Create read model updated by events

------------------------------------------------------------------------

# 🧪 Laboratory 8 --- Real-Time Communication

## Goals

-   Add live updates

## Topics

-   SignalR
-   WebSockets

## Practical Work

-   SignalR hub
-   Angular real-time updates

------------------------------------------------------------------------

# 🧪 Laboratory 9 --- Microservice Extraction

## Goals

-   Extract a separate service

## Topics

-   Service boundaries
-   Data ownership
-   Distributed transactions problem

## Practical Work

-   Extract Notification service
-   Communicate via messaging only

------------------------------------------------------------------------

# 🧪 Laboratory 10 --- Docker & Containerization

## Goals

-   Prepare for deployment

## Topics

-   Dockerfiles
-   Docker Compose
-   Container networking

## Practical Work

-   Dockerize API, Angular, RabbitMQ
-   Compose entire system

------------------------------------------------------------------------

# 🧪 Laboratory 11 --- CI/CD with Azure DevOps

## Goals

-   Automate builds and deployments

## Topics

-   Pipelines
-   Build agents
-   Docker image publishing

## Practical Work

-   Create pipeline
-   Run tests automatically
-   Push Docker images

------------------------------------------------------------------------

# 🧪 Laboratory 12 --- Observability & Scaling

## Goals

-   Monitor and scale distributed systems

## Topics

-   Logging vs Tracing
-   Distributed tracing
-   Horizontal scaling
-   Load balancing

## Practical Work

-   Add structured logging
-   Simulate load
-   Run multiple API instances

------------------------------------------------------------------------

# 📊 Evaluation Strategy

  Component                     Percentage
  ----------------------------- ------------
  Weekly Lab Progress           30%
  Midterm Architecture Review   20%
  Final Distributed Extension   30%
  Code Quality & Engineering    20%

------------------------------------------------------------------------

# 🧠 Advanced Optional Topics

-   Saga pattern
-   Circuit breaker
-   Redis caching
-   Event sourcing
-   Kubernetes
-   Rate limiting
-   OpenTelemetry

------------------------------------------------------------------------

# 🏁 Final Result

Students will build: - Event-driven architecture - CI/CD pipeline -
Containerized deployment - Real-time features - Production-grade logging
& monitoring

And understand why distributed systems are difficult.
