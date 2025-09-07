#!/bin/bash

# Check if docker is installed
if command -v docker &> /dev/null
then
    echo "✅ Docker is installed: $(docker --version)"
else
    echo "❌ Docker is not installed."
fi

# Path to your Docker Compose file defined fodler
INPUT_PATH=$1

if [ -z "$1" ]; then
    echo "❌ No docker compose file defined fodler path provided."
    echo "Usage: $0 <docker_compose_path> (docker compose file or directory with this file)"
    echo "⚠️ Warning: make sure your compose file named with <compose.yml> or <docker-compose.yml>"
    exit 1
fi

if [ -d "$INPUT_PATH" ]; then
    for file in docker-compose.yml docker-compose.yaml compose.yml compose.yaml; do
        if [ -f "$INPUT_PATH/$file" ]; then
            echo "✅ Found Docker Compose file: $TARGET/$file"
            exit 0
        fi
    done
    echo "⚠️  No Docker Compose file found in $TARGET"
    exit 1
elif [ -f "$INPUT_PATH" ]; then
    filename=$(basename -- "$INPUT_PATH")
    case "$filename" in
    docker-compose.yml|docker-compose.yaml|compose.yml|compose.yaml)
        echo "✅ Valid Docker Compose file: $TARGET"
        # exit 0
        ;;
    *)
        echo "⚠️  $TARGET is not a recognized Docker Compose file"
        exit 1
        ;;
esac

else
    exit 0
fi

echo "🚀 Starting process..."

# Build and publish the project in Release mode
compose_docker_images () {
    echo "🐳 Starting Docker Compose services in detached mode..."
    docker compose -f $INPUT_PATH up -d
}

compose_docker_images;