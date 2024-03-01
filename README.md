# TelemetryFlow

This project collects telemetry data and after processing them provides
metadata. Based on the following structure:

```mermaid
graph BT

    opcplc1(OPC PLC 1)
    opcplc2(OPC PLC 2)
    opcplc3(OPC PLC 3)

    publisher1(OPC Publisher 1)
    publisher2(OPC Publisher 2)

    mqttBroker(MQTT Broker)

    db(Database)

    metadataApi(Metadata API)

    dataEnrichment1(Data Enrichment1)
    dataEnrichment2(Data Enrichment2)

    exampleApp(Example APP)

    subgraph DataCollection
        opcplc1-->publisher1
        opcplc2-->publisher2
        opcplc3-->publisher1
        opcplc1-->publisher2

        publisher1<-->mqttBroker
        publisher2<-->mqttBroker
    end

    subgraph DataProcess 
        mqttBroker<-->dataEnrichment1
        mqttBroker<-->dataEnrichment2
    end

    subgraph Metadata maintenance
        dataEnrichment1<-->db
        dataEnrichment2<-->db
        db<-->metadataApi
        mqttBroker<-->metadataApi
    end

    subgraph Applications 
        mqttBroker-->exampleApp
    end
```

## Projects

### Manager WebApi project

This project contains the webapi for maintain metadata in the DB and activate subscriptions on the publishers to receive telemetry.

### Models ClassLib

This project will contain the common models used in the DB and the API requests and response.

### Data Classlib

This project will contain the DBContext and the related entity configurations.

### Migrations project

This project will run our Entity Framework migrations to create or update the Database.


## Dev Env

### MSSQL 2022

https://hub.docker.com/_/microsoft-mssql-server

```
host: localhost
user: SA
pass: {provided in Src/dev-env/.env MSSQL_SA_PASSWORD}
```



