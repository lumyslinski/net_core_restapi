#!/usr/bin/env bash
echo "Removing old image"
docker rm nc2_restapp
docker stop nc2_restapp
echo "Starting docker!"
docker build -t restapp . 
docker -D run --name nc2_restapp -p 50352:7777 restapp
read