# 🧪 Observability Playground (WIP)

A sandbox to explore distributed tracing, metrics, and logging in a .NET Core microservices environment.

This includes:
- 🛒 Order API (.NET)
- 📦 Inventory API (.NET)
- 📡 OpenTelemetry Collector
- 🧵 Grafana Tempo (distributed tracing backend)
- 📈 Prometheus
- 📊 Grafana
- 🐳 Docker Compose to wire it all together

---

## 📁 Project Structure

```
observability-playground/
├── docker-compose.yml
├── .env
├── src/
│   ├── OrderApi/
│   └── InventoryApi/ (coming soon)
├── otel-config/
│   └── collector-config.yaml
├── prometheus-config/
│   └── prometheus.yaml
├── grafana-provisioning/
│   ├── dashboards/
│   └── datasources/
├── tempo-config/
│   └── tempo.yaml
└── README.md
```

---

## 🚀 Getting Started

### Prerequisites

- [Docker](https://www.docker.com/)
- [.NET 9 SDK](https://dotnet.microsoft.com/)

### Run Everything

```bash
docker compose up --build
```

---

## 🌐 Service URLs

| Service           | URL                                  |
|-------------------|--------------------------------------|
| Order API         | http://localhost:5001/swagger        |       |
| Grafana           | http://localhost:3000                |
| Prometheus        | http://localhost:9090                |
| Grafana Tempo API | http://localhost:3200                |

> 🧑 Default Grafana login: `admin` / `admin`

---

> 📝 Add your `.json` dashboards inside `grafana-provisioning/dashboards/`

---

## 🧪 Observability Highlights

- **Distributed Tracing**: Powered by OpenTelemetry and Grafana Tempo
- **Metrics**: Prometheus scrapes the collector
- **Dashboards**: Grafana shows metrics and custom visualizations
- **Trace Context Propagation**: Traces flow between Order and Inventory APIs