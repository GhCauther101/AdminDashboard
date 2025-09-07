#!/bin/bash

# Check if dotnet is installed
if command -v dotnet &> /dev/null
then
    echo "✅ .NET is installed: $(dotnet --version)"
else
    echo "❌ .NET is not installed."
fi

# Check if Node.js is installed
if command -v node &> /dev/null; then
    echo "✅ Node.js is installed: $(node -v)"
else
    echo "❌ Node.js is not installed."
fi

# Check if npm is installed
if command -v npm &> /dev/null; then
    echo "✅ npm is installed: $(npm -v)"
else
    echo "❌ npm is not installed."
fi

if [ -z "$1" ]; then
    echo "❌ No argument provided."
    echo "Usage: $0 <deploy runtime id>"
    echo "Example: 
    💻 `win-x64` → Windows deployment environment 
    🐧 `linux-x64` → Linux deployment environment"
    exit 1
elif [ "$1" != "win-x64" || "$1" != "linux-x64" ]; then
    echo "❌ No deployment runtime has detected."
    echo "Example:\n 💻 `win-x64` → Windows deployment environment \n🐧 `linux-x64` → Linux deployment environment"
    exit 1
fi

echo "🚀 Starting process..."

# Path to your .NET project or solution
EXCHANGE_SERVICE_PROJECT_PATH="../src/AdminDashboard.ExchangeService/AdminDashboard.ExchangeService.csproj"
API_GATEWAY_PROJECT_PATH="../src/AdminDashboard.API/AdminDashboard.API.csproj"
CLIENT_PROJECT_PATH="../src/AdminDashboard.Client"
RUNTIME=$1

# Publish output directory
OUTPUT_DIR="../out"

# Build and publish the project in Release mode
dotnet_build_publish() {
    local PROJECT_PATH=$1
    local PROJECT_NAME_DIR=$2

    if [ -z "$PROJECT_PATH" ]; then
        echo "❌ Usage: dotnet_build_publish <project_path> [output_dir] [runtime_id]"
        return 1
    fi

    # Default output dir if not provided
    if [ -z "$OUTPUT_DIR" ]; then
        OUTPUT_DIR="./publish"
    fi

    echo "🛠️  Building project: $PROJECT_PATH"
    dotnet build "$PROJECT_PATH" -c Release

    echo "📦 Publishing project to: $OUTPUT_DIR"
    dotnet publish "$PROJECT_PATH" -c Release -o "$OUTPUT_DIR/$PROJECT_NAME_DIR" -r "$RUNTIME"

    echo "✅ Done! Published files are in $OUTPUT_DIR"
}

copy_client_app() {
    DEST="../out/$2/"

    # Check if source folder exists
    if [ ! -d "$DEST" ]; then
        mkdir $DEST
    fi

    # Copy the folder
    echo "🌐 Copying app to out directory ..."
    cp -r "$1" "../out"
    rm -rf ../out/$2/dist
    rm -rf ../out/$2/node_modules
    rm -rf ../out/$2/.vscode
    
    echo "🌐 Client app copied to '$DEST'"
}

#Use 'win-x64' runtime for windows developement purposes. 
#For production deployment purposes use 'linux-x64' runtime.
dotnet_build_publish $EXCHANGE_SERVICE_PROJECT_PATH 'AdminDashboard.ExchangeService' $RUNTIME
dotnet_build_publish $API_GATEWAY_PROJECT_PATH 'AdminDashboard.API' $RUNTIME
copy_client_app $CLIENT_PROJECT_PATH 'AdminDashboard.Client'