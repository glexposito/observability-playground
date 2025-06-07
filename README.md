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

---

## 🧪 How to Test the Dashboard

1. **Start the stack**  
   Make sure everything is running:
   ```bash
   docker compose up --build
   ```

2. **Access Grafana**  
   Open [http://localhost:3000](http://localhost:3000) in your browser.  
   - **Login:**  
     - **Username:** `admin`  
     - **Password:** `admin`

3. **Import the Dashboard**  
   - In Grafana, click the "+" icon on the left sidebar and select **"Import"**.
   - Upload or paste the contents of `order-api-dashboard.json` from this repo.
   - Select your Prometheus data source if prompted.

4. **Generate Some Data**  
   - Use a tool like [curl](https://curl.se/) or your browser to call the Order API a few times:  
     ```
     curl http://localhost:5001/orders/1
     ```
   - Or interact with the API using Swagger UI at [http://localhost:5001/swagger](http://localhost:5001/swagger).

5. **View Metrics**  
   - Go to your imported dashboard in Grafana to see live metrics for the Order API.

> ⚠️ **Note:**  
> The provided metrics and dashboard are for demonstration purposes. They are not production-grade and may not cover all edge cases or provide perfect accuracy. Building robust, meaningful dashboards and metrics for real-world systems requires significant additional effort and tuning.

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