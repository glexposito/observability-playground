# 🧪 Observability Playground (WIP)

A sandbox to explore distributed tracing, metrics, and logging in a .NET Core microservices environment.

This includes:
- 🛒 Order API (.NET)
- 📦 Inventory API (.NET)
- 📡 OpenTelemetry Collector
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
│   └── InventoryApi/
├── otel-config/
│   └── collector-config.yaml
├── prometheus-config/
│   └── prometheus.yml
├── grafana-provisioning/
│   ├── dashboards/
│   └── datasources/
└── README.md
```

---

## 🚀 Getting Started

### Prerequisites

- [Docker](https://www.docker.com/)
- [.NET 9 SDK](https://dotnet.microsoft.com/)

### Run Everything

```bash
docker compose up --build (not working yet)
```

---

## 🌐 Service URLs

| Service           | URL                                  |
|------------------|---------------------------------------|
| Order API        | http://localhost:5001/swagger         |
| Inventory API    | http://localhost:5002/swagger         |
| Grafana          | http://localhost:3000                 |
| Prometheus       | http://localhost:9090                 |

> 🧑 Default Grafana login: `admin` / `admin`

---

```yaml
apiVersion: 1

providers:
  - name: 'default'
    folder: ''
    type: file
    disableDeletion: false
    options:
      path: /etc/grafana/provisioning/dashboards
```

> 📝 Add your `.json` dashboards inside `grafana-provisioning/dashboards/`

---

## 🧪 Observability Highlights

- **Distributed Tracing**: Powered by OpenTelemetry
- **Metrics**: Prometheus scrapes the collector
- **Dashboards**: Grafana shows metrics and custom visualizations
- **Trace Context Propagation**: Traces flow between Order and Inventory APIs

---

## 📜 License

MIT
