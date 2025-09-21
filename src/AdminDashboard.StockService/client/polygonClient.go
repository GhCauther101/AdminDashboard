package polygon

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"net/url"

	"github.com/gorilla/websocket"
)

type Stock struct {
	EventType string
	Symbol string
	Volume int64
	AccumulatedVolume float64
	OpeningPrice float64
	VolumeWeightedAveragePrice float64
	OpeningTickPrice float64
	ClosingTickPrice float64
	HighestTickPrice float64
	LowestTickPrice float64
	WeightedAveragePrice float64
	AverageTradeSize int64
	StartTimeStamp int64
	EndTimeStamp int64
	OTC bool
}

type WSClient struct {
	conn   *websocket.Conn
	apiKey string
}

func NewWSClient(apiKey string) (*WSClient, error) {
	u := url.URL{Scheme: "wss", Host: "socket.polygon.io", Path: "/stocks"}

	conn, _, err := websocket.DefaultDialer.Dial(u.String(), nil)
	if err != nil {
		return nil, err
	}

	client := &WSClient{conn: conn, apiKey: apiKey}

	// Authenticate
	authMsg := fmt.Sprintf(`{"action":"auth","params":"%s"}`, apiKey)
	if err := conn.WriteMessage(websocket.TextMessage, []byte(authMsg)); err != nil {
		return nil, err
	}

	return client, nil
}

func (c *WSClient) Subscribe(symbol string) error {
	subMsg := fmt.Sprintf(`{"action":"subscribe","params":"T.%s"}`, symbol)
	return c.conn.WriteMessage(websocket.TextMessage, []byte(subMsg))
}

func (c *WSClient) Stream(ctx context.Context, out chan<- Stock) error {
	defer close(out)
	for {
		_, message, err := c.conn.ReadMessage()
		if err != nil {
			return err
		}

		var events []map[string]interface{}
		if err := json.Unmarshal(message, &events); err != nil {
			log.Println("unmarshal error:", err)
			continue
		}

		for _, e := range events {
			if e["ev"] == "T" {
				stock := Stock{
					EventType: e["ev"].(string),
					Symbol:    e["sym"].(string),
					Volume: e["v"].(int64),
					AccumulatedVolume: e["av"].(float64),
					OpeningPrice: e["op"].(float64),
					VolumeWeightedAveragePrice: e["vw"].(float64),
					OpeningTickPrice: e["o"].(float64),
					ClosingTickPrice: e["c"].(float64),
					HighestTickPrice: e["h"].(float64),
					LowestTickPrice: e["l"].(float64),
					AverageTradeSize: e["a"].(int64),
					WeightedAveragePrice: e["z"].(float64),
					StartTimeStamp: e["s"].(int64),
					EndTimeStamp: e["e"].(int64),
					OTC: e["otc"].(bool),
				}
				select {
					case <-ctx.Done():
						return ctx.Err()
					case out <- stock:
				}
			}
		}
	}
}
