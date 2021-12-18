package main

import (
	"fmt"
	"net/http"

	"github.com/MET-DEV/customer-service/handlers"
	"github.com/MET-DEV/customer-service/migrations"
	"github.com/gorilla/mux"
	"github.com/rs/cors"
)

func main() {
	fmt.Println("Server starting...")
	migrations.InitialMigration()
	r := mux.NewRouter()
	r.HandleFunc("/api/customers", handlers.GetAll).Methods("GET")
	r.HandleFunc("/api/customers", handlers.Add).Methods("POST")
	r.HandleFunc("/api/customers/{id}", handlers.GetById).Methods("GET")
	handler := cors.Default().Handler(r)
	server := &http.Server{
		Addr:    ":3000",
		Handler: handler,
	}
	server.ListenAndServe()

}
