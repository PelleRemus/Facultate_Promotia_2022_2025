# 🐳 FeaturesPlatform – Docker & RabbitMQ Setup Guide

This guide explains the required steps to run the **FeaturesPlatform** project, which depends on RabbitMQ for messaging.

---

# ⚠️ Prerequisites

To run this project, you must install the following:

## 1. Install WSL (Windows Subsystem for Linux)

Open **PowerShell as Administrator** and run:

```bash
wsl --install
```

After installation:
- Restart your computer
- Let WSL finish setup

---

## 2. Install Docker Desktop

Download and install Docker Desktop:

👉 https://www.docker.com/products/docker-desktop/

### Important:
- During installation, make sure **WSL 2 integration is enabled**
- After installation, **start Docker Desktop**
- Wait until Docker shows it is running

---

# 🚀 Running RabbitMQ

Once Docker is installed and running, open **PowerShell** and execute:

```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

---

# ✅ Verification

## RabbitMQ Management UI

Open your browser and go to:

```
http://localhost:15672
```

### Login credentials:
- Username: `guest`
- Password: `guest`

If the page loads successfully, RabbitMQ is running correctly.

---

# 🔌 Ports Used

| Port | Purpose |
|------|--------|
| 5672 | Application communication (AMQP) |
| 15672 | Web UI (management interface) |

---

# ❗ Common Issues

## Docker is not running
- Make sure Docker Desktop is started

## Port already in use
- Another service might be using port 5672 or 15672

## Cannot access UI
- Ensure container is running:

```bash
docker ps
```

You should see a container named `rabbitmq`

---

# 🧠 Why This Is Needed

The FeaturesPlatform uses RabbitMQ for:
- Event-driven communication
- Outbox pattern processing
- Background message handling

Without RabbitMQ, the application will not function correctly.

---

# 🎯 Summary

1. Install WSL
2. Install Docker Desktop
3. Start Docker
4. Run RabbitMQ container
5. Verify using the web UI

You are now ready to run the project 🚀

