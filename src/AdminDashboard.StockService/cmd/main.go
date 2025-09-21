package main

import (
	"log"
	"net"

	"google.golang.org/grpc"

	polygon "AdminDashboard.StockService/client"
	stream "AdminDashboard.StockService/gen"
	"AdminDashboard.StockService/service"
)

func main() {
	conn, err := net.Listen("tcp", ":55001")
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}

	grpcServer := grpc.NewServer()

	wsClient, err := polygon.NewWSClient("API_KEY")
	if err != nil {
		log.Fatalf("failed to connect to polygon: %v", err)
	}

	handler := service.NewStockStreamHandler(wsClient)
	stream.RegisterStockStreamServiceServer(grpcServer, handler)

	log.Println("gRPC server streaming 55001")

	if err := grpcServer.Serve(conn); err != nil {
		log.Fatalf("server error: %v", err)
	}
}
