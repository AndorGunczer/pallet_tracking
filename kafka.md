If you're on macOS:
    brew install kafka
Start Kafka in ONE command:
    brew services start kafka
Stop it:
    brew services stop kafka


Create a topic:
    bin/kafka-topics.sh --create --topic test --bootstrap-server localhost:9092
List topics:
    bin/kafka-topics.sh --list --bootstrap-server localhost:9092
Produce:
    bin/kafka-console-producer.sh --topic test --bootstrap-server localhost:9092
Consume:
    bin/kafka-console-consumer.sh --topic test --from-beginning --bootstrap-server localhost:9092