package service

import (
	"log"
	"AdminDashboard.StockService/client"
	"AdminDashboard.StockService/gen"
)

type StockStreamHandler struct {
	wsClient *polygon.WSClient
	stream.UnimplementedStockStreamServiceServer
}

func NewStockStreamHandler(ws *polygon.WSClient) *StockStreamHandler {
	return &StockStreamHandler{wsClient: ws}
}

func (h *StockStreamHandler) StreamTrades(req *stream.StockStreamRequest, srv stream.StockStreamService_StockServiceServer) error {
	ctx := srv.Context()

	if err := h.wsClient.Subscribe(req.Symbol); err != nil {
		return err
	}

	// Channel to receive trades
	stocksCh := make(chan polygon.Stock, 100)

	// Run stream in background
	go func() {
		if err := h.wsClient.Stream(ctx, stocksCh); err != nil {
			log.Println("polygon stream error:", err)
		}
	}()

	// Forward trades to gRPC stream
	for {
		select {
		case <-ctx.Done():
			return ctx.Err()
		case stock, ok := <-stocksCh:
			if !ok {
				return nil
			}
			resp := &stream.StockStreamResponse{
				
				Ev: stock.EventType,
				Sym:    stock.Symbol,
				V: stock.Volume,
				Av: stock.AccumulatedVolume,
				Op: stock.OpeningPrice,
				Vw: stock.VolumeWeightedAveragePrice,
				O: stock.OpeningTickPrice,
				C: stock.ClosingTickPrice,
				H: stock.HighestTickPrice,
				L: stock.LowestTickPrice,
				A: stock.WeightedAveragePrice,
				Z: stock.AverageTradeSize,
				S: stock.StartTimeStamp,
				E: stock.EndTimeStamp,
				Otc: stock.OTC,
			}
			if err := srv.Send(resp); err != nil {
				return err
			}
		}
	}
}