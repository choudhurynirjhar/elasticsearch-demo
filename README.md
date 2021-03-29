# Elasticsearch Demo

Docker command to install elasticsearch:

docker pull docker.elastic.co/elasticsearch/elasticsearch:7.11.2
docker run -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" docker.elastic.co/elasticsearch/elasticsearch:7.11.2

Docker command to install kibana:

docker pull docker.elastic.co/kibana/kibana:7.11.2
docker run --link YOUR_ELASTICSEARCH_CONTAINER_NAME_OR_ID:elasticsearch -p 5601:5601 docker.elastic.co/kibana/kibana:7.11.2
