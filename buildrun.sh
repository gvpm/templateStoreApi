sudo docker build -t storeapi .
sudo docker run --net=host -d -p 5000:5000 storeapi
