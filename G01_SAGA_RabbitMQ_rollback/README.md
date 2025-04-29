# SAGA PATTERN Coreography-Based

Immaginiamo un'applicazione per l'acquisto di un ordine, con i seguenti microservizi:

- Order Service (Gestisce gli ordini)
- Payment Service (Processa i pagamenti)
- Inventory Service (Gestisce la disponibilità dei prodotti)

## Creazione della Queue con RabbitMQ

```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
```

